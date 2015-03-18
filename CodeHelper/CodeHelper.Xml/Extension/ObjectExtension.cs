using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;

namespace CodeHelper.Xml.Extension
{
    public static class ObjectExtension
    {
        private static readonly Type ValueTypeType = typeof(ValueType);



        /// <summary>
        /// 将字符转换成自己的类型
        /// </summary>
        /// <param name="val">System.String</param>
        /// <returns>如果转换失败将返回 T 的默认值</returns>
        public static T ToT<T>(this object val)
        {
            if (val != null)
            {
                return val.ToT<T>(default(T));
            }
            else
            {
                return default(T);
            }
        }

        /// <summary>
        /// 当前对象转换成特定类型，如果转换失败或者对象为null，返回defaultValue。
        /// 如果传入的是可空类型：会试着转换成其真正类型后返回。
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <param name="value">原类型对象</param>
        /// <param name="defaultValue">转换出错或者对象为空的时候的默认返回值</param>
        /// <returns>转换后的值</returns>
        public static T ToT<T>(this object value, T defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }
            else if (value is T)
            {
                return (T)value;
            }
            try
            {
                Type typ = typeof(T);
                if (typ.BaseType == ObjectExtension.ValueTypeType && typ.IsGenericType)//可空泛型
                {
                    Type[] typs = typ.GetGenericArguments();
                    return (T)Convert.ChangeType(value, typs[0]);
                }
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch
            {
                return defaultValue;
            }
        }



        ///// <summary>
        ///// 根据类型 名称 获取context值
        ///// </summary>
        ///// <param name="ty">类型</param>
        ///// <param name="name">名称</param>
        ///// <returns></returns>
        //public static object GetValueByType1(Type ty, object value)
        //{
        //    if (value != null && value != DBNull.Value)
        //    {
        //        try
        //        {
        //            object result = new object();
        //            string Objvalue = string.Empty;
        //            Objvalue = string.Format("\"{0}\"", value);
        //            result = JsonConvert.DeserializeObject(Objvalue, ty);
        //            return result;
        //        }
        //        catch
        //        {
        //            return null;
        //        }
        //    }

        //    return null;
        //}

        /// <summary>
        /// 深度拷贝对象，适合轻量级对象拷贝
        /// 崔清勇 2011/11/07 17:01
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">对象自身</param>
        /// <returns>新对象</returns>
        public static T DeepClone<T>(this object obj) //深clone
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
            stream.Position = 0;
            return (T)formatter.Deserialize(stream);
        }

        /// <summary>
        /// 获取DataRow字段值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static T RowToT<T>(this DataRow row, string columnName)
        {
            return !row.Table.Columns.Contains(columnName) || row.IsNull(columnName)
                       ? default(T)
                       : row.Field<T>(columnName);
        }

    }
}
