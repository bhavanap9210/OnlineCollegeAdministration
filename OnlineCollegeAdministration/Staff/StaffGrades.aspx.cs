using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace OCA.Staff
{
    public partial class StaffGrades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonHelper _commonHelper = new CommonHelper();
                string _staffIdText= _commonHelper.GetUserIdText();
                string _staffID= _commonHelper.GetUserId();
                ucStaffGradeView.StaffId = _staffID;
                ucStaffGradeView.StaffIdText = _staffIdText;
                
                ucStaffGradeEdit.StaffId = _staffID;                

                ucStaffGradeView.LoadUserControlData();
                ucStaffGradeEdit.LoadUserControlData();
            }
        }

        protected void ucStaffGradesEdit_evtStaffGradesEdited(object sender, EventArgs e)
        {
            ucStaffGradeView.LoadUserControlData();
        }

         
        protected void ucStaffGradeView_evtStudentSelected(object sender, EventArgs e)
        {
            if (e != null)
            {
                CustomEventArgs e1 = (CustomEventArgs)e;
                ucStaffGradeEdit.StudentID = e1.ID;
                ucStaffGradeEdit.StaffCourseId = e1.AddlId0;
                ucStaffGradeEdit.CourseDurationId = e1.AddlId1;
                ucStaffGradeEdit.LoadUserControlData();
            }
        }

    }
}