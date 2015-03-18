/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

using CodeHelper.Core.Parse.ParseResults;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.Workflows;
namespace CodeHelper.Core.Parse.ParseResults.Workflows
{



    /**
     *
     * @author Administrator
     */
    public class Variable : TokenPair
    {
        public List<Field> Fields { get; set; }
        public List<Clz> Clzes { get; set; }

        internal VariableDefine Parse()
        {
            var rslt = new VariableDefine();

            foreach (var f in Fields)
            {
                rslt.Fields.Add(f.Parse());
            }

            foreach (var clz in this.Clzes)
            {
                rslt.Clzes.Add(clz.Parse());
            }
            return rslt;
        }
    }

}