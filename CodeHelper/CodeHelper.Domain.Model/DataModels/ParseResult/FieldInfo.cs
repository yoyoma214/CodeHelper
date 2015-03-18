using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.DataModel
{
    public class FieldInfo
    {
        public String Name { get; set; }
        public String System_type { get; set; }
        public String Db_type { get; set; }
        public Boolean Is_null { get; set; }
        public Boolean Is_pk { get; set; }

    }
}
