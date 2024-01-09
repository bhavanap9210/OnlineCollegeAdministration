using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace DataAccessLayer
{
    public class StudentDAL
    {
        /// <summary>
        /// Gets the StudentList
        /// </summary>
        /// <param name="studID"></param>
        /// <param name="studLastName"></param>
        /// <param name="studFirstName"></param>
        /// <param name="activeInd"></param>
        /// <returns>IDataReader</returns>
        public IDataReader GetStudentList(string studID, string studLastName, string studFirstName,string activeInd)
        {
            IDataReader rdr = null;
            string Query = "PROC_STUDENT_LIST";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_stud_id", studID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_stud_last_name", studLastName, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_stud_first_name", studFirstName, 100, 1, SqlDbType.NVarChar);
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
        /// Gets the Student Record
        /// </summary>
        /// <param name="studID"></param>
        /// <param name="optionCode">By id or Name -- I,N</param>
        /// <returns>IDataReader</returns>
        public IDataReader GetStudentRecord(string studID, string optionCode)
        {
            IDataReader rdr = null;
            string Query = "PROC_STUDENT_RECORD";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_stud_id", studID, 50, 1, SqlDbType.NVarChar);
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
        /// Insert Student Record
        /// </summary>
        /// <param name="studLN"></param>
        /// <param name="studFN"></param>
        /// <param name="studMN"></param>
        /// <param name="dob"></param>
        /// <param name="addr1"></param>
        /// <param name="addr2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="country"></param>
        /// <param name="studEmail"></param>
        /// <param name="studmobile"></param>
        /// <param name="password"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string InsertStudentRecord(string studLN, string studFN, string studMN, string dob, string addr1, string addr2, string city, string state, string zipCode, string country, string studEmail, string studmobile,string password, out string messageCode, out string messageText)
        {

            string Query = "PROC_INSERT_STUDENT_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            
            objdal.CreateInternalParameter<string>("@pin_student_last_name", studLN, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_first_name", studFN, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_middle_name", studMN, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_dob_dt", dob, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_addr1", addr1, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_addr2", addr2, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_city", city, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_state", state, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_zip_code", zipCode, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_country", country, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_email", studEmail, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_mobile_no", studmobile, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_passsword_txt", password, 250, 1, SqlDbType.NVarChar);
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
        /// Update Student Record
        /// </summary>
        /// <param name="studId"></param>
        /// <param name="studIdText"></param>
        /// <param name="studLN"></param>
        /// <param name="studFN"></param>
        /// <param name="studMN"></param>
        /// <param name="dob"></param>
        /// <param name="addr1"></param>
        /// <param name="addr2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="country"></param>
        /// <param name="studEmail"></param>
        /// <param name="studmobile"></param>
        /// <param name="password"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string UpdateStudentRecord(string studId,string studIdText,string studLN, string studFN, string studMN, string dob, string addr1, string addr2, string city, string state, string zipCode, string country, string studEmail, string studmobile,string password, out string messageCode, out string messageText)
        {

            string Query = "PROC_UPDATE_STUDENT_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_stud_id", studId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_stud_id_txt", studIdText, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_last_name", studLN, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_first_name", studFN, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_middle_name", studMN, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_dob_dt", dob, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_addr1", addr1, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_addr2", addr2, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_city", city, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_state", state, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_zip_code", zipCode, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_country", country, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_student_email", studEmail, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_mobile_no", studmobile, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_passsword_txt", password, 50, 1, SqlDbType.NVarChar);
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
        /// Activate or Inactivate Student Record
        /// </summary>
        /// <param name="studId"></param>        
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string ActivateInactivateStudentRecord(string studId, out string messageCode, out string messageText)
        {

            string Query = "PROC_ACTIVATE_INACTIVATE_STUDENT_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_stud_id", studId, 50, 1, SqlDbType.NVarChar);            
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
        /// Upload Student Image
        /// </summary>
        /// <param name="studId"></param>     
        /// <param name="imgByte"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string UploadStudentImage(string studId,byte[] imgByte, out string messageCode, out string messageText)
        {

            string Query = "PROC_UPLOAD_STUDENT_IMAGE";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;
            
            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_student_id", studId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<byte[]>("@pin_student_img", imgByte, 50000000, 1, SqlDbType.Image);
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
        /// Retrieved Upload Student Image
        /// </summary>
        /// <param name="studId"></param>             
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public IDataReader RetrieveUploadStudentImage(string studId, out string messageCode, out string messageText)
        {
            IDataReader rdr = null;
            string Query = "PROC_RETRIEVE_UPLOADED_STUDENT_IMAGE";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_student_id", studId, 50, 1, SqlDbType.NVarChar);            
            paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
            paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);

            parameter = objdal.parameterCollection;

            try
            {
                rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
                //messageCode = paramMessageCode.SqlValue.ToString();
                //messageText = paramMessageText.SqlValue.ToString();

            }
            catch (Exception ex)
            {
                return null;
            }
            return rdr;
        }
    }
}
