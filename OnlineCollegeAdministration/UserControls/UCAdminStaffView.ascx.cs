using DataAccessLayer;
using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OCA.UserControls
{
    public partial class UCAdminStaffView : CustomUserControl
    {
        public event EventHandler evtStaffSelected;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Loads the user control
        /// </summary>
        public override void LoadUserControlData()
        {
            ResetSearch();
            ClearStaffSelection();
            BindStaffs();
        }

        /// <summary>
        /// Clears the selection in the Grid view
        /// </summary>
        public void ClearStaffSelection()
        {
            foreach (GridViewRow  item in gvStaff.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    RadioButton rd = (RadioButton)item.FindControl("rdStaff");
                    rd.Checked = false;
                }
            }
        }

        /// <summary>
        /// Resets the Search fields
        /// </summary>
        private void ResetSearch()
        {
            txtStaffFNSearch.Text = "";
            txtStaffIDSearch.Text = "";
            txtStaffLNSearch.Text = "";
            ddlActive.ClearSelection();
        }

        /// <summary>
        /// Binds the grid view with the Staff list
        /// </summary>
        private void BindStaffs()
        {
            DataTable dt = new DataTable();

            IDataReader dr = new StaffDAL().GetStaffList(txtStaffIDSearch.Text.Trim(), txtStaffLNSearch.Text.Trim(), txtStaffFNSearch.Text.Trim(), ddlActive.SelectedValue);
            
                dt.Load(dr);
            
            if (!dr.IsClosed)
            {
                dr.Close();
            }
            gvStaff.DataSource = dt;
            gvStaff.DataBind();
        }

        protected void rdStaff_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow gvRow = ((RadioButton)(sender)).NamingContainer as GridViewRow;
            int rowIndex = gvRow.RowIndex;
            string StaffID = gvStaff.DataKeys[rowIndex].Values["staff_id"].ToString();
            CustomEventArgs e1 = new CustomEventArgs();
            e1.ID = StaffID;
            foreach (GridViewRow item in gvStaff.Rows)
            {
                if (item.RowIndex != rowIndex)
                {
                    if (item.RowType == DataControlRowType.DataRow)
                    {
                        RadioButton rd = (RadioButton)item.FindControl("rdStaff");
                        rd.Checked = false;
                    }
                }
            }
            OnevtStaffSelected(sender, e1);
        }


        protected void OnevtStaffSelected(object sender, CustomEventArgs e)
        {
            if (evtStaffSelected != null)
            {
                evtStaffSelected(sender, e);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvStaff.PageIndex = 0;
            BindStaffs();
        }


        protected void gvStaff_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStaff.PageIndex = e.NewPageIndex;
            BindStaffs();
        }
    }
}