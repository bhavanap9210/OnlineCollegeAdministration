using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OCA.Reports
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {
                string reportCode = GetReportCode();
                LoadUserControl(reportCode);
            }
        }

       
        #region Private Methods
        /// <summary>
        /// Gets the report code from the Query String
        /// </summary>
        /// <returns></returns>
        private string GetReportCode()
        {
            string reportCode = "";
            if (Request.QueryString.Count > 0)
            {
                if (Request.QueryString["rpt_cd"] != null)
                {
                    reportCode = Request.QueryString["rpt_cd"].ToString().Trim();
                }
            }
            return reportCode;
        }
        /// <summary>
        /// Loads the user control
        /// </summary>
        private void LoadUserControl(string reportCode)
        {
            ucStudentReports.Visible = false;
			ucStaffReports.Visible = false;
            ucOtherReports.Visible = false;
            if (reportCode == "R101" || reportCode == "R102" || reportCode == "R103")
            {
                ucStudentReports.Visible = true;
                ucStudentReports.ReportCode = reportCode;
                ucStudentReports.LoadControlData();
            }
			else if (reportCode == "R201" || reportCode == "R202")
            {
                ucStaffReports.Visible = true;
                ucStaffReports.ReportCode = reportCode;
                ucStaffReports.LoadControlData();
            }
            else if (reportCode == "R301" || reportCode == "R302" || reportCode == "R303" || reportCode == "R304" || reportCode == "R305" || reportCode == "R306")
            {
                ucOtherReports.Visible = true;
                ucOtherReports.ReportCode = reportCode;
                ucOtherReports.LoadControlData();
            }
        }
        #endregion
    }
}