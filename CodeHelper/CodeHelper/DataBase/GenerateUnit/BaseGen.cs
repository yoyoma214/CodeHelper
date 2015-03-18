using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.DataBaseHelper.Items.DBItems;

namespace CodeHelper.DataBaseHelper.GenerateUnit
{
    public class BaseGen :IGenerate
    {
        public virtual void Generate(StringBuilder builder)
        {
            //throw new NotImplementedException();
        }
        //public static IGenerate CreateGenerator(TableSchema table)
        //{
        //    return new ModelGen(table);
        //}
        //public static IGenerate CreateGenerator(ModelNode table)
        //{
        //    return null;
        //}
        //public static IGenerate CreateGenerator(TableSchema table)
        //{
        //    return null;
        //}
    }
}
