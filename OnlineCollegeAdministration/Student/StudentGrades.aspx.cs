using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OCA.Student
{
    public partial class StudentGrades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonHelper _commonHelper = new CommonHelper();
                string _studentIDText = _commonHelper.GetUserIdText();
                string _studentID = _commonHelper.GetUserId();
                ucStudentGradeView.StudentID = _studentID;
                ucStudentGradeView.StudentIDText= _studentIDText;

                ucStudentGradeAddEdit.StudentID = _studentID;
                ucStudentGradeAddEdit.StudentIDText = _studentIDText;

                ucStudentGradeView.LoadUserControlData();
                ucStudentGradeAddEdit.LoadUserControlData();
            }
        }
        
        protected void ucStudentGradesAddEdit_evtStudentGradesEdited(object sender, EventArgs e)
        {
            ucStudentGradeView.LoadUserControlData();
        }

        protected void ucStudentGradesView_evtStudentGradesSelected(object sender, EventArgs e)
        {
            if (e != null)
            {
                CustomEventArgs e1 = (CustomEventArgs)e;
                ucStudentGradeAddEdit.CourseDurationId = e1.ID;
                ucStudentGradeAddEdit.StaffId= e1.AddlId;
                ucStudentGradeAddEdit.StaffCourseId = e1.AddlId0;
                ucStudentGradeAddEdit.LoadUserControlData();
            }
        }

    }
}