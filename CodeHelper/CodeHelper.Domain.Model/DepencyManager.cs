using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ModuleRelations;
using CodeHelper.Core.Parser;

namespace CodeHelper.Domain.Model
{
    public class DepencyManager : IDepencyManager
    {
        Dictionary<Guid, IModuleRelation> moduleRelations = new Dictionary<Guid, IModuleRelation>();
        Dictionary<Guid, IParseModule> modules = new Dictionary<Guid, IParseModule>();

        private DepencyManager() { }

        private static DepencyManager instance = new DepencyManager();

        public static DepencyManager Instance()
        {
            return instance;
        }

        public void AddRelation(IModuleRelation relation)
        {
            moduleRelations.Add(relation.ModuleId.Value, relation);
        }

        public void RemoveRelation(IModuleRelation relation)
        {
            moduleRelations.Remove(relation.ModuleId.Value);
        }

        public void UpdateRelation(IModuleRelation relation)
        {
            if (moduleRelations.ContainsKey(relation.ModuleId.Value))
            {
                moduleRelations[relation.ModuleId.Value] = relation;
            }
            else
            {
                moduleRelations.Add(relation.ModuleId.Value, relation);
            }
        }

        public List<IModuleRelation> GetFollows(Guid moduleId)
        {
            if (!this.moduleRelations.ContainsKey(moduleId))
            {
                return new List<IModuleRelation>(0);
            }

            var m = this.moduleRelations[moduleId];

            return m.Follows;
        }

        public List<IModuleRelation> GetFollows(List<Guid> moduleIds)
        {
            List<IModuleRelation> rslt = new List<IModuleRelation>();

            moduleIds.ForEach(x => rslt.AddRange(this.GetFollows(x)));
            return rslt;
        }

        public void AddModule(IParseModule module)
        {
            modules.Add(module.FileId, module);
        }

        public void RemoveModule(Guid fileId)
        {
            if (this.modules.ContainsKey(fileId))
            {
                modules.Remove(fileId);
            }
        }

        public IParseModule GetModule(Guid fileId)
        {
            if (this.modules.ContainsKey(fileId))
            {
                return modules[fileId];
            }
            return null;
        }

        public IModuleRelation GetRelation(Guid fileId)
        {
            if (this.moduleRelations.ContainsKey(fileId))
                return this.moduleRelations[fileId];

            return null;
        }
    }
}
