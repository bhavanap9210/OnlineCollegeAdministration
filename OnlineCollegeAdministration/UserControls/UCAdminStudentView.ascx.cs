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
    public partial class UCAdminStudentView : CustomUserControl
    {
        public event EventHandler evtStudentSelected;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Loads the user control
        /// </summary>
        public override void LoadUserControlData()
        {
            ResetSearch();
            ClearStudentSelection();
            BindStudents();
        }

        /// <summary>
        /// Clears the selection in the Grid view
        /// </summary>
        public void ClearStudentSelection()
        {
            foreach (GridViewRow item in gvStudent.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    RadioButton rd = (RadioButton)item.FindControl("rdStudent");
                    rd.Checked = false;
                }
            }
        }

        /// <summary>
        /// Resets the Search fields
        /// </summary>
        private void ResetSearch()
        {
            txtStudentFNSearch.Text = "";
            txtStudentIDSearch.Text = "";
            txtStudentLNSearch.Text = "";
            ddlActive.ClearSelection();
        }

        /// <summary>
        /// Binds the grid view with the student list
        /// </summary>
        private void BindStudents()
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("student_id");
            //dt.Columns.Add("last_name_txt");
            //dt.Columns.Add("first_name_txt");

            //DataRow dr = dt.NewRow();
            //dr["student_id"] = "101";
            //dr["last_name_txt"] = "Sam";
            //dr["first_name_txt"] = "Hello";

            //dt.Rows.Add(dr);

            IDataReader dr = new StudentDAL().GetStudentList(txtStudentIDSearch.Text.Trim(), txtStudentLNSearch.Text.Trim(), txtStudentFNSearch.Text.Trim(), ddlActive.SelectedValue);

            dt.Load(dr);

            if (!dr.IsClosed)
            {
                dr.Close();
            }
            gvStudent.DataSource = dt;
            gvStudent.DataBind();
        }

        protected void rdStudent_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow gvRow = ((RadioButton)(sender)).NamingContainer as GridViewRow;
            int rowIndex = gvRow.RowIndex;
            string studentID = gvStudent.DataKeys[rowIndex].Values["student_id"].ToString();
            CustomEventArgs e1 = new CustomEventArgs();
            e1.ID = studentID;
            foreach (GridViewRow item in gvStudent.Rows)
            {
                if (item.RowIndex != rowIndex)
                {
                    if (item.RowType == DataControlRowType.DataRow)
                    {
                        RadioButton rd = (RadioButton)item.FindControl("rdStudent");
                        rd.Checked = false;
                    }
                }
            }
            OnevtStudentSelected(sender, e1);
        }


        protected void OnevtStudentSelected(object sender, CustomEventArgs e)
        {
            if (evtStudentSelected != null)
            {
                evtStudentSelected(sender, e);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvStudent.PageIndex = 0;
            BindStudents();
        }

        protected void gvStudent_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvStudent.PageIndex = e.NewPageIndex;
            BindStudents();
        }

    }
}