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
    public partial class UCStaffCoursesAddEdit : CustomUserControl
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
        /// Get or Set StaffIdText
        /// </summary>
        public string StaffIdText
        {
            get
            {
                if (ViewState["staff_id_txt"] != null)
                {
                    return ViewState["staff_id_txt"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["staff_id_txt"] = value;
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
            EnableDisableButtons(true);
            if (string.IsNullOrEmpty(CourseDurationId))
            {
                btEdit.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
                btnActivate.Enabled = false;
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
            rdr = _commonDAL.GetCommonDropDowns("Y", "0");
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
            rdr = _commonDAL.GetCommonDropDowns("M", "0");
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
            rdr = _commonDAL.GetCommonDropDowns("D", "0");
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
            rdr= new CourseDAL().GetCourseList("", "");
            if (rdr != null)
            {
                dt = new DataTable();
                dt.Load(rdr);
                ddlCourses.DataSource = dt;
                ddlCourses.DataTextField = "course_name";
                ddlCourses.DataValueField = "course_id";
                ddlCourses.DataBind();
                if (!rdr.IsClosed)
                {
                    rdr.Close();
                }
            }
        }

        /// <summary>
        /// Hides or Unhides the controls
        /// </summary>
        private void HideUnhideControls()
        {
            if (Mode == "A")
            {
                trCourses.Visible = true;
            }
            else if (Mode == "E")
            {
                trCourses.Visible = false;
            }
        }

        /// <summary>
        /// Clears the control
        /// </summary>
        private void ClearControl()
        {
            txtCourseDurationDesc.Text = "";
            txtCourseEndTime.Text = "";
            txtCourseStartTime.Text = "";
            ddlCourses.ClearSelection();
            ddlMonth.ClearSelection();
            ddlYear.ClearSelection();
            ddlDay.ClearSelection();

            lblStatus.Text = "";
            lblStaffID.Text = "";
            lblCourseDurationID.Text = "";
            
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
            ddlCourses.Enabled = isEnabled;
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

            btEdit.Enabled = isEnabled;
            btnAdd.Enabled = isEnabled;
            btnActivate.Enabled = isEnabled;
            btnSave.Enabled = !isEnabled;
            btnCancel.Enabled = !isEnabled;
        }


        /// <summary>
        /// Binds the data to the control
        /// </summary>
        private void BindData()
        {
            DataTable dt = new DataTable();
            IDataReader dr = new StaffCourseDAL().GetStaffCourseRecord(StaffId, CourseDurationId, "I");
            
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
                    lblStaffID.Text = StaffIdText;
                    lblCourseDurationID.Text = cmnHelper.GetStringValueFrmColumn(dt, "course_id_txt", 0);
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
                    val = cmnHelper.GetStringValueFrmColumn(dt, "course_id", 0);
                    if (ddlCourses.Items.FindByValue(val) != null)
                    {
                        ddlCourses.SelectedValue = val;
                    }

                    isActive = cmnHelper.GetBoolValueFrmColumn(dt, "active_ind", 0);
                    if (isActive)
                    {
                        lblStatus.Text = "Active";
                    }
                    else
                    {
                        lblStatus.Text = "Inactive";
                        //btEdit.Enabled = false;
                        //btnSave.Enabled = false;
                        //btnCancel.Enabled = false;
                    }
                }
            }
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            Mode = "E";
            EnableDisableControls(true);
            EnableDisableButtons(false);
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            CustomEventArgs ec = new CustomEventArgs();
            ec.ID = this.CourseDurationId;

            string messageCode = "";
            string messageText = "";
            string output = "";

            output = ValidateFields();

            if (string.IsNullOrEmpty(output))
            {
                if (Mode == "A")
                {
                    output = new StaffCourseDAL().InsertStaffCourseRecord(StaffId, txtCourseDurationDesc.Text.Trim(), txtCourseStartTime.Text.Trim(), txtCourseEndTime.Text.Trim(), ddlCourses.SelectedValue, ddlDay.SelectedValue, ddlYear.SelectedValue, ddlMonth.SelectedValue, out messageCode, out messageText);
                }
                else if (Mode == "E")
                {
                     
                    output = new StaffCourseDAL().UpdateStaffCourseRecord(StaffId,CourseDurationId,txtCourseDurationDesc.Text.Trim(),txtCourseStartTime.Text.Trim(),txtCourseEndTime.Text.Trim(), ddlCourses.SelectedValue,ddlDay.SelectedValue,ddlYear.SelectedValue, ddlMonth.SelectedValue,out messageCode, out messageText);
                }
            }

            if (string.IsNullOrEmpty(output))
            {
                if (messageCode == "101")
                {
                    lblMsg.Text = messageText;
                    lblMsg.CssClass = "successLabelClass";
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

            EnableDisableButtons(true);
            EnableDisableControls(false);
            BindData();

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
                || ddlDay.SelectedValue=="0"
                || ddlMonth.SelectedValue=="0"
                || ddlYear.SelectedValue=="0"
                || string.IsNullOrEmpty(ddlCourses.SelectedValue))
            {
                message = "Please enter mandatory fields marked with (*)";
            }

            bool isValidStartTime = ValidateDateTime(txtCourseStartTime.Text.Trim());
            bool isValidEndTime = ValidateDateTime(txtCourseEndTime.Text.Trim());
            if (!isValidStartTime || !isValidEndTime)
            {
                message = "Please enter valid time";
            }

            return message;
        }

        /// <summary>
        /// Validates if the entered time is valid or not
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private bool ValidateDateTime(string _time)
        {
            bool isValidTime = false;

            try
            {
                string[] time = _time.Split(':');
                int hr =int.Parse(time[0].ToString());
                int min = int.Parse(time[1].ToString());
                DateTime dtTime = new DateTime(1900,1,1,hr,min,0);
                isValidTime = true;
            }
            catch (Exception)
            {
                
            }
            return isValidTime;
        }
         

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
            Mode = "";
            EnableDisableControls(false);
            EnableDisableButtons(true);
            if (string.IsNullOrEmpty(CourseDurationId))
            {
                btEdit.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
            HideUnhideControls();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Mode = "A";
            ClearControl();
            EnableDisableControls(true);
            EnableDisableButtons(false);
            HideUnhideControls();
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            CustomEventArgs ec = new CustomEventArgs();
            ec.ID = this.CourseDurationId;

            string messageCode = "";
            string messageText = "";
            string output = "";

            output = ValidateFields();

            if (string.IsNullOrEmpty(output))
            {
                output = new StaffCourseDAL().ActivateInactivateStaffCourseRecord(StaffId, CourseDurationId, out messageCode, out messageText);
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

            EnableDisableButtons(true);
            EnableDisableControls(false);
            BindData();

        }
    }
}