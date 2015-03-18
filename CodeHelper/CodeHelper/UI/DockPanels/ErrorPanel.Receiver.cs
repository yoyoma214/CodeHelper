using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Infrastructure.Command;
using System.Windows.Forms;
using System.Drawing;
using CodeHelper.Core.Error;
using CodeHelper.Core.Services;
using CodeHelper.Core.Infrastructure;
using CodeHelper.Core.Infrastructure.Model;
using CodeHelper.AssembleLayer;
using CodeHelper.Core.Command;
using CodeHelper.Domain.Model;

namespace CodeHelper.UI.DockPanels
{
    public partial class ErrorPanel : IReceiverHolder
    {

        public ErrorPanel()
            : base()
        {
            this.TabText = this.Text = "错误列表";
            InitializeComponent();

            this.dgvError.RowHeadersWidth = 25;
        }

        protected override void OnLoad(EventArgs e)
        {
            GlobalService.ModelManager.ParseError += new OnParseError(GlobalService_ParseError);

            this.dgvError.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgvError_RowPostPaint);
            this.dgvError.CellDoubleClick += new DataGridViewCellEventHandler(dgvError_CellDoubleClick);

            base.OnLoad(e);
        }

        void dgvError_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                #region sort
                var dataSource = this.dgvError.DataSource as List<ParseErrorInfo>;

                var column = this.dgvError.Columns[e.ColumnIndex];
                if (column.Tag == null)
                    column.Tag = 0;

                var asc = !column.Tag.Equals(1)?true:false;

                if (column.Name == this.Line.Name)
                {
                    if (asc)
                        dataSource = dataSource.OrderBy(x => x.Line).ToList();
                    else
                        dataSource = dataSource.OrderByDescending(x => x.Line).ToList();
                }
                if (column.Name == this.CharIndexInLine.Name)
                {
                    if (asc)
                        dataSource = dataSource.OrderBy(x => x.CharPositionInLine).ToList();
                    else
                        dataSource = dataSource.OrderByDescending(x => x.CharPositionInLine).ToList();
                }
                if (column.Name == this.Message.Name)
                {
                    if (asc)
                        dataSource = dataSource.OrderBy(x => x.Message).ToList();
                    else
                        dataSource = dataSource.OrderByDescending(x => x.Message).ToList();
                }
                if (column.Name == this.File.Name)
                {
                    if (asc)
                        dataSource = dataSource.OrderBy(x => x.File).ToList();
                    else
                        dataSource = dataSource.OrderByDescending(x => x.File).ToList();
                }
                if (column.Name == this.ColumnFileId.Name)
                {
                    if (asc)
                        dataSource = dataSource.OrderBy(x => x.FileId).ToList();
                    else
                        dataSource = dataSource.OrderByDescending(x => x.FileId).ToList();
                }
                if (column.Name == this.ColumnErrorType.Name)
                {
                    if (asc)
                        dataSource = dataSource.OrderBy(x => x.ErrorType).ToList();
                    else
                        dataSource = dataSource.OrderByDescending(x => x.ErrorType).ToList();
                }
                if (asc)
                {
                    column.Tag = 1;
                }
                else
                {
                    column.Tag = 0;
                }

                this.dgvError.DataSource = dataSource;
                #endregion
            }
            if (e.RowIndex > -1)
            {
                var dataSource = this.dgvError.DataSource as List<ParseErrorInfo>;                                

                if (dataSource != null)
                {
                    var errorInfo = dataSource[e.RowIndex];

                    if ( string.IsNullOrWhiteSpace(errorInfo.File) && errorInfo.FileId == Guid.Empty)
                    {
                        return;
                    }
                    if (!errorInfo.FileId.HasValue)
                        return;

                    var ctx = GlobalService.EditorContextManager.Get(errorInfo.FileId.Value);

                    if (ctx != null)
                    {
                        ctx.Controller.RePosition(errorInfo.Line - 1,
                            errorInfo.CharPositionInLine, RePositionType.Error, errorInfo.Message);

                        DocumentViewManager.Instance().ActiveView(ctx.Model.FileId);
                    }
                    else
                    {
                        //Assemble.CreateEditor(errorInfo.File);

                        //var cmdHost_common = CommandHostManager.Instance().Get(CommandHostManager.HostType.Common);
                        ////var cmd = cmdHost_common.GetCommand(Dict.Commands.OpenFile);
                        //cmdHost_common.RunCommand(Dict.Commands.OpenFile);
                        if (string.IsNullOrWhiteSpace(errorInfo.File) && errorInfo.FileId.HasValue)
                        {
                            var model = GlobalService.ModelManager.GetModel(errorInfo.FileId.Value);
                            errorInfo.File = model.File;
                        }

                        CommandHostManager.Instance().OpenFile(errorInfo.File);

                        ctx = GlobalService.EditorContextManager.Get(errorInfo.FileId.Value);

                        ctx.Controller.RePosition(errorInfo.Line - 1,
                           errorInfo.CharPositionInLine, RePositionType.Error, errorInfo.Message);
                    }
                }
            }
        }

        void dgvError_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                dgvError.RowHeadersWidth - 4,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                dgvError.RowHeadersDefaultCellStyle.Font,
                rectangle,
                dgvError.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        void GlobalService_ParseError(string file, List<ParseErrorInfo> errors)
        {
            //if (errors == null || errors.Count == 0)
            //    return;

            //Action d2 = () => { this.dgvError.DataSource = errors; };
            //this.Invoke(d2);
            //return;
            if (this.InvokeRequired)
            {
                Action d = () => { this.dgvError.DataSource = errors; };
                this.Invoke(d);
            }
            else
            {
                this.dgvError.DataSource = errors;
            }
        }

        ReceiverBase receiver = new ReceiverBase();

        public ReceiverBase Receiver
        {
            get
            {
                return receiver;
            }
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // ErrorPanel
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 262);
        //    this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        //    this.Name = "ErrorPanel";
        //    this.ResumeLayout(false);

        //}
    }
}
