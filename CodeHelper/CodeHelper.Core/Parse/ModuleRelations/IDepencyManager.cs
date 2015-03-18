using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parser;

namespace CodeHelper.Core.Parse.ModuleRelations
{
    public interface IDepencyManager
    {        
        void AddModule(IParseModule module);

        void RemoveModule(Guid fileId);

        IParseModule GetModule(Guid fileId);

        void AddRelation(IModuleRelation relation);

        IModuleRelation GetRelation(Guid fileId);

        void RemoveRelation(IModuleRelation relation);

        void UpdateRelation(IModuleRelation relation);

        List<IModuleRelation> GetFollows(Guid moduleId);

        List<IModuleRelation> GetFollows(List<Guid> moduleIds);

    }
}
