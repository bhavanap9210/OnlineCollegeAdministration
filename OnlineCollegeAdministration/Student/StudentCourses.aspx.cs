using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OCA.Student
{
    public partial class StudentCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonHelper _commonHelper = new CommonHelper();
                string _studentIDText = _commonHelper.GetUserIdText();
                string _studentID = _commonHelper.GetUserId();
                ucStudentCourseView.StudentID = _studentID;
                ucStudentCourseView.StudentIDText= _studentIDText;

                ucStudentCourseAddEdit.StudentID = _studentID;
                ucStudentCourseAddEdit.StudentIDText = _studentIDText;

                ucStudentCourseView.LoadUserControlData();
                ucStudentCourseAddEdit.LoadUserControlData();
            }
        }



        protected void ucStudentCourseAddEdit_evtStudentCourseEdited(object sender, EventArgs e)
        {
            ucStudentCourseView.LoadUserControlData();
        }

        protected void ucStudentCourseView_evtStudentCourseSelected(object sender, EventArgs e)
        {
            if (e != null)
            {
                CustomEventArgs e1 = (CustomEventArgs)e;
                ucStudentCourseAddEdit.CourseDurationId = e1.ID;
                ucStudentCourseAddEdit.StaffId= e1.AddlId;
                ucStudentCourseAddEdit.StaffCourseId = e1.AddlId0;
                ucStudentCourseAddEdit.LoadUserControlData();
            }
        }

    }
}