using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ParseResults.DataModels
{
    public class Model : TokenPair
    {
        public String Name { get; set; }
        public List<Field> Fields { get; set; }
        public List<Model> Models { get; set; }
        public List<Attribute> Attributes { get; set; }

        public ModelInfo Parse()
        {
            var model = new ModelInfo();
            model.Name = this.Name;
            model.TokenPair = this;
            foreach (var attr in Attributes)
            {
                model.Attributes.Add(attr.Parse());
            }

            foreach (var field in this.Fields)
            {
                model.Fields.Add(field.Parse());
            }

            foreach (var m in this.Models)
            {
                model.Models.Add(m.Parse());
            }

            return model;
        }
    }
}
