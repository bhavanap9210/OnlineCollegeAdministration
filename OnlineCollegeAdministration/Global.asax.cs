using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;
using Helper;

namespace OCA
{
    public class Global : System.Web.HttpApplication
    {
        private string _userdata;
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    if (HttpContext.Current.User.Identity is FormsIdentity)
                    {
                        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                        FormsAuthenticationTicket ticket = id.Ticket;
                        
                        // Get the stored user-data, in this case, our roles
                        //string userData = ticket.UserData;
                        CommonHelper _commonHelper = new CommonHelper();
                        string userData = _commonHelper.GetValueFromCache(id.Name+"RoleIdsPageUrls");
                        if (!string.IsNullOrEmpty(userData))
                        {
                            string[] rolesPageurls = userData.Split('|');
                            string[] menuCatg = rolesPageurls[0].Split(',');
                            string[] menuNames = rolesPageurls[1].Split(',');
                            string[] roles = rolesPageurls[2].Split(',');
                            string[] menus = rolesPageurls[3].Split(',');
                            string userId = rolesPageurls[4].ToString();
                            HttpContext.Current.User = new CustomPrincipal(id, roles, menuCatg, menuNames, menus,userId);
                        }
                    }
                }
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}