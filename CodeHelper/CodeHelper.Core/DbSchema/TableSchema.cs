using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.DataBaseHelper.DbSchema
{
    public abstract class TableSchema
    {
        public IList<ColumnSchema> Columns = new List<ColumnSchema>();

        public bool IsView { get; set; }

        public string Name
        { get; set; }

        public ColumnSchema IdColumn
        {
            get
            {
                foreach (var col in this.Columns)
                {
                    if (col.IsPK)
                        return col;
                }
                return null;
            }
        }
    }
}
