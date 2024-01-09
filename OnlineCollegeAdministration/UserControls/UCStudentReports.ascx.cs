using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Web;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.ReportSource;
using CrystalDecisions.Shared;
using Helper;
using System.Data;
using DataAccessLayer;


namespace OCA.UserControls
{
    public partial class UCStudentReports : CustomUserControl
    {
        #region Variables
        ReportDocument rptDoc;

        /// <summary>
        /// Get or Set ViewCommonBE
        /// </summary>
        public CommonBE ViewCommonBE
        {
            get
            {
                if (ViewState["ViewCommonBE"] != null)
                {
                    return (CommonBE)ViewState["ViewCommonBE"];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                ViewState["ViewCommonBE"] = value;
            }
        }


        /// <summary>
        /// Get or Set ReportCode
        /// </summary>
        public string ReportCode
        {
            get
            {
                if (ViewState["ReportCode"] != null)
                {
                    return ViewState["ReportCode"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["ReportCode"] = value;
            }
        }


        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            rptDoc = new ReportDocument();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            IDataReader rdr = null;
            string reportName = "";
            ReportsDAL _reportsDAL = new ReportsDAL();
            string messageCode = "";
            string messageText = "";
            lblMsg.Text = "";
            bool isValid = SetSearchValues();
            if (!isValid)
            {
                return;
            }
            if (ReportCode == "R101")
            {
                reportName = "Student";
                rdr = _reportsDAL.GetStudentList(ViewCommonBE, out messageCode, out messageText);

            }
            else if (ReportCode == "R102")
            {
                reportName = "StudentStaff";
                rdr = _reportsDAL.GetStudentListByStaff(ViewCommonBE, out messageCode, out messageText);
            }
            else if (ReportCode == "R103")
            {
                reportName = "StudentCourse";
                rdr = _reportsDAL.GetStudentListByCourse(ViewCommonBE, out messageCode, out messageText);
            }
            else if (ReportCode == "R104")
            {
                reportName = "StudentCourse";
                rdr = _reportsDAL.GetStudentListByCourse(ViewCommonBE, out messageCode, out messageText);
            }

            if (messageCode == "101")
            {
                if (rdr != null)
                {
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    ds.Tables.Add(dt);
                    if (dt.Rows.Count < 1)
                    {
                        lblMsg.Text = "No records";
                        lblMsg.CssClass = "errorLabelClass";
                        return;
                    }
                    if (ReportCode == "R101" || ReportCode == "R102" || ReportCode == "R103")
                    {
                        ds.Tables[0].TableName = "Student";
                    }
                    ExportReport(reportName, ds);
                }
            }
            else
            {
                lblMsg.Text = messageText;
                lblMsg.CssClass = "errorLabelClass";
                return;
            }

        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }


        #region Public Methods
        /// <summary>
        /// Loads the Usercontrol
        /// </summary>
        public void LoadControlData()
        {
            ClearSearch();
            HideUnhideFields();
            //SetSearchValues();
        }


        #endregion

        #region Private Methods
        /// <summary>
        /// Exports the report
        /// </summary>
        /// <param name="reportName"></param>
        /// <param name="ds"></param>
        private void ExportReport(string reportName, DataSet ds)
        {
            lblMsg.Text = "";
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    try
                    {
                        ReportDocument rptDoc = new ReportDocument();
                        string reportNameFull = Request.PhysicalApplicationPath + "\\Reports\\Reports\\" + reportName + ".rpt";
                        rptDoc.Load(reportNameFull);
                        rptDoc.DataSourceConnections.Clear();
                        rptDoc.Database.Tables[0].SetDataSource(ds);
                        rptDoc.ExportToHttpResponse(ExportFormatType.PortableDocFormat, this.Page.Response, true, reportName);
                    }
                    catch (Exception ex)
                    {
                        lblMsg.Text = ex.Message;
                    }
                }
                else
                {
                    lblMsg.Text = "No Records";
                }
            }
            else
            {
                lblMsg.Text = "No Records";
            }
        }

        /// <summary>
        /// Hides or Unhides the fields based on the Report Code
        /// </summary>
        private void HideUnhideFields()
        {
            trCourse.Visible = false;
            trStaff.Visible = false;
            CommonHelper _commonHelper = new CommonHelper();

            if (ReportCode == "R101")
            {

            }
            else if (ReportCode == "R102")
            {
                if (!_commonHelper.IsinRole("3"))
                {
                    trStaff.Visible = true;
                }
                else
                {
                    trStaff.Visible = false;
                }

            }
            else if (ReportCode == "R103")
            {
                trCourse.Visible = true;
            }
        }

        /// <summary>
        /// Sets the Search Values
        /// </summary>
        private bool SetSearchValues()
        {
            bool isValid = false;
            string output = "";

            output = ValidateFields();
            CommonHelper _commonHelper = new CommonHelper();
            if (string.IsNullOrEmpty(output))
            {
                isValid = true;
                ViewCommonBE = new CommonBE();
                ViewCommonBE.ID = txtStudentID.Text.Trim();
                ViewCommonBE.LastName = txtLastName.Text.Trim();
                ViewCommonBE.FirstName = txtFirstName.Text.Trim();
                ViewCommonBE.MiddleName = txtMiddleName.Text.Trim();
                ViewCommonBE.DateOfBirth = txtDOB.Text.Trim();
                ViewCommonBE.ActiveInd = ddlActive.SelectedValue;
                ViewCommonBE.AddlName = "";
                ViewCommonBE.AddlID = "";
                if (ReportCode == "R102")
                {
                    ViewCommonBE.AddlName = txtStaffName.Text.Trim();
                    if (!_commonHelper.IsinRole("3"))
                    {
                        trStaff.Visible = true;
                        ViewCommonBE.AddlName = txtStaffName.Text.Trim();
                        ViewCommonBE.AddlID = txtStaffId.Text.Trim();
                    }
                    else
                    {
                        ViewCommonBE.AddlID = _commonHelper.GetUserIdText();
                    }
                }
                else if (ReportCode == "R103")
                {
                    ViewCommonBE.AddlName = txtCourseName.Text.Trim();
                    ViewCommonBE.AddlID = txtCourseId.Text.Trim();
                }                
            }
            else
            {
                lblMsg.Text = output;
                lblMsg.CssClass = "errorLabelClass";
            }

            return isValid;
        }
        /// <summary>
        /// Validate the fields
        /// </summary>
        /// <returns>string</returns>
        private string ValidateFields()
        {
            string message = "";

            if (ReportCode == "R101")
            {
                if (!string.IsNullOrEmpty(txtDOB.Text.Trim()))
                {
                    if (!ValidateHelper.IsDate(txtDOB.Text.Trim()))
                    {
                        message = "Please enter valid date";
                    }
                }
            }
            return message;
        }

        /// <summary>
        /// Clears the Search values
        /// </summary>
        private void ClearSearch()
        {
            if (ViewCommonBE != null)
            {
                ViewCommonBE.ID = "";
                ViewCommonBE.LastName = "";
                ViewCommonBE.FirstName = "";
                ViewCommonBE.MiddleName = "";
                ViewCommonBE.DateOfBirth = "";
                ViewCommonBE.ActiveInd = null;
                ViewCommonBE.AddlID = "";
                ViewCommonBE.AddlName = "";
            }
            txtDOB.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtStudentID.Text = "";
            txtCourseId.Text = "";
            txtCourseName.Text = "";
            txtStaffId.Text = "";
            txtStaffName.Text = "";
            ddlActive.ClearSelection();
        }

        #endregion
    }
}