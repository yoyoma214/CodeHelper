using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Services;
using CodeHelper.UI;
using CodeHelper.Domain.Model;
using CodeHelper.Core.Command;
using System.IO;
using CodeHelper.Commands.WorkFlow;
using CodeHelper.Core.Parse.ParseResults.Workflows;
using CodeHelper.Common;
//using CodeHelper.Workflow.Domain.Conditions;
using CodeHelper.Data.Repository.Workflow;
//using CodeHelper.Workflow;
using CodeHelper.Data.Repository.Workflow.Models;
using System.Windows.Forms;

namespace CodeHelper.Items.WorkFlow
{
    class WorkFlowNode : ModelNode
    {
        static WorkFlowNode()
        {
            //WorkflowDB.SearchWorkflow += new OnSearchWorkflow(WorkflowDB_SearchWorkflow);
        }

        //static WorkflowInfo WorkflowDB_SearchWorkflow(string name)
        //{
        //    //读取数据库流程记录
        //    using (var ctx = new WorkflowContext())
        //    {
        //        var wf = ctx.Sys_WorkflowDefines.Where(x=>x.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
        //        if (wf == null)
        //            return null;

        //        return new WorkflowInfo() { Id = wf.Id, Name = wf.Name };
        //    }
            
        //}

        //public string AssembleName { get; set; }

        public override Dict.NodeType NodeType
        {
            get
            {
                return Dict.NodeType.WorkFlow;
            }
        }

        public override System.Windows.Forms.ContextMenu GetPopMenu()
        {
            var menu = base.GetPopMenu();
            menu.MenuItems.Add("验证语句", ValidateModel);
            //menu.MenuItems.Add("生成工作流定义", GenDBSql);
            menu.MenuItems.Add("生成数据库代码", GenDBSql);
            //menu.MenuItems.Add("生成页面代码", GenViewCode);
            menu.MenuItems.Add("生成工作流代码", GenWFCode);
            menu.MenuItems.Add("生成Model代码", GenModelCode);
            menu.MenuItems.Add("生成Mapping代码", GenMappingCode);
            menu.MenuItems.Add("生成DBContext代码", GenDBContextCode);
            menu.MenuItems.Add("插入数据库", CreateWFDefine);

            return menu;
        }

        private void ValidateModel(object sender, EventArgs args)
        {
            var codeFrm = new ShowCodeFrm();
            var model = ModelManager.Instance().GetModel(this.FileId.Value);

            var module = ModelManager.Instance().MakeSureParseModule(model.File);
            if (module == null)
            {
                System.Windows.Forms.MessageBox.Show("模块还未生成");
                return;
            }
            
            var builder = new IndentStringBuilder();
            
            ((WorkflowDB)module).Render(builder);
            codeFrm.SetText(builder.ToString());
            codeFrm.Show();
        }

        //private void GenWFDefine(object sender, EventArgs args)
        //{

        //}

        private void GenDBSql(object sender, EventArgs args)
        {
            var codeFrm = new ShowCodeFrm();
            var model = ModelManager.Instance().GetModel(this.FileId.Value);

            var module = ModelManager.Instance().MakeSureParseModule(model.File);
            if (module == null)
            {
                System.Windows.Forms.MessageBox.Show("模块还没解析");
                return;
            }

            module.Name = this.Name;
            var builder = new IndentStringBuilder();
            ((WorkflowDB)module).RenderSql(Configer.WFDBType, builder);
            codeFrm.SetText(builder.ToString());
            codeFrm.Show();
        }

        private void GenWFCode(object sender, EventArgs args)
        {
            var codeFrm = new ShowCodeFrm();
            var model = ModelManager.Instance().GetModel(this.FileId.Value);

            var module = ModelManager.Instance().MakeSureParseModule(model.File);
            if (module == null)
            {
                System.Windows.Forms.MessageBox.Show("模块还没解析");
                return;
            }

            var builder = new IndentStringBuilder();
            ((WorkflowDB)module).RenderWF(builder);
            codeFrm.SetText(builder.ToString());
            codeFrm.Show();
        }

