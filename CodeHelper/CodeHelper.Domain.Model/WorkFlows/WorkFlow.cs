using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.ViewModels;
using CodeHelper.Core.Parse;
using CodeHelper.Core.Parse.ParseResults.Workflows;

namespace CodeHelper.Domain.Model.WorkFlows
{
    public class WorkFlow : BaseModel
    {
        public WorkFlow() { 
            //this.NameSpace = 
        }

        public WorkflowDB ModelDB { get; set; }

        public override Core.Parser.ParseType ParseType
        {
            get
            {
                return Core.Parser.ParseType.WorkFlow ;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}
