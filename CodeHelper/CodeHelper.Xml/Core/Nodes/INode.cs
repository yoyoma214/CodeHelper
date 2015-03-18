using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Xml.Core.Nodes
{
    public interface INode
    {
        System.Xml.XmlNode Dom { get; }

        string XML_TAG_NAME { get; set; }
        //void Parse();

        //Document OwnerDocument { get; }
        string Id { get; set; }
    }
}