        private void GenModelCode(object sender, EventArgs args)
        {
            var codeFrm = new ShowCodeFrm();
            var model = ModelManager.Instance().GetModel(this.FileId.Value);
            //var ns = "";
            //var p = this.Parent as FolderNode;
            //if (p != null)
            //{
            //    ns = p.NameSpace;
            //}

            var module = ModelManager.Instance().MakeSureParseModule(model.File);
            if (module == null)
            {
                System.Windows.Forms.MessageBox.Show("模块还没解析");
                return;
            }

            var builder = new IndentStringBuilder();
            //module.NameSpace = ns;
            ((WorkflowDB)module).RenderModel(builder);
            codeFrm.SetText(builder.ToString());
            codeFrm.Show();
        }

        private void GenMappingCode(object sender, EventArgs args)
        {
            var codeFrm = new ShowCodeFrm();
            var model = ModelManager.Instance().GetModel(this.FileId.Value);

            var module = ModelManager.Instance().MakeSureParseModule(model.File);
            if (module == null)
            {
                System.Windows.Forms.MessageBox.Show("模块还没解析");
                return;
            }

            var builder = new IndentStringBuilder();
            ((WorkflowDB)module).RenderMapping(builder);
            codeFrm.SetText(builder.ToString());
            codeFrm.Show();
        }

        private void GenDBContextCode(object sender, EventArgs args)
        {
            var codeFrm = new ShowCodeFrm();
            var model = ModelManager.Instance().GetModel(this.FileId.Value);

            var module = ModelManager.Instance().MakeSureParseModule(model.File);
            if (module == null)
            {
                System.Windows.Forms.MessageBox.Show("模块还没解析");
                return;
            }

            var builder = new IndentStringBuilder();
            ((WorkflowDB)module).RenderDBContext(builder);
            codeFrm.SetText(builder.ToString());
            codeFrm.Show();
        }

        private void CreateWFDefine(object sender, EventArgs args)
        {
            /*
            try
            {
                if (!this.FileId.HasValue)
                {
                    this.FileId = ModelManager.Instance().MakeSureParseModule(this.FullName).FileId;
                }
                
                var model = ModelManager.Instance().GetModel(this.FileId.Value);

                var module = ModelManager.Instance().MakeSureParseModule(model.File);
                if (module == null)
                {
                    System.Windows.Forms.MessageBox.Show("模块还没解析");
                    return;
                }

                var wf_model = ((WorkflowDB)module);
                Guid wfId = default(Guid);

                using (var ctx = new WorkflowContext())
                {
                    var app = new CodeHelper.Workflow.AppService();
                    var wfs = app.SearchWorkflowDefine(new SearchWorkflowDefine_Condition() { Name = wf_model.Name });
                    if (wfs != null && wfs.Count > 0)
                        wfId = wfs[0].Id;
                    else
                    {
                        wfId = Guid.NewGuid();
                        var wf = new Sys_WorkflowDefine(wfId);
                        wf.Name = this.Name;
                        wf.CreateTime = DateTime.Now;
                        wf.AssembleName = "TestWF";
                        wf.Namespace = wf_model.NameSpace;
                        ctx.Sys_WorkflowDefines.Add(wf);
                    }

                    Dictionary<string, Guid> nodes = new Dictionary<string, Guid>();

                    //创建或更新节点
                    foreach (var node in wf_model.Units)
                    {
                        //var node_db = new Sys_NodeDefine(Guid.NewGuid());
                        //node_db.WFId = wfId;
                        //node_db.Name = node.Name;
                        //node_db.Status = "normal";
                        //node_db.CreateTime = DateTime.Now;
                        //node_db.Description = "auto create";
                        //ctx.Sys_NodeDefines.Add(node_db);

                        //nodes.Add(node.Name.ToLower().Trim(), node_db.Id);
                        InsertDB_Nodes(ctx, null, node, wfId, nodes);
                    }

                    //创建转变
                    foreach (var unit in wf_model.Units)
                    {
                        InsertDB_Transitions(ctx, unit, nodes);
                        //if (node.Translation == null)
                        //    continue;

                        //foreach (var tr in node.Translation.Statments)
                        //{
                        //    var transition = new Sys_Transition(Guid.NewGuid());
                        //    transition.FromNodeId = nodes[node.Name.ToLower().Trim()];
                        //    transition.ToNodeId = nodes[tr.Target.ToLower().Trim()];
                        //    var builder = new IndentStringBuilder();
                        //    //tr.Expression.Render(builder);
                        //    transition.Condition = builder.ToString();
                        //    transition.CreateTime = DateTime.Now;
                        //    ctx.Sys_Transitions.Add(transition);
                        //}
                    }
                    ctx.Commit();
                    MessageBox.Show("操作成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             */
        }

