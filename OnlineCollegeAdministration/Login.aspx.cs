using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;
using Helper;

namespace OCA
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CommonHelper common = new CommonHelper();
            common.LogOut(true);
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            litFailureText.Text = "";
            // Initialize FormsAuthentication, for what it's worth
            FormsAuthentication.Initialize();
            string userName = LoginControl.UserName;
            string passwordText = EncryptDecrypt.Encrypt(LoginControl.Password);
            string roleIdsPageUrls= "";
            //if (userName == "Admin")
            //{
            //    roles = "Admin,Other";
            //}
            //else
            //{
            //    roles = "Other";
            //}

            ///FormsAuthentication.HashPasswordForStoringInConfigFile(LoginControl.Password, "md5"); // Or "sha1"

            string messageCode = string.Empty;
            string messageText = string.Empty;
            string menus = string.Empty;
            string userId = string.Empty;
            IDataReader reader = new DataAccessLayer.LoginDataAccessLayer().GetAuthenticateUserRolesLookup(userName, passwordText, out messageCode, out messageText);
            if (messageCode == "101")
            {
                while (reader.Read())
                {
                    roleIdsPageUrls = reader["menu_catg"].ToString() + "|" + reader["menu_name"].ToString() + "|" + reader["role_id_page_url"].ToString() + "|" + reader["addl_user_id"].ToString();
                    userId = reader["addl_user_id"].ToString();
                    
                    CommonHelper _commonHelper = new CommonHelper();

                    _commonHelper.SetValueCache(userName+"RoleIdsPageUrls", roleIdsPageUrls);
                    roleIdsPageUrls = "";
                    //1. Create a new ticket used for authentication
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                       1, // Ticket version
                       userName, // Username associated with ticket
                       DateTime.Now, // Date/time issued
                       DateTime.Now.AddMinutes(30), // Date/time to expire
                       true, // "true" for a persistent user cookie
                       roleIdsPageUrls, // User-data, in this case the roles
                       FormsAuthentication.FormsCookiePath);// Path cookie valid for



                    //2. Encrypt the cookie using the machine key for secure transport
                    string hash = FormsAuthentication.Encrypt(ticket);
                    
                    HttpCookie cookie = new HttpCookie(
                       FormsAuthentication.FormsCookieName, // Name of auth cookie
                       hash); // Hashed ticket

                    //3. Set the cookie's expiration time to the tickets expiration time
                    if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

                    // Add the cookie to the list for outgoing response
                    Response.Cookies.Add(cookie);

                    //4. Redirect to requested URL, or homepage if no previous page requested
                    string returnUrl = Request.QueryString["ReturnUrl"];
                    if (returnUrl == null) returnUrl = "~/Home.aspx";

                    _commonHelper.SetValueCache(userId + "menuName", "Home");
                    // Don't call FormsAuthentication.RedirectFromLoginPage since it
                    // could replace the authentication ticket (cookie) we just added
                    Response.Redirect(returnUrl);
                }
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
            }
            else
            {
                // Never tell the user if just the username is password is incorrect.
                // That just gives them a place to start, once they've found one or
                // the other is correct!
                litFailureText.Text = "Username / Password is incorrect. Please try again.";
                
                
            }


        }

    }
}