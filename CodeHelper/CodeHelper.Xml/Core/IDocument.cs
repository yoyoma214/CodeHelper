using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CodeHelper.Xml.Core
{
    public interface IDocument
    {
        void Load(string file);
        void Load(TextReader reader);
        void LoadXml(string xml);
        void Save(string file);
        System.Xml.XmlNode Root { get;}
    }
}
