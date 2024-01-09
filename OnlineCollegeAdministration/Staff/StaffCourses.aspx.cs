using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace OCA.Staff
{
    public partial class StaffCourses : System.Web.UI.Page
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDropDowns();
                LoadControls();
            }
        }


        protected void ucStaffCourseAddEdit_evtStaffCourseEdited(object sender, EventArgs e)
        {
            ucStaffCourseView.LoadUserControlData();
        }

        protected void ucStaffCourseView_evtStaffCourseSelected(object sender, EventArgs e)
        {
            if (e != null)
            {
                CustomEventArgs e1 = (CustomEventArgs)e;
                ucStaffCourseAddEdit.CourseDurationId = e1.ID;
                ucStaffCourseAddEdit.LoadUserControlData();
            }
        }

        protected void ddlStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadControls();
        }

        #region Private Methods
        

        /// <summary>
        /// Loads the user controls
        /// </summary>
        private void LoadControls()
        {
            string _staffID = ddlStaff.SelectedValue;
            string _staffIDText = ddlStaff.SelectedItem.Text ;
            CommonHelper _commonHelper = new CommonHelper();
           
            trddlStaff.Visible = false;
            trCourseCtrls.Visible = false;
            if (_commonHelper.IsinRole("1")) //Admin
            {
                trddlStaff.Visible = true;
                if (!string.IsNullOrEmpty(_staffID))
                {
                    trCourseCtrls.Visible = true;
                }
            }
            else if (_commonHelper.IsinRole("3")) //Staff
            {
                _staffID = _commonHelper.GetUserId();
                _staffIDText = _commonHelper.GetUserIdText();
                trCourseCtrls.Visible = true;
            }
            ucStaffCourseView.StaffId = _staffID;
            ucStaffCourseAddEdit.StaffId = _staffID;

            ucStaffCourseView.StaffIdText = _staffIDText;
            ucStaffCourseAddEdit.StaffIdText = _staffIDText;

            ucStaffCourseView.LoadUserControlData();
            ucStaffCourseAddEdit.LoadUserControlData();
        }

        /// <summary>
        /// Loads the Dropdowns
        /// </summary>
        private void LoadDropDowns()
        {
            ddlStaff.DataSource = new StaffDAL().GetStaffList("", "", "", "-1");
            ddlStaff.DataTextField = "staff_name";
            ddlStaff.DataValueField = "staff_id";
            ddlStaff.DataBind();

        }
        #endregion
    }
}