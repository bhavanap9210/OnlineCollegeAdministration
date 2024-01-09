using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Helper;

namespace OCA
{
    public partial class OCAMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.User != null)
            {
                CommonHelper _commonHelper = new CommonHelper();
                lblUserName.Text = _commonHelper.GetUserIdText();
            }
        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            CommonHelper common = new CommonHelper();
            common.LogOut(false);
        }

        protected void lnkHome_Click(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                CommonHelper _commonHelper = new CommonHelper();
                _commonHelper.SetValueCache(_commonHelper.GetUserId() + "menuName", "Home");
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}