        #region InsertDB_Nodes
        private void InsertDB_Nodes(WorkflowContext ctx, Guid? lineId, ParallelInfo parallel, Guid wfId, Dictionary<string, Guid> nodes)
        {
            var node_db = new Sys_NodeDefine(Guid.NewGuid());
            node_db.WFId = wfId;
            node_db.Name = parallel.Name;
            node_db.Status = "normal";
            node_db.CreateTime = DateTime.Now;
            node_db.Description = "auto create";
            node_db.IsParallel = true;
            node_db.ExecuteLineId = lineId;
            ctx.Sys_NodeDefines.Add(node_db);
            nodes.Add(node_db.Name, node_db.Id);
            foreach (var line in parallel.ExecuteLines)
            {                
                InsertDB_Nodes(ctx, line,node_db, wfId, nodes);
            }
        }

        private void InsertDB_Nodes(WorkflowContext ctx, ExecuteLineInfo line,Sys_NodeDefine parallel, Guid wfId, Dictionary<string, Guid> nodes)
        {
            var line_db = new Sys_ExecuteLine();
            line_db.Id = Guid.NewGuid();
            line_db.Name = line.Name;
            line_db.WFId = wfId;
            line_db.CreateTime = DateTime.Now;

            ctx.Sys_ExecuteLines.Add(line_db);

            var exe_Line = new Sys_Parallel_ExecuteLine();
            exe_Line.Id = Guid.NewGuid();
            exe_Line.NodeId = parallel.Id;            
            exe_Line.ExecuteLineId = line_db.Id;
            exe_Line.CreateTime = DateTime.Now;
            ctx.Sys_Parallel_ExecuteLines.Add(exe_Line);

            foreach (var unit in line.Units)
            {
                InsertDB_Nodes(ctx,line_db.Id, unit, wfId, nodes);
            }
        }

        private void InsertDB_Nodes(WorkflowContext ctx, Guid? lineId, UnitInfo unit, Guid wfId, Dictionary<string, Guid> nodes)
        {
            if (unit.Node != null)
                InsertDB_Nodes(ctx,lineId, unit.Node,wfId, nodes);
            if (unit.Parallel != null)
                InsertDB_Nodes(ctx,lineId, unit.Parallel,wfId, nodes);
        }

        private void InsertDB_Nodes(WorkflowContext ctx, Guid? lineId, NodeInfo node, Guid wfId, Dictionary<string, Guid> nodes)
        {
            //var node_db = new Sys_NodeDefine(Guid.NewGuid());
            //node_db.WFId = wfId;
            //node_db.Name = node.Name;
            //node_db.Status = "normal";
            //node_db.CreateTime = DateTime.Now;
            //node_db.Description = "auto create";
            //node_db.IsParallel = false;
            //node_db.ExecuteLineId = lineId;
            //if (node.RefWorkflow != null)
            //{
            //    var refWf = ctx.Sys_WorkflowDefines.Where(x => x.Name.Equals(node.RefWorkflow.Target, StringComparison.OrdinalIgnoreCase))
            //        .FirstOrDefault();
            //    if (refWf == null)
            //    {
            //        MessageBox.Show(string.Format("数据库找不到工作流:{0}",node.RefWorkflow.Target));
            //        return;
            //    }
            //    node_db.RefWFId =refWf.Id;
            //}
            //nodes.Add(node.Name, node_db.Id);
            //ctx.Sys_NodeDefines.Add(node_db);
        }
        #endregion
        
