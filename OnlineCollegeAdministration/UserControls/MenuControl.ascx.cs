using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using Helper;
using System.Data;

namespace OCA.UserControls
{
    public partial class MenuControl : CustomUserControl
    {

        /// <summary>
        /// Gets or Sets the menus in the DataTable
        /// </summary>
        private DataTable MenusTb
        {
            get
            {
                if (ViewState["menu_tb"] != null)
                {
                    return (DataTable)ViewState["menu_tb"];
                }
                else
                    return null;
            }
            set
            {
                ViewState["menu_tb"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetMenu();
            }
            CommonHelper _commonHelper = new CommonHelper();

            lblMenuName.Text = _commonHelper.GetValueFromCache(_commonHelper.GetUserId() + "menuName");
        }

        /// <summary>
        /// Sets the Menu based on the user role
        /// </summary>
        private void SetMenu()
        {

            //Gets the menu table based on the user
            if (HttpContext.Current.User != null)
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {

                    RBSMenu.Items.Clear();

                    CommonHelper cm = new CommonHelper();
                    DataTable dt = cm.GetMenus();
                    MenusTb = dt.Copy();
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            var grouped = from table in dt.AsEnumerable()
                                          group table by new { menu_catg = table["menu_catg"] } into groupby
                                          select new
                                          {
                                              Value = groupby.Key,
                                              ColumnValues = groupby
                                          };


                            MenuItem categoryItem;
                            MenuItem childItem;

                            foreach (var key in grouped)
                            {
                                categoryItem = new MenuItem();
                                categoryItem.Text = key.Value.menu_catg.ToString();
                                categoryItem.Selectable = false;

                                foreach (var columnValue in key.ColumnValues)
                                {
                                    childItem = new MenuItem();
                                    childItem.Text = columnValue["menu_name"].ToString();
                                    categoryItem.ChildItems.Add(childItem);
                                }

                                RBSMenu.Items.Add(categoryItem);
                            }
                        }

                    }
                }
            }

        }

        protected void RBSMenu_MenuItemClick(object sender, MenuEventArgs e)
        {
            string menuName = e.Item.Text;
            CommonHelper _commonHelper = new CommonHelper();
            _commonHelper.SetValueCache(_commonHelper.GetUserId() + "menuName", menuName);
            DataTable dtTemp = MenusTb.Copy();
            DataRow[] dr = dtTemp.Select("menu_name = '" + menuName + "'");
            menuName = dr[0]["menu_catg"].ToString() + "   -- " + menuName;
            _commonHelper.SetValueCache(_commonHelper.GetUserId() + "menuName", menuName);
            if (dr != null)
            {
                //Response.Redirect("http://localhost:50369" + dr[0]["page_url"].ToString());
                Response.Redirect(Request.ApplicationPath + dr[0]["page_url"].ToString());
            }
        }
    }
}