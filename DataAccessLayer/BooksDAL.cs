using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace DataAccessLayer
{
   public class BookDAL
    {
        /// <summary>
        /// Gets the BookList
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="bookName"></param>
        /// <param name="bookAuthorName"></param>
        /// <returns>IDataReader</returns>
        public IDataReader GetBookList(string bookID, string bookName,string bookAuthorName)
        {
            IDataReader rdr = null;
            string Query = "PROC_BOOK_LIST";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_book_id", bookID, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_book_name", bookName, 100, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_book_author_name", bookAuthorName, 100, 1, SqlDbType.NVarChar);

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
        /// Gets the Book Record
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns>IDataReader</returns>
        public IDataReader GetBookRecord(string bookID)
        {
            IDataReader rdr = null;
            string Query = "PROC_BOOK_RECORD";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_book_id", bookID, 50, 1, SqlDbType.NVarChar);

            parameter = objdal.parameterCollection;

            try
            {
                rdr = objdal.ExecuteReader(CommandType.StoredProcedure, Query, parameter,true);
            }
            catch (Exception ex)
            {
            }

            return rdr;

        }

        /// <summary>
        /// Insert Book Record
        /// </summary>        
        /// <param name="bookName"></param>
        /// <param name="bookAuthName"></param>
        /// <param name="dtTemp"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string InsertBookRecord(string bookName, string bookAuthName, DataTable dtTemp, out string messageCode, out string messageText)
        {

            string Query = "PROC_INSERT_BOOK_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;


            objdal.CreateInternalParameter<string>("@pin_book_name", bookName, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_book_author_name", bookAuthName, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<DataTable>("@pin_ut", dtTemp, 50, 1, SqlDbType.Structured);

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
        /// Update Book Record
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="bookName"></param>
        /// <param name="bookAuthName"></param>
        /// <param name="dtTemp"></param>
        /// <param name="messageCode"></param>
        /// <param name="messageText"></param>
        /// <returns>string</returns>
        public string UpdateBookRecord(string bookId, string bookName, string bookAuthName,DataTable dtTemp , out string messageCode, out string messageText)
        {

            string Query = "PROC_UPDATE_BOOK_RECORD";
            DALHelper objdal = new DALHelper();
            messageCode = string.Empty;
            messageText = string.Empty;

            List<SqlParameter> parameter = new List<SqlParameter>();
            SqlParameter paramMessageCode;
            SqlParameter paramMessageText;
            objdal.CreateInternalParameter<string>("@pin_book_id", bookId, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_book_name", bookName, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_book_author_name", bookAuthName, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<DataTable>("@pin_ut", dtTemp, 50, 1, SqlDbType.Structured);

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
