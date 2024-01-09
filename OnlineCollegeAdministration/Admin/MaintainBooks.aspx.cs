using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace OCA.Admin
{
    public partial class MaintainBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                udBookView.LoadUserControlData();
                udBookAddEdit.LoadUserControlData();
            }
        }

        protected void udBookAddEdit_evtBookEdited(object sender, EventArgs e)
        {
            udBookView.LoadUserControlData();
        }

        protected void udBookView_evtBookSelected(object sender, EventArgs e)
        {
            if (e != null)
            {
                CustomEventArgs e1 = (CustomEventArgs)e;
                udBookAddEdit.BookID = e1.ID;
                udBookAddEdit.LoadUserControlData();
            }
        }
    }
}