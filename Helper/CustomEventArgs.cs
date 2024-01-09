using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Helper
{
    public class CustomEventArgs:EventArgs
    {
        private string _id;

        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _addl_id;

        public string AddlId
        {
            get { return _addl_id; }
            set { _addl_id = value; }
        }

        private string _addl_id_0;

        public string AddlId0
        {
            get { return _addl_id_0; }
            set { _addl_id_0 = value; }
        }

        
        private string _addl_id_1;

        public string AddlId1
        {
            get { return _addl_id_1; }
            set { _addl_id_1 = value; }
        }
        private string _status_cd;

        public string StatusCode
        {
            get { return _status_cd; }
            set { _status_cd = value; }
        }

        private Boolean _isActive;

        public Boolean IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }

        private string _message_cd;

        public string MessageCode
        {
            get { return _message_cd; }
            set { _message_cd = value; }
        }

        private string _message_text;

        public string MessageText
        {
            get { return _message_text; }
            set { _message_text = value; }
        }
    }
}
