using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure.Model;
using CodeHelper.Domain.Model.DataModels;

namespace CodeHelper.Domain.Model.XmlModels
{
    public class XmlModel : BaseModel
    {
        internal XmlModel() { }

        public DataModel ModelDB { get; set; }

        public override Core.Parser.ParseType ParseType
        {
            get
            {
                return Core.Parser.ParseType.XmlModel;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}
