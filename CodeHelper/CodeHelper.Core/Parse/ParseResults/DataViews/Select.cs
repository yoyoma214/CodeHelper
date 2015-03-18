using System;
using System.Collections.Generic;
using CodeHelper.Core.Parse.ParseResults.DataViews.Joins;
using CodeHelper.Core.Parse.ParseResults.DataViews.Condition;
using CodeHelper.Core.Parse.ParseResults.DataViews.Grouping;
using CodeHelper.Core.Parse.ParseResults.DataViews.Orders;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class Select : TokenPair
    {
        public List<Select_Atom> Select_atoms { get; set; }
        public List<Union_Type> Union_types { get; set; }

        public void Parse(SelectContext ctx)
        {
            //var result = new SelectContext();

            //if (ctx == null)
            //{
            //    result.ContextType = ContextType.Program;                
            //}

            //SelectAtomContext.Context_Stack.Push(result);

            foreach (var atom in Select_atoms)
            {
                var a = new SelectAtomContext();
                ctx.Unions.Add(new UnionContext() { Context = a });
                atom.Parse(a);
            }

            for (var index = 0; index < this.Union_types.Count; index++)
            {
                ctx.Unions[index].UnionType = Union_types[index].Parse();
            }
     
            //result.ParentContext = ctx;
            //SelectAtomContext.Context_Stack.Pop();

            //return result;
        }
    }
}