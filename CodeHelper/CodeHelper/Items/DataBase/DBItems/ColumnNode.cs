using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using System.Data;
using CodeHelper.DataBaseHelper.DbSchema;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    public abstract class ColumnNode : BaseNode
    {
        public bool IsPK { get; set; }
        public Type SystemType { get; set; }
        public bool AllowDBNull { get; set; }
        public int Scale { get; set; }
        public int Precision { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
        public string DbType { get; set; }
        public string ForeignKeyTable { get; set; }
        public string ForeignKeyColumn { get; set; }
        public bool IsVirtualFK { get; set; }
        //private ColumnSchema _Column = null;

        public ColumnNode()
            : base()
        {
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "230";
        }

        public virtual ColumnSchema Column
        {
            //get
            //{ return this._Column; }
            set
            {
             
                if (value == null)
                {
                }
                else
                {
                    this.IsPK = value.IsPK;
                    this.AllowDBNull = value.AllowDBNull;
                    this.DbType = value.DataType;
                    this.Description = value.Description;
                    this.Text = this.Name = value.Name;
                    this.Precision = value.Precision;
                    this.Scale = value.Scale;
                    this.Size = value.Size;
                    this.ForeignKeyColumn = value.ForeignKeyColumn;
                    this.ForeignKeyTable = value.ForeignKeyTable;
                    this.IsVirtualFK = !string.IsNullOrWhiteSpace(value.ForeignKeyColumn);              
                    this.SystemType = value.SystemType;
                    this.Text = this.Name + " ("
                        + (this.IsPK ? "PK, " : "")
                        + this.DbType + (this.Size > 0 ? "(" + this.Size + ")" : "") + ", "
                        + (this.AllowDBNull ? "null" : "not null")
                        + ")";
                }
            }
        }
        public override void Save()
        {
            base.Save();
        }

        protected ColumnType dataInfo = DBGlobalService.CurrentProjectDoc.CreateNode<ColumnType>();

        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                this.dataInfo.IsPK = this.IsPK;
                this.dataInfo.Name = this.Name;
                this.dataInfo.AllowDBNull = this.AllowDBNull;
                this.dataInfo.DbType = this.DbType.ToString();
                this.dataInfo.Description = this.Description??"";
                this.dataInfo.Precision  = this.Precision;
                this.dataInfo.Scale = this.Scale;
                this.dataInfo.Size = this.Size;
                if (this.SystemType == null)
                {
                }
                if (this.SystemType == typeof(object))
                {
                }
                this.dataInfo.SystemType = this.SystemType.Name??"";
                this.dataInfo.ForeignKeyColumn = this.ForeignKeyColumn ?? "";
                this.dataInfo.ForeignKeyTable = this.ForeignKeyTable ?? "";
                this.dataInfo.IsVirtualFK = this.IsVirtualFK;
                return this.dataInfo;
            }
            set
            {
                    this.dataInfo = (ColumnType)value;
                this.IsPK = this.dataInfo.IsPK;
                this.AllowDBNull = this.dataInfo.AllowDBNull;
                this.DbType = this.dataInfo.DbType;
                this.Description = this.dataInfo.Description;
                this.Text = this.Name = this.dataInfo.Name;
                this.Precision = this.dataInfo.Precision;
                this.Scale = this.dataInfo.Scale;
                this.Size = this.dataInfo.Size;

                this.SystemType = SchemaUtility.GetSystemType(DBGlobalService.DbType, this.dataInfo.SystemType);
                if (this.SystemType == null)
                {
                }
                
                if (this.SystemType == typeof(object))
                {
                }
                this.Text = this.Name + " ("
                    + (this.IsPK ? "PK, " : "")
                    + this.DbType + (this.Size > 0 ? "(" + this.Size + ")" : "") + ", "
                    + (this.AllowDBNull ? "null" : "not null")
                    + ")";
            }
        }
    }
}
