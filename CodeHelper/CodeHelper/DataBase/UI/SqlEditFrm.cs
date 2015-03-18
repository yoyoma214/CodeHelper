using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project;
using Microsoft.ApplicationBlocks.Data;
using ICSharpCode.TextEditor.Document;
using CodeHelper.DataBaseHelper.Sql;
using CodeHelper.Core.Error;
using CodeHelper.Core.Parse.ParseResults.DataViews;
using CodeHelper.DataBaseHelper.GenerateUnit;
using CodeHelper.Common.Extensions;
using CodeHelper.DataBaseHelper.UI;
using CodeHelper.DataBaseHelper.Common;
using CodeHelper.Common;
using CodeHelper.DataBaseHelper.Extensions;

namespace CodeHelper.DataBaseHelper
{
    public partial class SqlEditFrm : Form
    {
        SqlType _sqlType = DBGlobalService.CurrentProjectDoc.CreateNode<SqlType>();
        public delegate void OnSave(SqlType sql, ref int hashcode);
        public event OnSave Save;
        private int Node_HashCode = 0;
        private ModelInfo ModelInfo;

        public SqlEditFrm(int node_HashCode)
            : this()
        {
            this.Node_HashCode = node_HashCode;
            this.splitContainer1.FixedPanel = FixedPanel.Panel1;
            this.splitContainer2.FixedPanel = FixedPanel.Panel2;
            //this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);
        }

        void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                var dataSource = this.dataGridView1.DataSource as List<ParseErrorInfo>;

