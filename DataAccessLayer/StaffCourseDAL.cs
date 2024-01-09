using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace DataAccessLayer
{
    public class StaffCourseDAL
    {
        /// <summary>
        ///  Gets the CourseList
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="courseIDText"></param>
        /// <param name="courseName"></param>
        /// <param name="yearNbr"></param>
        /// <param name="monthNbr"></param>
        /// <param name="dayNbr"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="activeInd"></param>
        /// <returns>IDataReader</returns>
        public IDataReader GetStaffCourseList(string staffId, string courseIDText, string courseName, string yearNbr, string monthNbr, string dayNbr, string startTime, string endTime, string activeInd)
        {
            IDataReader rdr = null;
            string Query = "PROC_STAFF_COURSE_LIST";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_staff_id", staffId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_id_txt", courseIDText, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_name", courseName, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_year_nbr", yearNbr, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_month_nbr", monthNbr, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_day_id", dayNbr, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_start_time", startTime, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_end_time", endTime, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_active_ind", activeInd, 100, 1, SqlDbType.NVarChar);

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
        /// <param name="staffId"></param>
        /// <param name="courseDurationID"></param>
        /// <param name="optionCode">By id or Name -- I,N</param>
        /// <returns>IDataReader</returns>
        public IDataReader GetStaffCourseRecord(string staffId, string courseDurationID, string optionCode)
        {
            IDataReader rdr = null;
            string Query = "PROC_STAFF_COURSE_RECORD";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_staff_id", staffId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_duration_id", courseDurationID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_option_cd", optionCode, 50, 1, SqlDbType.NVarChar);

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
        /// Insert the Staff Course record
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="courseDurationDesc"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="courseId"></param>
        /// <param name="dayNbr"></param>
        /// <param name="yearNbr"></param>
        /// <param name="monthNbr"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string InsertStaffCourseRecord(string staffID, string courseDurationDesc, string startTime, string endTime, string courseId, string dayNbr, string yearNbr, string monthNbr, out string messageCode, out string messageText)
        {
            string Query = "PROC_INSERT_STAFF_COURSE_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_staff_id", staffID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_duration_desc", courseDurationDesc, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_start_time", startTime, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_end_time", endTime, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_id", courseId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_year_nbr", yearNbr, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_month_nbr", monthNbr, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_day_id", dayNbr, 50, 1, SqlDbType.NVarChar);

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
        /// Updates the Staff Course record
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="courseDurationId"></param>
        /// <param name="courseDurationDesc"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="courseId"></param>
        /// <param name="dayNbr"></param>
        /// <param name="yearNbr"></param>
        /// <param name="monthNbr"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string UpdateStaffCourseRecord(string staffID, string courseDurationId, string courseDurationDesc, string startTime, string endTime, string courseId, string dayNbr, string yearNbr, string monthNbr, out string messageCode, out string messageText)
        {
            string Query = "PROC_UPDATE_STAFF_COURSE_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;

            objdal.CreateInternalParameter<string>("@pin_course_duration_id", courseDurationId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_id", staffID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_duration_desc", courseDurationDesc, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_start_time", startTime, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_end_time", endTime, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_id", courseId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_year_nbr", yearNbr, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_month_nbr", monthNbr, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_day_id", dayNbr, 50, 1, SqlDbType.NVarChar);

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
        /// Activate or Inactivate Staff Course Record
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="courseDurationID"></param>        
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string ActivateInactivateStaffCourseRecord(string staffId, string courseDurationID, out string messageCode, out string messageText)
        {

            string Query = "PROC_ACTIVATE_INACTIVATE_STAFF_COURSE_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_staff_id", staffId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_duration_id", courseDurationID, 50, 1, SqlDbType.NVarChar);
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
