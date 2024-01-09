using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OCA
{
    /// <summary>
    /// Summary description for CustomImageHandler
    /// </summary>
    public class CustomImageHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            
            string id = context.Request.QueryString["id"];
            string type = context.Request.QueryString["type"];
            string messageCode = "";
            string messageText = "";

            byte[] imagbyte = null;
            if (type == "ST")//Student
            {
                StudentDAL _studentDAL = new StudentDAL();

                IDataReader rdr = _studentDAL.RetrieveUploadStudentImage(id, out messageCode, out messageText);
                if (rdr != null)
                {
                    DataTable dt = new DataTable();

                    dt.Load(rdr);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["student_img"] != null && dt.Rows[0]["student_img"] != DBNull.Value)
                        {
                            imagbyte = (byte[])dt.Rows[0]["student_img"];
                            context.Response.BinaryWrite(imagbyte);

                        }
                    }
                }
            }
            else if (type == "S")//Staff
            {
                StaffDAL _staffDAL = new StaffDAL();

                IDataReader rdr = _staffDAL.RetrieveUploadStaffImage(id, out messageCode, out messageText);
                if (rdr != null)
                {
                    DataTable dt = new DataTable();
                    dt.Load(rdr);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["staff_img"] != null && dt.Rows[0]["staff_img"] != DBNull.Value)
                        {
                            imagbyte = (byte[])dt.Rows[0]["staff_img"];
                            context.Response.BinaryWrite(imagbyte);

                        }
                    }
                }
            }
            
            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}