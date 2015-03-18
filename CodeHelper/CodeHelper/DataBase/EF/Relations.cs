using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.EF.StorageModels;

namespace CodeHelper.DataBaseHelper.EF
{
    public class EntityRelation
    {
        public string TableName { get; set; }

        public string EntityName { get; set; }

        public List<AssociationSet> AssociationSets { get; set; }
        public List<Association> Associations { get; set; }

        public List<FKRelation> FKRelations { get; set; }

        public EntityRelation()
        {
            this.FKRelations = new List<FKRelation>();
            this.AssociationSets = new List<AssociationSet>();
            this.Associations = new List<Association>();
        }

        public class FKRelation
        {
            public TableType FromTableType { get; set; }

            public TableType ToTableType { get; set; }

            public string FromColumn { get; set; }

            public string ToColumn { get; set; }

            public string FromProperty { get; set; }

            public string ToProperty { get; set; }

            public string FromMulitplicity { get; set; }

            public string ToMulitplicity { get; set; }
        }
    }
}
