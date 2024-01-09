using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Helper;


namespace DataAccessLayer
{
   public class ReportsDAL
    {
        /// <summary>
        /// Gets the Student List
        /// </summary>
        /// <param name="_commonBE"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns></returns>
       public IDataReader GetStudentList(CommonBE _commonBE, out string messageCode, out string messageText)
        {
            IDataReader rdr = null;
            string Query = "PROC_REPORT_STUDENT_LIST";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;

            objdal.CreateInternalParameter<string>("@pin_student_id", _commonBE.ID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_last_name", _commonBE.LastName, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_first_name", _commonBE.FirstName, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_middle_name", _commonBE.MiddleName, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_dob", _commonBE.DateOfBirth, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_active_ind", _commonBE.ActiveInd, 100, 1, SqlDbType.NVarChar);
            paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
            paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);
            
            parameter = objdal.parameterCollection;

            try
            {
               rdr= objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
                messageCode = paramMessageCode.SqlValue.ToString();
                messageText = paramMessageText.SqlValue.ToString();

            }
            catch (Exception ex)
            {
                return null;
            }
            

            parameter = objdal.parameterCollection;            

            return rdr;

        }

       /// <summary>
       /// Gets the Staff List
       /// </summary>
       /// <param name="_commonBE"></param>
       /// <param name="messageCode"></param>
       /// <param name="messageText"></param>
       /// <returns></returns>
       public IDataReader GetStaffList(CommonBE _commonBE, out string messageCode, out string messageText)
       {
           IDataReader rdr = null;
           string Query = "PROC_REPORT_STAFF_LIST";
           DALHelper objdal = new DALHelper();
           messageCode = string.Empty;
           messageText = string.Empty;

           List<SqlParameter> parameter = new List<SqlParameter>();
           SqlParameter paramMessageCode;
           SqlParameter paramMessageText;

           objdal.CreateInternalParameter<string>("@pin_staff_id", _commonBE.ID, 50, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_staff_last_name", _commonBE.LastName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_staff_first_name", _commonBE.FirstName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_staff_middle_name", _commonBE.MiddleName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_dob", _commonBE.DateOfBirth, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_active_ind", _commonBE.ActiveInd, 100, 1, SqlDbType.NVarChar);
           paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
           paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);

           parameter = objdal.parameterCollection;

           try
           {
               rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
               messageCode = paramMessageCode.SqlValue.ToString();
               messageText = paramMessageText.SqlValue.ToString();

           }
           catch (Exception ex)
           {
               return null;
           }


           parameter = objdal.parameterCollection;

           return rdr;

       }

       /// <summary>
       /// Gets the Student list by Staff
       /// </summary>
       /// <param name="_commonBE"></param>
       /// <param name="messageCode"></param>
       /// <param name="messageText"></param>
       /// <returns></returns>
       public IDataReader GetStudentListByStaff(CommonBE _commonBE, out string messageCode, out string messageText)
       {
           IDataReader rdr = null;
           string Query = "PROC_REPORT_STUDENT_STAFF_LIST";
           DALHelper objdal = new DALHelper();
           messageCode = string.Empty;
           messageText = string.Empty;

           List<SqlParameter> parameter = new List<SqlParameter>();
           SqlParameter paramMessageCode;
           SqlParameter paramMessageText;

           objdal.CreateInternalParameter<string>("@pin_student_id", _commonBE.ID, 50, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_student_last_name", _commonBE.LastName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_student_first_name", _commonBE.FirstName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_student_middle_name", _commonBE.MiddleName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_dob", _commonBE.DateOfBirth, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_active_ind", _commonBE.ActiveInd, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_staff_id_txt", _commonBE.AddlID, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_staff_name_txt", _commonBE.AddlName, 100, 1, SqlDbType.NVarChar);
           paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
           paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);
            
           parameter = objdal.parameterCollection;

           try
           {
               rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
               messageCode = paramMessageCode.SqlValue.ToString();
               messageText = paramMessageText.SqlValue.ToString();

           }
           catch (Exception ex)
           {
               return null;
           }


           parameter = objdal.parameterCollection;

           return rdr;
       }

