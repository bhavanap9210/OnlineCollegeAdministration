using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OCA.Admin
{
    public partial class MaintainStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                udStaffView.LoadUserControlData();
                udStaffAddEdit.LoadUserControlData();
            }
        }

        protected void udStaffAddEdit_evtStaffEdited(object sender, EventArgs e)
        {
            udStaffView.LoadUserControlData();
        }

        protected void udStaffView_evtStaffSelected(object sender, EventArgs e)
        {
            if (e != null)
            {
                CustomEventArgs e1 = (CustomEventArgs)e;
                udStaffAddEdit.StaffID = e1.ID;
                udStaffAddEdit.LoadUserControlData();
            }
        }

    }
}