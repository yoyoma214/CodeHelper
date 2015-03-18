using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.DbConfig
{
    public class TableStatus
    {
        public string Table { get; set; }

        public string Field { get; set; }

        private List<StatusUnit> Units = new List<StatusUnit>();

        public class StatusUnit
        {
            public string Value { get; set; }
            public string Description { get; set; }
        }

        public void Parse(string line)
        {

            var cfg = line.Substring(line.IndexOf(':') + 1);

            this.Table = line.Substring(0, line.IndexOf(':')).Trim().ToLower();

            this.Field = cfg.Substring(0, cfg.IndexOf('(')).Trim().ToLower();

            var startIndex = cfg.IndexOf('(') + 1;
            var endIndex = cfg.IndexOf(')');
            var kv_str = cfg.Substring(startIndex, endIndex - startIndex);

            var kvs = kv_str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var kv in kvs)
            {
                var ss = kv.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                Units.Add(new StatusUnit()
                {
                    Value = ss[0].Trim(),
                    Description = ss[1].Trim()
                });
            }
        }
    }
}
