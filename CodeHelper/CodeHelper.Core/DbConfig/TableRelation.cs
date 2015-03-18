using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Core.DbConfig
{
    public enum RelationType
    {
        ManyToOne,
        OneToOne,
        OneToMany,
        ManyToMany
    }

    public class TableRelation
    {
        public RelationType Relation { get; set; }

        public string MainTable { get; set; }

        public string MainFK { get; set; }

        public string ForeignTable { get; set; }

        public string ForeignKey { get; set; }

        private string _NavigateProperty = null;

        public string NavigateProperty
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_NavigateProperty))
                    return this.MainFK;
                return _NavigateProperty;
            }
            set
            {
                _NavigateProperty = value;
            }
        }

        public List<string> ForeignDisplayFields { get; set; }

        public string DisplaySplit { get; set; }

        public TableRelation()
        {
            ForeignDisplayFields = new List<string>();
            this.DisplaySplit = "_";
        }
    }
}
