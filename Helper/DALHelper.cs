using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.SqlClient;

namespace Helper
{
    public class DALHelper
    {
        #region Variables
        SqlDataAdapter objda;
        public List<SqlParameter> parameterCollection;
        public SqlConnection Connection;
        #endregion Varaiables

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public DALHelper()
        {

        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Attaches the parameters.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="commandParameters">The command parameters.</param>
        private static void AttachParameters(SqlCommand command, List<SqlParameter> commandParameters)
        {
            foreach (SqlParameter p in commandParameters)
            {
                if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                {
                    p.Value = DBNull.Value;
                }
                command.Parameters.Add(p);
            }
        }

        /// <summary>
        /// Prepares the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="connection">The connection.</param>        
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <param name="commandParameters">The SQl parameters.</param>
        public SqlCommand PrepareCommand(CommandType commandType, string commandText, List<SqlParameter> commandParameters)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = commandText;
            command.CommandTimeout = 300;

            command.CommandType = commandType;

            if (commandParameters != null)
            {
                AttachParameters(command, commandParameters);
            }

            return command;
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>        
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The Query text.</param>
        /// <param name="commandParameters">The command parameters.</param>
        /// <returns></returns>
        public int ExecuteNonQuery(CommandType commandType, string Query, List<SqlParameter> commandParameters)
        {
            SqlConnection con;
            Connection = ConnectionHelper.GetConnection();
            con = Connection;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd = PrepareCommand(commandType, Query, commandParameters);
                con.Open();
                cmd.Connection = con;
                int retval = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

                return retval;
            }

            finally
            {
                con.Close();
            }

        }

        /// <summary>
        /// Gets the Direction for the Parameter
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public ParameterDirection GetParameterDirection(int direction)
        {
            if (direction == 1)
            {
                return ParameterDirection.Input;
            }
            else if (direction == 2)
            {
                return ParameterDirection.Output;
            }
            else
            {
                return ParameterDirection.InputOutput;
            }
        }

        /// <summary>
        /// Creates the Sql Parameters-For Direction--1 Input,2 Output,3 InputOutput
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parametername"></param>
        /// <param name="value"></param>
        /// <param name="size"></param>
        /// <param name="direction"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public SqlParameter CreateParameter<T>(string parametername, T value, int size, int direction, SqlDbType type)
        {
            SqlParameter parameter = new SqlParameter();

            parameter.Direction = GetParameterDirection(direction);
            parameter.Size = size;
            parameter.Value = value;
            parameter.SqlDbType = type;
            parameter.ParameterName = parametername;
            return parameter;
        }

        /// <summary>
        /// Creates the Sql Parameters-For Direction--1 Input,2 Output,3 InputOutput
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="parametername"></param>
        /// <param name="value"></param>
        /// <param name="size"></param>
        /// <param name="direction"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public SqlParameter CreateInternalParameter<T>(string parametername, T value, int size, int direction, SqlDbType type)
        {
            if (parameterCollection == null)
            {
                parameterCollection = new List<SqlParameter>();
            }

            SqlParameter parameter = new SqlParameter();

            parameter.Direction = GetParameterDirection(direction);
            parameter.Size = size;
            parameter.Value = value;
            parameter.SqlDbType = type;
            parameter.ParameterName = parametername;
            parameterCollection.Add(parameter);

            return parameter;
        }

        

        /// <summary>
        /// Creates the Data Adapter,provide inputs S for Select,I for insert,U for Update,D for Delete for the type of command
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public SqlDataAdapter CreateDataAdapter(List<SqlParameter> parameter, CommandType argcommandtype, string command, string Query, string SelectQuery)
        {
            SqlConnection connectionstring = ConnectionHelper.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(SelectQuery, connectionstring);

            if (command == "S")
            {
                if (parameter != null)
                {
                    da.SelectCommand.CommandType = argcommandtype;
                    da.SelectCommand.CommandTimeout = 0;
                    //objda.SelectCommand.CommandText = Query;
                    //objda.SelectCommand.Connection = connectionstring;
                    //for (int i = parameter.GetLowerBound(0); i <= parameter.GetUpperBound(0); i++)
                    //{
                    //    da.SelectCommand.Parameters.Add(parameter[i]);
                    //}
                    foreach (SqlParameter paramTemp in parameter)
                    {
                        da.SelectCommand.Parameters.Add(paramTemp);
                    }

                }
            }
            else if (command == "U")
            {
                if (parameter != null)
                {
                    da.UpdateCommand = new SqlCommand(Query);
                    da.UpdateCommand.CommandType = argcommandtype;
                    da.UpdateCommand.CommandTimeout = 0;
                    //objda.UpdateCommand.CommandText = Query;
                    //objda.UpdateCommand.Connection = connectionstring;
                    //for (int i = parameter.GetLowerBound(0); i <=parameter.GetUpperBound(0); i++)
                    //{
                    //    da.UpdateCommand.Parameters.Add(parameter[i]);
                    //}
                    foreach (SqlParameter paramTemp in parameter)
                    {
                        da.UpdateCommand.Parameters.Add(paramTemp);
                    }
                }
            }
            else if (command == "I")
            {
                if (parameter != null)
                {
                    da.InsertCommand = new SqlCommand(Query);
                    da.InsertCommand.CommandType = argcommandtype;
                    da.InsertCommand.CommandTimeout = 0;
                    //objda.InsertCommand.CommandText = Query;
                    //objda.InsertCommand.Connection = connectionstring;
                    //for (int i = parameter.GetLowerBound(0); i <= parameter.GetUpperBound(0); i++)
                    //{
                    //    da.InsertCommand.Parameters.Add(parameter[i]);
                    //}
                    foreach (SqlParameter paramTemp in parameter)
                    {
                        da.InsertCommand.Parameters.Add(paramTemp);
                    }
                }
            }
            else if (command == "D")
            {
                if (parameter != null)
                {
                    da.DeleteCommand = new SqlCommand(Query);
                    da.DeleteCommand.CommandType = argcommandtype;
                    da.DeleteCommand.CommandTimeout = 0;
                    //objda.DeleteCommand.CommandText = Query;
                    //objda.DeleteCommand.Connection = connectionstring;
                    //for (int i = parameter.GetLowerBound(0); i <= parameter.GetUpperBound(0); i++)
                    //{
                    //    da.DeleteCommand.Parameters.Add(parameter[i]);
                    //}
                    foreach (SqlParameter paramTemp in parameter)
                    {
                        da.DeleteCommand.Parameters.Add(paramTemp);
                    }
                }
            }
            else
            {
                if (parameter != null)
                {
                    da.SelectCommand.CommandType = argcommandtype;
                    da.SelectCommand.CommandTimeout = 0;

                    //for (int i = parameter.GetLowerBound(0); i <= parameter.GetUpperBound(0); i++)
                    //{
                    //    da.SelectCommand.Parameters.Add(parameter[i]);
                    //}
                    foreach (SqlParameter paramTemp in parameter)
                    {
                        da.SelectCommand.Parameters.Add(paramTemp);

                    }
                }
            }


            return da;
        }

