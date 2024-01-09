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
    public partial class UCAdminStudentAddEdit : CustomUserControl
    {
        public event EventHandler evtStudentEdited;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnevtStudentEdited(object sender, CustomEventArgs e)
        {
            if (evtStudentEdited != null)
            {
                evtStudentEdited(sender, e);
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
            if (string.IsNullOrEmpty(StudentID))
            {
                btnAdd.Enabled = true;
                btEdit.Enabled = false;
                btnActivate.Enabled = false;
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
            txtLastName.Text = "";
            txtFirstName.Text = "";
            txtMiddleName.Text = "";
            txtDOB.Text = "";
            txtAddr1.Text = "";
            txtAddr2.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            txtZipCode.Text = "";
            txtCountry.Text = "";
            txtEmail.Text = "";
            txtMobile.Text = "";
            txtChangePassword.Text = "";

            lblStatus.Text = "";
            lblStudentID.Text = "";
            
        }

        /// <summary>
        /// Enable or Disable the controls
        /// </summary>
        /// <param name="isEnabled"></param>
        private void EnableDisableControls(bool isEnabled)
        {
            txtLastName.Enabled = isEnabled;
            txtFirstName.Enabled = isEnabled;
            txtMiddleName.Enabled = isEnabled;
            txtDOB.Enabled = isEnabled;
            txtAddr1.Enabled = isEnabled;
            txtAddr2.Enabled = isEnabled;
            txtCity.Enabled = isEnabled;
            txtState.Enabled = isEnabled;
            txtZipCode.Enabled = isEnabled;
            txtCountry.Enabled = isEnabled;
            txtEmail.Enabled = isEnabled;
            txtMobile.Enabled = isEnabled;
            if (Mode == "E")
            {
                trChangePwd.Visible = true;
            }
            else if (Mode == "A")
            {
                trChangePwd.Visible = false;
            }
            txtChangePassword.Enabled = isEnabled;
        }

        /// <summary>
        /// Enable or Disable the buttons
        /// </summary>
        private void EnableDisableButtons(bool isEnabled)
        {
            btnAdd.Enabled = isEnabled;
            btEdit.Enabled = isEnabled;
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
            IDataReader dr = new StudentDAL().GetStudentRecord(StudentID,"I");
            if (dr != null)
            {
                dt.Load(dr);

            }
            string imgUrl = "~/CustomImageHandler.ashx?type=ST&id=";
            imgStudent.ImageUrl = imgUrl + StudentID;

            CommonHelper cmnHelper = new CommonHelper();
            Boolean isActive = false;
            DateTime dob;
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    lblStudentID.Text = cmnHelper.GetStringValueFrmColumn(dt, "student_id_txt", 0);
                    txtLastName.Text = cmnHelper.GetStringValueFrmColumn(dt, "student_last_name", 0);
                    txtFirstName.Text = cmnHelper.GetStringValueFrmColumn(dt, "student_first_name", 0);
                    txtMiddleName.Text = cmnHelper.GetStringValueFrmColumn(dt, "student_middle_name", 0);
                    dob = cmnHelper.GetDateValueFrmColumn(dt, "dob_dt", 0);
                    if (dob != null)
                    {
                        txtDOB.Text = dob.ToString("MM/dd/yyyy");
                    }

                    txtAddr1.Text = cmnHelper.GetStringValueFrmColumn(dt, "addr1", 0);
                    txtAddr2.Text = cmnHelper.GetStringValueFrmColumn(dt, "addr2", 0);
                    txtCity.Text = cmnHelper.GetStringValueFrmColumn(dt, "city", 0);
                    txtState.Text = cmnHelper.GetStringValueFrmColumn(dt, "state", 0);
                    txtZipCode.Text = cmnHelper.GetStringValueFrmColumn(dt, "zip_code", 0);
                    txtCountry.Text = cmnHelper.GetStringValueFrmColumn(dt, "country", 0);
                    txtEmail.Text = cmnHelper.GetStringValueFrmColumn(dt, "student_email", 0);
                    txtMobile.Text = cmnHelper.GetStringValueFrmColumn(dt, "mobile_no", 0);
                    string pwd = cmnHelper.GetStringValueFrmColumn(dt, "password", 0);
                    txtChangePassword.Text = "";
                    if (!string.IsNullOrEmpty(pwd))
                    {
                        txtChangePassword.Text = EncryptDecrypt.Decrypt(pwd);
                    }
                    isActive = cmnHelper.GetBoolValueFrmColumn(dt, "active_ind", 0);
                    if (isActive)
                    {
                        lblStatus.Text = "Active";
                    }
                    else
                    {
                        lblStatus.Text = "Inactive";
                        btnAdd.Enabled = false;
                        btEdit.Enabled = false;
                        btnActivate.Enabled = true;
                        btnSave.Enabled = false;
                        btnCancel.Enabled = false;
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
            ec.ID = this.StudentID;

            string messageCode = "";
            string messageText = "";
            string output = "";

            output = ValidateFields();

            if (string.IsNullOrEmpty(output))
            {
                if (Mode == "A")
                {
                    string pwd = Helper.EncryptDecrypt.Encrypt("student");
                    output = new StudentDAL().InsertStudentRecord(txtLastName.Text.Trim(), txtFirstName.Text.Trim(), txtMiddleName.Text.Trim(), txtDOB.Text.Trim(), txtAddr1.Text.Trim(), txtAddr2.Text.Trim(), txtCity.Text.Trim(), txtState.Text.Trim(), txtZipCode.Text.Trim(), txtCountry.Text.Trim(), txtEmail.Text.Trim(), txtMobile.Text.Trim(), pwd, out messageCode, out messageText);
                }
                else if (Mode == "E")
                {
                    string pwd = Helper.EncryptDecrypt.Encrypt(txtChangePassword.Text.Trim());
                    output = new StudentDAL().UpdateStudentRecord(StudentID, lblStudentID.Text, txtLastName.Text.Trim(), txtFirstName.Text.Trim(), txtMiddleName.Text.Trim(), txtDOB.Text.Trim(), txtAddr1.Text.Trim(), txtAddr2.Text.Trim(), txtCity.Text.Trim(), txtState.Text.Trim(), txtZipCode.Text.Trim(), txtCountry.Text.Trim(), txtEmail.Text.Trim(), txtMobile.Text.Trim(), pwd, out messageCode, out messageText);
                }
            }

            if (string.IsNullOrEmpty(output))
            {
                if (messageCode == "101")
                {
                    lblMsg.Text = messageText;
                    lblMsg.CssClass = "successLabelClass";
                    OnevtStudentEdited(sender, ec);
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
            if (string.IsNullOrEmpty(txtLastName.Text.Trim())
                || string.IsNullOrEmpty(txtFirstName.Text.Trim())
                || string.IsNullOrEmpty(txtDOB.Text.Trim())
                || string.IsNullOrEmpty(txtAddr1.Text.Trim())
                || string.IsNullOrEmpty(txtCity.Text.Trim())
                || string.IsNullOrEmpty(txtMobile.Text.Trim())
                || string.IsNullOrEmpty(txtState.Text.Trim())
                || string.IsNullOrEmpty(txtZipCode.Text.Trim())
                || string.IsNullOrEmpty(txtEmail.Text.Trim())
                )
            {
                message = "Please enter mandatory fields marked with (*)";
            }
            if (Mode != "A")
            {
                if (string.IsNullOrEmpty(txtChangePassword.Text.Trim()))
                {
                    message = "Please enter valid Password";
                }
            }
            if (!ValidateHelper.IsDate(txtDOB.Text.Trim()))
            {
                message = "Please enter valid date";
            }
            return message;
        }

        protected void btnActivate_Click(object sender, EventArgs e)
        {
            CustomEventArgs ec = new CustomEventArgs();
            ec.ID = this.StudentID;

            string messageCode = "";
            string messageText = "";
            string output = "";

            output = ValidateFields();

            if (string.IsNullOrEmpty(output))
            {                
                output = new StudentDAL().ActivateInactivateStudentRecord(StudentID, out messageCode, out messageText);
            }

            if (string.IsNullOrEmpty(output))
            {
                if (messageCode == "101")
                {
                    lblMsg.Text = messageText;
                    lblMsg.CssClass = "successLabelClass";
                    OnevtStudentEdited(sender, ec);
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
            StudentID = string.Empty;
            OnevtStudentEdited(sender, null);
            EnableDisableControls(false);
            EnableDisableButtons(true);
            if (string.IsNullOrEmpty(StudentID))
            {
                btnAdd.Enabled = true;
                btEdit.Enabled = false;
                btnActivate.Enabled = false;
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


        protected void btnUploadImage_Click(object sender, EventArgs e)
        {
            if (fileUpload.HasFile)
            {
                //getting length of uploaded file
                int length = fileUpload.PostedFile.ContentLength;
                //create a byte array to store the binary image data
                byte[] imgbyte = new byte[length];
                //store the currently selected file in memeory
                HttpPostedFile img = fileUpload.PostedFile;
                //set the binary data
                img.InputStream.Read(imgbyte, 0, length);

                string messageCode = "";
                string messageText = "";
                string output = "";


                if (string.IsNullOrEmpty(output))
                {
                    output = new StudentDAL().UploadStudentImage(StudentID, imgbyte, out messageCode, out messageText);
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

                BindData();
            }
        }
    }
}