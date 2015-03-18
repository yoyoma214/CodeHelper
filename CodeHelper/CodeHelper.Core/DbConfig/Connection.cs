using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeHelper.Core.DbConfig
{
    public class Connection
    {
        public string ConnectionString { get; set; }

        public Dictionary<string, string> TableRepositories { get; private set; }

        public List<TableRelation> TableRelations { get; private set; }

        public Dictionary<string, List<TableStatus>> TableStatuses { get; private set; }

        public Connection()
        {
            TableRepositories = new Dictionary<string, string>();
            TableRelations = new List<TableRelation>();
            TableStatuses = new Dictionary<string, List<TableStatus>>();
        }

        public Connection(string connStr):this()
        {
            this.ConnectionString = connStr;
        }

        public List<TableRelation> FindRelations(string table, string refTable)
        {
            var rslt = new List<TableRelation> ();
            foreach (var r in this.TableRelations)
            {
                if (!string.IsNullOrWhiteSpace(refTable))
                {
                    if (!string.Equals( r.ForeignTable , refTable , StringComparison.OrdinalIgnoreCase))
                        continue;
                }
                if (r.MainTable.Equals(table, StringComparison.CurrentCultureIgnoreCase))
                    rslt.Add(r);
            }

            return rslt;
        }

        public List<TableStatus> FindStatus(string table)
        {            
            foreach (var kv in this.TableStatuses)
            {
                if (kv.Key.Equals(table, StringComparison.OrdinalIgnoreCase))
                    return kv.Value;
            }

            return new List<TableStatus>(0);
        }

        public string FindRepostory(string table)
        {
            foreach (var kv in TableRepositories)
            {
                if (kv.Key.Equals(table, StringComparison.OrdinalIgnoreCase))
                    return kv.Value;
            }

            return CodeHelper.Common.GenHelper.GetClassName(table) + "Repository";
        }

        /// <summary>
        /// Table : TableRepository 
        /// </summary>
        /// <param name="cfg"></param>
        public void Parse_TableRepository(string cfg)
        {
            this.TableRepositories.Clear();

            if (string.IsNullOrWhiteSpace(cfg))
                return;

            StringReader r = new StringReader(cfg);
            string line = null;
            while ((line = r.ReadLine()) != null)
            {
                try
                {
                    var ss = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    TableRepositories.Add(ss[0].ToLower(), ss[1].Trim());
                }
                catch (Exception e)
                {
                    ConnectionManager.FireValidateError(this.ConnectionString, e.Message);
                }
            }
            
        }

        /// <summary>
        /// TableA : TableA_FK,TableA_NavigateProperty,TableB,TableB_Key,OneToOne,TableB_Field1...[split_tag]
        /// </summary>
        /// <param name="cfg"></param>
        public void Parse_TableRelation(string cfg)
        {
            this.TableRelations.Clear();

            if (string.IsNullOrWhiteSpace(cfg))
                return;

            StringReader r = new StringReader(cfg);
            string line = null;
            while ((line = r.ReadLine()) != null)
            {
                try
                {
                    if (string.IsNullOrWhiteSpace(line))
                        continue;

                    line = line.Replace(" ", "").Replace(".map", ":").Replace("(", "").Replace(")", "").Replace(";", "");
                    var ss = line.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                    var mr = new TableRelation();
                    mr.MainTable = ss[0].Trim().ToLower();
                    var ss_1 = ss[1].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                    mr.MainFK = ss_1[0].Trim();
                    mr.NavigateProperty = ss_1[1].Trim();
                    mr.ForeignTable = ss_1[2].Trim().ToLower();
                    mr.ForeignKey = ss_1[3].Trim();

                    RelationType type;
                    if (!Enum.TryParse<RelationType>(ss_1[4].Trim(), out type))
                    {
                        throw new Exception("关联类型不对:" + ss_1[4].Trim());
                    }
                    mr.Relation = type;

                    for (var index = 5; index < ss_1.Length; index++)
                    {
                        var s = ss_1[index].Trim().ToLower();

                        if (s.StartsWith("\""))
                            mr.DisplaySplit = s;
                        else
                            mr.ForeignDisplayFields.Add(s);
                    }

                    TableRelations.Add(mr);
                }
                catch (Exception e)
                {
                    ConnectionManager.FireValidateError(this.ConnectionString, e.Message);
                }
            }
        }

        /// <summary>
        /// Table : Field( Value [:Description] )+
        /// </summary>
        /// <param name="cfg"></param>
        public void Parse_TableStatus(string cfg)
        {
            this.TableStatuses.Clear();

            if (string.IsNullOrWhiteSpace(cfg))
                return;

            StringReader r = new StringReader(cfg);
            string line = null;
            while ((line = r.ReadLine()) != null)
            {
                try
                {
                    var tableStatus = new TableStatus();
                    tableStatus.Parse(line);
                   
                    List<TableStatus> list = null;
                    if (this.TableStatuses.ContainsKey(tableStatus.Table))
                    {
                        list = this.TableStatuses[tableStatus.Table];
                    }
                    else
                    {
                        list = new List<TableStatus>();
                        this.TableStatuses.Add(tableStatus.Table, list);
                    }
                   
                    foreach (var unit in list)
                    {
                        if (unit.Field.Equals(tableStatus.Field))
                        {
                            throw new Exception(string.Format("重复定义:{0}", tableStatus.Field));
                        }
                    }

                    list.Add(tableStatus);

                }
                catch (Exception e)
                {
                    ConnectionManager.FireValidateError(this.ConnectionString, e.Message);
                }
            }
        }
    }
}
