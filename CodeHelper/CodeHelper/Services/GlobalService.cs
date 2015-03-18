using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using CodeHelper.DataBaseHelper.EF.StorageModels;
using CodeHelper.DataBaseHelper.Repository;
using CodeHelper.Xml;
using CodeHelper.Core;
using System.IO;
using System.Windows.Forms;
using CodeHelper.Core.DbConfig;
//using Generator.Config;

namespace CodeHelper.DataBaseHelper
{
    public class DBGlobalService
    {
        public delegate void ClearError();
        
        public delegate void SaveDelegate();
        public static event SaveDelegate SaveProject;
        public static event ClearError OnClearError;

        public static void FireClearError()
        {
            if (OnClearError != null)
                OnClearError();
        }

        public static ImageList Icons { get; private set; }

        public static Document CurrentProjectDoc
        {
            get;
            set;
        }

        public static ProjectType CurrentProject
        {
            get;
            set;
        }

        public static Document BusinessCfgDoc
        {
            get;
            set;
        }

        public static string ProjectFile
        {
            get;
            set;
        }

        public static string BizFile
        {
            get
            {
                return DBGlobalService.ProjectFile.Replace(".xml", ".biz.xml");
            }
        }

        static DBGlobalService()
        {
            Icons = new ImageList();
        }

        public static string ConfigXsd = @"Project.xsd";

        private static string _connectionString = null;

        public static string ConnectionString
        {
            get
            {
                return _connectionString;
            }
            set
            {
                if (_connectionString != value)
                {
                    //validate cfg
                    var conn = ConnectionManager.Get(value);
                    foreach (var c in CurrentProject.Connections)
                    {
                        if (c.ConnectionString.Equals(value))
                        {
                            if (c.TableRefMapping != null)
                            {
                                conn.Parse_TableRelation(c.TableRefMapping.Settings);
                            }
                            if (c.TableRepository != null)
                            {
                                conn.Parse_TableRepository(c.TableRepository.Settings);
                            }
                            if (c.TableStatus != null)
                            {
                                conn.Parse_TableStatus(c.TableStatus.Settings);
                            }
                            ConnectionManager.Update(conn);
                            break;
                        }
                    }

                }

                _connectionString = value;
            }
        }

        
        static string mDbContexUsingClause = "";
        public static string DbContexUsingClause
        {
            get
            {
                if (string.IsNullOrWhiteSpace(mDbContexUsingClause))
                    return "using (var unitOfWork = UnitOfWorkFactory.Create(DbOption.OA))";

                return mDbContexUsingClause;
            }
            set
            {
                mDbContexUsingClause = value;
            }
        }
        public static DatabaseType DbType { get; set; }

        public static EF.StorageModels.Schema EFStorageModels { get; set; }
        public static EF.ConceptualModels.Schema EFConceptualModels { get; set; }
        public static EF.Mappings.Mapping EFMappings { get; set; }

        public static void Save()
        {
            if (SaveProject != null)
                SaveProject();
        }


        public static bool UseAutoMapper { get; set; }

        public static ConnectionType Connection
        {
            get
            {
                if (_connectionString == null)
                    return null;

                foreach (var conn in CurrentProject.Connections)
                {
                    if (conn.ConnectionString == _connectionString)
                        return conn;
                }

                return null;
            }
        }
    }

    public static class ProjecctExtension
    {
        public static Dictionary<string, ModelType> GetModels(this ProjectType project)
        {
            var rslt = new Dictionary<string, ModelType>();

            foreach (var conn in project.Connections)
            {
                if (conn.ConnectionString == DBGlobalService.ConnectionString)
                {
                    foreach (var table in conn.Tables)
                    {
                        rslt.Add(table.Name, table.Model);
                    }
                }
            }

            return rslt;
        }

        public static Dictionary<string, TableType> GetTables(this ProjectType project)
        {
            var rslt = new Dictionary<string, TableType>();

            foreach (var conn in project.Connections)
            {
                if (conn.ConnectionString == DBGlobalService.ConnectionString)
                {
                    foreach (var table in conn.Tables)
                    {
                        rslt.Add(table.Name, table);
                    }
                }
            }

            return rslt;
        }

    }
}
