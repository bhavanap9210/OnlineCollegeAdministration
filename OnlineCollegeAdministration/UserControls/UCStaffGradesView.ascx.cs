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
    public partial class UCStaffGradesView : CustomUserControl
    {
        public event EventHandler evtStudentSelected;


        /// <summary>
        /// Get or Set StaffId
        /// </summary>
        public string StaffId
        {
            get
            {
                if (ViewState["staff_id"] != null)
                {
                    return ViewState["staff_id"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["staff_id"] = value;
            }
        }
        /// <summary>
        /// Get or Set StaffIdText
        /// </summary>
        public string StaffIdText
        {
            get
            {
                if (ViewState["staff_id_txt"] != null)
                {
                    return ViewState["staff_id_txt"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["staff_id_txt"] = value;
            }
        }
        /// <summary>
        /// Loads the user control
        /// </summary>
        /// 
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Loads the user control
        /// </summary>
        public override void LoadUserControlData()
        {
            LoadDropDowns();
            ResetSearch();
            ClearStudentSelection();
            BindStudents();
        }

        /// <summary>
        /// Loads the Dropdowns
        /// </summary>
        private void LoadDropDowns()
        {
            CommonDAL _commonDAL = new CommonDAL();
            DataTable dt = new DataTable();
            IDataReader rdr = null;
            rdr = new StaffCourseDAL().GetStaffCourseList(StaffId,"", "","-1","-1","-1","","","-1");
            if (rdr != null)
            {
                dt = new DataTable();
                dt.Load(rdr);
                ddlCourses.DataSource = dt;
                ddlCourses.DataTextField = "course_name";
                ddlCourses.DataValueField = "course_duration_id";
                ddlCourses.DataBind();
                if (!rdr.IsClosed)
                {
                    rdr.Close();
                }
            }
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

            IDataReader dr = new StaffGradeDAL().GetStaffStudentGradeList(StaffId, txtStudentIDSearch.Text.Trim(), txtStudentLNSearch.Text.Trim(), txtStudentFNSearch.Text.Trim(), ddlCourses.SelectedValue, ddlActive.SelectedValue);
            if (dr != null)
            {
                dt.Load(dr);

                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            gvStudent.DataSource = dt;
            gvStudent.DataBind();
        }

        protected void rdStudent_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow gvRow = ((RadioButton)(sender)).NamingContainer as GridViewRow;
            int rowIndex = gvRow.RowIndex;
            string studentID = gvStudent.DataKeys[rowIndex].Values["student_id"].ToString();
            string staffCourseID = gvStudent.DataKeys[rowIndex].Values["staff_course_id"].ToString();
            string coursedurationID= gvStudent.DataKeys[rowIndex].Values["course_duration_id"].ToString();
            CustomEventArgs e1 = new CustomEventArgs();
            e1.ID = studentID;
            e1.AddlId= StaffId;
            e1.AddlId0 = staffCourseID;
            e1.AddlId1 = coursedurationID;
            
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