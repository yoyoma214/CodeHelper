using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.DbSchema;
using System.Drawing;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.DBItems
{
    public abstract class FieldNode : BaseNode
    {
        protected FieldType dataInfo = DBGlobalService.CurrentProjectDoc.CreateNode<FieldType>();
        private Type _systemType ;
        string _columnName = null;
        public string ColumnName
        {
            get
            { return _columnName; }
            set
            {
                _columnName = value;
                this.OnUpdate();
            }
        }
        public void OnColumnModify(bool modified = true)
        {
            if (modified)
            {
                this.TreeNode.BackColor = Color.Red;
            }
            else
            {
                this.TreeNode.BackColor = Color.White;
            }
        }
        public Type SystemType
        {
            get { return this._systemType; }
            set
            {
                this._systemType = value;
                this.OnUpdate();
            }
        }
        bool _nullAble;
        public bool NullAble
        {
            get
            {
                return this._nullAble;
            }
            set
            {
                this._nullAble = value;
                this.OnUpdate();
            }
        }

        public FieldNode()
            : base()
        {
            this.TreeNode.SelectedImageKey = this.TreeNode.ImageKey = "229";
        }

        public virtual void Assign(ColumnSchema column)
        {
            this.Name = column.Name;
            this.SystemType = column.SystemType;
            this.NullAble = column.AllowDBNull;
            this.Description = column.Description;
            this.ColumnName = column.Name;
        }

        protected override void OnUpdate()
        {
            if (this.SystemType != null)
            {
                var text = this.Name + " (" + this.SystemType.Name
                      + (this._systemType.IsValueType && this.NullAble ? ", ?" : "")
                      + " From: " + this.ColumnName +
                      ")";

                base.Text = text;
            }
            base.OnUpdate();
        }  
        public string Description { get; set; }
        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                this.dataInfo.Name = (this.Name);
                this.dataInfo.SystemType = this.SystemType.Name;
                this.dataInfo.Description = this.Description;
                this.dataInfo.NullAble = this.NullAble;
                this.dataInfo.ColumnName= this.ColumnName;
                return this.dataInfo;
            }
            set
            {
                this.dataInfo = (FieldType)value;
                this.Text = this.Name = this.dataInfo.Name;
                this.SystemType = SchemaUtility.GetSystemType(DBGlobalService.DbType, this.dataInfo.SystemType);
                this.Description = string.IsNullOrWhiteSpace(this.dataInfo.Description)?this.dataInfo.Description:"";
                this.NullAble = this.dataInfo.NullAble;
                this.ColumnName = string.IsNullOrWhiteSpace(this.dataInfo.ColumnName)?this.dataInfo.ColumnName:"";
            }
        }
        public override void Save()
        {                        
            base.Save();
        }
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                //base.Text = value;                
            }
        }
    }
}