        /// <summary>
        /// Creates the Data Adapter used to Get the list--Select only
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public SqlDataAdapter CreateDataAdapter(List<SqlParameter> parameter, CommandType argcommandtype, string SelectQuery)
        {
            SqlConnection connectionstring = ConnectionHelper.GetConnection();
            SqlDataAdapter da = new SqlDataAdapter(SelectQuery, connectionstring);

            if (parameter != null)
            {
                da.SelectCommand.CommandType = argcommandtype;
                da.SelectCommand.CommandTimeout = 0;

                //for (int i = parameter.GetLowerBound(0); i <= parameter.GetUpperBound(0); i++)
                //{
                //    da.SelectCommand.Parameters.Add(parameter[i]);
                //}
                foreach (SqlParameter paramTemp in parameter)
                {
                    da.SelectCommand.Parameters.Add(paramTemp);
                }
            }

            return da;
        }

        /// <summary>
        /// Executes the Procedure and returns the Dataset based on command-S,I,U,D
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public DataSet ExecuteDataset(string command, SqlDataAdapter da)
        {
            DataSet ds = new DataSet();

            if (command == "S")
                da.Fill(ds);
            else
            {
                da.Fill(ds);
                da.Update(ds);
            }

            return ds;
        }

        /// <summary>
        /// ExecuteScalar, returns the integer
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="Query"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public Int64 ExecuteScalar(CommandType commandType, string Query, List<SqlParameter> commandParameters)
        {
            Int64 retval = 0;
            SqlConnection con;
            Connection = ConnectionHelper.GetConnection();
            con = Connection;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd = PrepareCommand(commandType, Query, commandParameters);
                con.Open();
                cmd.Connection = con;
                retval = (Int64)cmd.ExecuteScalar();
                cmd.Parameters.Clear();

                return retval;
            }

            finally
            {
                con.Close();
            }
        }

        /// <summary>
        /// ExecuteReader,returs the SqlDatareader
        /// </summary>
        /// <param name="commandType"></param>
        /// <param name="Query"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public IDataReader ExecuteReader(CommandType commandType, string Query, List<SqlParameter> commandParameters,bool isMulResult=false)
        {
            SqlDataReader dr;
            SqlConnection con;
            Connection = ConnectionHelper.GetConnection();
            con = Connection;
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd = PrepareCommand(commandType, Query, commandParameters);
                con.Open();
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                //cmd.Parameters.Clear();
                if (isMulResult)
                {
                    return dr;
                }
                IDataReader rdrNew = null;
                DataTable dt = new DataTable();
                if (dr != null)
                {
                    dt.Load(dr);
                }
                if (!dr.IsClosed)
                {
                    dr.Close();
                }
                rdrNew = (IDataReader)dt.CreateDataReader();
                return rdrNew;
            }
            catch(Exception ex)
            {
                return null;
            }

            finally
            {
                if (!isMulResult)
                {
                    con.Close();
                }
            }

        }

        /// <summary>
        /// Returns the value of the parameter
        /// </summary>
        /// <param name="pamareterColl"></param>
        /// <param name="parameterName"></param>
        /// <returns></returns>
        public string GetParameterValue(List<SqlParameter> pamareterColl, string parameterName)
        {
            string value = pamareterColl.Find(item => item.ParameterName == parameterName).SqlValue.ToString();
            return value;
        }

        #endregion Public Methods

    }
}
