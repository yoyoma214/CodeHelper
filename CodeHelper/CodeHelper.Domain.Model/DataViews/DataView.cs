using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.DataViews;

namespace CodeHelper.Domain.Model.DataViews
{
    public class DataView: BaseModel
    {
        internal DataView() { }

        public DataViewDB ModelDB { get; set; }

        public override Core.Parser.ParseType ParseType
        {
            get
            {
                return Core.Parser.ParseType.DataView;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}
