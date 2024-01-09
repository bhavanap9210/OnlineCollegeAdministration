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
    public partial class UCOtherReports : CustomUserControl
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
            if (ReportCode == "R301")
            {
                reportName = "Course";
                rdr = _reportsDAL.GetCourseList(ViewCommonBE, out messageCode, out messageText);

            }
            else if (ReportCode == "R302")
            {
                reportName = "CourseStaffYearMonth";
                rdr = _reportsDAL.GetCourseListByYearMonth(ViewCommonBE, out messageCode, out messageText);
            }
            else if (ReportCode == "R303")
            {
                reportName = "Book";
                rdr = _reportsDAL.GetBookList(ViewCommonBE, out messageCode, out messageText);
            }
            else if (ReportCode == "R304")
            {
                reportName = "CourseStaff";
                rdr = _reportsDAL.GetCourseListByStaff(ViewCommonBE, out messageCode, out messageText);
            }
            else if (ReportCode == "R305")
            {
                reportName = "StudentGradeCourse";
                rdr = _reportsDAL.GetStudentGradesByCourseList(ViewCommonBE, out messageCode, out messageText);
            }
            else if (ReportCode == "R306")
            {
                reportName = "BookCourse";
                rdr = _reportsDAL.GetBookListByCourse(ViewCommonBE, out messageCode, out messageText);
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
                    if (ReportCode == "R301")
                    {
                        ds.Tables[0].TableName = "Course";
                    }
                    else if (ReportCode == "R302")
                    {
                        ds.Tables[0].TableName = "CourseStaff";
                    }
                    else if (ReportCode == "R303")
                    {
                        ds.Tables[0].TableName = "Book";
                    }
                    else if (ReportCode == "R304")
                    {
                        ds.Tables[0].TableName = "CourseStaff";
                    }
                    else if (ReportCode == "R305")
                    {
                        ds.Tables[0].TableName = "Student";
                    }
                    else if (ReportCode == "R306")
                    {
                        ds.Tables[0].TableName = "BookCourse";
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


        /// <summary>
        /// Loads all dropdowns
        /// </summary>
        private void LoadDropDownds()
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
        }


        #region Public Methods
        /// <summary>
        /// Loads the Usercontrol
        /// </summary>
        public void LoadControlData()
        {
            LoadDropDownds();
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
            trStudent0.Visible = false;
            trStudent1.Visible = false;
            trStudent2.Visible = false;
            trYearMonth.Visible = false;
            trBook.Visible = false;
            trStatus.Visible = true;
            CommonHelper _commonHelper = new CommonHelper();

            if (ReportCode == "R301")
            {
                trCourse.Visible = true;
                trStatus.Visible = false;
            }
            else if (ReportCode == "R302")
            {
                trCourse.Visible = true;
                trYearMonth.Visible = true;
            }
            else if (ReportCode == "R303")
            {
                trBook.Visible = true;
            }
            else if (ReportCode == "R304")
            {
                trStaff.Visible = true;
                trCourse.Visible = true;                
            }
            else if (ReportCode == "R305")//All Students Grades
            {
                bool isVisible = true;
                if (_commonHelper.IsinRole("2")) //Student
                {
                    isVisible = false;
                }
                trStudent0.Visible = isVisible;
                trStudent1.Visible = isVisible;
                trStudent2.Visible = isVisible;
                trStatus.Visible = isVisible;
                trCourse.Visible = true;
            }
            else if (ReportCode == "R306")
            {
                trBook.Visible = true;
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

                if (ReportCode == "R301")
                {                  
                    ViewCommonBE.AddlID= txtCourseId.Text.Trim();
                    ViewCommonBE.AddlName= txtCourseName.Text.Trim();                    
                }
                else if (ReportCode == "R302")
                {                     
                    ViewCommonBE.AddlID = txtCourseId.Text.Trim();
                    ViewCommonBE.AddlName = txtCourseName.Text.Trim();
                    ViewCommonBE.YearNbr = ddlYear.SelectedValue;
                    ViewCommonBE.MonthNbr = ddlMonth.SelectedValue;
                }
                else if (ReportCode == "R303")
                {
                    
                    ViewCommonBE.AddlID = txtBookAuthorName.Text.Trim();
                    ViewCommonBE.AddlName = txtBookName.Text.Trim();
                }
                else if (ReportCode == "R304")
                {                     
                    ViewCommonBE.ID = txtStaffId.Text.Trim();
                    ViewCommonBE.LastName = txtLastName.Text.Trim();
                    ViewCommonBE.FirstName = txtFirstName.Text.Trim();
                    ViewCommonBE.MiddleName = txtMiddleName.Text.Trim();
                    ViewCommonBE.DateOfBirth = txtDOB.Text.Trim();
                    ViewCommonBE.AddlID = txtCourseId.Text.Trim();
                    ViewCommonBE.AddlName = txtCourseName.Text.Trim();
                }
                else if (ReportCode == "R305")//Grades
                {
                    if (!_commonHelper.IsinRole("2")) //Student
                    {
                        ViewCommonBE.ID = txtStudentID.Text.Trim();
                    }
                    else
                    {
                        ViewCommonBE.ID = _commonHelper.GetUserIdText();// txtStudentID.Text.Trim();
                    }
                    ViewCommonBE.LastName = txtLastName.Text.Trim();
                    ViewCommonBE.FirstName = txtFirstName.Text.Trim();
                    ViewCommonBE.MiddleName = txtMiddleName.Text.Trim();
                    ViewCommonBE.DateOfBirth = txtDOB.Text.Trim();
                    ViewCommonBE.AddlID = txtCourseId.Text.Trim();
                    ViewCommonBE.AddlName = txtCourseName.Text.Trim();
                }
                else if (ReportCode == "R306")
                {                    
                    ViewCommonBE.AddlID0 = txtBookAuthorName.Text.Trim();
                    ViewCommonBE.AddlName0 = txtBookName.Text.Trim();
                    ViewCommonBE.AddlID = txtCourseId.Text.Trim();
                    ViewCommonBE.AddlName = txtCourseName.Text.Trim();
                }                
                ViewCommonBE.ActiveInd = ddlActive.SelectedValue;                
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

            if (ReportCode == "R305")
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
                ViewCommonBE.AddlID0 = "";
                ViewCommonBE.AddlName0 = "";
                ViewCommonBE.YearNbr= "0";
                ViewCommonBE.MonthNbr = "0";
            }
            txtDOB.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtStudentID.Text = "";
            txtCourseId.Text = "";
            txtCourseName.Text = "";
            txtStaffId.Text = "";
            txtBookAuthorName.Text = "";
            txtBookName.Text = "";
            txtCourseId.Text = "";
            txtCourseName.Text = "";
            txtBookAuthorName.Text = "";

            ddlActive.ClearSelection();
            ddlMonth.ClearSelection();
            ddlYear.ClearSelection();
        }

        #endregion
    }
}