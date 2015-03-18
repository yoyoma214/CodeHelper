using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser.DataModel
{
    public class ModelDB
    {
        //private Dictionary<String, ModelInfo> models = new Dictionary<String, ModelInfo>();
        //private List<MappingInfo> mapings = new List<MappingInfo>();
        //private String nameSpace = null;

        public void AddModel(ModelInfo modelInfo)
        {
            Models.Add(modelInfo.Name, modelInfo);
        }

        public ModelInfo GetModel(String name)
        {
            return Models[name];
        }

        public Dictionary<String, ModelInfo> Models { get; set; }
        /**
         * @return the nameSpace
         */
        public String NameSpace { get; set; }

        /**
          * @return the mapings
          */
        public List<MappingInfo> Mapings { get; set; }

    }
}
