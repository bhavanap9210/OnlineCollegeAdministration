using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Collections;
namespace Helper
{
    public class CustomPrincipal : IPrincipal
    {
        public string[] Roles
        {
            get;
            private set;
        }

        public string[] MenuUrls
        {
            get;
            private set;
        }
        public string[] MenuCatg
        {
            get;
            private set;
        }

        public string[] MenuNames
        {
            get;
            private set;
        }

        public string UserId
        {
            get;
            private set;
        }

        public CustomPrincipal(IIdentity _identity, string[] _roles, string[] _menuCatg, string[] _menuNames, string[] _menuUrls, string _userId)
        {
            Identity = _identity;
            Roles = _roles;
            MenuUrls = _menuUrls;
            MenuNames = _menuNames;
            MenuCatg = _menuCatg;
            UserId = _userId;
        }

        public IIdentity Identity
        {
            get;
            private set;
        }

        /// <summary>
        /// Checks for the Roles
        /// </summary>
        /// <param name="_roles"></param>
        /// <returns></returns>
        public bool IsInRole(string _roles)
        {
            bool isAuthenticated = false;
            if (Identity.IsAuthenticated && Roles.Contains(_roles))
            {
                isAuthenticated = true;
            }
            return isAuthenticated;
        }

        /// <summary>
        /// Checks for the menus
        /// </summary>
        /// <param name="_menuUrls"></param>
        /// <returns></returns>
        public bool IsMenuAllowed(string _menuUrls)
        {
            bool isAuthenticated = false;
            string _IISApplicationFolderName = System.Configuration.ConfigurationManager.AppSettings["IISApplicationFolderName"].ToString();
               
            _menuUrls = _menuUrls.Replace("/"+_IISApplicationFolderName , "");

            if (Identity.IsAuthenticated && (MenuUrls.Contains(_menuUrls) || _menuUrls.ToUpper()=="/Home.aspx".ToUpper()))
            {
                isAuthenticated = true;
            }
            return isAuthenticated;
        }
    }
}
