using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;

namespace CodeHelper.Core.Parse.ParseResults.DataModels
{
    public class DbProgram
    {
        public List<String> UsingNameSpaces { get; set; }

        public Dictionary<String, Model> Models { get; set; }

        public List<Mapping> Mapings { get; set; }
        public String NameSpace { get; set; }
        public List<ParseErrorInfo> Errors { get; set; }

        public DbProgram()
        {
            this.UsingNameSpaces = new List<string>();
            this.Models = new Dictionary<string, Model>();
            this.Mapings = new List<Mapping>();
            this.Errors = new List<ParseErrorInfo>();
        }

        public void Parse(DmModelDB db)
        {
            db.UsingNameSpaces.AddRange(this.UsingNameSpaces);
            db.NameSpace = this.NameSpace;

            foreach (var m in this.Models.Values)
            {
                db.Models.Add(m.Name,m.Parse());
            }

            foreach (var map in this.Mapings)
                db.Mapings.Add(map.Parse());

           db.Errors.AddRange(this.Errors);

        }
    }
}
