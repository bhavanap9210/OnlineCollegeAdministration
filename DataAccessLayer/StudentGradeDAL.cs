using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Helper;

namespace DataAccessLayer
{
    public class StudentGradeDAL
    {


        /// <summary>
        /// Gets the Student Grade Record
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="courseDurationID"></param>
        /// <param name="studentID"></param>
        /// <param name="optionCode">By id or Name -- I,N</param>
        /// <returns>IDataReader</returns>
        public IDataReader GetStudentGradeRecord(string staffId, string courseDurationID, string studentID, string staffCourseId, string optionCode)
        {
            IDataReader rdr = null;
            string Query = "PROC_STUDENT_GRADE_RECORD";
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
    }
}
