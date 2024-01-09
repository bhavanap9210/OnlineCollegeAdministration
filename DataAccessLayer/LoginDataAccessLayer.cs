using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace DataAccessLayer
{
    public class LoginDataAccessLayer
    {
        public LoginDataAccessLayer()
        {
        }

        /// <summary>
        /// Authenticates the user and gets the roles for that user
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns></returns>
        public IDataReader GetAuthenticateUserRolesLookup(string userName, string password, out string messageCode, out string messageText)
        {
            IDataReader rdr = null;
            string Query = "PROC_OCA_AUTHENTICATE_GET_USER_ROLES_MENUS";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;
            

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_user_name", userName, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_password", password, 100, 1, SqlDbType.NVarChar);
            paramMessageCode = objdal.CreateInternalParameter<string>("@pin_message_cd", messageCode, 10, 2, SqlDbType.NVarChar);
            paramMessageText = objdal.CreateInternalParameter<string>("@pin_message_text", messageText, 500, 2, SqlDbType.NVarChar);
            parameter = objdal.parameterCollection;


            try
            {
                rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter);
                messageCode = paramMessageCode.SqlValue.ToString();
                messageText = paramMessageText.SqlValue.ToString();

                //if (objdal.Connection != null)
                //{
                //    if (objdal.Connection.State != ConnectionState.Closed)
                //    {
                //        objdal.Connection.Close();
                //    }
                //}
            }
            catch (Exception ex)
            {
            }

            return rdr;

        }

        ///// <summary>
        ///// Insert Or Update when the User Log's in
        ///// </summary>
        ///// <param name="userid"></param>
        ///// <param name="monthnbr"></param>
        ///// <param name="yearnbr"></param>
        ///// <returns>Integer</returns>
        //public int InsertUpdateLoginUser(Int64 userid, Int64 monthnbr, Int64 yearnbr)
        //{
        //    int retval = 0;

        //    string Query = "PROC_LOGIN_REGISTERED_USER_INSERT_UPDATE";
        //    DALHelper objdal = new DALHelper();

        //    SqlParameter[] parameter = new SqlParameter[3];

        //    parameter[0] = objdal.CreateParameter<Int64>("@pin_user_id", userid, 50, 1, SqlDbType.Int);
        //    parameter[1] = objdal.CreateParameter<Int64>("@pin_month_nbr", monthnbr, 50, 1, SqlDbType.Int);
        //    parameter[2] = objdal.CreateParameter<Int64>("@pin_year_nbr", yearnbr, 50, 1, SqlDbType.Int);

        //    try
        //    {
        //        //Using SqlCommand object 
        //        retval = objdal.ExecuteNonQuery(CommandType.StoredProcedure, Query, parameter);
        //    }
        //    catch (Exception ex)
        //    {
        //        retval = -3;
        //    }

        //    return retval;
        //}

        //public DataSet GetLoginUser(Int64 userid, Int64 monthnbr, Int64 yearnbr)
        //{
        //    DataSet ds = new DataSet();
        //    string Query = "PROC_LOGIN_REGISTERED_USER_GET";
        //    DALHelper objdal = new DALHelper();

        //    SqlParameter[] parameter = new SqlParameter[3];

        //    parameter[0] = objdal.CreateParameter<Int64>("@pin_user_id", userid, 50, 1, SqlDbType.Int);
        //    parameter[1] = objdal.CreateParameter<Int64>("@pin_month_nbr", monthnbr, 50, 1, SqlDbType.Int);
        //    parameter[2] = objdal.CreateParameter<Int64>("@pin_year_nbr", yearnbr, 50, 1, SqlDbType.Int);

        //    SqlDataAdapter da = new SqlDataAdapter();

        //    string command = "S";
        //    string selectquery = Query;

        //    da = objdal.CreateDataAdapter(parameter, CommandType.StoredProcedure, command, Query, selectquery);

        //    try
        //    {
        //        ds = objdal.ExecuteDataset(command, da);
        //        ds.Tables[0].TableName = "Login_User_tb";
        //    }
        //    catch (Exception ex)
        //    {
        //    }

        //    return ds;

        //}
    }
}
