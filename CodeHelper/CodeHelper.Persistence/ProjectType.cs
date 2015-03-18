using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CodeHelper.Xml.Extension;
using CodeHelper.Xml;




namespace Project
{




    public class ProjectType
    : DataNode
    {
        public ProjectType
        ()
            : base()
        {
        }

        public ProjectType
        (XmlNode dom)
            : base(dom)
        {
        }

        public ProjectType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "ProjectType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }


        public ConnectionType CreateConnectionType()
        {
            return this.Dom.CreateNode<ConnectionType>();
        }


        public NodeList<ConnectionType> Connections
        {
            get
            {
                NodeList<ConnectionType> connections = null;
                XmlNode connections_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Connections")
                    {
                        connections_node = node;
                        connections = new NodeList<ConnectionType>(node);
                        break;
                    }
                }

                if (connections_node != null)
                {
                    foreach (XmlNode node in connections_node.ChildNodes)
                    {
                        connections.AddChild(new ConnectionType(node));
                    }
                }
                else
                {
                    connections = this.Dom.CreateNode<NodeList<ConnectionType>>("Connections");

                    this.AddChild(connections);
                }
                return connections;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }


    }


    public class ConnectionType
    : DataNode
    {
        public ConnectionType
        ()
            : base()
        {
        }

        public ConnectionType
        (XmlNode dom)
            : base(dom)
        {
        }

        public ConnectionType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "ConnectionType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }
        public event ProperyChanged<int> OnDbType_ProperyChanged;
        public int DbType
        {
            get
            {
                if (this.Dom.Attributes["DbType"] == null)
                    return default(int);
                return this.Dom.Attributes["DbType"].Value.ToT<int>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "DbType");
                var oldValue = default(int);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("DbType"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["DbType"].Value.ToT<int>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnDbType_ProperyChanged != null && oldValue != newValue)
                {
                    OnDbType_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("DbType", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnConnectionString_ProperyChanged;
        public string ConnectionString
        {
            get
            {
                if (this.Dom.Attributes["ConnectionString"] == null)
                    return default(string);
                return this.Dom.Attributes["ConnectionString"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "ConnectionString");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("ConnectionString"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["ConnectionString"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnConnectionString_ProperyChanged != null && oldValue != newValue)
                {
                    OnConnectionString_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("ConnectionString", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnDbContexUsingClause_ProperyChanged;
        public string DbContexUsingClause
        {
            get
            {
                if (this.Dom.Attributes["DbContexUsingClause"] == null)
                    return default(string);
                return this.Dom.Attributes["DbContexUsingClause"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "DbContexUsingClause");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("DbContexUsingClause"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["DbContexUsingClause"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnDbContexUsingClause_ProperyChanged != null && oldValue != newValue)
                {
                    OnDbContexUsingClause_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("DbContexUsingClause", oldValue, newValue);
            }
        }
        public event ProperyChanged<bool> OnUseAutoMapper_ProperyChanged;
        public bool UseAutoMapper
        {
            get
            {
                if (this.Dom.Attributes["UseAutoMapper"] == null)
                    return default(bool);
                return this.Dom.Attributes["UseAutoMapper"].Value.ToT<bool>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "UseAutoMapper");
                var oldValue = default(bool);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("UseAutoMapper"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["UseAutoMapper"].Value.ToT<bool>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnUseAutoMapper_ProperyChanged != null && oldValue != newValue)
                {
                    OnUseAutoMapper_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("UseAutoMapper", oldValue, newValue);
            }
        }


        public SqlType CreateSqlType()
        {
            return this.Dom.CreateNode<SqlType>();
        }


        public NodeList<SqlType> Sqls
        {
            get
            {
                NodeList<SqlType> sqls = null;
                XmlNode sqls_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Sqls")
                    {
                        sqls_node = node;
                        sqls = new NodeList<SqlType>(node);
                        break;
                    }
                }

                if (sqls_node != null)
                {
                    foreach (XmlNode node in sqls_node.ChildNodes)
                    {
                        sqls.AddChild(new SqlType(node));
                    }
                }
                else
                {
                    sqls = this.Dom.CreateNode<NodeList<SqlType>>("Sqls");

                    this.AddChild(sqls);
                }
                return sqls;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public TableType CreateTableType()
        {
            return this.Dom.CreateNode<TableType>();
        }


        public NodeList<TableType> Tables
        {
            get
            {
                NodeList<TableType> tables = null;
                XmlNode tables_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Tables")
                    {
                        tables_node = node;
                        tables = new NodeList<TableType>(node);
                        break;
                    }
                }

                if (tables_node != null)
                {
                    foreach (XmlNode node in tables_node.ChildNodes)
                    {
                        tables.AddChild(new TableType(node));
                    }
                }
                else
                {
                    tables = this.Dom.CreateNode<NodeList<TableType>>("Tables");

                    this.AddChild(tables);
                }
                return tables;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }
        public NodeList<TableType> Views
        {
            get
            {
                NodeList<TableType> views = null;
                XmlNode views_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Views")
                    {
                        views_node = node;
                        views = new NodeList<TableType>(node);
                        break;
                    }
                }

                if (views_node != null)
                {
                    foreach (XmlNode node in views_node.ChildNodes)
                    {
                        views.AddChild(new TableType(node));
                    }
                }
                else
                {
                    views = this.Dom.CreateNode<NodeList<TableType>>("Views");

                    this.AddChild(views);
                }
                return views;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }


        public QueryType CreateQueryType()
        {
            return this.Dom.CreateNode<QueryType>();
        }


        public QueryType Query
        {
            get
            {

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "QueryType" &&
                        node.Attributes["variable"] != null &&
                        node.Attributes["variable"].Value == "Query")
                    {
                        return new QueryType(node);
                    }
                }
                return null;
            }
            set
            {

                if (this.Query != null)
                {
                    this.Query.RemoveSelf();
                }

                var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
                attr.Value = "Query";
                value.Dom.Attributes.Append(attr);

                this.Dom.AppendChild(value.Dom);
            }
        }



        public TableRepositoryType CreateTableRepositoryType()
        {
            return this.Dom.CreateNode<TableRepositoryType>();
        }


        public TableRepositoryType TableRepository
        {
            get
            {

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "TableRepositoryType" &&
                        node.Attributes["variable"] != null &&
                        node.Attributes["variable"].Value == "TableRepository")
                    {
                        return new TableRepositoryType(node);
                    }
                }
                return null;
            }
            set
            {

                if (this.TableRepository != null)
                {
                    this.TableRepository.RemoveSelf();
                }

                var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
                attr.Value = "TableRepository";
                value.Dom.Attributes.Append(attr);

                this.Dom.AppendChild(value.Dom);
            }
        }



        public TableRefMappingType CreateTableRefMappingType()
        {
            return this.Dom.CreateNode<TableRefMappingType>();
        }


        public TableRefMappingType TableRefMapping
        {
            get
            {

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "TableRefMappingType" &&
                        node.Attributes["variable"] != null &&
                        node.Attributes["variable"].Value == "TableRefMapping")
                    {
                        return new TableRefMappingType(node);
                    }
                }
                return null;
            }
            set
            {

                if (this.TableRefMapping != null)
                {
                    this.TableRefMapping.RemoveSelf();
                }

                var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
                attr.Value = "TableRefMapping";
                value.Dom.Attributes.Append(attr);

                this.Dom.AppendChild(value.Dom);
            }
        }



        public TableStatusType CreateTableStatusType()
        {
            return this.Dom.CreateNode<TableStatusType>();
        }


        public TableStatusType TableStatus
        {
            get
            {

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "TableStatusType" &&
                        node.Attributes["variable"] != null &&
                        node.Attributes["variable"].Value == "TableStatus")
                    {
                        return new TableStatusType(node);
                    }
                }
                return null;
            }
            set
            {

                if (this.TableStatus != null)
                {
                    this.TableStatus.RemoveSelf();
                }

                var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
                attr.Value = "TableStatus";
                value.Dom.Attributes.Append(attr);

                this.Dom.AppendChild(value.Dom);
            }
        }



    }


    public class QueryType
    : DataNode
    {
        public QueryType
        ()
            : base()
        {
        }

        public QueryType
        (XmlNode dom)
            : base(dom)
        {
        }

        public QueryType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "QueryType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }


        public SqlType CreateSqlType()
        {
            return this.Dom.CreateNode<SqlType>();
        }


        public NodeList<SqlType> Sqls
        {
            get
            {
                NodeList<SqlType> sqls = null;
                XmlNode sqls_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Sqls")
                    {
                        sqls_node = node;
                        sqls = new NodeList<SqlType>(node);
                        break;
                    }
                }

                if (sqls_node != null)
                {
                    foreach (XmlNode node in sqls_node.ChildNodes)
                    {
                        sqls.AddChild(new SqlType(node));
                    }
                }
                else
                {
                    sqls = this.Dom.CreateNode<NodeList<SqlType>>("Sqls");

                    this.AddChild(sqls);
                }
                return sqls;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public QueryType CreateQueryType()
        {
            return this.Dom.CreateNode<QueryType>();
        }


        public NodeList<QueryType> Queries
        {
            get
            {
                NodeList<QueryType> queries = null;
                XmlNode queries_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Queries")
                    {
                        queries_node = node;
                        queries = new NodeList<QueryType>(node);
                        break;
                    }
                }

                if (queries_node != null)
                {
                    foreach (XmlNode node in queries_node.ChildNodes)
                    {
                        queries.AddChild(new QueryType(node));
                    }
                }
                else
                {
                    queries = this.Dom.CreateNode<NodeList<QueryType>>("Queries");

                    this.AddChild(queries);
                }
                return queries;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }


    }


    public class TableRepositoryType
    : DataNode
    {
        public TableRepositoryType
        ()
            : base()
        {
        }

        public TableRepositoryType
        (XmlNode dom)
            : base(dom)
        {
        }

        public TableRepositoryType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "TableRepositoryType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnSettings_ProperyChanged;
        public string Settings
        {
            get
            {
                if (this.Dom.Attributes["Settings"] == null)
                    return default(string);
                return this.Dom.Attributes["Settings"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Settings");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Settings"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Settings"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnSettings_ProperyChanged != null && oldValue != newValue)
                {
                    OnSettings_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Settings", oldValue, newValue);
            }
        }



    }


    public class TableRefMappingType
    : DataNode
    {
        public TableRefMappingType
        ()
            : base()
        {
        }

        public TableRefMappingType
        (XmlNode dom)
            : base(dom)
        {
        }

        public TableRefMappingType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "TableRefMappingType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnSettings_ProperyChanged;
        public string Settings
        {
            get
            {
                if (this.Dom.Attributes["Settings"] == null)
                    return default(string);
                return this.Dom.Attributes["Settings"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Settings");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Settings"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Settings"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnSettings_ProperyChanged != null && oldValue != newValue)
                {
                    OnSettings_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Settings", oldValue, newValue);
            }
        }



    }


    public class TableStatusType
    : DataNode
    {
        public TableStatusType
        ()
            : base()
        {
        }

        public TableStatusType
        (XmlNode dom)
            : base(dom)
        {
        }

        public TableStatusType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "TableStatusType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnSettings_ProperyChanged;
        public string Settings
        {
            get
            {
                if (this.Dom.Attributes["Settings"] == null)
                    return default(string);
                return this.Dom.Attributes["Settings"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Settings");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Settings"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Settings"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnSettings_ProperyChanged != null && oldValue != newValue)
                {
                    OnSettings_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Settings", oldValue, newValue);
            }
        }



    }


    public class TableType
    : DataNode
    {
        public TableType
        ()
            : base()
        {
        }

        public TableType
        (XmlNode dom)
            : base(dom)
        {
        }

        public TableType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "TableType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }



        public ModelType CreateModelType()
        {
            return this.Dom.CreateNode<ModelType>();
        }


        public ModelType Model
        {
            get
            {

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "ModelType" &&
                        node.Attributes["variable"] != null &&
                        node.Attributes["variable"].Value == "Model")
                    {
                        return new ModelType(node);
                    }
                }
                return null;
            }
            set
            {

                if (this.Model != null)
                {
                    this.Model.RemoveSelf();
                }

                var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
                attr.Value = "Model";
                value.Dom.Attributes.Append(attr);

                this.Dom.AppendChild(value.Dom);
            }
        }



        public ColumnSetType CreateColumnSetType()
        {
            return this.Dom.CreateNode<ColumnSetType>();
        }


        public ColumnSetType ColumnSet
        {
            get
            {

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "ColumnSetType" &&
                        node.Attributes["variable"] != null &&
                        node.Attributes["variable"].Value == "ColumnSet")
                    {
                        return new ColumnSetType(node);
                    }
                }
                return null;
            }
            set
            {

                if (this.ColumnSet != null)
                {
                    this.ColumnSet.RemoveSelf();
                }

                var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
                attr.Value = "ColumnSet";
                value.Dom.Attributes.Append(attr);

                this.Dom.AppendChild(value.Dom);
            }
        }



    }


    public class ModelType
    : DataNode
    {
        public ModelType
        ()
            : base()
        {
        }

        public ModelType
        (XmlNode dom)
            : base(dom)
        {
        }

        public ModelType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "ModelType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnColumnSetName_ProperyChanged;
        public string ColumnSetName
        {
            get
            {
                if (this.Dom.Attributes["ColumnSetName"] == null)
                    return default(string);
                return this.Dom.Attributes["ColumnSetName"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "ColumnSetName");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("ColumnSetName"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["ColumnSetName"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnColumnSetName_ProperyChanged != null && oldValue != newValue)
                {
                    OnColumnSetName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("ColumnSetName", oldValue, newValue);
            }
        }


        public FieldType CreateFieldType()
        {
            return this.Dom.CreateNode<FieldType>();
        }


        public NodeList<FieldType> Fields
        {
            get
            {
                NodeList<FieldType> fields = null;
                XmlNode fields_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Fields")
                    {
                        fields_node = node;
                        fields = new NodeList<FieldType>(node);
                        break;
                    }
                }

                if (fields_node != null)
                {
                    foreach (XmlNode node in fields_node.ChildNodes)
                    {
                        fields.AddChild(new FieldType(node));
                    }
                }
                else
                {
                    fields = this.Dom.CreateNode<NodeList<FieldType>>("Fields");

                    this.AddChild(fields);
                }
                return fields;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }


    }


    public class FieldType
    : DataNode
    {
        public FieldType
        ()
            : base()
        {
        }

        public FieldType
        (XmlNode dom)
            : base(dom)
        {
        }

        public FieldType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "FieldType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnColumnName_ProperyChanged;
        public string ColumnName
        {
            get
            {
                if (this.Dom.Attributes["ColumnName"] == null)
                    return default(string);
                return this.Dom.Attributes["ColumnName"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "ColumnName");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("ColumnName"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["ColumnName"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnColumnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnColumnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("ColumnName", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnSystemType_ProperyChanged;
        public string SystemType
        {
            get
            {
                if (this.Dom.Attributes["SystemType"] == null)
                    return default(string);
                return this.Dom.Attributes["SystemType"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "SystemType");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("SystemType"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["SystemType"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnSystemType_ProperyChanged != null && oldValue != newValue)
                {
                    OnSystemType_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("SystemType", oldValue, newValue);
            }
        }
        public event ProperyChanged<bool> OnNullAble_ProperyChanged;
        public bool NullAble
        {
            get
            {
                if (this.Dom.Attributes["NullAble"] == null)
                    return default(bool);
                return this.Dom.Attributes["NullAble"].Value.ToT<bool>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "NullAble");
                var oldValue = default(bool);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("NullAble"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["NullAble"].Value.ToT<bool>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnNullAble_ProperyChanged != null && oldValue != newValue)
                {
                    OnNullAble_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("NullAble", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnDescription_ProperyChanged;
        public string Description
        {
            get
            {
                if (this.Dom.Attributes["Description"] == null)
                    return default(string);
                return this.Dom.Attributes["Description"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Description");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Description"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Description"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnDescription_ProperyChanged != null && oldValue != newValue)
                {
                    OnDescription_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Description", oldValue, newValue);
            }
        }


        public ExpandType CreateExpandType()
        {
            return this.Dom.CreateNode<ExpandType>();
        }


        public NodeList<ExpandType> Expands
        {
            get
            {
                NodeList<ExpandType> expands = null;
                XmlNode expands_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Expands")
                    {
                        expands_node = node;
                        expands = new NodeList<ExpandType>(node);
                        break;
                    }
                }

                if (expands_node != null)
                {
                    foreach (XmlNode node in expands_node.ChildNodes)
                    {
                        expands.AddChild(new ExpandType(node));
                    }
                }
                else
                {
                    expands = this.Dom.CreateNode<NodeList<ExpandType>>("Expands");

                    this.AddChild(expands);
                }
                return expands;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }


    }


    public class ExpandType
    : DataNode
    {
        public ExpandType
        ()
            : base()
        {
        }

        public ExpandType
        (XmlNode dom)
            : base(dom)
        {
        }

        public ExpandType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "ExpandType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnKey_ProperyChanged;
        public string Key
        {
            get
            {
                if (this.Dom.Attributes["Key"] == null)
                    return default(string);
                return this.Dom.Attributes["Key"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Key");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Key"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Key"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnKey_ProperyChanged != null && oldValue != newValue)
                {
                    OnKey_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Key", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnVal_ProperyChanged;
        public string Val
        {
            get
            {
                if (this.Dom.Attributes["Val"] == null)
                    return default(string);
                return this.Dom.Attributes["Val"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Val");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Val"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Val"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnVal_ProperyChanged != null && oldValue != newValue)
                {
                    OnVal_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Val", oldValue, newValue);
            }
        }



    }


    public class SqlType
    : DataNode
    {
        public SqlType
        ()
            : base()
        {
        }

        public SqlType
        (XmlNode dom)
            : base(dom)
        {
        }

        public SqlType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "SqlType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnSqlStatement_ProperyChanged;
        public string SqlStatement
        {
            get
            {
                if (this.Dom.Attributes["SqlStatement"] == null)
                    return default(string);
                return this.Dom.Attributes["SqlStatement"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "SqlStatement");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("SqlStatement"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["SqlStatement"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnSqlStatement_ProperyChanged != null && oldValue != newValue)
                {
                    OnSqlStatement_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("SqlStatement", oldValue, newValue);
            }
        }
        public event ProperyChanged<bool> OnEncloseCondition_ProperyChanged;
        public bool EncloseCondition
        {
            get
            {
                if (this.Dom.Attributes["EncloseCondition"] == null)
                    return default(bool);
                return this.Dom.Attributes["EncloseCondition"].Value.ToT<bool>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "EncloseCondition");
                var oldValue = default(bool);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("EncloseCondition"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["EncloseCondition"].Value.ToT<bool>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnEncloseCondition_ProperyChanged != null && oldValue != newValue)
                {
                    OnEncloseCondition_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("EncloseCondition", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnResultModel_ProperyChanged;
        public string ResultModel
        {
            get
            {
                if (this.Dom.Attributes["ResultModel"] == null)
                    return default(string);
                return this.Dom.Attributes["ResultModel"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "ResultModel");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("ResultModel"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["ResultModel"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnResultModel_ProperyChanged != null && oldValue != newValue)
                {
                    OnResultModel_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("ResultModel", oldValue, newValue);
            }
        }



    }


    public class ColumnSetType
    : DataNode
    {
        public ColumnSetType
        ()
            : base()
        {
        }

        public ColumnSetType
        (XmlNode dom)
            : base(dom)
        {
        }

        public ColumnSetType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "ColumnSetType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }


        public ColumnType CreateColumnType()
        {
            return this.Dom.CreateNode<ColumnType>();
        }


        public NodeList<ColumnType> Columns
        {
            get
            {
                NodeList<ColumnType> columns = null;
                XmlNode columns_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Columns")
                    {
                        columns_node = node;
                        columns = new NodeList<ColumnType>(node);
                        break;
                    }
                }

                if (columns_node != null)
                {
                    foreach (XmlNode node in columns_node.ChildNodes)
                    {
                        columns.AddChild(new ColumnType(node));
                    }
                }
                else
                {
                    columns = this.Dom.CreateNode<NodeList<ColumnType>>("Columns");

                    this.AddChild(columns);
                }
                return columns;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }


    }


    public class ColumnType
    : DataNode
    {
        public ColumnType
        ()
            : base()
        {
        }

        public ColumnType
        (XmlNode dom)
            : base(dom)
        {
        }

        public ColumnType
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "ColumnType";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public event ProperyChanged<string> OnName_ProperyChanged;
        public string Name
        {
            get
            {
                if (this.Dom.Attributes["Name"] == null)
                    return default(string);
                return this.Dom.Attributes["Name"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Name");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Name"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Name"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Name", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnSystemType_ProperyChanged;
        public string SystemType
        {
            get
            {
                if (this.Dom.Attributes["SystemType"] == null)
                    return default(string);
                return this.Dom.Attributes["SystemType"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "SystemType");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("SystemType"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["SystemType"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnSystemType_ProperyChanged != null && oldValue != newValue)
                {
                    OnSystemType_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("SystemType", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnDbType_ProperyChanged;
        public string DbType
        {
            get
            {
                if (this.Dom.Attributes["DbType"] == null)
                    return default(string);
                return this.Dom.Attributes["DbType"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "DbType");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("DbType"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["DbType"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnDbType_ProperyChanged != null && oldValue != newValue)
                {
                    OnDbType_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("DbType", oldValue, newValue);
            }
        }
        public event ProperyChanged<bool> OnAllowDBNull_ProperyChanged;
        public bool AllowDBNull
        {
            get
            {
                if (this.Dom.Attributes["AllowDBNull"] == null)
                    return default(bool);
                return this.Dom.Attributes["AllowDBNull"].Value.ToT<bool>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "AllowDBNull");
                var oldValue = default(bool);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("AllowDBNull"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["AllowDBNull"].Value.ToT<bool>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnAllowDBNull_ProperyChanged != null && oldValue != newValue)
                {
                    OnAllowDBNull_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("AllowDBNull", oldValue, newValue);
            }
        }
        public event ProperyChanged<int> OnScale_ProperyChanged;
        public int Scale
        {
            get
            {
                if (this.Dom.Attributes["Scale"] == null)
                    return default(int);
                return this.Dom.Attributes["Scale"].Value.ToT<int>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Scale");
                var oldValue = default(int);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Scale"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Scale"].Value.ToT<int>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnScale_ProperyChanged != null && oldValue != newValue)
                {
                    OnScale_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Scale", oldValue, newValue);
            }
        }
        public event ProperyChanged<int> OnPrecision_ProperyChanged;
        public int Precision
        {
            get
            {
                if (this.Dom.Attributes["Precision"] == null)
                    return default(int);
                return this.Dom.Attributes["Precision"].Value.ToT<int>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Precision");
                var oldValue = default(int);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Precision"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Precision"].Value.ToT<int>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnPrecision_ProperyChanged != null && oldValue != newValue)
                {
                    OnPrecision_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Precision", oldValue, newValue);
            }
        }
        public event ProperyChanged<int> OnSize_ProperyChanged;
        public int Size
        {
            get
            {
                if (this.Dom.Attributes["Size"] == null)
                    return default(int);
                return this.Dom.Attributes["Size"].Value.ToT<int>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Size");
                var oldValue = default(int);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Size"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Size"].Value.ToT<int>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnSize_ProperyChanged != null && oldValue != newValue)
                {
                    OnSize_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Size", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnDescription_ProperyChanged;
        public string Description
        {
            get
            {
                if (this.Dom.Attributes["Description"] == null)
                    return default(string);
                return this.Dom.Attributes["Description"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Description");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Description"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Description"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnDescription_ProperyChanged != null && oldValue != newValue)
                {
                    OnDescription_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("Description", oldValue, newValue);
            }
        }
        public event ProperyChanged<bool> OnIsPK_ProperyChanged;
        public bool IsPK
        {
            get
            {
                if (this.Dom.Attributes["IsPK"] == null)
                    return default(bool);
                return this.Dom.Attributes["IsPK"].Value.ToT<bool>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "IsPK");
                var oldValue = default(bool);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("IsPK"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["IsPK"].Value.ToT<bool>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnIsPK_ProperyChanged != null && oldValue != newValue)
                {
                    OnIsPK_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("IsPK", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnForeignKeyTable_ProperyChanged;
        public string ForeignKeyTable
        {
            get
            {
                if (this.Dom.Attributes["ForeignKeyTable"] == null)
                    return default(string);
                return this.Dom.Attributes["ForeignKeyTable"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "ForeignKeyTable");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("ForeignKeyTable"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["ForeignKeyTable"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnForeignKeyTable_ProperyChanged != null && oldValue != newValue)
                {
                    OnForeignKeyTable_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("ForeignKeyTable", oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnForeignKeyColumn_ProperyChanged;
        public string ForeignKeyColumn
        {
            get
            {
                if (this.Dom.Attributes["ForeignKeyColumn"] == null)
                    return default(string);
                return this.Dom.Attributes["ForeignKeyColumn"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "ForeignKeyColumn");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("ForeignKeyColumn"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["ForeignKeyColumn"].Value.ToT<string>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnForeignKeyColumn_ProperyChanged != null && oldValue != newValue)
                {
                    OnForeignKeyColumn_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("ForeignKeyColumn", oldValue, newValue);
            }
        }
        public event ProperyChanged<bool> OnIsVirtualFK_ProperyChanged;
        public bool IsVirtualFK
        {
            get
            {
                if (this.Dom.Attributes["IsVirtualFK"] == null)
                    return default(bool);
                return this.Dom.Attributes["IsVirtualFK"].Value.ToT<bool>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "IsVirtualFK");
                var oldValue = default(bool);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("IsVirtualFK"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["IsVirtualFK"].Value.ToT<bool>();
                }

                if (value != null)
                    attr.Value = value.ToString();

                if (OnIsVirtualFK_ProperyChanged != null && oldValue != newValue)
                {
                    OnIsVirtualFK_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged("IsVirtualFK", oldValue, newValue);
            }
        }


        public ExpandType CreateExpandType()
        {
            return this.Dom.CreateNode<ExpandType>();
        }


        public NodeList<ExpandType> Expands
        {
            get
            {
                NodeList<ExpandType> expands = null;
                XmlNode expands_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Expands")
                    {
                        expands_node = node;
                        expands = new NodeList<ExpandType>(node);
                        break;
                    }
                }

                if (expands_node != null)
                {
                    foreach (XmlNode node in expands_node.ChildNodes)
                    {
                        expands.AddChild(new ExpandType(node));
                    }
                }
                else
                {
                    expands = this.Dom.CreateNode<NodeList<ExpandType>>("Expands");

                    this.AddChild(expands);
                }
                return expands;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }


    }
}