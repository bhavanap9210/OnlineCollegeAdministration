using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Helper
{
    public class CommonHelper
    {
        public CommonHelper()
        {
        }

        /// <summary>
        /// Logs out the current user
        /// </summary>
        public void LogOut(bool isLoginPage = false)
        {
            HttpContext context1 = HttpContext.Current;
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie cookie1 = new HttpCookie(cookieName, "");

            cookie1.Expires = new DateTime(1999, 10, 12);
            context1.Response.Cookies.Remove(cookieName);
            context1.Response.Cookies.Add(cookie1);
            context1.Response.Cache.SetExpires(cookie1.Expires);
            context1.Session.Clear();
            context1.Session.Abandon();

            
            if (!isLoginPage)
                context1.Response.Redirect("~/Login.aspx", false);
        }

        /// <summary>
        /// Authorizes the user for menus
        /// </summary>
        /// <param name="_request"></param>
        public void AuthorizeMenus(HttpRequest _request)
        {
            HttpContext context1 = HttpContext.Current;
            bool isAllowed = false;
            if (context1.User.Identity.IsAuthenticated)
            {
                try
                {
                    CustomPrincipal tempPrincipal = (CustomPrincipal)context1.User;
                    isAllowed = tempPrincipal.IsMenuAllowed(_request.RawUrl);
                }
                catch (Exception)
                {
                    LogOut();
                }                
            }
            if (!isAllowed)
            {
                LogOut(false);
            }
        }

        /// <summary>
        /// Sets the session
        /// </summary>
        /// <param name="_cacheName"></param>
        /// <param name="_data"></param>
        public void SetValueCache(string _cacheName, string _data)
        {
            HttpContext.Current.Cache.Remove(_cacheName);
            HttpContext.Current.Cache.Add(_cacheName, _data, null, System.Web.Caching.Cache.NoAbsoluteExpiration, new TimeSpan(0, 30, 0), System.Web.Caching.CacheItemPriority.Default, null);
        }

        /// <summary>
        /// Gets the value from the session
        /// </summary>
        /// <param name="_cacheName"></param>
        public string GetValueFromCache(string _cacheName)
        {
            string val = "";
            if (HttpContext.Current.Cache[_cacheName] != null)
            {
                val = HttpContext.Current.Cache[_cacheName].ToString();
            }
            return val;
        }

        /// <summary>
        /// Checks the user for their role
        /// </summary>
        /// <param name="_role"></param>
        /// <returns>bool</returns>
        public bool IsinRole(string _role)
        {
            HttpContext context1 = HttpContext.Current;
            bool isAllowed = false;
            if (context1.User.Identity.IsAuthenticated)
            {
                try
                {
                    CustomPrincipal tempPrincipal = (CustomPrincipal)context1.User;
                    isAllowed = tempPrincipal.IsInRole(_role);
                }
                catch (Exception)
                {
                    LogOut();
                }                
            }
            return isAllowed;
        }

        /// <summary>
        /// Gets the User Id for the logged in user
        /// </summary>
        /// <returns>string</returns>
        public string GetUserId()
        {
            HttpContext context1 = HttpContext.Current;
            string userId = "";
            if (context1.User.Identity.IsAuthenticated)
            {
                try
                {
                    CustomPrincipal tempPrincipal = (CustomPrincipal)context1.User;
                    userId = tempPrincipal.UserId;
                }
                catch (Exception)
                {
                    LogOut();
                }
                
            }
            return userId;
        }

        /// <summary>
        /// Gets the User Id Text for the logged in user
        /// </summary>
        /// <returns>string</returns>
        public string GetUserIdText()
        {
            HttpContext context1 = HttpContext.Current;
            string userId = "";
            if (context1.User.Identity.IsAuthenticated)
            {
                try
                {
                    CustomPrincipal tempPrincipal = (CustomPrincipal)context1.User;
                    userId = tempPrincipal.Identity.Name;
                }
                catch (Exception)
                {
                    LogOut();
                }
            }
            return userId;
        }

        /// <summary>
        /// Get the menus for the logged in user
        /// </summary>
        /// <returns></returns>
        public DataTable GetMenus()
        {
            DataTable dtMenus = new DataTable();
            dtMenus.Columns.Add("menu_catg", typeof(string));
            dtMenus.Columns.Add("menu_name", typeof(string));
            dtMenus.Columns.Add("page_url", typeof(string));
            HttpContext context1 = HttpContext.Current;

            if (context1.User.Identity.IsAuthenticated)
            {
                CustomPrincipal tempPrincipal = (CustomPrincipal)context1.User;
                int _menuCount = tempPrincipal.MenuNames.Length;
                DataRow dr;
                for (int i = 0; i < _menuCount; i++)
                {
                    dr = dtMenus.NewRow();
                    dr["menu_catg"] = tempPrincipal.MenuCatg[i].ToString();
                    dr["menu_name"] = tempPrincipal.MenuNames[i].ToString();
                    dr["page_url"] = tempPrincipal.MenuUrls[i].ToString();
                    dtMenus.Rows.Add(dr);
                }
            }
            return dtMenus;
        }


        /// <summary>
        /// Gets the Total amt value for a specified column in a table
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ColumnName"></param>
        /// <returns>Decimal</returns>
        public Decimal GetTotal(DataTable dt, String ColumnName)
        {
            Decimal sum = 0;
            DataRow row = dt.NewRow();

            if (dt.Rows.Count > 0)
            {
                if (row.Table.Columns.Contains(ColumnName))
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        if (dr[ColumnName] != null)
                        {
                            if (ValidateHelper.IsDecimal(dr[ColumnName].ToString()))
                            {
                                sum += Convert.ToDecimal(dr[ColumnName].ToString().Trim());
                            }
                        }
                    }
                }
            }
            return sum;
        }

        /// <summary>
        /// Gets the string from the table
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="colname"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public string GetStringValueFrmColumn(DataTable dt, string colname, int rowIndex)
        {
            string val = "";
            val = dt.Rows[rowIndex][colname].ToString();
            return val;
        }

        /// <summary>
        /// Gets the Int 64 from the table
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="colname"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public Int64 GetIntValueFrmColumn(DataTable dt, string colname, int rowIndex)
        {
            Int64 val = 0;
            if (ValidateHelper.IsNumeric(dt.Rows[rowIndex][colname].ToString()))
            {
                val = int.Parse(dt.Rows[rowIndex][colname].ToString());
            }
            return val;
        }

        /// <summary>
        /// Gets the Decimal from the table
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="colname"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public Decimal GetDecimalValueFrmColumn(DataTable dt, string colname, int rowIndex)
        {
            Decimal val = 0;
            if (ValidateHelper.IsDecimal(dt.Rows[rowIndex][colname].ToString()))
            {
                val = decimal.Parse(dt.Rows[rowIndex][colname].ToString());
            }
            return val;
        }

        /// <summary>
        /// Gets the DateTime from the table
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="colname"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public DateTime GetDateValueFrmColumn(DataTable dt, string colname, int rowIndex)
        {
            DateTime val = new DateTime();
            if (ValidateHelper.IsDate(dt.Rows[rowIndex][colname].ToString()))
            {
                val = DateTime.Parse(dt.Rows[rowIndex][colname].ToString());
            }
            return val;
        }

        /// <summary>
        /// Gets the Bool from the table
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="colname"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public Boolean GetBoolValueFrmColumn(DataTable dt, string colname, int rowIndex)
        {
            Boolean val = false;
            if (ValidateHelper.IsBool(dt.Rows[rowIndex][colname].ToString()))
            {
                if (dt.Rows[rowIndex][colname].ToString() == "1")
                {
                    val = true;
                }
                else if (dt.Rows[rowIndex][colname].ToString() == "0")
                {
                    val = false;
                }
            }
            return val;
        }
    }
}
