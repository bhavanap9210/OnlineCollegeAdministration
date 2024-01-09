using DataAccessLayer;
using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OCA.UserControls
{
    public partial class UCStudentCoursesAddEdit : CustomUserControl
    {
        public event EventHandler evtStaffCourseEdited;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnevtStaffCourseEdited(object sender, CustomEventArgs e)
        {
            if (evtStaffCourseEdited != null)
            {
                evtStaffCourseEdited(sender, e);
            }
        }

        /// <summary>
        /// Get or Set CourseDurationId
        /// </summary>
        public string CourseDurationId
        {
            get
            {
                if (ViewState["course_duration_id"] != null)
                {
                    return ViewState["course_duration_id"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["course_duration_id"] = value;
            }
        }

        /// <summary>
        /// Get or Set StaffId
        /// </summary>
        public string StaffId
        {
            get
            {
                if (ViewState["staff_id"] != null)
                {
                    return ViewState["staff_id"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["staff_id"] = value;
            }
        }
        /// <summary>
        /// Get or Set StaffCourseId
        /// </summary>
        public string StaffCourseId
        {
            get
            {
                if (ViewState["staff_course_id_txt"] != null)
                {
                    return ViewState["staff_course_id_txt"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["staff_course_id_txt"] = value;
            }
        }
        /// <summary>
        /// Get or Set StudentID
        /// </summary>
        public string StudentID
        {
            get
            {
                if (ViewState["student_id"] != null)
                {
                    return ViewState["student_id"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["student_id"] = value;
            }
        }

        /// <summary>
        /// Get or Set StudentIDText
        /// </summary>
        public string StudentIDText
        {
            get
            {
                if (ViewState["student_id_txt"] != null)
                {
                    return ViewState["student_id_txt"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["student_id_txt"] = value;
            }
        }
        /// <summary>
        /// Get or Set Mode
        /// </summary>
        public string Mode
        {
            get
            {
                if (ViewState["Mode"] != null)
                {
                    return ViewState["Mode"].ToString();
                }
                else
                {
                    return "E";//Edit MOde
                }
            }
            set
            {
                ViewState["Mode"] = value;
            }
        }

        /// <summary>
        /// Loads the user control
        /// </summary>
        public override void LoadUserControlData()
        {
            lblMsg.Text = "";
            ClearControl();
            LoadDropDowns();
            EnableDisableControls(false);
            HideUnhideControls();
            EnableDisableButtons(false);            
            if (string.IsNullOrEmpty(CourseDurationId))
            {
                btnAssign.Enabled = false;
                btnUnAssign.Enabled = false;
            }
            BindData();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadDropDowns()
        {
            CommonDAL _commonDAL = new CommonDAL();
            DataTable dt = new DataTable();
            IDataReader rdr = null;
            //Load Year dropdown
            rdr = _commonDAL.GetCommonDropDowns("Y", "-1");
            if (rdr != null)
            {
                dt.Load(rdr);
                ddlYear.DataSource = dt;
                ddlYear.DataValueField = "year_id";
                ddlYear.DataTextField = "year_nbr";
                ddlYear.DataBind();
            }
            if (!rdr.IsClosed)
            {
                rdr.Close();
            }
            //Load Month dropdown
            rdr = _commonDAL.GetCommonDropDowns("M", "-1");
            if (rdr != null)
            {
                dt = new DataTable();
                dt.Load(rdr);
                ddlMonth.DataSource = dt;
                ddlMonth.DataValueField = "month_nbr";
                ddlMonth.DataTextField = "month_name";
                ddlMonth.DataBind();
            }
            if (!rdr.IsClosed)
            {
                rdr.Close();
            }
            //Load Day dropdown
            rdr = _commonDAL.GetCommonDropDowns("D", "-1");
            if (rdr != null)
            {
                dt = new DataTable();
                dt.Load(rdr);
                ddlDay.DataSource = dt;
                ddlDay.DataValueField = "day_id";
                ddlDay.DataTextField = "day_name";
                ddlDay.DataBind();
            }
            if (!rdr.IsClosed)
            {
                rdr.Close();
            }            
        }

        /// <summary>
        /// Hides or Unhides the controls
        /// </summary>
        private void HideUnhideControls()
        {
            
        }

        /// <summary>
        /// Clears the control
        /// </summary>
        private void ClearControl()
        {
            txtCourseDurationDesc.Text = "";
            txtCourseEndTime.Text = "";
            txtCourseStartTime.Text = "";
            
            ddlMonth.ClearSelection();
            ddlYear.ClearSelection();
            ddlDay.ClearSelection();

            lblStatus.Text = "";
            lblStaffID.Text = "";
            lblCourseDurationID.Text = "";
            lblCourseName.Text = "";
        }

        /// <summary>
        /// Enable or Disable the controls
        /// </summary>
        /// <param name="isEnabled"></param>
        private void EnableDisableControls(bool isEnabled)
        {
            txtCourseDurationDesc.Enabled = isEnabled;
            txtCourseEndTime.Enabled = isEnabled;
            txtCourseStartTime.Enabled = isEnabled;            
            ddlMonth.Enabled = isEnabled;
            ddlYear.Enabled = isEnabled;
            ddlDay.Enabled = isEnabled;
        }

        /// <summary>
        /// Enable or Disable the buttons
        /// </summary>
        /// <param name="isEnabled"></param>
        private void EnableDisableButtons(bool isEnabled)
        {
            btnAssign.Enabled = isEnabled;
            btnUnAssign.Enabled = isEnabled;
        }


        /// <summary>
        /// Binds the data to the control
        /// </summary>
        private void BindData()
        {
            DataTable dt = new DataTable();
            IDataReader dr = new StudentCourseDAL().GetStudentCourseRecord(StaffId, CourseDurationId, StudentID,StaffCourseId, "I");

            if (dr != null)
            {
                dt.Load(dr);

            }

            CommonHelper cmnHelper = new CommonHelper();
            Boolean isActive = false;
            string val = "";

            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lblStaffID.Text = cmnHelper.GetStringValueFrmColumn(dt, "staff_id_txt", 0);
                    lblCourseDurationID.Text = cmnHelper.GetStringValueFrmColumn(dt, "course_id_txt", 0);
                    lblCourseName.Text = cmnHelper.GetStringValueFrmColumn(dt, "course_name", 0);
                    txtCourseDurationDesc.Text = cmnHelper.GetStringValueFrmColumn(dt, "course_duration_desc", 0);
                    txtCourseEndTime.Text = cmnHelper.GetStringValueFrmColumn(dt, "course_end_time", 0);
                    txtCourseStartTime.Text = cmnHelper.GetStringValueFrmColumn(dt, "course_start_time", 0);
                    val = cmnHelper.GetStringValueFrmColumn(dt, "year_nbr", 0);
                    if (ddlYear.Items.FindByValue(val) != null)
                    {
                        ddlYear.SelectedValue = val;
                    }
                    val = cmnHelper.GetStringValueFrmColumn(dt, "month_nbr", 0);
                    if (ddlMonth.Items.FindByValue(val) != null)
                    {
                        ddlMonth.SelectedValue = val;
                    }
                    val = cmnHelper.GetStringValueFrmColumn(dt, "course_day_id", 0);
                    if (ddlDay.Items.FindByValue(val) != null)
                    {
                        ddlDay.SelectedValue = val;
                    }
                    

                    isActive = cmnHelper.GetBoolValueFrmColumn(dt, "active_ind", 0);
                    bool isAssigned = cmnHelper.GetBoolValueFrmColumn(dt, "assigned_ind", 0);
                    if (isActive)
                    {
                        lblStatus.Text = "Course is Active";
                        if (isAssigned)
                        {
                            btnAssign.Enabled = false;
                            btnUnAssign.Enabled = true;
                        }
                        else
                        {
                            btnAssign.Enabled = true;
                            btnUnAssign.Enabled = false;
                        }
                    }
                    else
                    {
                        lblStatus.Text = "Course is Inactive";
                        btnAssign.Enabled = false;
                    }
                }
            }
        }
         
        /// <summary>
        /// Validate the fields
        /// </summary>
        /// <returns>string</returns>
        private string ValidateFields()
        {
            string message = "";
            if (string.IsNullOrEmpty(txtCourseDurationDesc.Text.Trim())
                || string.IsNullOrEmpty(txtCourseEndTime.Text.Trim())
                || string.IsNullOrEmpty(txtCourseStartTime.Text.Trim())
                || ddlDay.SelectedValue == "0"
                || ddlMonth.SelectedValue == "0"
                || ddlYear.SelectedValue == "0")
            {
                message = "Please enter mandatory fields marked with (*)";
            }

            return message;
        }
         

        protected void btnAssign_Click(object sender, EventArgs e)
        {
            CustomEventArgs ec = new CustomEventArgs();
            ec.ID = this.CourseDurationId;
            lblMsg.Text = "";
            string messageCode = "";
            string messageText = "";
            string output = "";

            output = ValidateFields();

            if (string.IsNullOrEmpty(output))
            {
                output = new StudentCourseDAL().AssignUnassignStudentCourse(StaffId, CourseDurationId,StaffCourseId,StudentID,"A", out messageCode, out messageText);
            }

            if (string.IsNullOrEmpty(output))
            {
                if (messageCode == "101")
                {
                    lblMsg.Text = messageText;
                    lblMsg.CssClass = "successLabelClass";
                    OnevtStaffCourseEdited(sender, ec);
                }
                else
                {
                    lblMsg.Text = messageText;
                    lblMsg.CssClass = "errorLabelClass";
                    return;
                }
            }
            else
            {
                lblMsg.Text = output;
                lblMsg.CssClass = "errorLabelClass";
                return;
            }

            BindData();

        }

        protected void btnUnAssign_Click(object sender, EventArgs e)
        {
            CustomEventArgs ec = new CustomEventArgs();
            ec.ID = this.CourseDurationId;
            lblMsg.Text = "";
            string messageCode = "";
            string messageText = "";
            string output = "";

            output = ValidateFields();

            if (string.IsNullOrEmpty(output))
            {
                output = new StudentCourseDAL().AssignUnassignStudentCourse(StaffId, CourseDurationId, StaffCourseId, StudentID, "U", out messageCode, out messageText);
            }

            if (string.IsNullOrEmpty(output))
            {
                if (messageCode == "101")
                {
                    lblMsg.Text = messageText;
                    lblMsg.CssClass = "successLabelClass";
                    OnevtStaffCourseEdited(sender, ec);
                }
                else
                {
                    lblMsg.Text = messageText;
                    lblMsg.CssClass = "errorLabelClass";
                    return;
                }
            }
            else
            {
                lblMsg.Text = output;
                lblMsg.CssClass = "errorLabelClass";
                return;
            }

            BindData();

        }
    }
}