using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

namespace CodeHelper.Common.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum e)
        {
            return EnumUtils.GetDescription(e);
        }
    }

    /// <summary>
    /// 枚举工具
    /// </summary>
    public static class EnumUtils
    {
        /// <summary>
        /// 获得枚举值的描述
        /// </summary>
        /// <param name="e">枚举值</param>
        /// <returns>描述</returns>
        public static string GetDescription(Enum e)
        {
            FieldInfo fi = e.GetType().GetField(e.ToString());
            try
            {
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return (attributes != null && attributes.Length > 0) ? attributes[0].Description : e.ToString();
            }
            catch
            {
                return "(Unknow)";
            }
        }



        /// <summary>
        /// 获得枚举项的集合
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns>枚举项</returns>
        public static List<EnumItem> GetEnumItems(Type enumType)
        {
            return (from Enum e in Enum.GetValues(enumType)
                    select new EnumItem
                    {
                        Name = e.ToString(),
                        Value = e.GetHashCode(),
                        Description = GetDescription(e)
                    }).ToList();
        }

        /// <summary>
        /// <para>将枚举转化为Dictionary。</para>
        /// <para>字典的键是枚举的数字值。</para>
        /// <para>字典的值是枚举的DescriptionAttribute值。</para>
        /// </summary>
        /// <typeparam name="T">枚举</typeparam>
        /// <returns>存储枚举值,枚举说明的字典。</returns>
        public static IDictionary<int, string> ConvertToDict<T>() where T : struct
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            FieldInfo[] fileds = typeof(T).GetFields();
            string description = string.Empty;
            foreach (FieldInfo filed in fileds)
            {
                object[] attrs = filed.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs == null || attrs.Length == 0)
                {
                    continue;
                }

                description = ((DescriptionAttribute)attrs[0]).Description;
                result.Add((int)filed.GetRawConstantValue(), description);
            }

            return result;
        }

        /// <summary>
        /// 功能：将字符串转换成枚举
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue">转换失败时的默认值</param>
        /// <returns></returns>
        public static T ToEnum<T>(string value, T defaultValue) where T : struct
        {
            if (typeof(T).IsEnum == false)
            {
                throw new Exception("类型错误，只能转换成枚举类型");
            }

            T result;

            if (Enum.TryParse<T>(value, false, out result))
            {
                return result;
            }

            return defaultValue;
        }
    }

    /// <summary>
    /// 枚举项
    /// </summary>
    public class EnumItem
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }
    }
}

