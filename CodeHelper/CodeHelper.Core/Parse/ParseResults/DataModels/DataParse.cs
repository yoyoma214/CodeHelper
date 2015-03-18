using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Services;
using CodeHelper.Core.Error;
using CodeHelper.Common;
using CodeHelper.Core.Parser;

namespace CodeHelper.Core.Parse.ParseResults.DataModels
{    
    public class FieldInfo : PropertyInfoBase
    {
        //public String Name { get; set; }
        public String System_type { get; set; }
        public String Db_type { get; set; }
        //public bool Is_null { get; set; }
        public bool Is_pk { get; set; }

        public FieldInfo()
            : base()
        {
            this.Nullabe = true;
        }

        public override void Init()
        {
            this.Type = System_type;
            //this.Nullabe = Is_null;
            if (this.Db_type != null)
            {
                this.Db_type = this.Db_type.Replace("\"", "");
            }
            base.Init();
        }
    }

    public class MappingInfo
    {
        public AtomTokenPair FromModel { get; set; }
        public AtomTokenPair TargetModel { get; set; }
        public AtomTokenPair FromField { get; set; }
        public AtomTokenPair FromNavigateProperty { get; set; }
        public AtomTokenPair TargetField { get; set; }
        public AtomTokenPair Relation { get; set; }
        public List<AtomTokenPair> ShowFields { get; set; }
        public AtomTokenPair SplitTag { get; set; }

        public MappingInfo()
        {
            this.ShowFields = new List<AtomTokenPair>();
        }
    }

    public class ModelInfo : TypeInfoBase
    {
        //public String Name { get; set; }
        public List<FieldInfo> Fields { get; set; }
        public List<ModelInfo> Models { get; set; }

        //public List<WiseMapping> Mappings { get; set; }

        public ModelInfo()
        {
            this.Fields = new List<FieldInfo>();
            this.Models = new List<ModelInfo>();
        }

        public override void Init()
        {
            if (this.Fields != null && this.Fields.Count > 0)
            {
                this.Fields.ForEach(x => x.Init());
                this.PropertyInfos.AddRange(this.Fields);
            }

            if (this.Models != null && this.Models.Count > 0)
            {
                this.Models.ForEach(x => x.Init());
                this.TypeInfos.AddRange(this.Models);
            }

            base.Init();
        }

        public override void Wise()
        {
            base.Wise();
        }
    }

  
}
