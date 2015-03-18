/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using System;
using CodeHelper.Core.Parse.ParseResults.Workflows;
using System.Collections.Generic;
namespace CodeHelper.Core.Parse.ParseResults.Workflows
{
    public class Clz : TokenPair
    {
        public String Name { get; set; }
        public List<Field> Fields { get; set; }


        internal ClzInfo Parse()
        {
            var rslt = new ClzInfo();
            rslt.TokenPair = this;
            rslt.Name = Name;

            foreach (var f in this.Fields)
            {
                rslt.fields.Add(f.Parse());
            }

            return rslt;
        }
    }
}