       /// <summary>
       /// Gets the Student list by Course
       /// </summary>
       /// <param name="_commonBE"></param>
       /// <param name="messageCode"></param>
       /// <param name="messageText"></param>
       /// <returns></returns>
       public IDataReader GetStudentListByCourse(CommonBE _commonBE, out string messageCode, out string messageText)
       {
           IDataReader rdr = null;
           string Query = "PROC_REPORT_STUDENT_COURSE_LIST";
           DALHelper objdal = new DALHelper();
           messageCode = string.Empty;
           messageText = string.Empty;

           List<SqlParameter> parameter = new List<SqlParameter>();
           SqlParameter paramMessageCode;
           SqlParameter paramMessageText;

           objdal.CreateInternalParameter<string>("@pin_student_id", _commonBE.ID, 50, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_student_last_name", _commonBE.LastName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_student_first_name", _commonBE.FirstName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_student_middle_name", _commonBE.MiddleName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_dob", _commonBE.DateOfBirth, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_active_ind", _commonBE.ActiveInd, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_course_duration_id_txt", _commonBE.AddlID, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_course_name", _commonBE.AddlName, 100, 1, SqlDbType.NVarChar);
           paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
           paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);
            
           parameter = objdal.parameterCollection;

           try
           {
               rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
               messageCode = paramMessageCode.SqlValue.ToString();
               messageText = paramMessageText.SqlValue.ToString();

           }
           catch (Exception ex)
           {
               return null;
           }


           parameter = objdal.parameterCollection;

           return rdr;
       }

       /// <summary>
       /// Returns the list of Staff by Course
       /// </summary>
       /// <param name="_commonBE"></param>
       /// <param name="messageCode"></param>
       /// <param name="messageText"></param>
       /// <returns></returns>
       public IDataReader GetStaffCourseList(CommonBE _commonBE, out string messageCode, out string messageText)
       {
           IDataReader rdr = null;
           string Query = "PROC_REPORT_STAFF_COURSE_LIST";
           DALHelper objdal = new DALHelper();
           messageCode = string.Empty;
           messageText = string.Empty;

           List<SqlParameter> parameter = new List<SqlParameter>();
           SqlParameter paramMessageCode;
           SqlParameter paramMessageText;

           objdal.CreateInternalParameter<string>("@pin_staff_id_txt", _commonBE.ID, 50, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_staff_last_name", _commonBE.LastName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_staff_first_name", _commonBE.FirstName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_staff_middle_name", _commonBE.MiddleName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_dob", _commonBE.DateOfBirth, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_active_ind", _commonBE.ActiveInd, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_course_id_txt", _commonBE.AddlID, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_course_name", _commonBE.AddlName, 100, 1, SqlDbType.NVarChar);
           paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
           paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);

           parameter = objdal.parameterCollection;

           try
           {
               rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
               messageCode = paramMessageCode.SqlValue.ToString();
               messageText = paramMessageText.SqlValue.ToString();

           }
           catch (Exception ex)
           {
               return null;
           }


           parameter = objdal.parameterCollection;

           return rdr;
       }

       /// <summary>
       /// Returns the list of Staff by Course
       /// </summary>
       /// <param name="_commonBE"></param>
       /// <param name="messageCode"></param>
       /// <param name="messageText"></param>
       /// <returns></returns>
       public IDataReader GetCourseList(CommonBE _commonBE, out string messageCode, out string messageText)
       {
           IDataReader rdr = null;
           string Query = "PROC_REPORT_COURSE_LIST";
           DALHelper objdal = new DALHelper();
           messageCode = string.Empty;
           messageText = string.Empty;

           List<SqlParameter> parameter = new List<SqlParameter>();
           SqlParameter paramMessageCode;
           SqlParameter paramMessageText;
           
           objdal.CreateInternalParameter<string>("@pin_course_id_txt", _commonBE.AddlID, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_course_name", _commonBE.AddlName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_active_ind", _commonBE.ActiveInd, 100, 1, SqlDbType.NVarChar);
           paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
           paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);

