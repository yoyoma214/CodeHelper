using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure.Model;

namespace CodeHelper.Domain.Model.DataModels
{
    public class DataModel : BaseModel
    {
        public override Core.Parser.ParseType ParseType
        {
            get
            {
                return Core.Parser.ParseType.DataModel;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}
