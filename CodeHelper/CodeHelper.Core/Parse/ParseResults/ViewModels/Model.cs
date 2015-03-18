using System;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.ViewModels
{
    public class Model : TokenPair
    {
        public String Area { get; set; }
        public List<Attribute> Attributes { get; set; }
        public String Name { get; set; }
        public List<Field> Fields { get; set; }
        public State State { get; set; }

        public ModelInfo Parse()
        {
            var rslt = new ModelInfo(this);
            rslt.Area = Area;
            rslt.Name = Name;

            foreach (var attr in this.Attributes)
            {
                rslt.Attributes.Add(attr.Parse());
            }

            foreach (var field in this.Fields)
            {
                rslt.FieldInfos.Add(field.Parse());
            }

            this.State.Parse(rslt);

            return rslt;
        }    
    }
}
