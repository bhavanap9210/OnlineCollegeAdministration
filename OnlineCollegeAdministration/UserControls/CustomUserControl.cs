using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Helper;

namespace OCA.UserControls
{
    public class CustomUserControl : System.Web.UI.UserControl
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            new CommonHelper().AuthorizeMenus(Request);
            //base.OnPreRender(e);
        }

        public virtual void LoadUserControlData()
        {
        }
    }
}