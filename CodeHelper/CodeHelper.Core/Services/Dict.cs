using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.Services
{
    public class Dict
    {
        public enum NodeType
        {
            Unknown,
            Project,
            XmlModelSet, XmlModel,
            DataModelSet, DataModel,
            ViewModelSet, ViewModel,            
            DataViewSet,DataView,
            WorkFlowSet, WorkFlow
        }

        public static class Extenstions
        {
            public const string XmlModel_Extension = ".xm";
            public const string DataModel_Extension = ".dm";
            public const string DataView_Extension = ".dv";
            public const string ViewModel_Extension = ".vm";
            public const string WorkFlow_Extension = ".wf";
        }

        public static class Commands
        {
            public const string ExitProcess = "ExitProcess";

            public const string OpenFile = "OpenFile";
            public const string CloseFile = "CloseFile";

            public const string NewProject = "NewProject";
            public const string OpenProject = "OpenProject";
            public const string ClosePrject = "ClosePrject";

            public const string OpenDataModel = "OpenDataModel";
            public const string NewDataModel = "NewDataModel";

            public const string OpenXmlModel = "OpenXmlModel";
            public const string NewXmlModel = "NewXmlModel";

            public const string RenameModel = "Rename";

            public const string DeleteModel = "DeleteModel";
            public const string DeleteFolder = "DeleteFolder";

            public const string OpenDataView = "OpenDataView";
            public const string NewDataView = "NewDataView";

            public const string OpenViewModel = "OpenViewModel";
            public const string NewViewModel = "NewViewModel";

            public const string OpenWorkFlow = "OpenWorkFlow";
            public const string NewWorkFlow = "NewWorkFlow";
            public const string DeleteWorkFlow = "DeleteWorkFlow";

            public const string PropertySelect = "PropertySelect";
        }
    }
}
