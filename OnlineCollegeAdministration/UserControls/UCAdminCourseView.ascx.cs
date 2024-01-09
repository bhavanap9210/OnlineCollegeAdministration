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
    public partial class UCAdminCourseView : CustomUserControl
    {
        public event EventHandler evtCourseSelected;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Loads the user control
        /// </summary>
        public override void LoadUserControlData()
        {
            ResetSearch();
            ClearCourseSelection();
            BindCourses();
        }

        /// <summary>
        /// Clears the selection in the Grid view
        /// </summary>
        public void ClearCourseSelection()
        {
            foreach (GridViewRow item in gvCourse.Rows)
            {
                if (item.RowType == DataControlRowType.DataRow)
                {
                    RadioButton rd = (RadioButton)item.FindControl("rdCourse");
                    rd.Checked = false;
                }
            }
        }

        /// <summary>
        /// Resets the Search fields
        /// </summary>
        private void ResetSearch()
        {
            
            txtCourseIDSearch.Text = "";
            txtCourseNameSearch.Text = "";
            
        }

        /// <summary>
        /// Binds the grid view with the Course list
        /// </summary>
        private void BindCourses()
        {
            DataTable dt = new DataTable();
            
            IDataReader dr = new CourseDAL().GetCourseList(txtCourseIDSearch.Text.Trim(), txtCourseNameSearch.Text.Trim());

            dt.Load(dr);

            if (!dr.IsClosed)
            {
                dr.Close();
            }
            gvCourse.DataSource = dt;
            gvCourse.DataBind();
        }

        protected void rdCourse_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow gvRow = ((RadioButton)(sender)).NamingContainer as GridViewRow;
            int rowIndex = gvRow.RowIndex;
            string CourseID = gvCourse.DataKeys[rowIndex].Values["course_id"].ToString();
            CustomEventArgs e1 = new CustomEventArgs();
            e1.ID = CourseID;
            foreach (GridViewRow item in gvCourse.Rows)
            {
                if (item.RowIndex != rowIndex)
                {
                    if (item.RowType == DataControlRowType.DataRow)
                    {
                        RadioButton rd = (RadioButton)item.FindControl("rdCourse");
                        rd.Checked = false;
                    }
                }
            }
            OnevtCourseSelected(sender, e1);
        }


        protected void OnevtCourseSelected(object sender, CustomEventArgs e)
        {
            if (evtCourseSelected != null)
            {
                evtCourseSelected(sender, e);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvCourse.PageIndex = 0;
            BindCourses();
        }

        protected void gvCourse_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCourse.PageIndex = e.NewPageIndex;
            BindCourses();
        }
    }
}