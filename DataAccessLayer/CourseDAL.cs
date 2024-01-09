using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace DataAccessLayer
{
    public class CourseDAL
    {
        /// <summary>
        /// Gets the CourseList
        /// </summary>
        /// <param name="courseID"></param>
        /// <param name="courseName"></param>
        /// <returns>IDataReader</returns>
        public IDataReader GetCourseList(string courseID, string courseName)
        {
            IDataReader rdr = null;
            string Query = "PROC_COURSE_LIST";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_course_id", courseID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_name", courseName, 100, 1, SqlDbType.NVarChar);
            
            parameter = objdal.parameterCollection;


            try
            {
                rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
            }
            catch (Exception ex)
            {
            }

            return rdr;

        }

        /// <summary>
        /// Gets the Course Record
        /// </summary>
        /// <param name="courseID"></param>
        /// <returns>IDataReader</returns>
        public IDataReader GetCourseRecord(string courseID)
        {
            IDataReader rdr = null;
            string Query = "PROC_COURSE_RECORD";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_course_id", courseID, 50, 1, SqlDbType.NVarChar);

            parameter = objdal.parameterCollection;

            try
            {
                rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
            }
            catch (Exception ex)
            {
            }

            return rdr;

        }

        /// <summary>
        /// Insert Course Record
        /// </summary>        
        /// <param name="courseName"></param>
        /// <param name="courseDesc"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string InsertCourseRecord( string courseName, string courseDesc, out string messageCode, out string messageText)
        {

            string Query = "PROC_INSERT_COURSE_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;


            objdal.CreateInternalParameter<string>("@pin_course_name", courseName, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_desc", courseDesc, 50, 1, SqlDbType.NVarChar);

            paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
            paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);

            parameter = objdal.parameterCollection;

            try
            {
                objdal.ExecuteNonQuery(CommandType.StoredProcedure, Query, parameter);
                messageCode = paramMessageCode.SqlValue.ToString();
                messageText = paramMessageText.SqlValue.ToString();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

        /// <summary>
        /// Update Course Record
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="courseName"></param>
        /// <param name="courseDesc"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string UpdateCourseRecord(string courseId, string courseName, string courseDesc, out string messageCode, out string messageText)
        {

            string Query = "PROC_UPDATE_COURSE_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_course_id", courseId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_name", courseName, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_desc", courseDesc, 50, 1, SqlDbType.NVarChar);

            paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
            paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);

            parameter = objdal.parameterCollection;

            try
            {
                objdal.ExecuteNonQuery(CommandType.StoredProcedure, Query, parameter);
                messageCode = paramMessageCode.SqlValue.ToString();
                messageText = paramMessageText.SqlValue.ToString();

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "";
        }

    }
}
