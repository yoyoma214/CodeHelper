using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Generator.DbSchema.Postgres;
using System.Xml;
using CodeHelper.Persistence.Enums;
using CodeHelper.Core;

namespace Generator.DbSchema
{
    public class DbTypeProvider
    {

        private static readonly Dictionary<string, Type> systemtypeMap =
        new Dictionary<string, Type>(){
    {typeof(string).Name,typeof(string)},
    {typeof(byte[]).Name,typeof(byte[])},
    {typeof(byte).Name,typeof(byte)},
    {typeof(bool).Name,typeof(bool)},
    {typeof(decimal).Name,typeof(decimal)},
    {typeof(DateTime).Name,typeof(DateTime)},
    {typeof(double).Name,typeof(double)},
    {typeof(Guid).Name,typeof(Guid)},
    {typeof(int).Name,typeof(int)},
    {typeof(short).Name,typeof(short)},
    {typeof(sbyte).Name,typeof(sbyte)},
    {typeof(object).Name,typeof(object)},
    {typeof(float).Name,typeof(float)},
    {typeof(TimeSpan).Name,typeof(TimeSpan)},
    {typeof(ushort).Name,typeof(ushort)},
    {typeof(uint).Name,typeof(uint)},
    {typeof(Int64).Name,typeof(Int64)},
    {typeof(XmlDocument).Name,typeof(XmlDocument)},
    {typeof(DateTimeOffset).Name,typeof(DateTimeOffset)}
                };
        public static IList<KeyValuePair<string, Type>> SystemTypeMap
        {
            get
            {

                var r = from kv in systemtypeMap
                        orderby kv.Key ascending
                        select kv;
                return r.ToList();
            }
        }
        public Type GetSystemType(string nativeType)
        {
            return GetSystemType(GetDbType(nativeType));
            //if (systemtypeMap.ContainsKey(nativeType))
            //{
            //    return systemtypeMap[nativeType];
            //}
            //return null;
        }

        public virtual Type GetSystemType(DbType type)
        {
            switch (type)
            {
                    
                case DbType.AnsiString:
                    return typeof(string);

                case DbType.Binary:
                    return typeof(byte[]);

                case DbType.Byte:
                    return typeof(byte);

                case DbType.Boolean:
                    return typeof(bool);

                case DbType.Currency:
                    return typeof(decimal);

                case DbType.Date:
                    return typeof(DateTime);

                case DbType.DateTime:
                    return typeof(DateTime);

                case DbType.Decimal:
                    return typeof(decimal);

                case DbType.Double:
                    return typeof(double);

                case DbType.Guid:
                    return typeof(Guid);

                case DbType.Int16:
                    return typeof(short);

                case DbType.Int32:
                    return typeof(int);

                case DbType.Int64:
                    return typeof(long);

                case DbType.Object:
                    return typeof(object);

                case DbType.SByte:
                    return typeof(sbyte);

                case DbType.Single:
                    return typeof(float);

                case DbType.String:
                    return typeof(string);

                case DbType.Time:
                    return typeof(TimeSpan);

                case DbType.UInt16:
                    return typeof(ushort);

                case DbType.UInt32:
                    return typeof(uint);

                case DbType.VarNumeric:
                    return typeof(decimal);

                case DbType.AnsiStringFixedLength:
                    return typeof(string);

                case DbType.StringFixedLength:
                    return typeof(string);

                //case (DbType.String | DbType.Double):
                //    return typeof(object);

                case DbType.Xml:
                    return typeof(XmlDocument);

                case DbType.DateTime2:
                    return typeof(DateTime);

                case DbType.DateTimeOffset:
                    return typeof(DateTimeOffset);
            }
            return null;

        }

        public virtual DbType GetDbType(string nativeType)
        {           
            switch (nativeType.Trim().ToLower())
            {
                case "string":
                    return DbType.String;

                case "bigint":
                    return DbType.Int64;

                case "binary":
                    return DbType.Binary;

                case "bit":
                    return DbType.Boolean;

                case "char":
                    return DbType.AnsiStringFixedLength;

                case "datetime":
                    return DbType.DateTime;

                case "decimal":
                    return DbType.Decimal;

                case "float":
                    return DbType.Double;

                case "image":
                    return DbType.Binary;

                case "int":
                    return DbType.Int32;

                case "int32":
                    return DbType.Int32;

                case "money":
                    return DbType.Currency;

                case "nchar":
                    return DbType.StringFixedLength;

                case "ntext":
                    return DbType.String;

                case "numeric":
                    return DbType.Decimal;

                case "nvarchar":
                    return DbType.String;

                case "real":
                    return DbType.Single;

                case "smalldatetime":
                    return DbType.DateTime;

                case "smallint":
                    return DbType.Int16;

                case "smallmoney":
                    return DbType.Currency;

                case "sql_variant":
                    return DbType.Object;

                case "sysname":
                    return DbType.StringFixedLength;

                case "text":
                    return DbType.AnsiString;

                case "timestamp":
                    return DbType.Binary;

                case "tinyint":
                    return DbType.Byte;

                case "uniqueidentifier":
                    return DbType.Guid;

                case "varbinary":
                    return DbType.Binary;

                case "varchar":
                    return DbType.AnsiString;

                case "xml":
                    return DbType.Xml;

                case "datetime2":
                    return DbType.DateTime2;

                case "time":
                    return DbType.Time;

                case "date":
                    return DbType.Date;

                case "datetimeoffset":
                    return DbType.DateTimeOffset;
                case "bool":
                    return DbType.Boolean;
                case "boolean":
                    return DbType.Boolean;
                case "guid":
                    return DbType.Guid;                
            }
            return DbType.Object;
        }

        public string GetSpecifcDbType(DatabaseType dbType, string nativeType)
        {
            var t = this.GetDbType(nativeType);
            switch (t)
            {
                case DbType.AnsiStringFixedLength:
                case DbType.AnsiString:
                    return "nvarchar";
                case DbType.Binary:
                    return "binary(50)";
                case DbType.Boolean:
                    return "bit";
                case DbType.Byte:
                    return "smallint";
                case DbType.Currency:
                    return "money";
                case DbType.Date:
                    return "date";
                case DbType.Time:
                case DbType.DateTime:
                    return "datetime";
                case DbType.DateTime2:
                    return "datetime2(7)";
                case DbType.DateTimeOffset:
                    return "datetimeoffset(7)";
                case DbType.VarNumeric:
                case DbType.Decimal:
                    return "decimal(18, 4)";
                case DbType.Double:
                    return "float";
                case DbType.Guid:
                    return "uniqueidentifier";
                case DbType.UInt16:
                case DbType.Int16:
                    return "smallint";
                case DbType.UInt32:
                case DbType.Int32:
                    return "int";
                case DbType.UInt64:
                case DbType.Int64:
                    return "bigint";
                case DbType.Object:
                    return "unkown";
                case DbType.SByte:
                    return "tinyint";
                case DbType.StringFixedLength:
                case DbType.String:
                    return "nvarchar";
                default:
                    break;                    
            }
            return "unknown";
        }

        public static DbTypeProvider Create(DatabaseType databaseType)
        {
            if (databaseType == DatabaseType.Postgres)
                return new PostgresDbTypeProvider();

            return null;
        }
    }
}
