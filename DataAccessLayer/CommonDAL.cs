using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace DataAccessLayer
{
    public class CommonDAL
    {
        /// <summary>
        /// Gets the common dropdown values based on the Type
        /// </summary>
        /// <param name="type">Year, Month,Day- Y,M,D</param>
        /// <param name="optionCode">Select,All -- 0,-1</param>
        /// <returns>IDataReader</returns>
        public IDataReader GetCommonDropDowns(string type, string optionCode)
        {
            IDataReader rdr = null;
            string Query = "PROC_COMMON_DROPDOWN_LIST";
            DALHelper objdal = new DALHelper();

            List<SqlParameter> parameter = new List<SqlParameter>();

            objdal.CreateInternalParameter<string>("@pin_type_cd", type, 50, 1, SqlDbType.NVarChar);
            objdal.CreateInternalParameter<string>("@pin_option_code", optionCode, 100, 1, SqlDbType.NVarChar);

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
    }
}
