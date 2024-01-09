using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OCA.Admin
{
    public partial class MaintainStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                udStudentView.LoadUserControlData();
                udStudentAddEdit.LoadUserControlData();
            }
        }

        protected void udStudentAddEdit_evtStudentEdited(object sender, EventArgs e)
        {
            udStudentView.LoadUserControlData();
        }

        protected void udStudentView_evtStudentSelected(object sender, EventArgs e)
        {
            if (e != null)
            {
                CustomEventArgs e1 = (CustomEventArgs)e;
                udStudentAddEdit.StudentID = e1.ID;
                udStudentAddEdit.LoadUserControlData();
            }
        }

    }
}