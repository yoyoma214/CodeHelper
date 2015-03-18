using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.ViewModels;
using CodeHelper.Core.Parse;

namespace CodeHelper.Domain.Model.ViewModels
{
    public class ViewModel : BaseModel
    {
        internal ViewModel() { }

        public ViewModelDB ModelDB { get; set; }

        public override Core.Parser.ParseType ParseType
        {
            get
            {
                return Core.Parser.ParseType.ViewModel ;
            }
            set
            {
                base.ParseType = value;
            }
        }
    }
}
