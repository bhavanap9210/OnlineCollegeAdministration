using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    [Serializable]
    public class CommonBE
    {
        private string _id;
        private string _last_name;
        private string _first_name;
        private string _middle_name;   
        private string _course;
        private string _start_dt;
        private string _end_dt;
        private string _dob;
        private string _active_ind;
        private string _addl_name;
        private string _addl_id;
        private string _addl_desc;
        private string _year_nbr;
        private string _month_nbr;
        private string _addl_name_0;
        private string _addl_id_0;

        public string AddlDesc
        {
            get { return _addl_desc; }
            set { _addl_desc = value; }
        }

        public string YearNbr
        {
            get { return _year_nbr; }
            set { _year_nbr = value; }
        }

        public string MonthNbr
        {
            get { return _month_nbr; }
            set { _month_nbr = value; }
        }

        public string ActiveInd
        {
            get { return _active_ind; }
            set { _active_ind = value; }
        }   

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        

        public string LastName
        {
            get { return _last_name; }
            set { _last_name = value; }
        }
        

        public string FirstName
        {
            get { return _first_name; }
            set { _first_name = value; }
        }

        public string MiddleName
        {
            get { return _middle_name; }
            set { _middle_name = value; }
        }

        public string Course
        {
            get { return _course; }
            set { _course = value; }
        }
        

        public string StartDate
        {
            get { return _start_dt; }
            set { _start_dt = value; }
        }
        

        public string EndDate
        {
            get { return _end_dt; }
            set { _end_dt = value; }
        }

        public string DateOfBirth
        {
            get { return _dob; }
            set { _dob = value; }
        }

        public string AddlID
        {
            get { return _addl_id; }
            set { _addl_id = value; }
        }


        public string AddlName
        {
            get { return _addl_name; }
            set { _addl_name = value; }
        }

        public string AddlID0
        {
            get { return _addl_id_0; }
            set { _addl_id_0 = value; }
        }


        public string AddlName0
        {
            get { return _addl_name_0; }
            set { _addl_name_0 = value; }
        }
    }
}
