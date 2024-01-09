using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public class ValidateHelper
    {
        public ValidateHelper()
        {
        }
        /// <summary>
        /// Checks whether specified string is decimal or not
        /// </summary>
        /// <param name="val"></param>
        /// <returns>bool</returns>
        public static bool IsDecimal(string val)
        {
            try
            {
                Decimal.Parse(val.Trim());
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Checks whether specified string is int or not
        /// </summary>
        /// <param name="val"></param>
        /// <returns>bool</returns>
        public static bool IsNumeric(string val)
        {
            try
            {
                int.Parse(val.Trim());
                return true;
            }
            catch { return false; }
        }


        /// <summary>
        /// Checks whether specified string is Date or not
        /// </summary>
        /// <param name="val"></param>
        /// <returns>bool</returns>
        public static bool IsDate(string val)
        {
            try
            {
                DateTime.Parse(val.Trim());
                return true;
            }
            catch { return false; }
        }


        /// <summary>
        /// Checks whether specified string is Bool or not
        /// </summary>
        /// <param name="val"></param>
        /// <returns>bool</returns>
        public static bool IsBool(string val)
        {
            try
            {
                if (val == "1" || val == "0")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
    }
}
