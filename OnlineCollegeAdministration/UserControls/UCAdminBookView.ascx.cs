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
    public partial class UCAdminBookView : CustomUserControl
    {
        public event EventHandler evtBookSelected;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Loads the user control
        /// </summary>
        public override void LoadUserControlData()
        {
            ResetSearch();
            ClearBookSelection();
            BindBooks();
        }

        /// <summary>
        /// Clears the selection in the Grid view
        /// </summary>
        public void ClearBookSelection()
        {
            foreach (GridViewRow item in gvBook.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    RadioButton rd = (RadioButton)item.FindControl("rdBook");
                    rd.Checked = false;
                }
            }
        }

        /// <summary>
        /// Resets the Search fields
        /// </summary>
        private void ResetSearch()
        {

            txtBookIDSearch.Text = "";
            txtBookNameSearch.Text = "";
            txtBookAuthorNameSearch.Text = "";
        }

        /// <summary>
        /// Binds the grid view with the Book list
        /// </summary>
        private void BindBooks()
        {
            DataTable dt = new DataTable();

            IDataReader dr = new BookDAL().GetBookList(txtBookIDSearch.Text.Trim(), txtBookNameSearch.Text.Trim(),txtBookAuthorNameSearch.Text.Trim());

            dt.Load(dr);

            if (!dr.IsClosed)
            {
                dr.Close();
            }
            gvBook.DataSource = dt;
            gvBook.DataBind();
        }

        protected void rdBook_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow gvRow = ((RadioButton)(sender)).NamingContainer as GridViewRow;
            int rowIndex = gvRow.RowIndex;
            string BookID = gvBook.DataKeys[rowIndex].Values["book_id"].ToString();
            CustomEventArgs e1 = new CustomEventArgs();
            e1.ID = BookID;
            foreach (GridViewRow item in gvBook.Rows)
            {
                if (item.RowIndex != rowIndex)
                {
                    if (item.RowType == DataControlRowType.DataRow)
                    {
                        RadioButton rd = (RadioButton)item.FindControl("rdBook");
                        rd.Checked = false;
                    }
                }
            }
            OnevtBookSelected(sender, e1);
        }


        protected void OnevtBookSelected(object sender, CustomEventArgs e)
        {
            if (evtBookSelected != null)
            {
                evtBookSelected(sender, e);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvBook.PageIndex = 0;
            BindBooks();
        }

        protected void gvBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBook.PageIndex = e.NewPageIndex;
            BindBooks();
        }
    }
}