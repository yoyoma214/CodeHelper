using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.XmlModels
{
    public class FieldGroupInfo : TokenPair
    {
        public List<FieldInfo> Fields { get; set; }
        public bool IsOrder { get; set; }

        //public override void Init()
        //{
        //    this.TokenPair = this;
        //    base.Init();
        //}
    }
}
