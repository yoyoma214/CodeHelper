using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CodeHelper.DataBaseHelper.UI.PropertyGrids
{
    class MyConverter : ExpandableObjectConverter
    {

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {

            return true;

        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {

            return true;

        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {

            var conn_attr = context.
                PropertyDescriptor.Attributes[typeof(ConnectionListAttribute)];

            var list = new List<string>();
            StandardValuesCollection vals = new StandardValuesCollection(list);
            if ( conn_attr != null )
            {
                ConnectionListAttribute lst = (ConnectionListAttribute)conn_attr; 
               
                
                foreach( var conn in DBGlobalService.CurrentProject.Connections)
                {
                    list.Add(conn.Name);
                }

                vals = new TypeConverter.StandardValuesCollection(list);
            }
            


            return vals;

        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {

            return true;

        }

    }

}
