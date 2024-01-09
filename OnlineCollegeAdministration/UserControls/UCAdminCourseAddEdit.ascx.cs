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
    public partial class UCAdminCourseAddEdit : CustomUserControl
    {
        public event EventHandler evtCourseEdited;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnevtCourseEdited(object sender, CustomEventArgs e)
        {
            if (evtCourseEdited != null)
            {
                evtCourseEdited(sender, e);
            }
        }


        /// <summary>
        /// Get or Set CourseID
        /// </summary>
        public string CourseID
        {
            get
            {
                if (ViewState["Course_id"] != null)
                {
                    return ViewState["Course_id"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["Course_id"] = value;
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
            EnableDisableControls(false);
            EnableDisableButtons(true);
            if (string.IsNullOrEmpty(CourseID))
            {
                btnAdd.Enabled = true;
                btEdit.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
            BindData();
        }

        /// <summary>
        /// Clears the control
        /// </summary>
        private void ClearControl()
        {
            txtCourseName.Text = "";
            txtCourseDesc.Text = "";            
            lblCourseID.Text = "";
        }

        /// <summary>
        /// Enable or Disable the controls
        /// </summary>
        /// <param name="isEnabled"></param>
        private void EnableDisableControls(bool isEnabled)
        {
            txtCourseName.Enabled = isEnabled;
            txtCourseDesc.Enabled = isEnabled;
        }

        /// <summary>
        /// Enable or Disable the buttons
        /// </summary>
        private void EnableDisableButtons(bool isEnabled)
        {
            btnAdd.Enabled = isEnabled;
            btEdit.Enabled = isEnabled;
            btnSave.Enabled = !isEnabled;
            btnCancel.Enabled = !isEnabled;
        }


        /// <summary>
        /// Binds the data to the control
        /// </summary>
        private void BindData()
        {
            DataTable dt = new DataTable();
            IDataReader dr = new CourseDAL().GetCourseRecord(CourseID);
            if (dr != null)
            {
                dt.Load(dr);

            }
            CommonHelper cmnHelper = new CommonHelper();
            Boolean isActive = false;
            DateTime dob;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lblCourseID.Text = cmnHelper.GetStringValueFrmColumn(dt, "course_id", 0);
                    txtCourseName.Text = cmnHelper.GetStringValueFrmColumn(dt, "course_name", 0);
                    txtCourseDesc.Text = cmnHelper.GetStringValueFrmColumn(dt, "course_desc", 0);                    
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
            ec.ID = this.CourseID;

            string messageCode = "";
            string messageText = "";
            string output = "";

            output = ValidateFields();

            if (string.IsNullOrEmpty(output))
            {
                if (Mode == "A")
                {
                    output = new CourseDAL().InsertCourseRecord(txtCourseName.Text.Trim(), txtCourseDesc.Text.Trim(), out messageCode, out messageText);
                }
                else if (Mode == "E")
                {                    
                    output = new CourseDAL().UpdateCourseRecord(CourseID, txtCourseName.Text.Trim(), txtCourseDesc.Text.Trim(), out messageCode, out messageText);
                }
            }

            if (string.IsNullOrEmpty(output))
            {
                if (messageCode == "101")
                {
                    lblMsg.Text = messageText;
                    lblMsg.CssClass = "successLabelClass";
                    OnevtCourseEdited(sender, ec);
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
            if (string.IsNullOrEmpty(txtCourseName.Text.Trim())
                || string.IsNullOrEmpty(txtCourseDesc.Text.Trim()))
            {
                message = "Please enter mandatory fields marked with (*)";
            }
            
            return message;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
            CourseID = string.Empty;
            OnevtCourseEdited(sender, null);
            EnableDisableControls(false);
            EnableDisableButtons(true);
            if (string.IsNullOrEmpty(CourseID))
            {
                btnAdd.Enabled = true;
                btEdit.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Mode = "A";
            ClearControl();
            EnableDisableControls(true);
            EnableDisableButtons(false);
        }
    }
}