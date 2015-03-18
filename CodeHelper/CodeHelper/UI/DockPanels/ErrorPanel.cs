using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeifenLuo.WinFormsUI.Docking;

namespace CodeHelper.UI.DockPanels
{
    public partial class ErrorPanel : DockContent
    {
        private System.Windows.Forms.DataGridViewTextBoxColumn Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn CharIndexInLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Message;
        private System.Windows.Forms.DataGridViewTextBoxColumn File;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnErrorType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFileId;
        private System.Windows.Forms.DataGridView dgvError;
    
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorPanel));
            this.dgvError = new System.Windows.Forms.DataGridView();
            this.Line = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CharIndexInLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Message = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.File = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnErrorType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFileId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvError)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvError
            // 
            this.dgvError.AllowUserToAddRows = false;
            this.dgvError.AllowUserToDeleteRows = false;
            this.dgvError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvError.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Line,
            this.CharIndexInLine,
            this.Message,
            this.File,
            this.ColumnErrorType,
            this.ColumnFileId});
            this.dgvError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvError.Location = new System.Drawing.Point(0, 0);
            this.dgvError.Margin = new System.Windows.Forms.Padding(2);
            this.dgvError.Name = "dgvError";
            this.dgvError.ReadOnly = true;
            this.dgvError.RowTemplate.Height = 27;
            this.dgvError.Size = new System.Drawing.Size(420, 262);
            this.dgvError.TabIndex = 1;
            // 
            // Line
            // 
            this.Line.DataPropertyName = "Line";
            this.Line.HeaderText = "行";
            this.Line.Name = "Line";
            this.Line.ReadOnly = true;
            this.Line.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Line.Width = 30;
            // 
            // CharIndexInLine
            // 
            this.CharIndexInLine.DataPropertyName = "CharPositionInLine";
            this.CharIndexInLine.HeaderText = "字符";
            this.CharIndexInLine.Name = "CharIndexInLine";
            this.CharIndexInLine.ReadOnly = true;
            this.CharIndexInLine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.CharIndexInLine.Width = 60;
            // 
            // Message
            // 
            this.Message.DataPropertyName = "Message";
            this.Message.HeaderText = "信息";
            this.Message.Name = "Message";
            this.Message.ReadOnly = true;
            this.Message.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Message.Width = 400;
            // 
            // File
            // 
            this.File.DataPropertyName = "File";
            this.File.HeaderText = "文件";
            this.File.Name = "File";
            this.File.ReadOnly = true;
            this.File.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.File.Width = 400;
            // 
            // ColumnErrorType
            // 
            this.ColumnErrorType.DataPropertyName = "ErrorType";
            this.ColumnErrorType.HeaderText = "错误类型";
            this.ColumnErrorType.Name = "ColumnErrorType";
            this.ColumnErrorType.ReadOnly = true;
            // 
            // ColumnFileId
            // 
            this.ColumnFileId.DataPropertyName = "FileId";
            this.ColumnFileId.HeaderText = "文件ID";
            this.ColumnFileId.Name = "ColumnFileId";
            this.ColumnFileId.ReadOnly = true;
            // 
            // ErrorPanel
            // 
            this.ClientSize = new System.Drawing.Size(420, 262);
            this.Controls.Add(this.dgvError);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ErrorPanel";
            ((System.ComponentModel.ISupportInitialize)(this.dgvError)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
