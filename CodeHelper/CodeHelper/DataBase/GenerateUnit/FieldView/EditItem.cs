using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.DbSchema;

namespace CodeHelper.DataBaseHelper.GenerateUnit.FieldView
{
    class EditItem
    {
        FieldType _fieldInfo = null;
        protected string Name
        {
            get
            {
                return this._fieldInfo != null ? this._fieldInfo.Name : "";
            }
        }
        protected string SystemTypeName
        {
            get
            {
                return this._fieldInfo != null ? this._fieldInfo.SystemType : "";
            }
        }
        protected Type SystemType
        {
            get
            {
                return this._fieldInfo != null ? SchemaUtility.GetSystemType(DBGlobalService.DbType,this._fieldInfo.SystemType) : null;
            }
        }
        protected FieldType FieldInfo
        {
            get
            {
                return this._fieldInfo;
            }
        }
        public EditItem(FieldType field)
        {
            this._fieldInfo = field;
        }
        
    }
}