           parameter = objdal.parameterCollection;

           try
           {
               rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
               messageCode = paramMessageCode.SqlValue.ToString();
               messageText = paramMessageText.SqlValue.ToString();

           }
           catch (Exception ex)
           {
               return null;
           }


           parameter = objdal.parameterCollection;

           return rdr;
       }
       /// <summary>
       /// Returns the list of Staff by Course
       /// </summary>
       /// <param name="_commonBE"></param>
       /// <param name="messageCode"></param>
       /// <param name="messageText"></param>
       /// <returns></returns>
       public IDataReader GetCourseListByYearMonth(CommonBE _commonBE, out string messageCode, out string messageText)
       {
           IDataReader rdr = null;
           string Query = "PROC_REPORT_COURSE_YEAR_MONTH_LIST";
           DALHelper objdal = new DALHelper();
           messageCode = string.Empty;
           messageText = string.Empty;

           List<SqlParameter> parameter = new List<SqlParameter>();
           SqlParameter paramMessageCode;
           SqlParameter paramMessageText;

           objdal.CreateInternalParameter<string>("@pin_course_id_txt", _commonBE.AddlID, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_course_name", _commonBE.AddlName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_year_nbr", _commonBE.YearNbr, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_month_nbr", _commonBE.MonthNbr, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_active_ind", _commonBE.ActiveInd, 100, 1, SqlDbType.NVarChar);
           paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
           paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);

           parameter = objdal.parameterCollection;

           try
           {
               rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
               messageCode = paramMessageCode.SqlValue.ToString();
               messageText = paramMessageText.SqlValue.ToString();

           }
           catch (Exception ex)
           {
               return null;
           }


           parameter = objdal.parameterCollection;

