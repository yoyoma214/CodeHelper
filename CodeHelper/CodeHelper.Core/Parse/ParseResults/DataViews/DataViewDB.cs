using System;
using System.Collections.Generic;

namespace CodeHelper.Core.Parse.ParseResults.DataViews
{
    public class DataViewDB : ParseModuleBase
    {
        public Select Select { get; set; }
        public Search_Option Search_option { get; set; }
        public SelectContext Context { get; set; }

        public List<SqlOption> Options { get; set; }
        public bool IsPager
        {
            get
            {
                var b = false;

                foreach (var option in Options)
                {
                    if (option.Name.Equals("pager", StringComparison.OrdinalIgnoreCase))
                    {
                        bool.TryParse(option.Value, out b);                        
                    }
                }
                return b;
            }
        }

        public List<OrderPair> OrderPairs
        {
            get
            {
                var rslt = new List<OrderPair>();

                foreach (var option in Options)
                {
                    //查找排序选项
                    if (option.Name.Equals("orderby", StringComparison.OrdinalIgnoreCase))
                    {
                        var ss = option.Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (ss.Length == 0)
                            break;
                        
                        //遍历每个字段排序选项
                        foreach (var field in ss)
                        {
                            var temp = field.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                            if (temp.Length == 0)
                                break;

                            var pair = new OrderPair();
                            pair.OrderType = OrderType.Asc;

                            pair.FieldName = temp[0];
                            var pair2 = new OrderPair();
                            pair2.FieldName = temp[0];

                            rslt.Add(pair);

                            //查找可能的asc,desc的组合("|")分割
                            if ( temp.Length > 1 )
                            {
                                var types = temp[1].Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                                if (types.Length == 0)
                                    break;

                                if (types.Length == 1)
                                {
                                    if (types[0].Equals("desc", StringComparison.OrdinalIgnoreCase))
                                    {
                                        pair.OrderType = OrderType.Desc;
                                    }
                                }
                                else if (types.Length == 2) 
                                {
                                    if (types[0].Equals("desc", StringComparison.OrdinalIgnoreCase))
                                    {
                                        pair.OrderType = OrderType.Desc;
                                    }

                                    if (types[1].Equals("desc", StringComparison.OrdinalIgnoreCase))
                                    {
                                        pair2.OrderType = OrderType.Desc ;
                                    }
                                    else
                                    {
                                        pair2.OrderType = OrderType.Asc;
                                    }                        

                                    rslt.Add(pair2);
                                }
                            }                                                        
                        }
                    }
                }

                //排重
                for (int i = 0; i < rslt.Count; i++)
                {
                    var pair = rslt[i];
                    OrderPair pair2 ;

                    for (int j = i + 1; j < rslt.Count; j++)
                    {
                        pair2 = rslt[j];
                        if (pair.FieldName == pair2.FieldName && pair.OrderType == pair2.OrderType)
                        {
                            rslt.Remove(pair2);
                            i--;
                            j--;
                        }
                    }
                }
                return rslt;
            }
        }

        public struct OrderPair
        {
            public OrderType OrderType;
            public string FieldName;
            public string SafeName
            {
                get
                {
                    return FieldName.Replace(".", "_");
                }
            }
        }
        public enum OrderType
        {
            Asc,Desc
        }

        public override Parser.ParseType ParseType
        {
            get
            {
                return Parser.ParseType.DataView;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DataViewDB()
        {
            this.Context = new SelectContext();
             this.Options = new List<SqlOption>();
        }

        public override void Initialize()
        {
            //throw new NotImplementedException();
        }

        public void Parse()
        {
            //this.Context.ContextType = ContextType.Program;

            //todo:安全性可能有问题，thist.Context可以为null 避免
            SelectAtomContext.Context_Stack.Clear();
            SelectAtomContext.Condition_Stack.Clear();
            this.Context = new SelectContext();
            this.Select.Parse(this.Context);
        }

        public override void Wise()
        {
            base.Wise();
        }

        public void InitOption()
        {
            if (Search_option == null || Search_option.Option_expression == null ||
                Search_option.Option_expression.Option_list == null ||
                Search_option.Option_expression.Option_list.Options == null)
                return;

            foreach (var option in Search_option.Option_expression.Option_list.Options)
            {
                this.Options.Add(new SqlOption() { Name = option.Option_name.Text.Replace("'", ""), Value = option.Option_value.text.Replace("'", "") });
            }
        }
    }
}