using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Core.Error;
using CodeHelper.Core.Parser;

namespace CodeHelper.Core.Parse.ParseResults.XmlModels
{
    public class XmModelDB : ParseModuleBase
    {
        //public Dictionary<string, ElementInfo> Elements { get; set; }
        public List<ElementInfo> Elements { get; set; }

        public override ParseType ParseType
        {
            get
            {
                return Parser.ParseType.XmlModel;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void Initialize()
        {
            if (Elements == null || Elements.Count == 0)
                return;

            //Elements.Values.ToList().ForEach(x => { 
            //    this.Types.Add(x);
            //    x.Init();
            //});

            Elements.ToList().ForEach(x =>
            {
                this.Types.Add(x);
                x.Init();
            });            
        }


    }
}
