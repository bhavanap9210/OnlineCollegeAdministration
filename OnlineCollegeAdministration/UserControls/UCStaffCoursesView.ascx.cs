﻿using DataAccessLayer;
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
    public partial class UCStaffCoursesView : CustomUserControl
    {
        public event EventHandler evtCourseSelected;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

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
        public override void LoadUserControlData()
        {
            ResetSearch();
            ClearStaffSelection();
            if (string.IsNullOrEmpty(StaffId))
            {
                btnSearch.Enabled = false;
                return;
            }
            LoadDropDowns();
            BindCourses();
        }

        /// <summary>
        /// Loads the dropdowns
        /// </summary>
        private void LoadDropDowns()
        {
            CommonDAL _commonDAL = new CommonDAL();
            DataTable dt = new DataTable();
            IDataReader rdr = null;
            //Load Year dropdown
            rdr = _commonDAL.GetCommonDropDowns("Y", "-1");
            if (rdr != null)
            {
                dt.Load(rdr);
                ddlYearSearch.DataSource = dt;
                ddlYearSearch.DataValueField = "year_id";
                ddlYearSearch.DataTextField = "year_nbr";
                ddlYearSearch.DataBind();
            }
            if (!rdr.IsClosed)
            {
                rdr.Close();
            }
            //Load Month dropdown
            rdr = _commonDAL.GetCommonDropDowns("M", "-1");
            if (rdr != null)
            {
                dt = new DataTable();
                dt.Load(rdr);
                ddlMonthSearch.DataSource = dt;
                ddlMonthSearch.DataValueField = "month_nbr";
                ddlMonthSearch.DataTextField = "month_name";
                ddlMonthSearch.DataBind();
            }
            if (!rdr.IsClosed)
            {
                rdr.Close();
            }
            //Load Day dropdown
            rdr = _commonDAL.GetCommonDropDowns("D", "-1");
            if (rdr != null)
            {
                dt = new DataTable();
                dt.Load(rdr);
                ddlDaySearch.DataSource = dt;
                ddlDaySearch.DataValueField = "day_id";
                ddlDaySearch.DataTextField = "day_name";
                ddlDaySearch.DataBind();
            }
            if (!rdr.IsClosed)
            {
                rdr.Close();
            }
        }

        /// <summary>
        /// Clears the selection in the Grid view
        /// </summary>
        public void ClearStaffSelection()
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
            txtCourseStartTimeSearch.Text = "";
            txtCourseEndTimeSearch.Text = "";
            txtCourseIDSearch.Text = "";
            txtCourseNameSearch.Text = "";
            ddlActive.ClearSelection();
            ddlMonthSearch.ClearSelection();
            ddlYearSearch.ClearSelection();
            ddlDaySearch.ClearSelection();
        }

        /// <summary>
        /// Binds the grid view with the Course list
        /// </summary>
        private void BindCourses()
        {
            DataTable dt = new DataTable();

            IDataReader dr = new StaffCourseDAL().GetStaffCourseList(StaffId, txtCourseIDSearch.Text.Trim(), txtCourseNameSearch.Text.Trim(),ddlYearSearch.SelectedValue,ddlMonthSearch.SelectedValue,ddlDaySearch.SelectedValue, txtCourseStartTimeSearch.Text.Trim(),txtCourseEndTimeSearch.Text.Trim(), ddlActive.SelectedValue);
            if (dr != null)
            {
                dt.Load(dr);

                if (!dr.IsClosed)
                {
                    dr.Close();
                }
            }
            gvCourse.DataSource = dt;
            gvCourse.DataBind();
        }

        protected void rdCourse_CheckedChanged(object sender, EventArgs e)
        {
            GridViewRow gvRow = ((RadioButton)(sender)).NamingContainer as GridViewRow;
            int rowIndex = gvRow.RowIndex;
            string courseDurationid = gvCourse.DataKeys[rowIndex].Values["course_duration_id"].ToString();
            CustomEventArgs e1 = new CustomEventArgs();
            e1.ID = courseDurationid;
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