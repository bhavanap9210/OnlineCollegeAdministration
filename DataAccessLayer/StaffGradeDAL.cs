using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace DataAccessLayer
{
   public class StaffGradeDAL
    {
        /// <summary>
        /// Gets the Student Grade List by Staff
        /// </summary>
        /// <param name="studID"></param>
        /// <param name="studLastName"></param>
        /// <param name="studFirstName"></param>
        /// <param name="courseDurationId"></param>
        /// <param name="activeInd"></param>
        /// <returns>IDataReader</returns>
        public IDataReader GetStaffStudentGradeList(string staffID,string studID, string studLastName, string studFirstName,string courseDurationId, string activeInd)
        {
            IDataReader rdr = null;
            string Query = "PROC_STAFF_STUDENT_GRADE_LIST";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_staff_id", staffID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_id", studID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_last_name", studLastName, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_first_name", studFirstName, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_duration_id", courseDurationId, 100, 1, SqlDbType.NVarChar);
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
        /// Gets the Student Grade Record
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="courseDurationID"></param>
        /// <param name="studentID"></param>
        /// <param name="optionCode">By id or Name -- I,N</param>
        /// <returns>IDataReader</returns>
        public IDataReader GetStaffStudentGradeRecord(string staffId, string courseDurationID, string studentID, string staffCourseId, string optionCode)
        {
            IDataReader rdr = null;
            string Query = "PROC_STAFF_STUDENT_GRADE_RECORD";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_staff_id", staffId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_course_id", staffCourseId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_course_duration_id", courseDurationID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_id", studentID, 50, 1, SqlDbType.NVarChar);
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
        /// Update the Grade for the Student by the Staff
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="staffCourseID"></param>
        /// <param name="courseDurationId"></param>
        /// <param name="studentId"></param>
        /// <param name="gradId"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns></returns>
        public string UpdateStaffStudentGradeRecord(string staffID,string staffCourseID, string courseDurationId, string studentId,string gradId, out string messageCode, out string messageText)
        {
            string Query = "PROC_UPDATE_STAFF_STUDENT_GRADE_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;

            objdal.CreateInternalParameter<string>("@pin_course_duration_id", courseDurationId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_id", staffID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_course_id", staffCourseID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_id", studentId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_grade_id", gradId, 50, 1, SqlDbType.NVarChar);            

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
