using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.DataBaseHelper.UI.PropertyGrids
{
    class ConnectionListAttribute : Attribute
    {

        public string[] lists;

        public ConnectionListAttribute()
        {
            //如果要实现动态下拉列表，在此处初始化lists对象值   
            lists = new string[] { "A", "B", "C", "D", "E" };

        }

    }

}
