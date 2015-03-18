using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ModuleRelations
{
    public class ModuleRelationBase : IModuleRelation
    {
        public ModuleRelationBase()
        {
            this.Dependants = new ModuleRelationList<IModuleRelation>();
            this.Follows = new ModuleRelationList<IModuleRelation>();
        }

        public Guid? ModuleId
        {
            get;
            set;
        }

        public ModuleRelationList<IModuleRelation> Dependants
        {
            get;
            set;
        }

        public ModuleRelationList<IModuleRelation> Follows
        {
            get;
            set;
        }
    }
}
