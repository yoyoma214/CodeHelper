using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Parse.ParseResults.DataViews;
using Project;

namespace CodeHelper.DataBaseHelper.Sql
{
    class ResloveTableAgent : IResloveTableAgent
    {
        public TableInfo Reslove(string tableName)
        {
            ConnectionType currentConn = null;

            foreach (var conn in DBGlobalService.CurrentProject.Connections)
            {
                if (conn.ConnectionString == DBGlobalService.ConnectionString)
                {
                    currentConn = conn;
                    break;
                }
            }

            if (currentConn == null)
                return null;

            var tables = new List<TableType>();
            tables.AddRange(currentConn.Tables);
            tables.AddRange(currentConn.Views);

            foreach (var table in tables)
            {
                if (string.Equals(table.Name, tableName, StringComparison.OrdinalIgnoreCase))
                {
                    var rslt = new TableInfo();
                    rslt.Name = table.Name;

                    foreach (var column in table.ColumnSet.Columns)
                    {
                        var fieldInfo = new FieldInfo();
                        fieldInfo.FullName = column.Name;
                        var typeInfo = Type.GetType(column.SystemType);
                        switch (column.SystemType.ToLower())
                        {
                            case "int32" :
                                fieldInfo.DbType = DbType.Int;
                                break;
                            case "boolean":
                                fieldInfo.DbType = DbType.Bool;
                                break;
                            case "char":
                                fieldInfo.DbType = DbType.Char;
                                break;
                            case "datetime":
                                fieldInfo.DbType = DbType.DateTime;
                                break;
                            case "float":
                                fieldInfo.DbType = DbType.Float;
                                break;
                            case "string":
                                fieldInfo.DbType = DbType.String;
                                break;
                        }
          
                        rslt.Fields.Add(fieldInfo);
                    }
                    return rslt;
                }
            }
            return null;
            
        }


        public ModelInfo ResloveMapModel(string tableName)
        {

            ConnectionType currentConn = null;

            foreach (var conn in DBGlobalService.CurrentProject.Connections)
            {
                if (conn.ConnectionString == DBGlobalService.ConnectionString)
                {
                    currentConn = conn;
                    break;
                }
            }

            if (currentConn == null)
                return null;

            var tables = new List<TableType>();
            tables.AddRange(currentConn.Tables);
            tables.AddRange(currentConn.Views);

            foreach (var table in tables)
            {
                if (string.Equals(table.Name, tableName, StringComparison.OrdinalIgnoreCase))
                {
                    if (table.Model == null)
                        return null;

                    var rslt = new ModelInfo();
                    rslt.Name = table.Model.Name;

                    foreach (var field in table.Model.Fields)
                    {
                        var fieldInfo = new FieldInfo();
                        fieldInfo.FullName = field.Name;
                        var typeInfo = Type.GetType(field.SystemType);
                        switch (field.SystemType.ToLower())
                        {
                            case "int32":
                                fieldInfo.DbType = DbType.Int;
                                break;
                            case "boolean":
                                fieldInfo.DbType = DbType.Bool;
                                break;
                            case "char":
                                fieldInfo.DbType = DbType.Char;
                                break;
                            case "datetime":
                                fieldInfo.DbType = DbType.DateTime;
                                break;
                            case "float":
                                fieldInfo.DbType = DbType.Float;
                                break;
                            case "string":
                                fieldInfo.DbType = DbType.String;
                                break;
                            case "guid":
                                fieldInfo.DbType = DbType.Guid;
                                break;
                            case "decimal":
                                fieldInfo.DbType = DbType.Decimal;
                                break;
                            default:
                                break;
                        }
                        fieldInfo.NullAble = field.NullAble;
                        rslt.Fields.Add(fieldInfo);
                    }
                    return rslt;
                }
            }
            return null;
        }


        public FieldInfo ResloveMapField(string tableName, string fieldName)
        {
            var model = this.ResloveMapModel(tableName);
            if (model == null)
                return null;

            foreach (var field in model.Fields)
            {
                if (field.ShortName.Equals(fieldName, StringComparison.OrdinalIgnoreCase))
                    return field;
            }

            return null;
        }
    }
}
