using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OCA.Admin
{
    public partial class MaintainCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                udCourseView.LoadUserControlData();
                udCourseAddEdit.LoadUserControlData();
            }
        }

        protected void udCourseAddEdit_evtCourseEdited(object sender, EventArgs e)
        {
            udCourseView.LoadUserControlData();
        }

        protected void udCourseView_evtCourseSelected(object sender, EventArgs e)
        {
            if (e != null)
            {
                CustomEventArgs e1 = (CustomEventArgs)e;
                udCourseAddEdit.CourseID = e1.ID;
                udCourseAddEdit.LoadUserControlData();
            }
        }
    }
}