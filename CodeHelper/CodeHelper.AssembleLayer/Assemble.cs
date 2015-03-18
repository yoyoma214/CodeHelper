using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CodeHelper.Domain.Model.DataModels;
using CodeHelper.Core.Infrastructure;
using CodeHelper.Core.Infrastructure.Model;
using System.IO;
using CodeHelper.Core.Services;
using CodeHelper.Domain.EditorController;
using CodeHelper.Editors;
using CodeHelper.Core;

using CodeHelper.Domain.Model;
using CodeHelper.Domain.Controller.EditorController;

namespace CodeHelper.AssembleLayer
{
    /// <summary>
    /// 保证系统中一个文件有自己的模型，控制器，编辑器；且只能有一个这个组合！
    /// </summary>
    public class Assemble
    {
        public static EditorContext CreateEditor(string file)
        {
            IEditor editor = null;
            IModel model = null;
            IEditorController controller = null;

            var extension = Path.GetExtension(file);

            model = ModelManager.Instance().MakeSureModel(file);

            if (GlobalService.EditorContextManager.Contains(model.FileId))
            {
                return GlobalService.EditorContextManager.Get(model.FileId);
            }

            if (extension == Dict.Extenstions.XmlModel_Extension)
            {
                editor = new XmlModelEditor();
                model.File = file;
                controller = new XmlModelEditorController();
            }

            if (extension == Dict.Extenstions.DataModel_Extension)
            {
                editor = new DataModelEditor();  
                model.File = file;
                controller = new DataModelEditorController();
            }
            if (extension == Dict.Extenstions.DataView_Extension)
            {
                editor = new DataViewEditor();
                model.File = file;
                controller = new DataViewEditorController();
            }
            if (extension == Dict.Extenstions.ViewModel_Extension)
            {
                editor = new ViewModelEditor();
                model.File = file;
                controller = new ViewModelEditorController();
            }
            if (extension == Dict.Extenstions.WorkFlow_Extension)
            {
                editor = new WorkFlowEditor();
                model.File = file;
                controller = new WorkFlowEditorController();
            }
            var context = new EditorContext();
            context.EditorContainer = editor;
            context.Model = model;
            context.Controller = controller;

            context.Controller.Bind( editor, model);

            GlobalService.EditorContextManager.Add(context);

            return context;
        }
    }
}
