using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using CodeHelper.Xml.Extension;
using CodeHelper.Xml;


namespace CodeHelper.DataBaseHelper.Repository
{


    public class BusinessCfg
      : DataNode
    {
        public BusinessCfg
        ()
            : base()
        {
        }

        public BusinessCfg
        (XmlNode dom)
            : base(dom)
        {
        }

        public BusinessCfg
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "BusinessCfg";
            }
            set
            {
                throw new Exception("cannot set");
            }
        }




        public ServiceFolder CreateServiceFolder()
        {
            return this.Dom.CreateNode<ServiceFolder>();
        }


        public ServiceFolder ServiceFolder
        {
            get
            {

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "ServiceFolder" &&
                        node.Attributes["variable"] != null &&
                        node.Attributes["variable"].Value == "ServiceFolder")
                    {
                        return new ServiceFolder(node);
                    }
                }
                return null;
            }
            set
            {

                if (this.ServiceFolder != null)
                {
                    this.ServiceFolder.RemoveSelf();
                }

                var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
                attr.Value = "ServiceFolder";
                value.Dom.Attributes.Append(attr);

                this.Dom.AppendChild(value.Dom);
            }
        }



        public AjaxFolder CreateAjaxFolder()
        {
            return this.Dom.CreateNode<AjaxFolder>();
        }


        public AjaxFolder AjaxFolder
        {
            get
            {

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "AjaxFolder" &&
                        node.Attributes["variable"] != null &&
                        node.Attributes["variable"].Value == "AjaxFolder")
                    {
                        return new AjaxFolder(node);
                    }
                }
                return null;
            }
            set
            {

                if (this.AjaxFolder != null)
                {
                    this.AjaxFolder.RemoveSelf();
                }

                var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
                attr.Value = "AjaxFolder";
                value.Dom.Attributes.Append(attr);

                this.Dom.AppendChild(value.Dom);
            }
        }



        public FormViewFolder CreateFormViewFolder()
        {
            return this.Dom.CreateNode<FormViewFolder>();
        }


        public FormViewFolder FormViewFolder
        {
            get
            {

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "FormViewFolder" &&
                        node.Attributes["variable"] != null &&
                        node.Attributes["variable"].Value == "FormViewFolder")
                    {
                        return new FormViewFolder(node);
                    }
                }
                return null;
            }
            set
            {

                if (this.FormViewFolder != null)
                {
                    this.FormViewFolder.RemoveSelf();
                }

                var attr = this.Dom.OwnerDocument.CreateAttribute("variable");
                attr.Value = "FormViewFolder";
                value.Dom.Attributes.Append(attr);

                this.Dom.AppendChild(value.Dom);
            }
        }



    }


    public class Service
    : DataNode
    {
        public Service
        ()
            : base()
        {
        }

        public Service
        (XmlNode dom)
            : base(dom)
        {
        }

        public Service
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "Service";
            }
            set
            {
                throw new Exception("cannot set");
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
                attr.Value = value.ToString();

                if (OnConnectionString_ProperyChanged != null && oldValue != newValue)
                {
                    OnConnectionString_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged(ConnectionString, oldValue, newValue);
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
                attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged(Name, oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnCode_ProperyChanged;
        public string Code
        {
            get
            {
                if (this.Dom.Attributes["Code"] == null)
                    return default(string);
                return this.Dom.Attributes["Code"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Code");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Code"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Code"].Value.ToT<string>();
                }
                attr.Value = value.ToString();

                if (OnCode_ProperyChanged != null && oldValue != newValue)
                {
                    OnCode_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged(Code, oldValue, newValue);
            }
        }



    }


    public class Ajax
    : DataNode
    {
        public Ajax
        ()
            : base()
        {
        }

        public Ajax
        (XmlNode dom)
            : base(dom)
        {
        }

        public Ajax
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "Ajax";
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
                attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged(Name, oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnCode_ProperyChanged;
        public string Code
        {
            get
            {
                if (this.Dom.Attributes["Code"] == null)
                    return default(string);
                return this.Dom.Attributes["Code"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Code");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Code"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Code"].Value.ToT<string>();
                }
                attr.Value = value.ToString();

                if (OnCode_ProperyChanged != null && oldValue != newValue)
                {
                    OnCode_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged(Code, oldValue, newValue);
            }
        }



    }


    public class ServiceFolder
    : DataNode
    {
        public ServiceFolder
        ()
            : base()
        {
        }

        public ServiceFolder
        (XmlNode dom)
            : base(dom)
        {
        }

        public ServiceFolder
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "ServiceFolder";
            }
            set
            {
                throw new Exception("cannot set");
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
                attr.Value = value.ToString();

                if (OnConnectionString_ProperyChanged != null && oldValue != newValue)
                {
                    OnConnectionString_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged(ConnectionString, oldValue, newValue);
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
                attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged(Name, oldValue, newValue);
            }
        }


        public ServiceFolder CreateServiceFolder()
        {
            return this.Dom.CreateNode<ServiceFolder>();
        }


        public NodeList<ServiceFolder> ServiceFolders
        {
            get
            {
                NodeList<ServiceFolder> serviceFolders = null;
                XmlNode serviceFolders_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "ServiceFolders")
                    {
                        serviceFolders_node = node;
                        serviceFolders = new NodeList<ServiceFolder>(node);
                        break;
                    }
                }

                if (serviceFolders_node != null)
                {
                    foreach (XmlNode node in serviceFolders_node.ChildNodes)
                    {
                        serviceFolders.AddChild(new ServiceFolder(node));
                    }
                }
                else
                {
                    serviceFolders = this.Dom.CreateNode<NodeList<ServiceFolder>>("ServiceFolders");

                    this.AddChild(serviceFolders);
                }
                return serviceFolders;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public Service CreateService()
        {
            return this.Dom.CreateNode<Service>();
        }


        public NodeList<Service> Services
        {
            get
            {
                NodeList<Service> services = null;
                XmlNode services_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Services")
                    {
                        services_node = node;
                        services = new NodeList<Service>(node);
                        break;
                    }
                }

                if (services_node != null)
                {
                    foreach (XmlNode node in services_node.ChildNodes)
                    {
                        services.AddChild(new Service(node));
                    }
                }
                else
                {
                    services = this.Dom.CreateNode<NodeList<Service>>("Services");

                    this.AddChild(services);
                }
                return services;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }


    }


    public class AjaxFolder
    : DataNode
    {
        public AjaxFolder
        ()
            : base()
        {
        }

        public AjaxFolder
        (XmlNode dom)
            : base(dom)
        {
        }

        public AjaxFolder
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "AjaxFolder";
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
                attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged(Name, oldValue, newValue);
            }
        }


        public AjaxFolder CreateAjaxFolder()
        {
            return this.Dom.CreateNode<AjaxFolder>();
        }


        public NodeList<AjaxFolder> AjaxFolders
        {
            get
            {
                NodeList<AjaxFolder> ajaxFolders = null;
                XmlNode ajaxFolders_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "AjaxFolders")
                    {
                        ajaxFolders_node = node;
                        ajaxFolders = new NodeList<AjaxFolder>(node);
                        break;
                    }
                }

                if (ajaxFolders_node != null)
                {
                    foreach (XmlNode node in ajaxFolders_node.ChildNodes)
                    {
                        ajaxFolders.AddChild(new AjaxFolder(node));
                    }
                }
                else
                {
                    ajaxFolders = this.Dom.CreateNode<NodeList<AjaxFolder>>("AjaxFolders");

                    this.AddChild(ajaxFolders);
                }
                return ajaxFolders;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public Ajax CreateAjax()
        {
            return this.Dom.CreateNode<Ajax>();
        }


        public NodeList<Ajax> Ajaxs
        {
            get
            {
                NodeList<Ajax> ajaxs = null;
                XmlNode ajaxs_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "Ajaxs")
                    {
                        ajaxs_node = node;
                        ajaxs = new NodeList<Ajax>(node);
                        break;
                    }
                }

                if (ajaxs_node != null)
                {
                    foreach (XmlNode node in ajaxs_node.ChildNodes)
                    {
                        ajaxs.AddChild(new Ajax(node));
                    }
                }
                else
                {
                    ajaxs = this.Dom.CreateNode<NodeList<Ajax>>("Ajaxs");

                    this.AddChild(ajaxs);
                }
                return ajaxs;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }


    }


    public class FormView
    : DataNode
    {
        public FormView
        ()
            : base()
        {
        }

        public FormView
        (XmlNode dom)
            : base(dom)
        {
        }

        public FormView
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "FormView";
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
                attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged(Name, oldValue, newValue);
            }
        }
        public event ProperyChanged<string> OnCode_ProperyChanged;
        public string Code
        {
            get
            {
                if (this.Dom.Attributes["Code"] == null)
                    return default(string);
                return this.Dom.Attributes["Code"].Value.ToT<string>();
            }
            set
            {
                var attr = this.Dom.Attributes.OfType<XmlAttribute>()
                  .FirstOrDefault(x => x.Name == "Code");
                var oldValue = default(string);
                var newValue = value;
                if (attr == null)
                {
                    attr = this.Dom.Attributes.Append(this.Dom.OwnerDocument.CreateAttribute("Code"));
                }
                else
                {
                    oldValue = this.Dom.Attributes["Code"].Value.ToT<string>();
                }
                attr.Value = value.ToString();

                if (OnCode_ProperyChanged != null && oldValue != newValue)
                {
                    OnCode_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged(Code, oldValue, newValue);
            }
        }



    }


    public class FormViewFolder
    : DataNode
    {
        public FormViewFolder
        ()
            : base()
        {
        }

        public FormViewFolder
        (XmlNode dom)
            : base(dom)
        {
        }

        public FormViewFolder
        (Document document)
            : base(document)
        {
        }

        public override string XML_TAG_NAME
        {
            get
            {
                return "FormViewFolder";
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
                attr.Value = value.ToString();

                if (OnName_ProperyChanged != null && oldValue != newValue)
                {
                    OnName_ProperyChanged(oldValue, newValue);
                }
                this.FireAnyProperyChanged(Name, oldValue, newValue);
            }
        }


        public FormViewFolder CreateFormViewFolder()
        {
            return this.Dom.CreateNode<FormViewFolder>();
        }


        public NodeList<FormViewFolder> FormViewFolders
        {
            get
            {
                NodeList<FormViewFolder> formViewFolders = null;
                XmlNode formViewFolders_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "FormViewFolders")
                    {
                        formViewFolders_node = node;
                        formViewFolders = new NodeList<FormViewFolder>(node);
                        break;
                    }
                }

                if (formViewFolders_node != null)
                {
                    foreach (XmlNode node in formViewFolders_node.ChildNodes)
                    {
                        formViewFolders.AddChild(new FormViewFolder(node));
                    }
                }
                else
                {
                    formViewFolders = this.Dom.CreateNode<NodeList<FormViewFolder>>("FormViewFolders");

                    this.AddChild(formViewFolders);
                }
                return formViewFolders;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }

        public FormView CreateFormView()
        {
            return this.Dom.CreateNode<FormView>();
        }


        public NodeList<FormView> FormViews
        {
            get
            {
                NodeList<FormView> formViews = null;
                XmlNode formViews_node = null;

                foreach (XmlNode node in this.Dom.ChildNodes)
                {
                    if (node.Name == "FormViews")
                    {
                        formViews_node = node;
                        formViews = new NodeList<FormView>(node);
                        break;
                    }
                }

                if (formViews_node != null)
                {
                    foreach (XmlNode node in formViews_node.ChildNodes)
                    {
                        formViews.AddChild(new FormView(node));
                    }
                }
                else
                {
                    formViews = this.Dom.CreateNode<NodeList<FormView>>("FormViews");

                    this.AddChild(formViews);
                }
                return formViews;

            }
            set
            {
                throw new Exception("cannot set");
            }
        }


    }
}