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
    public partial class UCAdminBookAddEdit : CustomUserControl
    {
        public event EventHandler evtBookEdited;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OnevtBookEdited(object sender, CustomEventArgs e)
        {
            if (evtBookEdited != null)
            {
                evtBookEdited(sender, e);
            }
        }


        /// <summary>
        /// Get or Set BookID
        /// </summary>
        public string BookID
        {
            get
            {
                if (ViewState["Book_id"] != null)
                {
                    return ViewState["Book_id"].ToString();
                }
                else
                {
                    return "";
                }
            }
            set
            {
                ViewState["Book_id"] = value;
            }
        }


        /// <summary>
        /// Get or Set Mode
        /// </summary>
        public string Mode
        {
            get
            {
                if (ViewState["Mode"] != null)
                {
                    return ViewState["Mode"].ToString();
                }
                else
                {
                    return "E";//Edit MOde
                }
            }
            set
            {
                ViewState["Mode"] = value;
            }
        }

        /// <summary>
        /// Loads the user control
        /// </summary>
        public override void LoadUserControlData()
        {
            lblMsg.Text = "";
            ClearControl();            
            EnableDisableButtons(true);
            if (string.IsNullOrEmpty(BookID))
            {
                btnAdd.Enabled = true;
                btEdit.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
            BindData();
            EnableDisableControls(false);
        }

        /// <summary>
        /// Clears the control
        /// </summary>
        private void ClearControl()
        {
            txtBookName.Text = "";
            txtBookAuthorName.Text = "";
            lblBookID.Text = "";
            gvCourse.DataSource = new DataTable();
            gvCourse.DataBind();
        }

        /// <summary>
        /// Enable or Disable the controls
        /// </summary>
        /// <param name="isEnabled"></param>
        private void EnableDisableControls(bool isEnabled)
        {
            txtBookName.Enabled = isEnabled;
            txtBookAuthorName.Enabled = isEnabled;
            foreach (GridViewRow item in gvCourse.Rows)
            {
                ((CheckBox)item.FindControl("chkCourse")).Enabled = isEnabled;
            }
        }

        /// <summary>
        /// Enable or Disable the buttons
        /// </summary>
        private void EnableDisableButtons(bool isEnabled)
        {
            btnAdd.Enabled = isEnabled;
            btEdit.Enabled = isEnabled;
            btnSave.Enabled = !isEnabled;
            btnCancel.Enabled = !isEnabled;
        }


        /// <summary>
        /// Binds the data to the control
        /// </summary>
        private void BindData()
        {
            DataTable dt = new DataTable();
            IDataReader dr = new BookDAL().GetBookRecord(BookID);
            if (dr != null)
            {
                CommonHelper cmnHelper = new CommonHelper();

                if (dr.Read())
                {
                    lblBookID.Text = dr["book_id"].ToString();
                    txtBookName.Text = dr["book_name"].ToString();
                    txtBookAuthorName.Text = dr["book_author_name"].ToString();
                }

                if (!dr.IsClosed)
                {
                    if (dr.NextResult())
                    {
                        dt.Load(dr);
                        gvCourse.DataSource = dt;
                        gvCourse.DataBind();
                    }
                }
            }
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            Mode = "E";
            EnableDisableControls(true);
            EnableDisableButtons(false);

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            CustomEventArgs ec = new CustomEventArgs();
            ec.ID = this.BookID;

            string messageCode = "";
            string messageText = "";
            string output = "";
            DataTable dtTemp = GetTempTable();

            foreach (GridViewRow item in gvCourse.Rows)
            {
                DataRow dr = dtTemp.NewRow();
                string ind = gvCourse.DataKeys[item.RowIndex].Values["selected_ind"].ToString();
                CheckBox chk = new CheckBox();
                if (ind == "1")
                {
                    chk.Checked = true;
                }
                else
                    chk.Checked = false;

                if (((CheckBox)item.FindControl("chkCourse")).Checked != chk.Checked)
                {
                    if (Mode == "A")
                    {
                        dr["book_course_id"] = 0;
                        dr["book_id"] = "";
                    }
                    else if (Mode == "E")
                    {
                        dr["book_course_id"] = 0;
                        if (gvCourse.DataKeys[item.RowIndex].Values["book_course_id"] != null)
                        {
                            if(ValidateHelper.IsNumeric(gvCourse.DataKeys[item.RowIndex].Values["book_course_id"].ToString()))
                            {
                            dr["book_course_id"] = Int32.Parse(gvCourse.DataKeys[item.RowIndex].Values["book_course_id"].ToString());
                            }
                        }
                        
                        dr["book_id"] = this.BookID;
                    }

                    dr["course_id"] = gvCourse.DataKeys[item.RowIndex].Values["course_id"].ToString();

                    dtTemp.Rows.Add(dr);
                }
            }
            output = ValidateFields();

            if (string.IsNullOrEmpty(output))
            {
                if (Mode == "A")
                {
                    output = new BookDAL().InsertBookRecord(txtBookName.Text.Trim(), txtBookAuthorName.Text.Trim(), dtTemp, out messageCode, out messageText);
                }
                else if (Mode == "E")
                {
                    output = new BookDAL().UpdateBookRecord(BookID, txtBookName.Text.Trim(), txtBookAuthorName.Text.Trim(), dtTemp, out messageCode, out messageText);
                }
            }

            if (string.IsNullOrEmpty(output))
            {
                if (messageCode == "101")
                {
                    lblMsg.Text = messageText;
                    lblMsg.CssClass = "successLabelClass";
                    OnevtBookEdited(sender, ec);
                }
                else
                {
                    lblMsg.Text = messageText;
                    lblMsg.CssClass = "errorLabelClass";
                    return;
                }
            }
            else
            {
                lblMsg.Text = output;
                lblMsg.CssClass = "errorLabelClass";
                return;
            }

            EnableDisableButtons(true);
            EnableDisableControls(false);
            BindData();

        }

        /// <summary>
        /// Validate the fields
        /// </summary>
        /// <returns>string</returns>
        private string ValidateFields()
        {
            string message = "";
            if (string.IsNullOrEmpty(txtBookName.Text.Trim())
                || string.IsNullOrEmpty(txtBookAuthorName.Text.Trim())
                )
            {
                message = "Please enter mandatory fields marked with (*)";
            }

            return message;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
            BookID = string.Empty;
            OnevtBookEdited(sender, null);
            EnableDisableControls(false);
            EnableDisableButtons(true);
            if (string.IsNullOrEmpty(BookID))
            {
                btnAdd.Enabled = true;
                btEdit.Enabled = false;
                btnSave.Enabled = false;
                btnCancel.Enabled = false;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Mode = "A";
            ClearControl();
            EnableDisableControls(true);
            EnableDisableButtons(false);
            BindCourses();
        }


        /// <summary>
        /// Binds the grid view with the Course list
        /// </summary>
        private void BindCourses()
        {
            DataTable dt = new DataTable();

            IDataReader dr = new CourseDAL().GetCourseList("", "");

            dt.Load(dr);

            if (!dr.IsClosed)
            {
                dr.Close();
            }
            gvCourse.DataSource = dt;
            gvCourse.DataBind();
        }

        /// <summary>
        /// Gets the temp table
        /// </summary>
        /// <returns></returns>
        private DataTable GetTempTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("book_course_id",Type.GetType("System.Int32"));
            dt.Columns.Add("book_id");
            dt.Columns.Add("course_id");
            return dt;
        }
         
        protected void gvCourse_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chk = (CheckBox)e.Row.FindControl("chkCourse");
                string ind = gvCourse.DataKeys[e.Row.RowIndex].Values["selected_ind"].ToString();
                if (ind == "1")
                {
                    chk.Checked = true;
                }
                else
                    chk.Checked = false;
            }
        }
    }
}