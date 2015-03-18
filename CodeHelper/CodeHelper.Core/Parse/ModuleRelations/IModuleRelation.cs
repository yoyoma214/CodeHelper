using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Parse.ModuleRelations
{
    public interface IModuleRelation
    {
        Guid? ModuleId { get; set; }

        ModuleRelationList<IModuleRelation> Dependants { get; set; }

        ModuleRelationList<IModuleRelation> Follows { get; set; }
    }

    public class ModuleRelationList<T> : List<T> where T : IModuleRelation
    {
        public bool Contains(Guid fileId)
        {
            return this.FirstOrDefault(x => x.ModuleId == fileId) != null;
        }
    }
}
