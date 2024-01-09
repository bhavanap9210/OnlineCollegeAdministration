using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace DataAccessLayer
{
    public class StaffDAL
    {
        /// <summary>
        /// Gets the StaffList
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="staffLastName"></param>
        /// <param name="staffFirstName"></param>
        /// <param name="activeInd"></param>
        /// <returns>IDataReader</returns>
        public IDataReader GetStaffList(string staffID, string staffLastName, string staffFirstName,string activeInd)
        {
            IDataReader rdr = null;
            string Query = "PROC_STAFF_LIST";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_staff_id", staffID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_last_name", staffLastName, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_first_name", staffFirstName, 100, 1, SqlDbType.NVarChar);
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
        /// Gets the Staff Record
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="optionCode">By id or Name -- I,N</param>
        /// <returns>IDataReader</returns>
        public IDataReader GetStaffRecord(string staffID,string optionCode)
        {
            IDataReader rdr = null;
            string Query = "PROC_STAFF_RECORD";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_staff_id", staffID, 50, 1, SqlDbType.NVarChar);
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
        /// Insert Staff Record
        /// </summary>
        /// <param name="staffLN"></param>
        /// <param name="staffFN"></param>
        /// <param name="staffMN"></param>
        /// <param name="dob"></param>
        /// <param name="addr1"></param>
        /// <param name="addr2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="country"></param>
        /// <param name="staffEmail"></param>
        /// <param name="staffmobile"></param>
        /// <param name="password"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string InsertStaffRecord(string staffLN, string staffFN, string staffMN, string dob, string addr1, string addr2, string city, string state, string zipCode, string country, string staffEmail, string staffmobile,string password, out string messageCode, out string messageText)
        {

            string Query = "PROC_INSERT_STAFF_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            
            objdal.CreateInternalParameter<string>("@pin_staff_last_name", staffLN, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_first_name", staffFN, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_middle_name", staffMN, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_dob_dt", dob, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_addr1", addr1, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_addr2", addr2, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_city", city, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_state", state, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_zip_code", zipCode, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_country", country, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_email", staffEmail, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_mobile_no", staffmobile, 50, 1, SqlDbType.NVarChar);
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
        /// Update Staff Record
        /// </summary>
        /// <param name="staffID"></param>
        /// <param name="staffIDText"></param>
        /// <param name="staffLN"></param>
        /// <param name="staffFN"></param>
        /// <param name="staffMN"></param>
        /// <param name="dob"></param>
        /// <param name="addr1"></param>
        /// <param name="addr2"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zipCode"></param>
        /// <param name="country"></param>
        /// <param name="staffEmail"></param>
        /// <param name="staffmobile"></param>
        /// <param name="password"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string UpdateStaffRecord(string staffID,string staffIDText,string staffLN, string staffFN, string staffMN, string dob, string addr1, string addr2, string city, string state, string zipCode, string country, string staffEmail, string staffmobile,string password, out string messageCode, out string messageText)
        {

            string Query = "PROC_UPDATE_STAFF_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_staff_id", staffID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_id_txt", staffIDText, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_last_name", staffLN, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_first_name", staffFN, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_middle_name", staffMN, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_dob_dt", dob, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_addr1", addr1, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_addr2", addr2, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_city", city, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_state", state, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_zip_code", zipCode, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_country", country, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_staff_email", staffEmail, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_mobile_no", staffmobile, 50, 1, SqlDbType.NVarChar);
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
        /// Activate or Inactivate Staff Record
        /// </summary>
        /// <param name="staffID"></param>        
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string ActivateInactivateStaffRecord(string staffID, out string messageCode, out string messageText)
        {

            string Query = "PROC_ACTIVATE_INACTIVATE_STAFF_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_staff_id", staffID, 50, 1, SqlDbType.NVarChar);            
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
        /// Upload Staff Image
        /// </summary>
        /// <param name="staffID"></param>     
        /// <param name="imgByte"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string UploadStaffImage(string staffID, byte[] imgByte, out string messageCode, out string messageText)
        {

            string Query = "PROC_UPLOAD_STAFF_IMAGE";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_staff_id", staffID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<byte[]>("@pin_staff_img", imgByte, 50000000, 1, SqlDbType.Image);
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
        /// Retrieved Upload Staff Image
        /// </summary>
        /// <param name="staffId"></param>             
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public IDataReader RetrieveUploadStaffImage(string staffId, out string messageCode, out string messageText)
        {
            IDataReader rdr = null;
            string Query = "PROC_RETRIEVE_UPLOADED_STAFF_IMAGE";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_staff_id", staffId, 50, 1, SqlDbType.NVarChar);
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
