using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.DataViews;

namespace CodeHelper.Core.Parse.ParseResults.DataModels
{
    public class Field : TokenPair
    {
        public String Name { get; set; }
        public String System_type { get; set; }
        public String Db_type { get; set; }
        public Boolean Is_null { get; set; }
        public Boolean Is_pk { get; set; }
        public List<Attribute> Attributes { get; set; }

        public FieldInfo Parse()
        {
            var field = new FieldInfo();
            field.Name = this.Name;
            field.System_type = this.System_type;
            field.Db_type = this.Db_type;
            //field.Is_null = this.Is_null;
            field.TokenPair = this;
            field.Is_pk = this.Is_pk;
            field.Nullabe = this.Is_null;
            foreach (var attr in this.Attributes)
                field.Attributes.Add(attr.Parse());

            return field;
        }
    }
}
