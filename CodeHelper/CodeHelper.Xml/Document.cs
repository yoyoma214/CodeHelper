using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Xml.Core;
using System.IO;
using System.Xml;

namespace CodeHelper.Xml
{
    [Serializable]
    public class Document
    {
        XmlDocument xmlDocument = new XmlDocument();

        public Document()
        {
            XmlDeclaration dec = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDocument.AppendChild(dec);
        }

        public void Load(string file)
        {
            xmlDocument.Load(file);
        }

        public void Load(TextReader reader)
        {
            xmlDocument.Load(reader);
        }

        public void LoadXml(string xml)
        {
            xmlDocument.LoadXml(xml);
        }

        public void Save(string file)
        {
            xmlDocument.Save(file);
        }
        public void Save(Stream stream)
        {
            xmlDocument.Save(stream);
        }

        public void Save(TextWriter textWriter)
        {
            xmlDocument.Save(textWriter);
        }

        public void Save(XmlWriter writer)
        {
            xmlDocument.Save(writer);
        }
        public DataNode Root
        {
            get
            {
                foreach (XmlNode node in xmlDocument.ChildNodes)
                {
                    if (node.NodeType == XmlNodeType.Element)
                    {
                        return new DataNode(node);
                    }
                }
                return null;
            }
            set
            {
                if (value == null)
                {
                    xmlDocument.RemoveAll();
                    return;
                }

                if (Root != null)
                    throw new Exception("已经有根节点了");
                
                xmlDocument.AppendChild(value.Dom);
            }
        }

        public T CreateNode<T>() where T : DataNode, new()
        {            
            var t = new T();
            t.Dom = xmlDocument.CreateElement(t.XML_TAG_NAME);
            //t.OwnerDocument = this;
            return t;
        }

        public T CreateNode<T>(string name) where T : DataNode, new()
        {
            var t = new T();
            t.Dom = xmlDocument.CreateElement(name);
            //t.OwnerDocument = this;
            return t;
        }
    }

    public static class XmlNodeExtension
    {
        public static T CreateNode<T>(this XmlNode node) where T : DataNode, new()
        {            
            var t = new T();
            t.Dom = node.OwnerDocument.CreateElement(t.XML_TAG_NAME);
            return t;
        }

        public static T CreateNode<T>(this XmlNode node, string name) where T : DataNode, new()
        {
            var t = new T();
            t.Dom = node.OwnerDocument.CreateElement(name);
            return t;
        }

        public static T CreateNode<T>(this DataNode node) where T : DataNode, new()
        {
            var t = new T();
            t.Dom = node.Dom.OwnerDocument.CreateElement(t.XML_TAG_NAME);
            return t;
        }

        public static T CreateNode<T>(this DataNode node, string name) where T : DataNode, new()
        {
            var t = new T();
            t.Dom = node.Dom.OwnerDocument.CreateElement(name);
            return t;
        } 
    }
}