        #region InsertDB_Transitions
        private void InsertDB_Transitions(WorkflowContext ctx, UnitInfo unit, Dictionary<string, Guid> nodes)
        {
            if (unit.Node != null)
                InsertDB_Transitions(ctx,  unit.Node, nodes);
            if (unit.Parallel != null)
                InsertDB_Transitions(ctx, unit.Parallel, nodes);
        }

        private void InsertDB_Transitions(WorkflowContext ctx, ParallelInfo parallelInfo, Dictionary<string, Guid> nodes)
        {
            InsertDB_Transitions(ctx, parallelInfo as NodeInfo, nodes);
            //平行节点默认跳转到每个执行线上的第一个节点

            foreach (var line in parallelInfo.ExecuteLines)
            {
                var fistNodeInLine = nodes[line.Units[0].Name];
                var transition = new Sys_Transition(Guid.NewGuid());
                transition.FromNodeId = nodes[parallelInfo.Name.ToLower().Trim()];
                transition.ToNodeId = fistNodeInLine;
                transition.Condition = "true";
                transition.CreateTime = DateTime.Now;
                ctx.Sys_Transitions.Add(transition);

                InsertDB_Transitions(ctx, line, nodes);
            }
        }

        private void InsertDB_Transitions(WorkflowContext ctx, ExecuteLineInfo line, Dictionary<string, Guid> nodes)
        {
            foreach (var unit in line.Units)
            {
                InsertDB_Transitions(ctx, unit, nodes);
            }
        }

        private void InsertDB_Transitions(WorkflowContext ctx, NodeInfo nodeInfo, Dictionary<string, Guid> nodes)
        {
            if (nodeInfo.Translation == null ||
                nodeInfo.Translation.Statments == null)
                return;

            foreach (var tr in nodeInfo.Translation.Statments)
            {
                var transition = new Sys_Transition(Guid.NewGuid());
                transition.FromNodeId = nodes[nodeInfo.Name.ToLower().Trim()];
                transition.ToNodeId = nodes[tr.Target.ToLower().Trim()];
                var builder = new IndentStringBuilder();
                tr.Expression.Render(builder);
                transition.Condition = builder.ToString();
                transition.CreateTime = DateTime.Now;
                ctx.Sys_Transitions.Add(transition);
            }
        }
        #endregion

        private void GenViewCode(object sender, EventArgs args)
        {
            var codeFrm = new ShowCodeFrm();
            var model = ModelManager.Instance().GetModel(this.FileId.Value);

            var module = ModelManager.Instance().MakeSureParseModule(model.File);
            if (module == null)
            {
                System.Windows.Forms.MessageBox.Show("模块还没解析");
                return;
            }
            
            var builder = new StringBuilder();
            //((WorkflowlDB)module).RenderView(builder);
            codeFrm.SetText(builder.ToString());
            codeFrm.Show();
        }

        public override string Extension
        {
            get { return Dict.Extenstions.WorkFlow_Extension; }
            set { }
        }

        public override void Load()
        {
            this.Name = Path.GetFileNameWithoutExtension(this.FullName);
            
            base.Load();
        }

        public override void OnDoubleClick()
        {
            var cmd = CommandHostManager.Instance().Get<OpenWorkFlowCommand>(
                CommandHostManager.HostType.WorkFlow, Dict.Commands.OpenWorkFlow);

            cmd.File = this.FullName;

            cmd.Execute();

            base.OnDoubleClick();
        }
    }
}