           return rdr;
       }
       /// <summary>
       /// Returns the list of Staff by Course
       /// </summary>
       /// <param name="_commonBE"></param>
       /// <param name="messageCode"></param>
       /// <param name="messageText"></param>
       /// <returns></returns>
       public IDataReader GetBookList(CommonBE _commonBE, out string messageCode, out string messageText)
       {
           IDataReader rdr = null;
           string Query = "PROC_REPORT_BOOK_LIST";
           DALHelper objdal = new DALHelper();
           messageCode = string.Empty;
           messageText = string.Empty;

           List<SqlParameter> parameter = new List<SqlParameter>();
           SqlParameter paramMessageCode;
           SqlParameter paramMessageText;
           
           objdal.CreateInternalParameter<string>("@pin_book_name", _commonBE.AddlName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_book_author_name", _commonBE.AddlID, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_active_ind", _commonBE.ActiveInd, 100, 1, SqlDbType.NVarChar);
           paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
           paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);

           parameter = objdal.parameterCollection;

           try
           {
               rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
               messageCode = paramMessageCode.SqlValue.ToString();
               messageText = paramMessageText.SqlValue.ToString();

           }
           catch (Exception ex)
           {
               return null;
           }


           parameter = objdal.parameterCollection;

           return rdr;
       }
       /// <summary>
       /// Returns the list of Staff by Course
       /// </summary>
       /// <param name="_commonBE"></param>
       /// <param name="messageCode"></param>
       /// <param name="messageText"></param>
       /// <returns></returns>
       public IDataReader GetCourseListByStaff(CommonBE _commonBE, out string messageCode, out string messageText)
       {
           IDataReader rdr = null;
           string Query = "PROC_REPORT_COURSE_STAFF_LIST";
           DALHelper objdal = new DALHelper();
           messageCode = string.Empty;
           messageText = string.Empty;

           List<SqlParameter> parameter = new List<SqlParameter>();
           SqlParameter paramMessageCode;
           SqlParameter paramMessageText;

           objdal.CreateInternalParameter<string>("@pin_staff_id_txt", _commonBE.ID, 50, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_staff_last_name", _commonBE.LastName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_staff_first_name", _commonBE.FirstName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_staff_middle_name", _commonBE.MiddleName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_dob", _commonBE.DateOfBirth, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_active_ind", _commonBE.ActiveInd, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_course_id_txt", _commonBE.AddlID, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_course_name", _commonBE.AddlName, 100, 1, SqlDbType.NVarChar);
           paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
           paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);

           parameter = objdal.parameterCollection;

           try
           {
               rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
               messageCode = paramMessageCode.SqlValue.ToString();
               messageText = paramMessageText.SqlValue.ToString();

           }
           catch (Exception ex)
           {
               return null;
           }


           parameter = objdal.parameterCollection;

           return rdr;
       }
       /// <summary>
       /// Returns the list of Staff by Course
       /// </summary>
       /// <param name="_commonBE"></param>
       /// <param name="messageCode"></param>
       /// <param name="messageText"></param>
       /// <returns></returns>
       public IDataReader GetStudentGradesByCourseList(CommonBE _commonBE, out string messageCode, out string messageText)
       {
           IDataReader rdr = null;
           string Query = "PROC_REPORT_STUDENT_GRADE_COURSE_LIST";
           DALHelper objdal = new DALHelper();
           messageCode = string.Empty;
           messageText = string.Empty;

           List<SqlParameter> parameter = new List<SqlParameter>();
           SqlParameter paramMessageCode;
           SqlParameter paramMessageText;

           objdal.CreateInternalParameter<string>("@pin_student_id_txt", _commonBE.ID, 50, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_student_last_name", _commonBE.LastName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_student_first_name", _commonBE.FirstName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_student_middle_name", _commonBE.MiddleName, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_dob", _commonBE.DateOfBirth, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_active_ind", _commonBE.ActiveInd, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_course_id_txt", _commonBE.AddlID, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_course_name", _commonBE.AddlName, 100, 1, SqlDbType.NVarChar);
           paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
           paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);

           parameter = objdal.parameterCollection;

           try
           {
               rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
               messageCode = paramMessageCode.SqlValue.ToString();
               messageText = paramMessageText.SqlValue.ToString();

           }
           catch (Exception ex)
           {
               return null;
           }


           parameter = objdal.parameterCollection;

           return rdr;
       }
       /// <summary>
       /// Returns the list of Staff by Course
       /// </summary>
       /// <param name="_commonBE"></param>
       /// <param name="messageCode"></param>
       /// <param name="messageText"></param>
       /// <returns></returns>
       public IDataReader GetBookListByCourse(CommonBE _commonBE, out string messageCode, out string messageText)
       {
           IDataReader rdr = null;
           string Query = "PROC_REPORT_BOOK_COURSE_LIST";
           DALHelper objdal = new DALHelper();
           messageCode = string.Empty;
           messageText = string.Empty;

           List<SqlParameter> parameter = new List<SqlParameter>();
           SqlParameter paramMessageCode;
           SqlParameter paramMessageText;

           
           objdal.CreateInternalParameter<string>("@pin_book_name", _commonBE.AddlID0, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_book_author_name", _commonBE.AddlName0, 50, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_active_ind", _commonBE.ActiveInd, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_course_id_txt", _commonBE.AddlID, 100, 1, SqlDbType.NVarChar);
           objdal.CreateInternalParameter<string>("@pin_course_name", _commonBE.AddlName, 100, 1, SqlDbType.NVarChar);
           paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
           paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);

           parameter = objdal.parameterCollection;

           try
           {
               rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
               messageCode = paramMessageCode.SqlValue.ToString();
               messageText = paramMessageText.SqlValue.ToString();

           }
           catch (Exception ex)
           {
               return null;
           }


           parameter = objdal.parameterCollection;

           return rdr;
       }
    }
}