                if (dataSource != null)
                {
                    var errorInfo = dataSource[e.RowIndex];

                    if (string.IsNullOrWhiteSpace(errorInfo.File) && errorInfo.FileId == Guid.Empty)
                    {
                        return;
                    }

                    this.textEditorControl.ActiveTextAreaControl.JumpTo(errorInfo.Line, errorInfo.CharPositionInLine);

                }
            }
        }

        public SqlEditFrm()
        {
            InitializeComponent();
            this.textEditorControl.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
            this.textEditorControl_Output.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("C#");

            this.dataGridView1.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView1_RowsAdded);
            this.dataGridView1.RowsRemoved += new DataGridViewRowsRemovedEventHandler(dataGridView1_RowsRemoved);
            this.dataGridView1.CellDoubleClick += new DataGridViewCellEventHandler(dataGridView1_CellDoubleClick);

            this.cbEncloseCondition.Checked = true;
            this.cbEncloseCondition_CheckedChanged(null, null);
            this.txtResultModel_TextChanged(null, null);
        }

        void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //foreach (DataGridViewRow row in this.dataGridView1.Rows)
            //{
            //    row.Cells[this.ColumnName.Name].Value = "Table" + (row.Index == 0 ? "" : row.Index.ToString());
            //}            
        }

        void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //if (e.RowIndex > -1)
            //{
            //    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
            //    row.Cells[this.ColumnName.Name].Value = "Table" + (e.RowIndex == 0 ? "" : e.RowIndex.ToString());
            //}            
            foreach (DataGridViewRow row in this.dataGridView1.Rows)
            {
                //if (row.Index < this.dataGridView1.Rows.Count-1)
                //{                    
                //    var name = "Table" + (row.Index == 0 ? "" : row.Index.ToString());
                //    //if (name.Equals("Table2"))
                //    //{
                //    //}
                //    row.Cells[this.ColumnName.Name].Value = name;
                //}
            }
        }
        public void UpdateItem(SqlType sqlType, string connectionString)
        {
            this._sqlType = sqlType;
            this.txtName.Text = sqlType.Name;
            this.ConnectionString = connectionString;

            //this.dataGridView1.AllowUserToAddRows = true;             

            //foreach (var s in sqlType.MySqlStatements)
            //{
            //    string tableName = s.HasTableName() ? s.TableName.Value : "";
            //    this.dataGridView1.Rows.Add(new object[] { null, tableName,s.Statement.Value });
            //}

            this.textEditorControl.Document.TextContent = sqlType.SqlStatement;
            this.cbEncloseCondition.Checked = sqlType.EncloseCondition;
            this.txtResultModel.Text = sqlType.ResultModel;

            this.cbEncloseCondition_CheckedChanged(null, null);
            this.txtResultModel_TextChanged(null, null);
        }

        private class StatementInfo
        {
            public string Statement { get; set; }
        }
        public SqlType GetItem()
        {
            return this._sqlType;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
            {
                MessageBox.Show("名字不能为空");
                return;
            }
            this._sqlType.Name = this.txtName.Text.Trim();
            //if (this._sqlType.HasPagerContentTable())
            //    this._sqlType.RemovePagerContentTable();
            //if (this._sqlType.HasPagerRecordCountTable())
            //    this._sqlType.RemovePagerRecordCountTable();

            //this.DialogResult = System.Windows.Forms.DialogResult.OK;

            //while (this._sqlType.HasSqlStatement())
            //{
            //    this._sqlType.RemoveSqlStatement();
            //}


            //SqlStatementType sql = new SqlStatementType();
            //sql.AddStatement(this.textEditorControl.Document.TextContent));

            //this._sqlType.AddSqlStatement(sql);
            this._sqlType.SqlStatement = this.textEditorControl.Document.TextContent;
            this._sqlType.EncloseCondition = this.cbEncloseCondition.Checked;
            this._sqlType.ResultModel = this.txtResultModel.Text.Trim();

            if (Save != null)
            {
                this.Save(_sqlType, ref this.Node_HashCode);
            }

            //foreach (DataGridViewRow row in this.dataGridView1.Rows)
            //{
            //    if (!row.IsNewRow)
            //    {
            //        SqlStatementType sql = new SqlStatementType();
            //        sql.AddStatement((string)row.Cells[this.ColumnSql.Name].Value));

            //        this._sqlType.AddSqlStatement(sql);
            //    }
            //}

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //this.Close();       
            this.textEditorControl.Document.UndoStack.Undo();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == 0 && !this.dataGridView1.Rows[e.RowIndex].IsNewRow)
            {
                EditSqlStatementFrm f = new EditSqlStatementFrm();
                f.SetSql(this.dataGridView1[this.ColumnSql.Index, e.RowIndex].Value.ToString());
                if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this.dataGridView1.Rows[e.RowIndex].
                        Cells[this.ColumnSql.Name].Value = f.GetSql();
                }
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            //foreach (DataGridViewRow row in this.dataGridView1.Rows)
            //{
            //    if (!row.IsNewRow)
            //    {
            //        string statment = (string)row.Cells[this.ColumnSql.Name].Value;
            //        if (string.IsNullOrWhiteSpace(statment))
            //        {
            //            MessageBox.Show("查询语句不能为空");
            //        }

            //        sb.AppendLine(statment + ";");
            //    }
            //}
            string sql = this.textEditorControl.Document.TextContent;

            if (string.IsNullOrWhiteSpace(sql))
            {
                MessageBox.Show("查询语句不能为空");
                return;
            }

            var selectSql = this.textEditorControl.ActiveTextAreaControl.SelectionManager.SelectedText;
            if (!string.IsNullOrWhiteSpace(selectSql))
            {
                sql = selectSql;
            }

            try
            {
                DataSet ds =
                   SqlHelper.ExecuteDataset(this.ConnectionString, CommandType.Text, sql);

                this.dataGridView1.Hide();

                //List<string> tables = new List<string>();
                //tables.Add("--请选择--");
                this.splitContainer2.Panel2.Controls.Clear();
                List<DataGridView> dgvStack = new List<DataGridView>();
                foreach (DataTable m in ds.Tables)
                {
                    //tables.Add(m.TableName);
                    var dgv = new DataGridView();
                    dgv.AllowUserToAddRows = false;
                    dgv.DataSource = m;
                    dgv.Dock = DockStyle.Fill;
                    dgv.AllowUserToDeleteRows = false;

                    dgvStack.Add(dgv);
                }

                if (dgvStack.Count == 1)
                {
                    var dgv = dgvStack[0];
                    this.splitContainer2.Panel2.Controls.Add(dgv);
                }
                else
                {
                    SplitContainer parentContainer = null;

                    while (dgvStack.Count != 0)
                    {
                        if (parentContainer == null)
                        {
                            parentContainer = new SplitContainer();
                            parentContainer.Dock = DockStyle.Fill;
                            parentContainer.Orientation = Orientation.Horizontal;
                            parentContainer.Panel1.Controls.Add(dgvStack[0]);
                            parentContainer.Panel2.Controls.Add(dgvStack[1]);
                            dgvStack.RemoveAt(0);
                            dgvStack.RemoveAt(0);
                            this.splitContainer2.Panel2.Controls.Add(parentContainer);
                        }
                        else
                        {
                            var spContainer = new SplitContainer();

                            spContainer.Dock = DockStyle.Fill;
                            spContainer.Orientation = Orientation.Horizontal;

                            spContainer.Panel1.Controls.Add(dgvStack[0]);
                            dgvStack.RemoveAt(0);

                            if (dgvStack.Count > 1)
                            {
                                spContainer.Panel2.Controls.Add(dgvStack[1]);
                                dgvStack.RemoveAt(0);
                            }
                            else
                            {
                                spContainer.Panel2.Hide();
                            }
                            spContainer.Dock = DockStyle.Bottom;
                            parentContainer.Panel2.Controls.Add(spContainer);

                            parentContainer = spContainer;
                        }
                        //dgv.Dock = DockStyle.Top;
                        //this.splitContainer2.Panel2.Controls.Add(dgv);
                    }
                }

                //this.cbPagerContentTable.Text = this._sqlType.PagerContentTable.Value;
                //this.cbPagerRecordCountTable.Text = this._sqlType.PagerRecordCountTable.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询出错:" + ex.Message);
            }

        }

        public string ConnectionString { get; set; }

        private bool IsValueType(CodeHelper.Core.Parse.ParseResults.DataViews.DbType type)
        {
            return type == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Bool ||
                type == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Char ||
                type == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.DateTime ||
                type == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Float ||
                type == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Guid ||
                type == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Int
                ;
        }

        private void btnGenSearchConditionInfo_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);

                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();
                dvDB.Context.Wise(null);
                var orders = dvDB.OrderPairs;

                var condition_class = new StringBuilder();
                var parameterName = "";
                condition_class.AppendLine("using System;");
                condition_class.AppendLine("using System.Collections.Generic;");
                condition_class.AppendLine();
                condition_class.AppendLine("namespace xxx");
                condition_class.AppendLine("{");
                var query_Class = GeneratorUtil.ClassName(this.txtName.Text.Trim());
                condition_class.AppendLine(string.Format("public class {0}_Condition", query_Class));
                condition_class.AppendLine("{");
                //generate order by type
                if (dvDB.OrderPairs.Count > 0)
                {
                    condition_class.AppendLine(string.Format("\tpublic enum OrderByType"));
                    condition_class.AppendLine(("\t{"));
                    //condition_class.Append(("\t\t"));
                    foreach (var order in dvDB.OrderPairs.OrderByName())
                    {
                        condition_class.Append("\t\t" + GeneratorUtil.ClassName(order.SafeName) + "_" + order.OrderType + ",");
                        condition_class.AppendLine();
                    }
                    condition_class.AppendLine((""));
                    condition_class.AppendLine(("\t}"));
                    condition_class.AppendLine();
                    condition_class.AppendLine(("\tpublic OrderByType? OrderBy{get;set;}"));
                    condition_class.AppendLine();
                }

                foreach (var p in dvDB.Context.Parameters.OrderByName())
                {
                    parameterName = p.Name.Substring(1);
                    condition_class.AppendLine("\t" + string.Format("public {0} {1}",
                        //EnumUtils.GetDescription(p.DbType), p.NullAble && IsValueType(p.DbType) ? "?" : "", GeneratorUtil.ClassName(parameterName)));
                        p.SystemType, GeneratorUtil.ClassName(parameterName)));
                    condition_class.AppendLine("\t" + "{get;set;}");
                    condition_class.AppendLine();

                    foreach (var option in p.Options)
                    {
                        if (option.Name.Equals("op", StringComparison.OrdinalIgnoreCase))
                        {
                            if (option.Value.Equals("all", StringComparison.OrdinalIgnoreCase))
                            {
                                condition_class.AppendLine("\t" + string.Format("public enum {0}_ConditionType",
                                    GeneratorUtil.ClassName(parameterName)));
                                condition_class.AppendLine("\t" + "{");
                                condition_class.AppendLine("\t\t" + "GT,GT_EQ,LT,LT_EQ,EQ,NOT_EQ,BETWEEN");
                                condition_class.AppendLine("\t" + "}");
                                condition_class.AppendLine();
                                condition_class.AppendLine("\t" + string.Format("public {0}_ConditionType {0}_Condition",
                                    GeneratorUtil.ClassName(parameterName)) + "{get;set;}");
                                condition_class.AppendLine();
                            }
                        }
                    }
                }
                condition_class.AppendLine();
                if (dvDB.IsPager)
                {
                    condition_class.AppendLine("\t" + "public int PageIndex{get;set;}");
                    condition_class.AppendLine("\t" + "public int PageSize{get;set;}");
                    condition_class.AppendLine("\t" + "public int RecordCount{get;set;}");
                }

                condition_class.AppendLine(string.Format("\t" + "public {0}_Condition()", query_Class));
                condition_class.AppendLine("\t{");
                foreach (var p in dvDB.Context.Parameters.OrderByName())
                {
                    if (p.SystemType.StartsWith("List<"))
                    {
                        condition_class.AppendLine(string.Format("\t\tthis.{0} = new {1}();", p.ClassName, p.SystemType));
                    }
                }

                condition_class.AppendLine("\t}");

                condition_class.AppendLine("}");
                condition_class.AppendLine("}");
                AppendHeader(condition_class);

                textEditorControl_Output.Document.TextContent = condition_class.ToString();// dvDB.Context.Render();
                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
                textEditorControl_Output.Refresh();
            }
        }

        private void OnError(List<ParseErrorInfo> errors)
        {
            if (errors != null && errors.Count > 0)
            {
                if (this.dataGridView1.Parent == null)
                {
                    this.splitContainer2.Panel2.Controls.Clear();
                    this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
                }
                this.dataGridView1.DataSource = errors;
                this.dataGridView1.Columns[0].Visible = false;
                this.dataGridView1.Columns[1].Visible = false;
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].Width = 400;

            }
            else
            {
                this.dataGridView1.DataSource = null;
            }
        }

        private void AppendHeader(StringBuilder builder, string file = null)
        {
            var content = builder.ToString();

            if (!content.StartsWith("#region COPYRIGHT COMPANY SOLUTIONS"))
            {
                var filename = "";

                var tag = "public class";
                var tagLength = tag.Length;

                var tagIndex = content.IndexOf(tag);
                if (tagIndex < 0)
                {
                    tag = "public interface";
                    tagLength = tag.Length;
                    tagIndex = content.IndexOf(tag);
                }
                if (tagIndex < 0)
                {
                    tag = "public static class";
                    tagLength = tag.Length;
                    tagIndex = content.IndexOf(tag);
                }

                if (tagIndex > -1)
                {
                    try
                    {
                        content.Substring(tagIndex + tag.Length).ToList().ForEach(
                            c =>
                            {
                                if (c == ':' || c == '\r' || c == '\n' || c == '{')
                                {
                                    throw new Exception("终止查找");
                                }
                                else
                                {
                                    filename += c;
                                }
                            }
                            );
                    }
                    catch
                    {
                    }
                    var coreId = System.Configuration.ConfigurationManager.AppSettings["CoreId"];
                    var crno = System.Configuration.ConfigurationManager.AppSettings["CRNO"];
                    if (crno == null) crno = "";
                    crno = crno.PadLeft(14);

                    filename = filename.Trim();
                    if (!string.IsNullOrWhiteSpace(file))
                    {
                        filename = file.Trim();
                    }
                    var header = string.Format(string.Format(@"#region COPYRIGHT COMPANY
/*******************************************************************************
*                     COPYRIGHT 2014 COMPANY SOLUTIONS, INC
*                           ALL RIGHTS RESERVED.
*                     COMPANY SOLUTIONS CONFIDENTIAL PROPRIETARY
********************************************************************************
*
*   FILE NAME       : {0}.cs
*
*--------------------------------- REVISIONS -----------------------------------
* CR/PR             Core ID   Date        Description
* ---------------   --------  ----------  --------------------------------------
* {1}    {2}   {3}   Creation
*******************************************************************************/
#endregion
", filename, crno, coreId, DateTime.Now.ToString("MM/dd/yyyy")) + "\r\n");
                    //header += "{\r\n";

                    builder.Insert(0, header);

                    //builder.Append("}");
                }
            }
        }

        private void btnGenEFFunction_Click(object sender, EventArgs e)
        {

            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);
                SelectContext.Root = dvDB.Context;
                SelectContext.Root.CurrentQuery = GeneratorHelper.ClassName(this.txtName.Text.Trim());
                dvDB.InitOption();
                dvDB.Context.Wise(null);

                if (dvDB.Context.Unions.Count == 0 || dvDB.Context.Unions[0].Context.TableJoinInfos.Count == 0
                    || dvDB.Context.Unions[0].Context.TableJoinInfos[0].RightModelInfo == null)
                    return;

                if (dvDB.Context.Unions[0].Context.TableJoinInfos.Count == 1)
                {
                    this.GenEFFunction_OneTable(dvDB);
                    return;
                }

                if (dvDB.Context.Unions[0].Context.TableJoinInfos.Count > 1)
                {
                    this.GenEFFunction_MulitTable(dvDB);
                    return;
                }

            }
        }

        private void GenEFFunction_OneTable(DataViewDB dvDB)
        {
            //获得对应的model
            var modelName = "unknown";


            modelName = GeneratorUtil.ClassName(this.txtResultModel.Text.Trim());


            //生成spacification
            var spec_class = new StringBuilder();
            //推断出model类名
            var condition_class = GeneratorUtil.ClassName(this.txtName.Text.Trim() + "_Condition");
            var condition_variable = "condition";

            spec_class.AppendLine(string.Format("public static ISpecification<{0}> {1}({2} {3})"
                , modelName, GeneratorUtil.ClassName(this.txtName.Text.Trim()), condition_class, condition_variable));

            spec_class.AppendLine("{");
            var spec = dvDB.Context.Unions[0].Context.Condition.RenderEFSpec(spec_class, modelName, condition_class, dvDB.Context.Parameters);
            if (string.IsNullOrWhiteSpace(spec))
            {
                spec_class.AppendLine(string.Format("\t\t return new DirectSpecification<{0}>(x=>true);", modelName));
            }
            else
            {
                spec_class.AppendLine(string.Format("\t\t return {0};", spec));
            }
            spec_class.AppendLine("}");

            var resultType = string.Format("List<{0}>", modelName);
            if (dvDB.IsPager)
            {
                resultType = string.Format("PageOfReturn<{0}>", modelName);
            }

            var functionName = GeneratorUtil.ClassName(this.txtName.Text);
            var conditionName = functionName + "_Condition";
            //var condition_variable = "condition";

            spec_class.AppendLine();
            spec_class.AppendLine();
            spec_class.AppendLine();
            spec_class.AppendLine(string.Format("public {0} {1}( {2} {3} )", resultType, functionName, conditionName, condition_variable));
            spec_class.AppendLine("{");
            spec_class.AppendLine(string.Format("\t var data = this.GetAll( {0}.{1}(condition ));", modelName + "Specification", functionName));
            var group = dvDB.Context.Unions[0].Context.Group;
            var returnFields = dvDB.Context.Unions[0].Context.ReturnFields;
            if (group != null && group.Fields.Count > 0)
            {
                spec_class.AppendLine(string.Format("\t data = data.GroupBy(x=> new "));
                spec_class.AppendLine("\t {");
                foreach (var f in group.Fields.OrderByName())
                {
                    spec_class.Append("\t\t x." + f);
                    if (f != group.Fields[group.Fields.Count - 1])
                    {
                        spec_class.AppendLine(", ");
                    }
                    else
                    {
                        spec_class.AppendLine();
                    }
                }
                spec_class.AppendLine("\t })");
                spec_class.AppendFormatLine("\t .Select(x => new {0}", modelName);
                spec_class.AppendLine("\t {");
                foreach (var f in returnFields.OrderByName())
                {
                    if (group.Fields.Contains(f.FullName))
                    {
                        spec_class.AppendFormatLine("\t\t {0} = x.Key.{0},", f.ShortName);
                    }
                    else
                    {
                        FunctionFieldInfo func = f as FunctionFieldInfo;
                        if (func == null)
                        {
                            spec_class.AppendFormatLine("\t\t {0} = x.{0},", f.ShortName);
                        }
                        else
                        {
                            if (func.FunctionName.Equals("count", StringComparison.OrdinalIgnoreCase))
                            {
                                spec_class.AppendFormatLine("\t\t {0} = x.Count(),", f.Alias);
                            }
                            else if (func.FunctionName.Equals("sum", StringComparison.OrdinalIgnoreCase))
                            {
                                spec_class.AppendFormatLine("\t\t {0} = x.Sum(o=>o.{1}),", f.Alias, func.ParameterFields[0].ShortName);
                            }
                            else if (func.FunctionName.Equals("avg", StringComparison.OrdinalIgnoreCase))
                            {
                                spec_class.AppendFormatLine("\t\t {0} = x.Average(o=>o.{1}),", f.Alias, func.ParameterFields[0].ShortName);
                            }
                        }
                    }
                }
                spec_class.AppendLine("\t }");

            }
            //order by 
            if (dvDB.OrderPairs.Count > 0)
            {
                spec_class.AppendLine(string.Format("\t if( condition.OrderBy.HasValue )"));
                spec_class.AppendLine("\t {");
                spec_class.AppendLine("\t\t switch(condition.OrderBy)");
                spec_class.AppendLine("\t\t {");
                foreach (var order in dvDB.OrderPairs.OrderByName())
                {
                    if (order.OrderType == DataViewDB.OrderType.Asc)
                    {
                        spec_class.AppendLine(string.Format("\t\t case {0}.OrderByType.{1}:",
                            condition_class, GeneratorUtil.ClassName(order.SafeName + "_Asc")));

                        spec_class.AppendLine(string.Format("\t\t\t data = data.OrderBy(x=>x.{0});", order.FieldName));
                        spec_class.AppendLine("\t\t\t break;");

                    }
                    else if (order.OrderType == DataViewDB.OrderType.Desc)
                    {
                        spec_class.AppendLine(string.Format("\t\t case {0}.OrderByType.{1}:",
                            condition_class, GeneratorUtil.ClassName(order.SafeName + "_Desc")));
                        spec_class.AppendLine(string.Format("\t\t\t data = data.OrderByDescending(x=>x.{0});", order.FieldName));
                        spec_class.AppendLine("\t\t\t break;");

                    }
                }
                spec_class.AppendLine("\t\t default:");
                spec_class.AppendLine("\t\t\t break;");
                spec_class.AppendLine("\t\t }");
                spec_class.AppendLine("\t }");
            }
            var top = dvDB.Context.Unions[0].Context.TopValue;
            if (top != null)
            {
                if (top.IsParameter)
                {
                    spec_class.AppendLine(string.Format("\t data = data.Take(x.{0});", top.ClassName));
                }
                else if (top is ValueFieldInfo)
                {
                    spec_class.AppendLine(string.Format("\t data = data.Take({0});", ((ValueFieldInfo)top).Value));
                }
            }
            if (dvDB.IsPager)
            {
                spec_class.AppendLine(string.Format("\t var result = new {0}();", resultType));
                spec_class.AppendLine(string.Format("\t result.RecordCount = data.Count();", resultType));
                spec_class.AppendLine(string.Format("\t result.PageIndex = condition.PageIndex;", resultType));
                spec_class.AppendLine(string.Format("\t result.PageSize = condition.PageSize;", resultType));
                spec_class.AppendLine(string.Format("\t result.PageRecords = data.Skip(condition.PageSize * (condition.PageIndex - 1)).Take(condition.PageSize).ToList();", resultType));
                spec_class.AppendLine(string.Format("\t return result;", resultType));
            }
            else
            {
                spec_class.AppendLine(string.Format("\t return data.ToList();", resultType));
            }

            spec_class.AppendLine("}");

            spec_class.AppendLine();

            textEditorControl_Output.Document.TextContent = spec_class.ToString();// dvDB.Context.Render();

            textEditorControl_Output.Refresh();

            var frm = new ShowCodeFrm();
            frm.Show();
            frm.SetText(textEditorControl_Output.Document.TextContent);
        }

        private void GenEFFunction_MulitTable(DataViewDB dvDB)
        {
            //获得对应的model
            var modelName = "unknown";

            modelName = GeneratorUtil.ClassName(this.txtResultModel.Text.Trim());

            var functionName = GeneratorUtil.ClassName(this.txtName.Text);
            var conditionName = functionName + "_Condition";
            var resultType = string.Format("List<{0}>", modelName);
            if (dvDB.IsPager)
            {
                resultType = string.Format("PageOfReturn<{0}>", modelName);
            }
            var condition_class = GeneratorUtil.ClassName(this.txtName.Text.Trim() + "_Condition");
            var condition_variable = "condition";

            var builder = new StringBuilder();
            builder.AppendLine();

            //生成相关的join条件类
            for (var i = 1; i < dvDB.Context.Unions[0].Context.TableJoinInfos.Count; i++)
            {
                List<FieldInfo> join_codition_fields = new List<FieldInfo>();
                var joinInfo_prev = dvDB.Context.Unions[0].Context.TableJoinInfos[i - 1];
                var joinInfo = dvDB.Context.Unions[0].Context.TableJoinInfos[i];
                var conditions = joinInfo.Condition.Conditions[0].CompareComplexConditionInfos;
                if (conditions.Count > 1)
                {
                    for (var index = 0; index < conditions.Count; index++)
                    {
                        var binary = conditions[index].AtomConditionInfo as BinaryConditionInfo;
                        join_codition_fields.Add(binary.LeftValue);
                    }
                    var join_info_name = GeneratorHelper.ClassName(this.txtName.Text.Trim() + "_" + joinInfo_prev.Alias + "_" + joinInfo.Alias + "_JoinCondition");
                    builder.AppendFormat("class {0}", join_info_name);
                    builder.AppendLine();
                    builder.AppendLine("{");
                    foreach (var field in join_codition_fields)
                    {
                        //关联时可能其中一个为可空
                        var systemType = EnumUtils.GetDescription(field.DbType);
                        if (this.IsValueType(field.DbType) && field.DbType != CodeHelper.Core.Parse.ParseResults.DataViews.DbType.String)
                            systemType += "?";

                        builder.AppendFormat("\tinternal {0} {1}", systemType, field.ClassName);
                        builder.AppendLine("\t{get;set;}");
                    }
                    builder.AppendLine("}");
                    builder.AppendLine();
                }
            }

            builder.AppendLine(string.Format("public {0} {1}( {2} {3} )", resultType, functionName, conditionName, condition_variable));
            builder.AppendLine("{");
            builder.AppendLine("\t " + DBGlobalService.DbContexUsingClause);
            builder.AppendLine("\t {");
            dvDB.Context.RenderEF(builder);
            //builder.AppendLine(string.Format("\t var data = this.GetAll( {0}.{1}(condition ));", modelName + "Specification", functionName));


            builder.Append(string.Format("\t var list = q_final.Select(x=>new {0}()", modelName));
            builder.AppendLine("{");
            var first_return_field = "";
            foreach (var f in dvDB.Context.Unions[0].Context.ReturnFields)
            {
                if (f is MutiField)
                {
                    var mutiField = f as MutiField;
                    foreach (var field in mutiField.AllFields)
                    {
                        if (string.IsNullOrWhiteSpace(first_return_field)) first_return_field = field.ClassName;
                        builder.AppendLine(string.Format("\t\t {0} = x.{1}.{2},", field.ClassName, mutiField.Table, field.FullName));
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(first_return_field)) first_return_field = f.ClassName;
                    builder.AppendLine(string.Format("\t\t {0} = x.{1},", f.ClassName, f.FullName));
                }
            }
            builder.AppendLine("\t });");

            //order by 
            if (dvDB.OrderPairs.Count > 0)
            {
                builder.AppendLine(string.Format("\t if( condition.OrderBy.HasValue )"));
                builder.AppendLine("\t {");
                builder.AppendLine("\t\t switch(condition.OrderBy)");
                builder.AppendLine("\t\t {");
                foreach (var order in dvDB.OrderPairs)
                {
                    if (order.OrderType == DataViewDB.OrderType.Asc)
                    {
                        builder.AppendLine(string.Format("\t\t case {0}.OrderByType.{1}:",
                            condition_class, GeneratorUtil.ClassName(order.SafeName + "_Asc")));

                        builder.AppendLine(string.Format("\t\t\t list = list.OrderBy(x=>x.{0});", order.FieldName));
                        builder.AppendLine("\t\t\t break;");

                    }
                    else if (order.OrderType == DataViewDB.OrderType.Desc)
                    {
                        builder.AppendLine(string.Format("\t\t case {0}.OrderByType.{1}:",
                            condition_class, GeneratorUtil.ClassName(order.SafeName + "_Desc")));
                        builder.AppendLine(string.Format("\t\t\t list = list.OrderByDescending(x=>x.{0});", order.FieldName));
                        builder.AppendLine("\t\t\t break;");

                    }
                }
                builder.AppendLine("\t\t }");
                builder.AppendLine("\t }");
            }
            if (dvDB.IsPager)
            {
                if (dvDB.OrderPairs.Count == 0)
                {
                    builder.AppendLine(string.Format("\t list = list.OrderBy( x=>x.{0});//if no order,ef cannot pager!!!", first_return_field));
                }
                builder.AppendLine(string.Format("\t var result = new {0}();", resultType));
                builder.AppendLine(string.Format("\t result.RecordCount = list.Count();", resultType));
                builder.AppendLine(string.Format("\t result.PageIndex = condition.PageIndex;", resultType));
                builder.AppendLine(string.Format("\t result.PageSize = condition.PageSize;", resultType));
                builder.AppendLine(string.Format("\t result.PageRecords = list.Skip(condition.PageSize * (condition.PageIndex - 1)).Take(condition.PageSize).ToList();", resultType));
                builder.AppendLine(string.Format("\t return result;", resultType));
            }
            else
            {
                /*
                builder.Append(string.Format("\t return list.Select(x=>new {0}()", modelName));
                builder.AppendLine("{");
                foreach (var f in dvDB.Context.Unions[0].Context.ReturnFields)
                {
                    if (f is MutiField)
                    {
                        var mutiField = f as MutiField;
                        foreach (var field in mutiField.AllFields)
                        {
                            builder.AppendLine(string.Format("\t\t {0} = x.{1}.{2},", field.ClassName, mutiField.Table, field.FullName));
                        }
                    }
                    else
                    {
                        builder.AppendLine(string.Format("\t\t {0} = x.{1},", f.ClassName, f.FullName));
                    }
                }
                builder.AppendLine("\t }).ToList();");
                 */

                builder.AppendLine(string.Format("\t return list.ToList();", modelName));
            }

            builder.AppendLine("\t }");
            //builder.AppendLine(string.Format("\t return default({0});", resultType));
            builder.AppendLine("}");

            builder.AppendLine();

            textEditorControl_Output.Document.TextContent = builder.ToString();// dvDB.Context.Render();

            textEditorControl_Output.Refresh();

            var frm = new ShowCodeFrm();
            frm.Show();
            frm.SetText(textEditorControl_Output.Document.TextContent);
        }

        private void btnGenSearchConditionDto_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;

            if (dvDB != null)
            {
                OnError(dvDB.Errors);
                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();
                dvDB.Context.Wise(null);
                var orders = dvDB.OrderPairs;

                var condition_class = new StringBuilder();
                var parameterName = "";
                var query_Class = GeneratorUtil.ClassName(this.txtName.Text.Trim());

                condition_class.AppendLine("using System;");
                condition_class.AppendLine("using System.Collections.Generic;");
                condition_class.AppendLine("using System.Runtime.Serialization;");
                condition_class.AppendLine();
                condition_class.AppendLine("namespace xxx");
                condition_class.AppendLine("{");
                condition_class.AppendLine("\t[DataContract]");
                condition_class.AppendLine(string.Format("\tpublic class {0}_ConditionDto", query_Class));
                condition_class.AppendLine("\t{");
                //generate order by type
                if (dvDB.OrderPairs.Count > 0)
                {
                    condition_class.AppendLine("\t\t[DataContract]");
                    condition_class.AppendLine(string.Format("\t\tpublic enum OrderByType"));
                    condition_class.AppendLine(("\t\t{"));
                    //condition_class.Append(("\t\t"));
                    foreach (var order in dvDB.OrderPairs.OrderByName())
                    {
                        condition_class.AppendLine("\t\t\t[EnumMember]");
                        condition_class.AppendLine("\t\t\t" + GeneratorUtil.ClassName(order.SafeName) + "_" + order.OrderType + ",");
                    }
                    condition_class.AppendLine((""));
                    condition_class.AppendLine(("\t\t}"));
                    condition_class.AppendLine();
                    condition_class.AppendLine("\t\t[DataMember]");
                    condition_class.AppendLine(("\t\tpublic OrderByType? OrderBy{get;set;}"));
                    condition_class.AppendLine();
                }

                foreach (var p in dvDB.Context.Parameters.OrderByName())
                {
                    parameterName = p.Name.Substring(1);
                    condition_class.AppendLine("\t\t[DataMember]");
                    condition_class.AppendLine("\t\t" + string.Format("public {0} {1}",
                         p.SystemType, GeneratorUtil.ClassName(parameterName)));
                    condition_class.AppendLine("\t\t" + "{get;set;}");
                    condition_class.AppendLine();

                    foreach (var option in p.Options)
                    {
                        if (option.Name.Equals("op", StringComparison.OrdinalIgnoreCase))
                        {
                            if (option.Value.Equals("all", StringComparison.OrdinalIgnoreCase))
                            {
                                condition_class.AppendLine("\t\t[DataContract]");
                                condition_class.AppendLine("\t\t" + string.Format("public enum {0}_ConditionType",
                                    GeneratorUtil.ClassName(parameterName)));
                                condition_class.AppendLine("\t\t" + "{");
                                condition_class.AppendLine("\t\t\t[EnumMember]");
                                condition_class.AppendLine("\t\t\t" + "GT,");
                                condition_class.AppendLine("\t\t\t[EnumMember]");
                                condition_class.AppendLine("\t\t\t" + "GT_EQ,");
                                condition_class.AppendLine("\t\t\t[EnumMember]");
                                condition_class.AppendLine("\t\t\t" + "LT,");
                                condition_class.AppendLine("\t\t\t[EnumMember]");
                                condition_class.AppendLine("\t\t\t" + "LT_EQ,");
                                condition_class.AppendLine("\t\t\t[EnumMember]");
                                condition_class.AppendLine("\t\t\t" + "EQ,");
                                condition_class.AppendLine("\t\t\t[EnumMember]");
                                condition_class.AppendLine("\t\t\t" + "NOT_EQ,");
                                condition_class.AppendLine("\t\t\t[EnumMember]");
                                condition_class.AppendLine("\t\t\t" + "BETWEEN");
                                condition_class.AppendLine("\t\t" + "}");
                                condition_class.AppendLine();
                                condition_class.AppendLine("\t\t\t[DataMember]");
                                condition_class.AppendLine("\t\t"
                                    + string.Format("\tpublic {0}_ConditionType {0}_Condition"
                                    , GeneratorUtil.ClassName(parameterName)) + "{get;set;}");

                                condition_class.AppendLine();
                            }
                        }
                    }
                }
                if (dvDB.IsPager)
                {
                    condition_class.AppendLine("\t\t[DataMember]");
                    condition_class.AppendLine("\t\t" + "public int PageIndex{get;set;}");
                    condition_class.AppendLine("\t\t[DataMember]");
                    condition_class.AppendLine("\t\t" + "public int PageSize{get;set;}");
                    condition_class.AppendLine("\t\t[DataMember]");
                    condition_class.AppendLine("\t\t" + "public int RecordCount{get;set;}");
                }

                condition_class.AppendLine(string.Format("\t\t" + "public {0}_ConditionDto()", query_Class));
                condition_class.AppendLine("\t\t{");
                foreach (var p in dvDB.Context.Parameters.OrderByName())
                {
                    if (p.SystemType.StartsWith("List<"))
                    {
                        condition_class.AppendLine(string.Format("\t\t\tthis.{0} = new {1}();", p.ClassName, p.SystemType));
                    }
                }

                condition_class.AppendLine("\t\t}");
                condition_class.AppendLine("\t}");
                condition_class.AppendLine("}");

                AppendHeader(condition_class);

                textEditorControl_Output.Document.TextContent = condition_class.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
            }
        }

        private void btnConvertConditionDtoToDomain_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }

            if (dvDB != null)
            {
                OnError(dvDB.Errors);
                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();
                dvDB.Context.Wise(null);
                var orders = dvDB.OrderPairs;
                var dtoName = string.Format("{0}_ConditionDto", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var dtoName_variable = GeneratorUtil.VariableName(dtoName);
                var domainName = string.Format("{0}_Condition", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var domainName_variable = GeneratorUtil.VariableName(domainName);

                dtoName_variable = "condtionDto";

                var condition_class = new StringBuilder();

                if (DBGlobalService.UseAutoMapper)
                {
                    condition_class.AppendFormat("Mapper.CreateMap<{0}, {1}>();", dtoName, domainName);
                }
                else
                {
                    condition_class.AppendLine(string.Format("public static {0} ConvertTo{0}({1} {2})", domainName, dtoName, dtoName_variable));
                    condition_class.AppendLine("{");
                    condition_class.AppendLine(string.Format("\treturn new {0}()", domainName));
                    condition_class.AppendLine("\t{");
                    if (dvDB.OrderPairs.Count > 0)
                    {
                        condition_class.AppendLine(string.Format("\t\tOrderBy=({1}.OrderByType?){0}.OrderBy,", dtoName_variable, domainName));
                    }
                    foreach (var p in dvDB.Context.Parameters.OrderByName())
                    {
                        var parameterName = GeneratorUtil.ClassName(p.Name.Substring(1));
                        condition_class.AppendLine(string.Format("\t\t{0}={1}.{0},", parameterName, dtoName_variable));

                        foreach (var option in p.Options)
                        {
                            if (option.Name.Equals("op", StringComparison.OrdinalIgnoreCase))
                            {
                                if (option.Value.Equals("all", StringComparison.OrdinalIgnoreCase))
                                {
                                    condition_class.AppendLine(string.Format("\t\t{0}_Condition=({1}.{0}_ConditionType){2}.{0}_Condition,", parameterName, domainName, dtoName_variable));
                                }
                            }
                        }
                    }

                    if (dvDB.IsPager)
                    {
                        condition_class.AppendLine(string.Format("\t\tPageIndex={0}.PageIndex,", dtoName_variable));
                        condition_class.AppendLine(string.Format("\t\tPageSize={0}.PageSize,", dtoName_variable));
                        condition_class.AppendLine(string.Format("\t\tRecordCount={0}.RecordCount,", dtoName_variable));
                    }

                    condition_class.AppendLine("\t};");
                    condition_class.AppendLine("}");
                }

                textEditorControl_Output.Document.TextContent = condition_class.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
            }
        }

        private void btntConvertConditionDomainToDto_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);
                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();
                dvDB.Context.Wise(null);
                var orders = dvDB.OrderPairs;
                var dtoName = string.Format("{0}_ConditionDto", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var dtoName_variable = GeneratorUtil.VariableName(dtoName);
                var domainName = string.Format("{0}_Condition", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var domainName_variable = GeneratorUtil.VariableName(domainName);

                domainName_variable = "condition";

                var condition_class = new StringBuilder();
                if (DBGlobalService.UseAutoMapper)
                {
                    condition_class.AppendFormat("Mapper.CreateMap<{0}, {1}>();", domainName, dtoName);
                }
                else
                {
                    condition_class.AppendLine(string.Format("public static {0} ConvertTo{0}({1} {2})", dtoName, domainName, domainName_variable));
                    condition_class.AppendLine("{");
                    condition_class.AppendLine(string.Format("\treturn new {0}()", dtoName));
                    condition_class.AppendLine("\t{");
                    if (dvDB.OrderPairs.Count > 0)
                    {
                        condition_class.AppendLine(string.Format("\t\tOrderBy=({1}.OrderByType?){0}.OrderBy,", domainName_variable, dtoName));
                    }
                    foreach (var p in dvDB.Context.Parameters.OrderByName())
                    {
                        var parameterName = GeneratorUtil.ClassName(p.Name.Substring(1));
                        condition_class.AppendLine(string.Format("\t\t{0}={1}.{0},", parameterName, domainName_variable));

                        foreach (var option in p.Options)
                        {
                            if (option.Name.Equals("op", StringComparison.OrdinalIgnoreCase))
                            {
                                if (option.Value.Equals("all", StringComparison.OrdinalIgnoreCase))
                                {
                                    condition_class.AppendLine(string.Format("\t\t{0}_Condition=({1}.{0}_ConditionType){2}.{0}_Condition,", parameterName, dtoName, domainName_variable));
                                }
                            }
                        }
                    }

                    if (dvDB.IsPager)
                    {
                        condition_class.AppendLine(string.Format("\t\tPageIndex={0}.PageIndex,", domainName_variable));
                        condition_class.AppendLine(string.Format("\t\tPageSize={0}.PageSize,", domainName_variable));
                        condition_class.AppendLine(string.Format("\t\tRecordCount={0}.RecordCount,", domainName_variable));
                    }

                    condition_class.AppendLine("\t};");
                    condition_class.AppendLine("}");
                }

                textEditorControl_Output.Document.TextContent = condition_class.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
            }

        }

        private void btnGenView_Click(object sender, EventArgs e)
        {
            try
            {
                List<ParseErrorInfo> errors;

                ContextMenu contextMenu;

                DataViewDB dvDB;

                SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

                textEditorControl_Output.Document.TextContent = null;

                if (dvDB == null)
                {
                    OnError(SqlParser.Instance().Errors.ToList());
                }

                if (dvDB != null)
                {

                    OnError(dvDB.Errors);
                    SelectContext.Root = dvDB.Context;

                    dvDB.InitOption();
                    dvDB.Context.Wise(null);

                    this.ModelInfo = dvDB.Context.Unions[0].Context.TableJoinInfos[0].RightModelInfo;

                    var orders = dvDB.OrderPairs;

                    //获得对应的model
                    var modelName = "unknown";

                    if (dvDB.Context.Unions[0].Context.TableJoinInfos.Count == 1)
                    {
                        modelName = dvDB.Context.Unions[0].Context.TableJoinInfos[0].RightModelInfo.Name;
                        modelName = GeneratorUtil.ClassName(modelName);
                    }
                    if (modelName != GeneratorHelper.ClassName(this.txtResultModel.Text))
                    {

                    }
                    List<FieldInfo> fields = new List<FieldInfo>();

                    foreach (var field in dvDB.Context.Unions[0].Context.ReturnFields)
                    {
                        if (field is MutiField)
                        {
                            var muti_fieds = field as MutiField;
                            foreach (var f in muti_fieds.AllFields)
                            {
                                fields.Add(f);
                            }
                        }
                        else
                        {
                            fields.Add(field);
                        }
                    }
                    fields = fields.OrderByName();

                    var builder = new StringBuilder();
                    builder.AppendLine(@"@section css{    
    <style type='text/css'>
        label.right
        {
            width: 130px;
        }
        form p label
        {
            padding-right: 5px;
        }
    </style>
}");
                    builder.AppendLine("@section js{");
                    builder.AppendLine("<link href=\"../../Content/jqGridStyle/ui.jqgrid.css\" rel=\"stylesheet\" type=\"text/css\" />");
                    builder.AppendLine("<link href=\"../../Content/css/msgbox.css\" rel=\"stylesheet\" type=\"text/css\" />");
                    builder.AppendLine("<script src=\"../../Scripts/jqGrid/i18n/grid.locale-en.js\" type=\"text/javascript\"></script>");
                    builder.AppendLine("<script src=\"../../Scripts/jqGrid/jquery.jqGrid.min.js\" type=\"text/javascript\"></script>");
                    builder.AppendLine("<script src=\"../../Scripts/jquery.form.js\" type=\"text/javascript\"></script>");
                    builder.AppendLine("<script src=\"../../Scripts/jquery.validate.js\" type=\"text/javascript\"></script>");
                    builder.AppendLine("<script src=\"../../Scripts/resourceManagement.js\" type=\"text/javascript\"></script>");
                    builder.AppendLine("<script src=\"../../Scripts/msgbox.js\" type=\"text/javascript\"></script>");
                    builder.AppendLine("<script type=\"text/javascript\">");
                    builder.AppendLine("    $(function () {");
                    builder.AppendLine("         $(\".date\").datepicker({");
                    builder.AppendLine("            changeMonth: true,");
                    builder.AppendLine("            changeYear: true,");
                    builder.AppendLine("            dateFormat: 'yy-mm-dd',");
                    builder.AppendLine("            onSelect: function () { $(this).valid(); }");
                    builder.AppendLine("         });");
                    builder.AppendLine();

                    builder.AppendLine("         initializeGrid();");
                    builder.AppendLine("         $('#listTable .editItem').live('click', function () {");
                    builder.AppendLine(@"           var callback = function () {
                    onClickFilter();
                }

                var id = $(this).attr(""list_item_id"");

");
                    builder.AppendLine(string.Format(@"             MsgBox.OpenUrlNoScroll('Edit Item', 'Edit{0}Item?r=' + Math.random() + ""&Id="" + id
                                        , 640, 400, false, callback);
", modelName));


                    //builder.AppendLine(string.Format("             createOrEditItem('{0}', $(this).attr('itemId'));", modelName));
                    builder.AppendLine("        });");
                    builder.AppendLine("        $('#listTable .deleteItem').live('click', function () {");
                    builder.AppendLine("            var itemId = $(this).attr('list_item_id');");
                    builder.AppendLine("            jConfirm(\"Are you sure you want to delete it?\", 'confirm', function (res) {");
                    builder.AppendLine("                if (!res) return;");
                    builder.AppendLine();

                    builder.AppendLine("            $.ajax({");
                    builder.AppendLine("            \ttype: \"POST\",");
                    builder.AppendLine("            \turl: \"/Controller/DeleteAction\",");
                    builder.AppendLine("            \tdata: eval(\"({'idList[0]' : '\" + itemId + \"'})\"), ");
                    builder.AppendLine("            \tsuccess: function (data) {");
                    builder.AppendLine("            \t\tif (!data.IsSuccess)");
                    builder.AppendLine("            \t\t\tjAlert(data.Message);");
                    builder.AppendLine("            \t\telse {");
                    builder.AppendLine("            \t\t\trefreshList();");
                    builder.AppendLine("            \t\t}");
                    builder.AppendLine("            \t},");
                    builder.AppendLine("            \t\terror: function (XMLHttpRequest, textStatus, errorThrown) {");
                    builder.AppendLine("            \t\t\tjAlert(\"error occured\");");
                    builder.AppendLine("            \t\t}");
                    builder.AppendLine("            \t\t, dataType: \"json\"");
                    builder.AppendLine("            \t});");
                    builder.AppendLine("            });");
                    builder.AppendLine("        });");
                    builder.AppendLine("    });");
                    builder.AppendLine();
                    builder.AppendLine("    function refreshList() {");
                    builder.AppendLine("    \t$(\"#listTable\").trigger('reloadGrid');");
                    builder.AppendLine("    }");
                    builder.AppendLine("");

                    builder.AppendLine("    function onDeleteMultiple() {");
                    builder.AppendLine("    \tjConfirm(\"Are you sure you want to delete them?\", 'confirm', function (res) {");
                    builder.AppendLine("    \tif (!res) return;");
                    builder.AppendLine("");
                    builder.AppendLine("    \tdeleteAllItem('Controller', 'DeleteAction', {");
                    builder.AppendLine("    \t\tonSuccess: function (data) {");
                    builder.AppendLine("    \t\t\tif (!data.IsSuccess)");
                    builder.AppendLine("    \t\t\t\tjAlert(data.Message);");
                    builder.AppendLine("    \t\t\telse {");
                    builder.AppendLine("    \t\t\t\trefreshList();");
                    builder.AppendLine("    \t\t\t}");
                    builder.AppendLine("    \t\t},");
                    builder.AppendLine("    \t\tonError: function () {");
                    builder.AppendLine("    \t\t\tjAlert(\"error occured\");");
                    builder.AppendLine("    \t\t}");
                    builder.AppendLine("    \t});");
                    builder.AppendLine("    });");
                    builder.AppendLine("    }");
                    builder.AppendLine("");
                    builder.AppendLine("    function onClickAdd() {");
                    builder.AppendLine("    \tvar callback = function () {");
                    builder.AppendLine("    \t\tonClickFilter();");
                    builder.AppendLine("    \t}");
                    builder.AppendLine("");
                    builder.AppendLine("    \tMsgBox.OpenUrlNoScroll('Add Item', '/Controller/EditAction?r=' + Math.random(), 640, 400, false, callback);");
                    builder.AppendLine("    }");
                    builder.AppendLine("");

                    builder.AppendLine("    function onClickFilter() {");
                    builder.AppendLine("        submitFilterForm({");
                    var parameters = dvDB.Context.Parameters.OrderByName();
                    for (var index = 0; index < parameters.Count; index++)
                    {
                        var parameterName = parameters[index].Name.Substring(1);
                        parameterName = GeneratorUtil.ClassName(parameterName);
                        builder.Append(string.Format("            {0}: trimStr($('#{0}Filter').val())", parameterName));
                        if (index != dvDB.Context.Parameters.Count - 1)
                        {
                            builder.AppendLine(",");
                        }
                        else
                        {
                            builder.AppendLine();
                        }

                    }
                    builder.AppendLine("        });");
                    builder.AppendLine("    }");
                    builder.AppendLine();
                    builder.AppendLine("    function initializeGrid() {");
                    builder.AppendLine("        $('#listTable').jqGrid('GridUnload');");
                    builder.AppendLine("        $('#listTable').jqGrid({");
                    builder.AppendLine(string.Format("            url: '/Controller/{0}_List',"
                        , modelName.StartsWith("vw_", StringComparison.OrdinalIgnoreCase) ? modelName.Substring(3) : modelName));
                    builder.AppendLine("            ");
                    builder.AppendLine("        postData: {");
                    for (var index = 0; index < parameters.Count; index++)
                    {
                        var parameterName = parameters[index].Name.Substring(1);
                        parameterName = GeneratorUtil.ClassName(parameterName);
                        builder.Append(string.Format("            {0}: trimStr($('#{0}Filter').val())", parameterName));
                        if (index != dvDB.Context.Parameters.Count - 1)
                        {
                            builder.AppendLine(",");
                        }
                        else
                        {
                            builder.AppendLine("");
                        }
                    }
                    builder.AppendLine("        },");
                    builder.AppendLine("            datatype: 'json',");
                    var hasId = false;
                    builder.Append("            colNames: [");
                    foreach (var f in fields)
                    {
                        if (f.ClassName.Equals("id", StringComparison.OrdinalIgnoreCase))
                        {
                            hasId = true;
                            break;
                        }
                    }
                    if (hasId)
                    {
                        builder.Append("'Actions', ");
                    }
                    for (var index = 0; index < fields.Count; index++)
                    {
                        var field = GeneratorUtil.ClassName(fields[index].FullName);
                        if (field.Equals("id", StringComparison.OrdinalIgnoreCase))
                            continue;
                        builder.AppendFormat(" '{0}'", field);
                        if (index < fields.Count - 1)
                        {
                            builder.Append(",");
                        }
                    }
                    builder.AppendLine("],");
                    builder.AppendLine("            colModel: [");
                    if (hasId)
                    {
                        builder.Append("                {" + string.Format(" name: '{0}', index: '{0}', width: '85', sortable: false, resizable: false, formatter: formatActions", "Id") + " },");
                        builder.AppendLine();
                    }
                    for (var index = 0; index < fields.Count; index++)
                    {
                        var field = GeneratorUtil.ClassName(fields[index].FullName);
                        if (field.Equals("id", StringComparison.OrdinalIgnoreCase))
                            continue;

                        builder.Append("                {" + string.Format(" name: '{0}', index: '{0}', width: '120', resizable: true", field) + "}");

                        if (index < fields.Count - 1)
                        {
                            builder.Append(",");
                        }
                        builder.AppendLine();
                    }
                    builder.AppendLine("            ],");
                    builder.AppendLine("            rowNum: 20,");
                    builder.AppendLine("            autowidth: true,");
                    builder.AppendLine("            shrinkToFit: false,");
                    builder.AppendLine("            sortable: true,");
                    builder.AppendLine("            jsonReader: {");
                    builder.AppendLine("                repeatitems: false,");
                    builder.AppendLine(string.Format("                root: '{0}s',", ViewModelClass()));
                    builder.AppendLine("                total: 'PageCount',");
                    builder.AppendLine("                records: 'RecordCount'");
                    builder.AppendLine("            },");
                    builder.AppendLine("            prmNames: {");
                    builder.AppendLine("                page: 'PageIndex',");
                    builder.AppendLine("                rows: 'PageSize',");
                    builder.AppendLine("                sort: 'SortBy',");
                    builder.AppendLine("                order: 'SortOrder'");
                    builder.AppendLine("            },");
                    builder.AppendLine(string.Format("            caption: '{0} List',", modelName));
                    builder.AppendLine("            height: '100%',");
                    builder.AppendLine("            gridComplete: function () {");
                    builder.AppendLine("                $(this).closest('.ui-jqgrid-view').find('div.ui-jqgrid-titlebar').hide();");
                    builder.AppendLine("                // Initialize checkbox");
                    builder.AppendLine("                var rowIds = $('#listTable').jqGrid('getDataIDs');");
                    builder.AppendLine("                for (var i = 0; i < rowIds.length; i++) {");
                    builder.AppendLine("                \tvar curRowData = $(\"#listTable\").jqGrid('getRowData', rowIds[i]);");
                    builder.AppendLine("                \tvar curChk = $(\"#\" + rowIds[i] + \"\").find(\":checkbox\");");
                    builder.AppendLine("                \t$(curChk).addClass('listchk');");
                    builder.AppendLine("                \tcurChk.attr('value', $(curRowData['Id']).attr('list_item_id'));");
                    builder.AppendLine("                \t}");
                    builder.AppendLine("            },");
                    builder.AppendLine("            beforeSelectRow: function () {");
                    builder.AppendLine("                return false;");
                    builder.AppendLine("            },");
                    builder.AppendLine("            pager: '#pager',");
                    builder.AppendLine("            multiselect: true,");
                    builder.AppendLine("            viewrecords: true");
                    builder.AppendLine("        })");
                    builder.AppendLine("    }");
                    builder.AppendLine();
                    //                builder.AppendLine("    function onClickEdit() {");

                    //                builder.AppendLine(@"           var callback = function () {
                    //                    onClickFilter();
                    //                }
                    //");
                    //                builder.AppendLine(string.Format(@"             MsgBox.OpenUrlNoScroll('Edit Item', 'Edit{0}Item?r=' + Math.random()
                    //                                        , 380, 400, false, callback);
                    //", modelName));

                    //                builder.AppendLine("        }");

                    builder.AppendLine();
                    builder.AppendLine(@"    function onClickExport()
    {
        $('#SortBy').val($('#listTable').getGridParam('sortname'));
        $('#SortOrder').val($('#listTable').getGridParam('sortorder'));
        
        var url = '/Controller/$$$$ExprotAction_Export';
        $('#ExportForm .data').empty();
        $('#filterForm').find('input,select').clone(false,true).removeAttr('id').appendTo($('#ExportForm .data'));
        $('#ExportForm select').each(function(){
            var sourceSelect = $('#filterForm').find('select[name=' + $(this).attr('name') + ']');
            $(this).val(sourceSelect.val());
        });

        $('#ExportForm input').each(function () {
				$(this).val(trimStr($(this).val()));
		});

        $('#ExportForm').attr('action',url);
        $('#ExportForm').submit();
    }".Replace("$$$$ExprotAction", modelName.StartsWith("vw_", StringComparison.OrdinalIgnoreCase) ? modelName.Substring(3) : modelName));
                    builder.AppendLine();
                    builder.AppendLine("    </script>");
                    builder.AppendLine("}");
                    builder.AppendLine(string.Format(@"<div class='blank'>
</div>
<div class='maincontent'>
    <div class='tab'>
        <div class='tab-header'>
            <h3>
                {0} List
            </h3>
        </div>
        <div class='filters' style='margin-top: 5px;'>", modelName));
                    builder.AppendLine("        <form method='post' id='ExportForm' style='display:none' action=''>");
                    builder.AppendLine("        \t<div class='data'></div>");
                    builder.AppendLine("        </form>");
                    builder.AppendLine(@"        <form method='post' id='filterForm' class='form' action=''>");
                    builder.AppendLine("        <input type='hidden' id='SortBy' name='SortBy'  />");
                    builder.AppendLine("        <input type='hidden' id='SortOrder' name='SortOrder'  />");
                    builder.AppendLine("        <fieldset>");

                    for (var index = 0; index < dvDB.Context.Parameters.Count; index++)
                    {
                        var label_class = "";

                        if (index % 2 == 0)
                        {
                            builder.AppendLine("                <p>");
                        }
                        else
                        {
                            label_class = " class=\"right\"";
                        }
                        var parameterName = dvDB.Context.Parameters[index].Name.Substring(1);
                        parameterName = GeneratorUtil.ClassName(parameterName);
                        var para = dvDB.Context.Parameters[index];
                        var clz = "";
                        if (para.DbType == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.DateTime)
                        {
                            clz = " class = 'date' ";
                        }

                        if (para.DbType == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Bool)
                        {
                            var item = para.ShortName.EndsWith("id", StringComparison.OrdinalIgnoreCase) ?
                                para.ShortName.Substring(0, para.ShortName.Length - 2) : para.ShortName;
                            item = GeneratorHelper.VariableName(item);

                            var itemList = item + "_List";

                            builder.AppendLine(string.Format(@"
                    <label{0}>
                        {1}</label>
                    <select  name='{1}' {2} id='{1}Filter' >", label_class, parameterName, clz, item, itemList));
                            builder.AppendLine("                        <option value=''>----Please Select----</option>");
                            builder.AppendLine("                        <option value='true'>Yes</option>");
                            builder.AppendLine("                        <option value='false'>No</option>");
                            builder.AppendLine("                    </select>");
                        }
                        else if (para.DbType == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Guid)
                        {
                            var item = para.ShortName.EndsWith("id", StringComparison.OrdinalIgnoreCase) ?
                                para.ShortName.Substring(0, para.ShortName.Length - 2) : para.ShortName;

                            item = string.IsNullOrWhiteSpace(item) ? para.ShortName : item;

                            item = GeneratorHelper.VariableName(item);

                            var itemList = item + "_List";

                            builder.AppendLine(string.Format(@"
                    <label{0}>
                        {1}</label>
                    <select  name='{1}' {2} id='{1}Filter' >
                    <option value=''>----Please Select----</option>
                    @foreach (var {3} in {4})", label_class, parameterName, clz, item, itemList));

                            builder.AppendLine("                    {");
                            builder.AppendFormat("                        <option value='@{0}.Id'>@{0}.xxx</option>", item);
                            builder.AppendLine();
                            builder.AppendLine("                    }");
                            builder.AppendLine("                    </select>");
                            //builder.AppendLine("                </p>");
                        }
                        else
                        {
                            builder.AppendLine(string.Format(@"
                    <label{0}>
                        {1}</label>
                    <input type='text' name='{1}' {2} id='{1}Filter' />", label_class, parameterName, clz));
                        }

                        if (index % 2 == 1)
                        {
                            builder.AppendLine("                </p>");
                        }
                        else if (index == dvDB.Context.Parameters.Count - 1)
                        {
                            builder.AppendLine("                </p>");
                        }

                    }

                    //                builder.AppendLine(string.Format(@"
                    //                <p>
                    //                    <a onclick='onClickFilter()' class='button blue'>Filter</a> <a onclick='createOrEditItem('{0}')'
                    //                        class='button blue' style='float: right;'>Add</a>
                    //                </p>", modelName));

                    builder.AppendLine("                <p>");
                    builder.AppendLine("                    <a onclick='onClickFilter()' class='button blue'>Filter</a>");
                    builder.AppendLine(@"                    <a onclick='onDeleteMultiple()'
                        class='button blue' style='float: right;'>Delete</a>");
                    builder.Append("                    <a onclick='onClickAdd(");
                    //builder.Append(modelName);
                    builder.Append(")'");
                    builder.AppendLine(" class='button blue' style='float: right;'>Add</a>");
                    builder.AppendLine("                    <a onclick='onClickExport()'  class='button blue'>Export</a>");
                    builder.AppendLine("                </p>");
                    builder.AppendLine(@"
            </fieldset>
            </form>
        </div>
        <div class='tab-content listplaceholder'>
            <div class='tab-content listContent'>
                <table id='listTable'>
                </table>
                <div id='pager'>
                </div>
            </div>
        </div>
    </div>
</div>
<div class='popupplaceholder'>
</div>
            ");


                    textEditorControl_Output.Document.TextContent = builder.ToString();// dvDB.Context.Render();

                    textEditorControl_Output.Refresh();

                    var frm = new ShowCodeFrm();
                    frm.SetText(textEditorControl_Output.Document.TextContent);
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenVModelSearchCode_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;

            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {

                OnError(dvDB.Errors);
                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();
                dvDB.Context.Wise(null);

                var search = GeneratorUtil.ClassName(this.txtName.Text.Trim());
                var dtoName = string.Format("{0}_ConditionDto", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var dtoName_variable = GeneratorUtil.VariableName(dtoName);
                var domainName = string.Format("{0}_Condition", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var domainName_variable = GeneratorUtil.VariableName(domainName);

                this.ModelInfo = dvDB.Context.Unions[0].Context.TableJoinInfos[0].RightModelInfo;
                //var modelName = GeneratorUtil.ClassName(this.ModelInfo.Name);
                var orders = dvDB.OrderPairs.OrderByName();

                //获得对应的model
                var modelName = this.ViewModelClass();// GeneratorUtil.ClassName(this.txtResultModel.Text.Trim());

                //if (dvDB.Context.Unions[0].Context.TableJoinInfos.Count == 1)
                //{
                //    modelName = dvDB.Context.Unions[0].Context.TableJoinInfos[0].RightModelInfo.Name;
                //    modelName = GeneratorUtil.ClassName(modelName);
                //}

                var builder = new StringBuilder();

                builder.AppendLine(string.Format(@"public PageOfReturn<{0}> {1}({2} condition)", modelName, search, domainName));
                builder.AppendLine("{");
                if (orders.Count > 0)
                {
                    builder.AppendLine(string.Format("\tcondition.OrderBy = GetOrderByByCondition(condition);"));
                }

                builder.AppendLine(string.Format("\tvar resourceService = new ResourceService();"));
                if (!DBGlobalService.UseAutoMapper)
                {
                    builder.AppendLine(string.Format("\tvar conditionDto = DataConverter.ConvertTo{0}(condition);", dtoName));
                }
                else
                {
                    builder.AppendLine(string.Format("\tvar conditionDto = Mapper.Map<{0}, {1}>(condition);", domainName, dtoName));
                }
                var paras = dvDB.Context.Parameters;
                foreach (var p in paras)
                {
                    if (p.Name.EndsWith("_End", StringComparison.OrdinalIgnoreCase) && p.DbType == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.DateTime)
                    {
                        builder.AppendLine();
                        builder.AppendLine(string.Format("\tif(conditionDto.{0}.HasValue)", p.ClassName));
                        builder.AppendLine("\t{");
                        builder.AppendLine(string.Format("\t\tconditionDto.{0} = conditionDto.{0}.Value.Date.AddDays(1).AddMilliseconds(-1);", p.ClassName));
                        builder.AppendLine("\t}");
                    }
                }

                builder.AppendLine();
                builder.AppendLine(string.Format("\treturn resourceService.{0}(conditionDto);", search));
                /*
                builder.AppendLine(string.Format("\tvar resultDto = resourceService.{0}(conditionDto);", search));
                builder.AppendLine(string.Format("\tPageOfReturn<{0}> result = null;", modelName));
                builder.AppendLine("\tif(resultDto != null && resultDto.PageRecords != null)");
                builder.AppendLine("\t{");
                builder.AppendLine(string.Format("\t    result = new PageOfReturn<{0}>", modelName));
                builder.AppendLine("\t    {");
                builder.AppendLine("\t        PageCount = resultDto.PageCount,");
                builder.AppendLine("\t        PageIndex = resultDto.PageIndex,");
                builder.AppendLine("\t        PageSize = resultDto.PageSize,");
                builder.AppendLine("\t        RecordCount = resultDto.RecordCount,");
                builder.AppendLine(string.Format("\t        PageRecords = resultDto.PageRecords.Select(item => DataConverter.ConvertTo{0}(item)).ToList()", modelName));
                builder.AppendLine("\t    };");
                builder.AppendLine("\t}");
                builder.AppendLine("\treturn result;");
                 */
                builder.AppendLine("}");
                builder.AppendLine();

                //convent to orderby enum value
                if (orders.Count > 0)
                {
                    builder.AppendLine(string.Format(@"private static {0}.OrderByType GetOrderByByCondition({1} condition)", domainName, domainName));
                    builder.AppendLine("{");
                    builder.AppendLine(string.Format("\tvar result = {0}.OrderByType.{1}_{2};", domainName, orders[0].FieldName, orders[0].OrderType));
                    builder.AppendLine("\tcondition.SortBy = condition.SortBy == null ? string.Empty : condition.SortBy;");
                    builder.AppendLine("\tswitch(condition.SortBy.ToLower())");
                    builder.AppendLine("\t{");
                    //orders = orders.OrderBy(x => x.FieldName).ToList();
                    for (var i = 0; i < orders.Count; i++)
                    {
                        var order = orders[i];
                        builder.AppendLine(string.Format("\t\tcase \"{0}\":", order.FieldName.ToLower()));
                        var field_orders = new List<DataViewDB.OrderPair>();
                        for (var j = i; j < orders.Count; j++)
                        {
                            if (orders[j].FieldName == order.FieldName)
                            {
                                field_orders.Add(orders[j]);
                                i++;
                            }
                        }
                        i--;



                        for (var j = 0; j < field_orders.Count; j++)
                        {
                            var o = field_orders[j];
                            if (j == 0)
                            {
                                builder.AppendLine(string.Format("\t\t\tif (condition.SortOrder.Equals(\"{0}\", StringComparison.OrdinalIgnoreCase))", o.OrderType));
                                builder.AppendLine(string.Format("\t\t\t\tresult = {0}.OrderByType.{1}_{2};", domainName, o.FieldName, o.OrderType));
                            }
                            else
                            {
                                builder.AppendLine(string.Format("\t\t\telse if (condition.SortOrder.Equals(\"{0}\", StringComparison.OrdinalIgnoreCase))", o.OrderType));
                                builder.AppendLine(string.Format("\t\t\t\tresult = {0}.OrderByType.{1}_{2};", domainName, o.FieldName, o.OrderType));
                            }

                        }
                        builder.AppendLine();
                        builder.AppendLine("\t\t\t\tbreak;");

                    }
                    builder.AppendLine("\t\tdefault:");
                    builder.AppendLine("\t\t\tbreak;");
                    builder.AppendLine("\t}");

                    builder.AppendLine("\treturn result;");
                    builder.AppendLine("}");
                }
                textEditorControl_Output.Document.TextContent = builder.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
            }
        }

        private void btnGenService_Click(object sender, EventArgs e)
        {
            if (this.cbEncloseCondition.Checked)
            {
                GenService_HaveCondtionClass();
            }
            else
            {
                GenService_NoCondtionClass();
            }
        }

        private void GenService_HaveCondtionClass()
        {
            try
            {
                List<ParseErrorInfo> errors;

                ContextMenu contextMenu;

                DataViewDB dvDB;

                SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

                textEditorControl_Output.Document.TextContent = null;


                if (dvDB != null)
                {
                    SelectContext.Root = dvDB.Context;
                    OnError(dvDB.Errors);
                    dvDB.InitOption();
                    dvDB.Context.Wise(null);

                    var search = GeneratorUtil.ClassName(this.txtName.Text.Trim());
                    var dtoName = string.Format("{0}_ConditionDto", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                    var dtoName_variable = GeneratorUtil.VariableName(dtoName);
                    var domainName = string.Format("{0}_Condition", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                    var domainName_variable = GeneratorUtil.VariableName(domainName);
                    var action = GeneratorUtil.ClassName(this.txtName.Text.Trim());
                    var retrunInfoDto_class = "ReturnInfoDto";
                    if (dvDB.IsPager)
                    {
                        retrunInfoDto_class = "PageOfReturnDto";
                    }
                    this.ModelInfo = dvDB.Context.Unions[0].Context.TableJoinInfos[0].RightModelInfo;

                    var orders = dvDB.OrderPairs;

                    //获得对应的model
                    var modelName = "unknown";

                    //if (dvDB.Context.Unions[0].Context.TableJoinInfos.Count == 1)
                    //{
                    //    modelName = dvDB.Context.Unions[0].Context.TableJoinInfos[0].RightModelInfo.Name;
                    //    modelName = GeneratorUtil.ClassName(modelName);
                    //}

                    modelName = GeneratorUtil.ClassName(this.txtResultModel.Text.Trim());
                    var varModelName = Helper.GetVarName(modelName);

                    var builder = new StringBuilder();

                    builder.AppendLine(string.Format(@"        [OperationContract]
        [WithoutAuthorization]
        [FaultContractAttribute(typeof(UnAuthorization))]"));
                    if (dvDB.IsPager)
                    {
                        builder.AppendLine(string.Format("        {0}<{1}Dto> {2}({3} condition); ", retrunInfoDto_class, modelName, action, dtoName));
                    }
                    else
                    {
                        builder.AppendLine(string.Format("        {0}<List<{1}Dto>> {2}({3} condition); ", retrunInfoDto_class, modelName, action, dtoName));
                    }

                    builder.AppendLine();
                    builder.AppendLine();
                    if (dvDB.IsPager)
                    {
                        builder.AppendLine(string.Format("        public {0}<{1}Dto> {2}({3} condition)", retrunInfoDto_class, modelName, action, dtoName));
                    }
                    else
                    {
                        builder.AppendLine(string.Format("        public {0}<List<{1}Dto>> {2}({3} condition)", retrunInfoDto_class, modelName, action, dtoName));
                    }
                    builder.AppendLine("        {");
                    builder.AppendLine(string.Format("        \treturn _appService.{0}(condition);", action));
                    builder.AppendLine("        }");

                    builder.AppendLine();
                    builder.AppendLine();

                    if (dvDB.IsPager)
                    {
                        builder.AppendLine(string.Format("        public {0}<{1}Dto> {2}({2}_ConditionDto conditionDto)", retrunInfoDto_class, modelName, action));
                    }
                    else
                    {
                        builder.AppendLine(string.Format("        public {0}<List<{1}Dto>> {2}({2}_ConditionDto conditionDto)", retrunInfoDto_class, modelName, action));
                    }
                    builder.AppendLine(("        {"));
                    if (dvDB.IsPager)
                    {
                        builder.AppendLine(string.Format("            var result = new PageOfReturnDto<{0}Dto>();", modelName));
                        builder.AppendLine(string.Format("            result.PageRecords = new List<{0}Dto>();", modelName));
                    }
                    else
                    {
                        builder.AppendLine(string.Format("            var result = new ReturnInfoDto<List<{0}Dto>>();", modelName));
                        builder.AppendLine(string.Format("            result.Data = new List<{0}Dto>();", modelName));
                    }

                    builder.AppendLine(string.Format("                "));
                    builder.AppendLine(string.Format("            try"));
                    builder.AppendLine(("            {"));
                    if (!DBGlobalService.UseAutoMapper)
                    {
                        builder.AppendLine(string.Format("                var condition = DataConverter.ConvertTo{0}(conditionDto);", domainName));
                    }
                    else
                    {
                        builder.AppendLine(string.Format("                var condition = Mapper.Map<{0}, {1}>(conditionDto);", dtoName, domainName));
                    }
                    //builder.AppendLine(string.Format("                using (var unitOfWork = UnitOfWorkFactory.Create(DbOption.OA))"));
                    builder.AppendLine(string.Format("                " + DBGlobalService.DbContexUsingClause));
                    builder.AppendLine(("                {"));
                    builder.AppendLine(string.Format("                    var {0}DB = new {1}Repository(unitOfWork);", varModelName, modelName));
                    //var libList = libDB.GetLibraryInfo(condition);"));
                    builder.AppendLine(string.Format("                    var list = {0}DB.{1}(condition);", varModelName, action));
                    builder.AppendLine(string.Format("                    if (list != null)"));
                    builder.AppendLine(("                    {"));
                    if (dvDB.IsPager)
                    {
                        if (!DBGlobalService.UseAutoMapper)
                        {
                            builder.AppendLine(string.Format("                        list.PageRecords.ForEach(x => result.PageRecords.Add(DataConverter.ConvertTo{0}Dto(x)));", modelName));
                        }
                        else
                        {
                            builder.AppendLine(string.Format("                        list.PageRecords.ForEach(x => result.PageRecords.Add(Mapper.Map<{0}, {1}Dto>(x)));", modelName, modelName));
                        }
                    }
                    else
                    {
                        if (!DBGlobalService.UseAutoMapper)
                        {
                            builder.AppendLine(string.Format("                        list.ForEach(x => result.Data.Add(DataConverter.ConvertTo{0}Dto(x)));", modelName));
                        }
                        else
                        {
                            builder.AppendLine(string.Format("                        list.ForEach(x => result.Data.Add(Mapper.Map<{0}, {1}Dto>(x)));", modelName, modelName));
                        }
                    }
                    builder.AppendLine(("                    }"));
                    builder.AppendLine();
                    builder.AppendLine(string.Format("                    result.IsSuccess = true;"));
                    if (dvDB.IsPager)
                    {
                        builder.AppendLine(string.Format("                    result.PageIndex = list.PageIndex;"));
                        builder.AppendLine(string.Format("                    result.PageSize = list.PageSize;"));
                        builder.AppendLine(string.Format("                    result.RecordCount = list.RecordCount;"));
                    }
                    builder.AppendLine(("                }"));
                    builder.AppendLine(("            }"));
                    builder.AppendLine(string.Format("            catch (Exception ex)"));
                    builder.AppendLine(("            {"));
                    builder.AppendLine(string.Format("                result.IsSuccess = false;"));
                    builder.AppendLine(string.Format("                result.Message = ex.Message;"));
                    builder.AppendLine(string.Format("                new Logging().Simple_Error(ex);"));
                    builder.AppendLine(("            }"));
                    builder.AppendLine(string.Format("                "));
                    builder.AppendLine(string.Format("            return result;"));
                    builder.AppendLine(("        }"));

                    builder.AppendLine();

                    this.txtResultModel.Text = this.txtResultModel.Text.Trim();

                    var viewModel = this.txtResultModel.Text.StartsWith("vw_", StringComparison.OrdinalIgnoreCase) ?
                        this.txtResultModel.Text.Substring(3) : this.txtResultModel.Text;

                    viewModel = GeneratorHelper.ClassName(viewModel);

                    var viewDto = GeneratorHelper.ClassName(this.txtResultModel.Text) + "Dto";

                    if (!viewModel.EndsWith("info", StringComparison.OrdinalIgnoreCase))
                    {
                        viewModel += "Info";
                    }


                    var viewReturn = retrunInfoDto_class.Substring(0, retrunInfoDto_class.Length - 3);
                    if (dvDB.IsPager)
                    {
                        builder.AppendLine(string.Format("public {0}<{1}> {2}({2}_ConditionDto condition)", viewReturn, viewModel, action));
                    }
                    else
                    {
                        builder.AppendLine(string.Format("public {0}<List<{1}>> {2}({2}_ConditionDto condition)", viewReturn, viewModel, action));
                    }
                    builder.AppendLine("{");
                    if (dvDB.IsPager)
                    {
                        builder.AppendLine(string.Format("\tvar result = new {0}<{1}>();", viewReturn, viewModel));
                    }
                    else
                    {
                        builder.AppendLine(string.Format("\tvar result = new {0}<List<{1}>>();", viewReturn, viewModel));
                        builder.AppendLine(string.Format("\tresult.Data = new List<{0}>();", viewModel));
                    }
                    if (orders.Count > 0)
                    {
                        builder.AppendLine(string.Format("\tif (condition.OrderBy == null)"));
                        builder.AppendLine("\t{");
                        builder.AppendLine(string.Format("\t\tcondition.OrderBy = {0}_ConditionDto.OrderByType.{1}_{2};", action, orders[0].SafeName, orders[0].OrderType));
                        builder.AppendLine("\t}");
                    }
                    builder.AppendLine();
                    builder.AppendLine("\tvar rsltDto = serviceClient");
                    if (dvDB.IsPager)
                    {
                        builder.AppendLine(string.Format("\t\t.Invoke<{0}<{1}Dto>>(x => x.{2}(condition));", retrunInfoDto_class, modelName, action));
                    }
                    else
                    {
                        builder.AppendLine(string.Format("\t\t.Invoke<{0}<List<{1}Dto>>>(x => x.{2}(condition));", retrunInfoDto_class, modelName, action));
                    }
                    builder.AppendLine();
                    builder.AppendLine("\tif (rsltDto.IsSuccess)");
                    builder.AppendLine("\t{");

                    builder.AppendLine("\t\tresult.IsSuccess = rsltDto.IsSuccess;");
                    builder.AppendLine("\t\tresult.Message = rsltDto.Message;");
                    if (dvDB.IsPager)
                    {
                        builder.AppendLine("\t\tresult.PageIndex = rsltDto.PageIndex;");
                        builder.AppendLine("\t\tresult.PageSize = rsltDto.PageSize;");
                        builder.AppendLine("\t\tresult.RecordCount = rsltDto.RecordCount;");
                        if (!DBGlobalService.UseAutoMapper)
                        {
                            builder.AppendLine(string.Format("\t\trsltDto.PageRecords.ForEach(x => result.PageRecords.Add(DataConverter.ConvertTo{0}(x)));", viewModel));
                        }
                        else
                        {
                            builder.AppendLine(string.Format("\t\trsltDto.PageRecords.ForEach(x => result.PageRecords.Add(Mapper.Map<{0}, {1}>(x)));", viewDto, viewModel));
                        }
                    }
                    else
                    {
                        if (!DBGlobalService.UseAutoMapper)
                        {
                            builder.AppendLine(string.Format("\t\trsltDto.Data.ForEach(x => result.Data.Add(DataConverter.ConvertTo{0}(x)));", viewModel));
                        }
                        else
                        {
                            builder.AppendLine(string.Format("\t\trsltDto.Data.ForEach(x => result.Data.Add(Mapper.Map<{0}, {1}>(x)));", viewDto, viewModel));
                        }
                    }
                    builder.AppendLine("\t}");
                    builder.AppendLine("\treturn result;");
                    builder.AppendLine("}");
                    textEditorControl_Output.Document.TextContent = builder.ToString();// dvDB.Context.Render();

                    textEditorControl_Output.Refresh();

                    var frm = new ShowCodeFrm();
                    frm.SetText(textEditorControl_Output.Document.TextContent);
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void GenService_NoCondtionClass()
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;


            if (dvDB != null)
            {
                SelectContext.Root = dvDB.Context;
                OnError(dvDB.Errors);
                dvDB.InitOption();
                dvDB.Context.Wise(null);

                var search = GeneratorUtil.ClassName(this.txtName.Text.Trim());
                var dtoName = string.Format("{0}_ConditionDto", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var dtoName_variable = GeneratorUtil.VariableName(dtoName);
                var domainName = string.Format("{0}_Condition", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var domainName_variable = GeneratorUtil.VariableName(domainName);
                var action = GeneratorUtil.ClassName(this.txtName.Text.Trim());
                this.ModelInfo = dvDB.Context.Unions[0].Context.TableJoinInfos[0].RightModelInfo;

                var orders = dvDB.OrderPairs;

                //获得对应的model
                var modelName = "unknown";

                modelName = GeneratorUtil.ClassName(this.txtResultModel.Text.Trim());

                var builder = new StringBuilder();

                builder.AppendLine(string.Format(@"        [OperationContract]
        [WithoutAuthorization]
        [FaultContractAttribute(typeof(UnAuthorization))]
        ReturnInfoDto<{0}Dto> {1}({2} condition); ", modelName, action, dtoName));

                builder.AppendLine();
                builder.AppendLine();
                builder.AppendLine(string.Format("        public ReturnInfoDto<{0}Dto> {1}({2} condition)", modelName, action, dtoName));
                builder.AppendLine("        {");
                builder.AppendLine(string.Format("        \treturn _appService.{0}({1});", action, dtoName));
                builder.AppendLine("        }");

                builder.AppendLine();
                builder.AppendLine();

                builder.AppendLine(string.Format("        public PageOfReturnDto<{0}Dto> {1}({1}_ConditionDto conditionDto)", modelName, action));
                builder.AppendLine(("        {"));
                builder.AppendLine(string.Format("            var result = new PageOfReturnDto<{0}>();", dtoName));
                builder.AppendLine(string.Format("            result.PageRecords = new List<{0}>();", dtoName));
                builder.AppendLine(string.Format("                "));
                builder.AppendLine(string.Format("            try"));
                builder.AppendLine(("            {"));
                if (!DBGlobalService.UseAutoMapper)
                {
                    builder.AppendLine(string.Format("                var condition = DataConverter.ConvertTo{0}(conditionDto);", domainName));
                }
                else
                {
                    builder.AppendLine(string.Format("                var condition = Mapper.Map<{0}, {1}>(conditionDto);", dtoName, domainName));
                }
                //builder.AppendLine(string.Format("                using (var unitOfWork = UnitOfWorkFactory.Create(DbOption.OA))"));
                builder.AppendLine(string.Format("                " + DBGlobalService.DbContexUsingClause));
                builder.AppendLine(("                {"));
                builder.AppendLine(string.Format("                    var libDB = new {0}Repository(unitOfWork);", modelName));
                //var libList = libDB.GetLibraryInfo(condition);"));
                builder.AppendLine(string.Format("                    var libList = libDB.{0}(condition);", action));
                builder.AppendLine(string.Format("                    if (libList != null)"));
                builder.AppendLine(("                    {"));
                if (!DBGlobalService.UseAutoMapper)
                {
                    builder.AppendLine(string.Format("                        libList.PageRecords.ForEach(x => result.PageRecords.Add(DataConverter.ConvertTo{0}Dto(x)));", modelName));
                }
                else
                {
                    builder.AppendLine(string.Format("                        //libList.PageRecords.ForEach(x => result.PageRecords.Add(Mapper.Map<{0}, {1}>(x)));", modelName, dtoName));
                }
                builder.AppendLine(("                    }"));
                builder.AppendLine();
                builder.AppendLine(string.Format("                    result.IsSuccess = true;"));
                builder.AppendLine(string.Format("                    result.PageIndex = libList.PageIndex;"));
                builder.AppendLine(string.Format("                    result.PageSize = libList.PageSize;"));
                builder.AppendLine(string.Format("                    result.RecordCount = libList.RecordCount;"));
                builder.AppendLine(("                }"));
                builder.AppendLine(("            }"));
                builder.AppendLine(string.Format("            catch (Exception ex)"));
                builder.AppendLine(("            {"));
                builder.AppendLine(string.Format("                result.IsSuccess = false;"));
                builder.AppendLine(string.Format("                result.Message = ex.Message;"));
                builder.AppendLine(string.Format("                new Logging().Simple_Error(ex);"));
                builder.AppendLine(("            }"));
                builder.AppendLine(string.Format("                "));
                builder.AppendLine(string.Format("            return result;"));
                builder.AppendLine(("        }"));
                textEditorControl_Output.Document.TextContent = builder.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
            }
        }

        private void btnValidateSql_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            this.textEditorControl_Output.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);
                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();

                dvDB.Context.Wise(null);
                var builder = new StringBuilder();
                dvDB.Context.Render(builder);
                this.textEditorControl_Output.Text = builder.ToString();
                this.textEditorControl_Output.Invalidate();
                textEditorControl_Output.Refresh();
            }
        }

        private void btnGenResultModel_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            this.textEditorControl_Output.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);
                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();

                dvDB.Context.Wise(null);
                var builder = new StringBuilder();
                var resultModel = this.txtResultModel.Text.Trim();

                if (string.IsNullOrWhiteSpace(resultModel))
                {
                    if (dvDB.Context.Unions.Count == 1)
                    {
                        var contxt = dvDB.Context.Unions[0].Context;
                        resultModel = contxt.TableJoinInfos[0].RightModelInfo.Name;
                    }
                }
                builder.AppendLine("using System;");
                builder.AppendLine("using System.Linq;");
                builder.AppendLine("using System.Data;");
                builder.AppendLine("using System.Collections.Generic;");
                builder.AppendLine();
                builder.AppendLine("namespace xxx");
                builder.AppendLine("{");

                builder.AppendLine("\tpublic class " + resultModel);
                builder.AppendLine("\t{");
                if (dvDB.Context.Unions.Count < 1)
                {
                    builder.AppendLine("没有查询表或者视图对象");
                    return;
                }

                foreach (var field in dvDB.Context.Unions[0].Context.ReturnFields.OrderByName())
                {
                    if (field is MutiField)
                    {
                        var muti_fieds = field as MutiField;
                        foreach (var f in muti_fieds.AllFields.OrderByName())
                        {
                            var field_name = string.IsNullOrWhiteSpace(f.Alias) ? f.FullName : f.Alias;
                            field_name = GeneratorUtil.ClassName(field_name);
                            if (field_name.LastIndexOf(".") > -1)
                            {
                                field_name = field_name.Substring(field_name.LastIndexOf(".") + 1);
                            }

                            builder.AppendLine(string.Format("\t\tpublic {0} {1}", f.SystemType, field_name));
                            builder.AppendLine("\t\t{get;set;}");
                            builder.AppendLine();
                        }
                    }
                    else
                    {
                        var field_name = string.IsNullOrWhiteSpace(field.Alias) ? field.FullName : field.Alias;
                        field_name = GeneratorUtil.ClassName(field_name);
                        if (field_name.LastIndexOf(".") > -1)
                        {
                            field_name = field_name.Substring(field_name.LastIndexOf(".") + 1);
                        }
                        var nullAble = field.NullAble ? "?" : "";
                        if (field.SystemType.Equals("string", StringComparison.OrdinalIgnoreCase))
                        {
                            nullAble = "";
                        }
                        builder.AppendLine(string.Format("\t\tpublic {0}{1} {2}", EnumUtils.GetDescription(field.DbType), nullAble, field_name));
                        builder.AppendLine("\t\t{get;set;}");
                        builder.AppendLine();
                    }
                }
                builder.AppendLine("\t}");
                builder.AppendLine("}");
                AppendHeader(builder);

                this.textEditorControl_Output.Text = builder.ToString();
                this.textEditorControl_Output.Invalidate();
                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
            }
        }

        private void btnGenResultDTO_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            this.textEditorControl_Output.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);
                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();

                dvDB.Context.Wise(null);
                var builder = new StringBuilder();
                var resultModel = this.txtResultModel.Text.Trim() + "Dto";

                if (string.IsNullOrWhiteSpace(resultModel))
                {
                    if (dvDB.Context.Unions.Count == 1)
                    {
                        var contxt = dvDB.Context.Unions[0].Context;
                        resultModel = contxt.TableJoinInfos[0].RightModelInfo.Name;
                    }
                }
                builder.AppendLine("using System;");
                builder.AppendLine("using System.Linq;");
                builder.AppendLine("using System.Data;");
                builder.AppendLine("using System.Runtime.Serialization;");
                builder.AppendLine("using System.Collections.Generic;");
                builder.AppendLine();
                builder.AppendLine("namespace xxx");
                builder.AppendLine("{");
                builder.AppendLine("\t[DataContract]");
                builder.AppendLine("\tpublic class " + resultModel);
                builder.AppendLine("\t{");
                foreach (var field in dvDB.Context.Unions[0].Context.ReturnFields.OrderByName())
                {
                    if (field is MutiField)
                    {
                        var muti_fieds = field as MutiField;
                        foreach (var f in muti_fieds.AllFields.OrderByName())
                        {
                            var field_name = string.IsNullOrWhiteSpace(f.Alias) ? f.FullName : f.Alias;
                            field_name = GeneratorUtil.ClassName(field_name);
                            if (field_name.LastIndexOf(".") > -1)
                            {
                                field_name = field_name.Substring(field_name.LastIndexOf(".") + 1);
                            }
                            builder.AppendLine("\t\t[DataMember]");
                            builder.AppendLine(string.Format("\t\tpublic {0} {1}", f.SystemType, field_name));
                            builder.AppendLine("\t\t{get;set;}");
                            builder.AppendLine();
                        }
                    }
                    else
                    {
                        var field_name = string.IsNullOrWhiteSpace(field.Alias) ? field.FullName : field.Alias;
                        field_name = GeneratorUtil.ClassName(field_name);
                        if (field_name.LastIndexOf(".") > -1)
                        {
                            field_name = field_name.Substring(field_name.LastIndexOf(".") + 1);
                        }
                        builder.AppendLine("\t\t[DataMember]");
                        builder.AppendLine(string.Format("\t\tpublic {0} {1}", EnumUtils.GetDescription(field.DbType), field_name));
                        builder.AppendLine("\t\t{get;set;}");
                        builder.AppendLine();
                    }
                }
                builder.AppendLine("\t}");
                builder.AppendLine("}");
                AppendHeader(builder);

                this.textEditorControl_Output.Text = builder.ToString();
                this.textEditorControl_Output.Invalidate();
                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
            }
        }

        private void btnGenResultToDTO_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);

                dvDB.InitOption();
                dvDB.Context.Wise(null);
                var orders = dvDB.OrderPairs;

                var dtoName = string.Format("{0}Dto", GeneratorUtil.ClassName(this.txtResultModel.Text.Trim()));
                var dtoName_variable = GeneratorUtil.VariableName(dtoName);
                var domainName = string.Format("{0}", GeneratorUtil.ClassName(this.txtResultModel.Text.Trim()));
                var domainName_variable = GeneratorUtil.VariableName(domainName);

                var condition_class = new StringBuilder();
                condition_class.AppendLine(string.Format("public static {0} ConvertTo{0}({1} {2})", dtoName, domainName, domainName_variable));
                condition_class.AppendLine("{");
                condition_class.AppendLine(string.Format("\treturn new {0}()", dtoName));
                condition_class.AppendLine("\t{");
                foreach (var filed in dvDB.Context.Unions[0].Context.ReturnFields.OrderByName())
                {
                    if (filed is MutiField)
                    {
                        var mutiField = filed as MutiField;
                        foreach (var f in mutiField.AllFields.OrderByName())
                        {
                            var filedName = GeneratorUtil.ClassName(f.Alias ?? f.FullName);
                            condition_class.AppendLine(string.Format("\t\t{0} = {1}.{0},", filedName, domainName_variable));
                        }
                    }
                    else
                    {
                        var filedName = GeneratorUtil.ClassName(filed.Alias ?? filed.FullName);
                        condition_class.AppendLine(string.Format("\t\t{0} = {1}.{0},", filedName, domainName_variable));
                    }
                }

                condition_class.AppendLine("\t};");
                condition_class.AppendLine("}");

                textEditorControl_Output.Document.TextContent = condition_class.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
            }
        }

        private void btnGenSearchResultInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnDTOtoResult_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);

                dvDB.InitOption();
                dvDB.Context.Wise(null);
                var orders = dvDB.OrderPairs;

                var dtoName = string.Format("{0}Dto", GeneratorUtil.ClassName(this.txtResultModel.Text.Trim()));
                var dtoName_variable = GeneratorUtil.VariableName(dtoName);
                var domainName = string.Format("{0}", GeneratorUtil.ClassName(this.txtResultModel.Text.Trim()));
                var domainName_variable = GeneratorUtil.VariableName(domainName);

                var condition_class = new StringBuilder();
                condition_class.AppendLine(string.Format("public static {0} ConvertTo{0}({1} {2})", domainName, dtoName, dtoName_variable));
                condition_class.AppendLine("{");
                condition_class.AppendLine(string.Format("\treturn new {0}()", domainName));
                condition_class.AppendLine("\t{");
                foreach (var filed in dvDB.Context.Unions[0].Context.ReturnFields.OrderByName())
                {
                    if (filed is MutiField)
                    {
                        var mutiField = filed as MutiField;
                        foreach (var f in mutiField.AllFields.OrderByName())
                        {
                            var filedName = GeneratorUtil.ClassName(f.Alias ?? f.FullName);
                            condition_class.AppendLine(string.Format("\t\t{0} = {1}.{0},", filedName, dtoName_variable));
                        }
                    }
                    else
                    {
                        var filedName = GeneratorUtil.ClassName(filed.Alias ?? filed.FullName);
                        condition_class.AppendLine(string.Format("\t\t{0} = {1}.{0},", filedName, dtoName_variable));
                    }
                }

                condition_class.AppendLine("\t};");
                condition_class.AppendLine("}");

                textEditorControl_Output.Document.TextContent = condition_class.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
            }
        }

        private void cbEncloseCondition_CheckedChanged(object sender, EventArgs e)
        {
            this.btnGenSearchConditionInfo.Enabled = this.cbEncloseCondition.Checked;
            this.btnGenSearchConditionDto.Enabled = this.cbEncloseCondition.Checked;
            this.btnConvertCondtionDtoToDomain.Enabled = this.cbEncloseCondition.Checked;
            this.btntConvertCondtionDomainToDto.Enabled = this.cbEncloseCondition.Checked;
            //this.btnGenSearchConditionInfo.Enabled = this.cbEncloseCondition.Checked;
        }

        private void txtResultModel_TextChanged(object sender, EventArgs e)
        {
            this.btnGenEFFunction.Enabled = this.txtResultModel.Text.Trim().Length > 0;
            //this.btnGenSqlFunction.Enabled = this.txtResultModel.Text.Trim().Length > 0;
            //this.btnGenSearchConditionDto.Enabled = this.txtResultModel.Text.Trim().Length > 0;
            //this.btnConvertCondtionDtoToDomain.Enabled = this.txtResultModel.Text.Trim().Length > 0;
            //this.btntConvertCondtionDomainToDto.Enabled = this.txtResultModel.Text.Trim().Length > 0;
            this.btnGenView.Enabled = this.txtResultModel.Text.Trim().Length > 0;
            this.btnGenVModelSearchCode.Enabled = this.txtResultModel.Text.Trim().Length > 0;
            this.btnGenService.Enabled = this.txtResultModel.Text.Trim().Length > 0;
            this.btnGenResultToDTO.Enabled = this.txtResultModel.Text.Trim().Length > 0;
            this.btnGenResultDTO.Enabled = this.txtResultModel.Text.Trim().Length > 0;
            this.btnGenResultModel.Enabled = this.txtResultModel.Text.Trim().Length > 0;
            //this.btnGenSearchConditionInfo.Enabled = this.txtResultModel.Text.Trim().Length > 0;
            this.btnDTOtoResult.Enabled = this.txtResultModel.Text.Trim().Length > 0;
        }

        private void btnGenSqlFunction_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);
                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();
                dvDB.Context.Wise(null);

                if (dvDB.Context.Unions[0].Context.TableJoinInfos.Count == 0
                    || dvDB.Context.Unions[0].Context.TableJoinInfos[0].RightModelInfo == null)
                    return;

                //获得对应的model
                var modelName = "unknown";

                modelName = GeneratorUtil.ClassName(this.txtResultModel.Text.Trim());
                var action = this.txtName.Text.Trim();
                action = GeneratorUtil.ClassName(action);

                //生成spacification
                var builder = new StringBuilder();
                //推断出model类名
                var condition_class = GeneratorUtil.ClassName(this.txtName.Text.Trim() + "_Condition");
                var condition_variable = "condition";

                if (dvDB.IsPager)
                {
                    builder.AppendLine(string.Format("public PageOfResult<{0}> {1}({1}_Condition condition)", modelName, action));
                }
                else
                {
                    builder.AppendLine(string.Format("public ResultInfo<{0}> {1}({1}_Condition condition)", modelName, action));
                }
                builder.AppendLine("{");
                //builder.AppendLine("\t待完善;");
                dvDB.Context.RenderSql(builder);

                builder.AppendLine("}");

                builder.AppendLine();

                textEditorControl_Output.Document.TextContent = builder.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.Show();
                frm.SetText(textEditorControl_Output.Document.TextContent);

            }
        }

        private string ViewModelClass()
        {
            //this.txtResultModel.Text = this.txtResultModel.Text.Trim();

            //var viewModel = this.txtResultModel.Text.StartsWith("vw_", StringComparison.OrdinalIgnoreCase) ?
            //    this.txtResultModel.Text.Substring(3) : this.txtResultModel.Text;


            //if (!viewModel.EndsWith("info", StringComparison.OrdinalIgnoreCase))
            //{
            //    viewModel += "Info";
            //}

            //return viewModel;

            return Helper.GetViewMode(this.txtResultModel.Text);
        }

        private string ViewModelDtoCalss()
        {
            this.txtResultModel.Text = this.txtResultModel.Text.Trim();

            var viewModel = this.txtResultModel.Text.StartsWith("vw_", StringComparison.OrdinalIgnoreCase) ?
                this.txtResultModel.Text.Substring(3) : this.txtResultModel.Text;

            viewModel = GeneratorHelper.ClassName(viewModel);

            var viewDto = viewModel + "Dto";

            return viewDto;
        }

        private void btnGenViewModel_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);
                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();

                dvDB.Context.Wise(null);
                var builder = new StringBuilder();

                var resultModel = this.ViewModelClass();

                if (string.IsNullOrWhiteSpace(resultModel))
                {
                    if (dvDB.Context.Unions.Count == 1)
                    {
                        var contxt = dvDB.Context.Unions[0].Context;
                        resultModel = contxt.TableJoinInfos[0].RightModelInfo.Name;
                    }
                }
                builder.AppendLine("using System;");
                builder.AppendLine("using System.Linq;");
                builder.AppendLine("using System.Data;");
                builder.AppendLine("using System.Collections.Generic;");
                builder.AppendLine();
                builder.AppendLine("namespace xxx");
                builder.AppendLine("{");

                builder.AppendLine("\tpublic class " + resultModel);
                builder.AppendLine("\t{");
                foreach (var field in dvDB.Context.Unions[0].Context.ReturnFields.OrderByName())
                {
                    if (field is MutiField)
                    {
                        var muti_fieds = field as MutiField;
                        foreach (var f in muti_fieds.AllFields.OrderByName())
                        {
                            var field_name = string.IsNullOrWhiteSpace(f.Alias) ? f.FullName : f.Alias;
                            field_name = GeneratorUtil.ClassName(field_name);
                            if (field_name.LastIndexOf(".") > -1)
                            {
                                field_name = field_name.Substring(field_name.LastIndexOf(".") + 1);
                            }

                            builder.AppendLine(string.Format("\t\tpublic {0} {1}", f.SystemType, field_name));
                            builder.AppendLine("\t\t{get;set;}");
                            builder.AppendLine();
                        }
                    }
                    else
                    {
                        var field_name = string.IsNullOrWhiteSpace(field.Alias) ? field.FullName : field.Alias;
                        field_name = GeneratorUtil.ClassName(field_name);
                        if (field_name.LastIndexOf(".") > -1)
                        {
                            field_name = field_name.Substring(field_name.LastIndexOf(".") + 1);
                        }
                        var nullAble = field.NullAble ? "?" : "";
                        if (field.SystemType.Equals("string", StringComparison.OrdinalIgnoreCase))
                        {
                            nullAble = "";
                        }
                        builder.AppendLine(string.Format("\t\tpublic {0}{1} {2}", EnumUtils.GetDescription(field.DbType), nullAble, field_name));
                        builder.AppendLine("\t\t{get;set;}");
                        builder.AppendLine();
                    }
                }
                builder.AppendLine("\t}");
                builder.AppendLine("}");
                AppendHeader(builder);

                this.textEditorControl_Output.Text = builder.ToString();
                this.textEditorControl_Output.Invalidate();
                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
            }

        }

        private void btnGenDTOtoViewModel_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }

            if (dvDB != null)
            {
                OnError(dvDB.Errors);

                dvDB.InitOption();
                SelectContext.Root = dvDB.Context;

                dvDB.Context.Wise(null);
                var orders = dvDB.OrderPairs;

                var dtoName = string.Format("{0}Dto", GeneratorUtil.ClassName(this.txtResultModel.Text.Trim()));
                var dtoName_variable = GeneratorUtil.VariableName(dtoName);
                var domainName = string.Format("{0}", this.ViewModelClass());
                var domainName_variable = GeneratorUtil.VariableName(domainName);

                var condition_class = new StringBuilder();
                if (DBGlobalService.UseAutoMapper)
                {
                    condition_class.AppendFormat("Mapper.CreateMap<{0}, {1}>();", dtoName, domainName);
                }
                else
                {
                    dtoName_variable = "dto"; ;

                    condition_class.AppendLine(string.Format("public static {0} ConvertTo{0}({1} {2})", domainName, dtoName, dtoName_variable));
                    condition_class.AppendLine("{");
                    condition_class.AppendLine(string.Format("\treturn new {0}()", domainName));
                    condition_class.AppendLine("\t{");
                    foreach (var filed in dvDB.Context.Unions[0].Context.ReturnFields.OrderByName())
                    {
                        if (filed is MutiField)
                        {
                            var mutiField = filed as MutiField;
                            foreach (var f in mutiField.AllFields.OrderByName())
                            {
                                var filedName = GeneratorUtil.ClassName(f.Alias ?? f.FullName);
                                condition_class.AppendLine(string.Format("\t\t{0} = {1}.{0},", filedName, dtoName_variable));
                            }
                        }
                        else
                        {
                            var filedName = GeneratorUtil.ClassName(filed.Alias ?? filed.FullName);
                            condition_class.AppendLine(string.Format("\t\t{0} = {1}.{0},", filedName, dtoName_variable));
                        }
                    }

                    condition_class.AppendLine("\t};");
                    condition_class.AppendLine("}");
                }

                textEditorControl_Output.Document.TextContent = condition_class.ToString();// dvDB.Context.Render();

                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
            }
        }

        private void btnGenViewCondition_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnGenPageViewModel_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);

                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();
                dvDB.Context.Wise(null);
                var orders = dvDB.OrderPairs;

                var baseCondition = "ListCondition";
                if (dvDB.IsPager)
                {
                    baseCondition = "PagerCondition";
                }
                var condition = GeneratorHelper.ClassName(this.txtName.Text.Trim() + "_Condition");

                var condition_class = new StringBuilder();
                var parameterName = "";
                condition_class.AppendLine("using System;");
                condition_class.AppendLine("using System.Linq;");
                condition_class.AppendLine("using System.Collections.Generic;");
                condition_class.AppendLine();
                condition_class.AppendLine("namespace xxx");
                condition_class.AppendLine("{");
                condition_class.AppendLine(string.Format("\tpublic class {0}_Condition : {1}", GeneratorUtil.ClassName(this.txtName.Text.Trim()), baseCondition));
                condition_class.AppendLine("\t{");
                //generate order by type
                if (dvDB.OrderPairs.Count > 0)
                {
                    condition_class.AppendLine(string.Format("\t\tpublic enum OrderByType"));
                    condition_class.AppendLine(("\t\t{"));
                    //condition_class.Append(("\t\t"));
                    foreach (var order in dvDB.OrderPairs.OrderByName())
                    {
                        condition_class.Append("\t\t\t" + GeneratorUtil.ClassName(order.SafeName) + "_" + order.OrderType + ",");
                        condition_class.AppendLine();
                    }
                    condition_class.AppendLine((""));
                    condition_class.AppendLine(("\t\t}"));
                    condition_class.AppendLine();
                    condition_class.AppendLine(("\t\tpublic OrderByType? OrderBy{get;set;}"));
                    condition_class.AppendLine();
                }

                foreach (var p in dvDB.Context.Parameters.OrderByName())
                {
                    parameterName = p.Name.Substring(1);
                    condition_class.AppendLine("\t\t" + string.Format("public {0} {1}",
                        //EnumUtils.GetDescription(p.DbType), p.NullAble && IsValueType(p.DbType) ? "?" : "", GeneratorUtil.ClassName(parameterName)));
                        p.SystemType, GeneratorUtil.ClassName(parameterName)));
                    condition_class.AppendLine("\t\t" + "{get;set;}");
                    condition_class.AppendLine();

                    foreach (var option in p.Options)
                    {
                        if (option.Name.Equals("op", StringComparison.OrdinalIgnoreCase))
                        {
                            if (option.Value.Equals("all", StringComparison.OrdinalIgnoreCase))
                            {
                                condition_class.AppendLine("\t\t" + string.Format("public enum {0}_ConditionType",
                                    GeneratorUtil.ClassName(parameterName)));
                                condition_class.AppendLine("\t\t" + "{");
                                condition_class.AppendLine("\t\t\t" + "GT,GT_EQ,LT,LT_EQ,EQ,NOT_EQ,BETWEEN");
                                condition_class.AppendLine("\t\t" + "}");
                                condition_class.AppendLine();
                                condition_class.AppendLine("\t\t" + string.Format("public {0}_ConditionType {0}_Condition",
                                    GeneratorUtil.ClassName(parameterName)) + "{get;set;}");
                                condition_class.AppendLine();
                            }
                        }
                    }
                }
                condition_class.AppendLine();
                //if (dvDB.IsPager)
                //{
                //    condition_class.AppendLine("\t\t" + "public int PageIndex{get;set;}");
                //    condition_class.AppendLine("\t\t" + "public int PageSize{get;set;}");
                //    condition_class.AppendLine("\t\t" + "public int RecordCount{get;set;}");
                //}

                condition_class.AppendLine("\t}");
                condition_class.AppendLine();
                condition_class.AppendLine();
                //condition_class.AppendLine();
                var queryName = GeneratorHelper.ClassName(this.txtName.Text.Trim());
                condition_class.AppendLine(string.Format("\tpublic class {0}Model : {0}_Condition", queryName));
                condition_class.AppendLine("\t{");
                condition_class.AppendLine(string.Format("\t\tpublic List<{0}> {0}s", ViewModelClass()));
                condition_class.AppendLine("\t\t{ get; set; }");
                condition_class.AppendLine();
                condition_class.AppendLine(string.Format("\t\tpublic {0}Model()", queryName));
                condition_class.AppendLine("\t\t{");
                condition_class.AppendLine(string.Format("\t\t\tthis.{0}s = new List<{0}>();", ViewModelClass()));
                condition_class.AppendLine("\t\t}");
                condition_class.AppendLine();
                condition_class.AppendLine("\t\tpublic void Action()");
                condition_class.AppendLine("\t\t{");
                //condition_class.AppendLine("\t\t\tvar service = new ServiceLayer.xxxService();");
                condition_class.AppendLine(string.Format("\t\t\tvar rslt = {0}(this);", queryName));
                if (dvDB.IsPager)
                {
                    condition_class.AppendLine(string.Format("\t\t\tthis.{0}s = rslt.PageRecords;", ViewModelClass()));
                    condition_class.AppendLine("\t\t\tthis.RecordCount = rslt.RecordCount;");
                }
                else
                {
                    condition_class.AppendLine(string.Format("\t\t\tthis.{0}s = rslt.Data;", ViewModelClass()));
                }
                condition_class.AppendLine("\t\t}");
                condition_class.AppendLine("\t}");
                condition_class.AppendLine("}");
                AppendHeader(condition_class, queryName + "Model");

                textEditorControl_Output.Document.TextContent = condition_class.ToString();// dvDB.Context.Render();
                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
                textEditorControl_Output.Refresh();
            }
        }

        private void btnGenActions_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);

                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();
                dvDB.Context.Wise(null);

                var builder = new IndentStringBuilder();
                var query = Helper.GetClassName(this.txtName.Text.Trim());
                var query_header = query.EndsWith("_query", StringComparison.OrdinalIgnoreCase) ? query.Substring(0, query.Length - 6) :
                    query;

                builder.AppendFormatLine("public ActionResult {0}({1}Model model)", query_header, query);
                builder.IncreaseIndentLine("{");
                builder.AppendLine("return View(model);");
                builder.DecreaseIndentLine("}");
                builder.AppendLine();

                builder.AppendFormatLine("public ActionResult {0}_List({1}Model model)", query_header, query);
                builder.IncreaseIndentLine("{");
                builder.AppendLine("model.Action();");
                builder.AppendLine("return Json(model, JsonRequestBehavior.AllowGet);");
                builder.DecreaseIndentLine("}");
                builder.AppendLine();

                builder.AppendFormatLine("public ActionResult {0}_Export({1}Model model)", query_header, query);
                builder.IncreaseIndentLine("{");
                builder.AppendLine("model.PageSize = int.MaxValue;");
                builder.AppendLine("model.PageIndex = 1;");
                builder.AppendLine("model.Action();");
                builder.AppendLine("var rdlc = new Company.ZCH49.OASystem.Crosscutting.Report.ReportGenerator();");
                builder.AppendLine("var error = \"\";");
                builder.AppendFormatLine("if (model.{0}Infos.Count > 0)", query_header);
                builder.IncreaseIndentLine("{");
                builder.AppendFormatLine("var buff = rdlc.GenerateReport(model.{0}Infos, \"{0}_Export\", out error);", query_header);
                builder.AppendFormatLine("return this.File(buff, \"application/vnd.ms-excel\", \"{0} Export.xls\");", query_header.Replace("_", " ").Trim());
                builder.DecreaseIndentLine("}");
                builder.AppendLine("else");
                builder.IncreaseIndentLine("{");
                builder.AppendLine("return new EmptyResult();");
                builder.DecreaseIndentLine("}");
                builder.DecreaseIndentLine("}");
                builder.AppendLine();

                textEditorControl_Output.Document.TextContent = builder.ToString();// dvDB.Context.Render();
                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
                textEditorControl_Output.Refresh();
            }

        }

        private void btnGenCCFlowService_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                SelectContext.Root = dvDB.Context;
                OnError(dvDB.Errors);
                dvDB.InitOption();
                dvDB.Context.Wise(null);

                var search = GeneratorUtil.ClassName(this.txtName.Text.Trim());
                var dtoName = string.Format("{0}_ConditionDto", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var dtoName_variable = GeneratorUtil.VariableName(dtoName);
                var domainName = string.Format("{0}_Condition", GeneratorUtil.ClassName(this.txtName.Text.Trim()));
                var domainName_variable = GeneratorUtil.VariableName(domainName);
                var action = GeneratorUtil.ClassName(this.txtName.Text.Trim());
                var retrunInfoDto_class = "ReturnInfoDto";
                if (dvDB.IsPager)
                {
                    retrunInfoDto_class = "PageOfReturnDto";
                }
                this.ModelInfo = dvDB.Context.Unions[0].Context.TableJoinInfos[0].RightModelInfo;

                var orders = dvDB.OrderPairs;

                //获得对应的model
                var modelName = "unknown";
                var paras = dvDB.Context.Parameters;

                modelName = GeneratorUtil.ClassName(this.txtResultModel.Text.Trim());
                var varModelName = Helper.GetVarName(modelName);

                var serviceDict = new Dictionary<string, string>();
                var result_list = false;
                var result_wraper = true;

                foreach (var op in dvDB.Options)
                {
                    if (op.Name.StartsWith(":"))
                    {
                        serviceDict.Add(op.Name.Substring(1), op.Value);
                    }
                    else if (op.Name.Equals("result_list", StringComparison.OrdinalIgnoreCase))
                    {
                        bool.TryParse(op.Value, out result_list);
                    }
                    else if (op.Name.Equals("result_wraper", StringComparison.OrdinalIgnoreCase))
                    {
                        bool.TryParse(op.Value, out result_wraper);
                    }
                }

                if (serviceDict.Count == 0)
                    return;

                var modelFields = new Dictionary<string, FieldInfo>();

                foreach (var field in dvDB.Context.Unions[0].Context.ReturnFields.OrderByName())
                {
                    if (field is MutiField)
                    {
                        var muti_fieds = field as MutiField;
                        foreach (var f in muti_fieds.AllFields.OrderByName())
                        {
                            var field_name = string.IsNullOrWhiteSpace(f.Alias) ? f.FullName : f.Alias;
                            field_name = GeneratorUtil.ClassName(field_name);
                            if (field_name.LastIndexOf(".") > -1)
                            {
                                field_name = field_name.Substring(field_name.LastIndexOf(".") + 1);
                            }

                            modelFields.Add(field_name, f);
                        }
                    }
                    else
                    {
                        var field_name = string.IsNullOrWhiteSpace(field.Alias) ? field.FullName : field.Alias;
                        field_name = GeneratorUtil.ClassName(field_name);
                        if (field_name.LastIndexOf(".") > -1)
                        {
                            field_name = field_name.Substring(field_name.LastIndexOf(".") + 1);
                        }
                        var nullAble = field.NullAble ? "?" : "";
                        if (field.SystemType.Equals("string", StringComparison.OrdinalIgnoreCase))
                        {
                            nullAble = "";
                        }
                        modelFields.Add(field_name, field);
                    }
                }

                //验证返回字段是否合法
                foreach (var srv in serviceDict)
                {
                    var ss = srv.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var s in ss)
                    {
                        if (!modelFields.ContainsKey(s))
                        {
                            MessageBox.Show(string.Format("结果集中没有该字段:{0} {1}", srv.Key, s));
                            return;
                        }
                    }
                }

                var builder = new IndentStringBuilder();

                foreach (var srv in serviceDict)
                {
                    builder.AppendFormatLine("[OperationContract]");
                    builder.AppendFormatLine("[WithoutAuthorization]");
                    builder.AppendFormatLine("[FaultContractAttribute(typeof(UnAuthorization))]");
                    builder.AppendFormat("List<KeyValuePair<string, string>> {0}(", srv.Key);
                    var fields = srv.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    for (var index = 0; index < paras.Count(); index++)
                    {
                        var para = paras[index];
                        builder.AppendFormat("string {0}", para.VariableName);
                        if (index != paras.Count() - 1)
                        {
                            builder.AppendFormat(", ", para);
                        }
                    }
                    builder.AppendFormatLine(");");
                    builder.AppendLine();
                }


                foreach (var srv in serviceDict)
                {
                    builder.AppendFormat("public List<KeyValuePair<string, string>> {0}(", srv.Key);

                    var fields = srv.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    for (var index = 0; index < paras.Count(); index++)
                    {
                        var para = paras[index];
                        builder.AppendFormat("string {0}", para.VariableName);
                        if (index != paras.Count() - 1)
                        {
                            builder.AppendFormat(", ");
                        }
                    }
                    builder.AppendFormatLine(")");
                    builder.IncreaseIndentLine("{");

                    builder.AppendFormatLine("try");
                    builder.IncreaseIndentLine("{");
                    builder.AppendFormat("var ret = _appService.{0}(", action);
                    for (var index = 0; index < paras.Count(); index++)
                    {
                        var para = paras[index];
                        var parseString = para.VariableName;
                        if (para.DbType == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Guid)
                        {
                            parseString = string.Format("Guid.Parse({0})", para.VariableName);
                        }
                        else if (para.DbType == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.Int)
                        {
                            parseString = string.Format("Int.Parse({0})", para.VariableName);
                        }
                        builder.AppendFormat("{0}", parseString);
                        if (index != paras.Count() - 1)
                        {
                            builder.AppendFormat(", ");
                        }
                    }
                    builder.AppendFormatLine(");");
                    if (!result_list)
                    {
                        if (result_wraper)
                        {
                            builder.AppendLine("if (ret == null || ret.Data == null)");
                            builder.AppendLine("\treturn null;");
                        }
                        else
                        {
                            builder.AppendLine("if (ret == null)");
                            builder.AppendLine("\treturn null;");
                        }
                    }
                    else
                    {
                        if (result_wraper)
                        {
                            builder.AppendLine("if (ret == null || ret.Data == null || ret.Data.Count() < 1)");
                            builder.AppendLine("\treturn null;");
                        }
                        else
                        {
                            builder.AppendLine("if (ret == null || ret.Data.Count() < 1)");
                            builder.AppendLine("\treturn null;");
                        }
                    }
                    builder.AppendLine();

                    builder.AppendLine("List<KeyValuePair<string, string>> kvs = new List<KeyValuePair<string, string>>();");

                    if (!result_list)
                    {
                        builder.Append("kvs.Add(new KeyValuePair<string, string>(");
                        for (var index = 0; index < fields.Count(); index++)
                        {
                            var field = fields[index];
                            if (modelFields[field].DbType == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.String)
                            {
                                if (result_wraper)
                                {
                                    builder.AppendFormat("ret.Data.{0}", field);
                                }
                                else
                                {
                                    builder.AppendFormat("ret.{0}", field);
                                }
                            }
                            else
                            {
                                if (result_wraper)
                                {
                                    builder.AppendFormat("ret.Data.{0}.ToString()", field);
                                }
                                else
                                {
                                    builder.AppendFormat("ret.{0}.ToString()", field);
                                }
                            }
                            if (index != fields.Count() - 1)
                            {
                                builder.AppendFormat(", ");
                            }
                        }
                        builder.AppendLine("));");
                    }
                    else
                    {
                        if (result_wraper)
                        {
                            builder.Append("kvs.AddRange(ret.Data.Select(o => new KeyValuePair<string, string>(");
                        }
                        else
                        {
                            builder.Append("kvs.AddRange(ret.Select(o => new KeyValuePair<string, string>(");
                        }
                        for (var index = 0; index < fields.Count(); index++)
                        {
                            var field = fields[index];
                            if (modelFields[field].DbType == CodeHelper.Core.Parse.ParseResults.DataViews.DbType.String)
                            {
                                builder.AppendFormat("o.{0}", field);
                            }
                            else
                            {
                                builder.AppendFormat("o.{0}.ToString()", field);
                            }
                            if (index != fields.Count() - 1)
                            {
                                builder.AppendFormat(", ");
                            }
                        }
                        builder.AppendLine(")));");
                    }

                    builder.AppendLine("return kvs.AddDefaultItem();");
                    builder.DecreaseIndentLine("}");
                    builder.AppendFormatLine("catch( Exception ex)");
                    builder.IncreaseIndentLine("{");
                    builder.AppendLine("LogHelper.Error(ex);");
                    builder.AppendLine("return null;");
                    builder.DecreaseIndentLine("}");
                    builder.DecreaseIndentLine("}");
                    builder.AppendLine();
                }

                textEditorControl_Output.Document.TextContent = builder.ToString();// dvDB.Context.Render();
                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
                textEditorControl_Output.Refresh();
            }
        }

        private void btnGenOrderBy_Click(object sender, EventArgs e)
        {
            List<ParseErrorInfo> errors;

            ContextMenu contextMenu;

            DataViewDB dvDB;

            SqlParser.Instance().Parse(this.textEditorControl.Document.TextContent, 0, out dvDB, out errors, out contextMenu);

            this.textEditorControl_Output.Document.HighlightingStrategy =
                HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");

            textEditorControl_Output.Document.TextContent = null;
            if (dvDB == null)
            {
                OnError(SqlParser.Instance().Errors.ToList());
            }
            if (dvDB != null)
            {
                OnError(dvDB.Errors);
                SelectContext.Root = dvDB.Context;

                dvDB.InitOption();

                dvDB.Context.Wise(null);
                var builder = new StringBuilder();
                var resultModel = this.txtResultModel.Text.Trim();

                if (string.IsNullOrWhiteSpace(resultModel))
                {
                    if (dvDB.Context.Unions.Count == 1)
                    {
                        var contxt = dvDB.Context.Unions[0].Context;
                        resultModel = contxt.TableJoinInfos[0].RightModelInfo.Name;
                    }
                }

                if (dvDB.Context.Unions.Count < 1)
                {
                    builder.AppendLine("没有查询表或者视图对象");
                    return;
                }
                builder.Append("'orderby' = '");
                bool isFirst = true;

                foreach (var field in dvDB.Context.Unions[0].Context.ReturnFields.OrderByName())
                {
                    if (field is MutiField)
                    {
                        var muti_fieds = field as MutiField;
                        foreach (var f in muti_fieds.AllFields.OrderByName())
                        {
                            var field_name = string.IsNullOrWhiteSpace(f.Alias) ? f.FullName : f.Alias;
                            field_name = GeneratorUtil.ClassName(field_name);
                            if (field_name.LastIndexOf(".") > -1)
                            {
                                field_name = field_name.Substring(field_name.LastIndexOf(".") + 1);
                            }
                            if (f.SystemType == "Guid" || f.SystemType == "Guid?")
                                continue;

                            if (isFirst)
                                builder.AppendFormat(string.Format("{0} asc|desc", field_name));
                            else
                                builder.AppendFormat(string.Format(",{0} asc|desc", field_name));

                            isFirst = false;
                        }
                    }
                    else
                    {
                        var field_name = string.IsNullOrWhiteSpace(field.Alias) ? field.FullName : field.Alias;
                        field_name = GeneratorUtil.ClassName(field_name);
                        if (field_name.LastIndexOf(".") > -1)
                        {
                            field_name = field_name.Substring(field_name.LastIndexOf(".") + 1);
                        }
                        var nullAble = field.NullAble ? "?" : "";
                        if (field.SystemType.Equals("string", StringComparison.OrdinalIgnoreCase))
                        {
                            nullAble = "";
                        }

                        if (field.SystemType == "Guid" || field.SystemType == "Guid?")
                            continue;

                        if (isFirst)
                            builder.AppendFormat(string.Format("{0} asc|desc", field_name));
                        else
                            builder.AppendFormat(string.Format(",{0} asc|desc", field_name));

                        isFirst = false;
                    }
                }
                builder.Append("'");

                this.textEditorControl_Output.Text = builder.ToString();
                this.textEditorControl_Output.Invalidate();
                textEditorControl_Output.Refresh();

                var frm = new ShowCodeFrm();
                frm.SetText(textEditorControl_Output.Document.TextContent);
                frm.Show();
            }
        }
    }
}
