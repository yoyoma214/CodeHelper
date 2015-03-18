using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Project;
using Altova.Types;

namespace Generator.Items.DBItems
{
    class OperationItemNode:BaseNode
    {
        public bool Asynchronism { get; set; }

        OperationItemType dataInfo = new OperationItemType();
        internal override CodeHelper.Xml.DataNode DataInfo
        {
            get
            {
                this.dataInfo.AddAsynchronism(this.Asynchronism));
                this.dataInfo.AddName(this.Name));
                return dataInfo;
            }
            set
            {
                this.dataInfo =(OperationItemType) value;
                this.Asynchronism = this.dataInfo.HasAsynchronism() ? this.dataInfo.Asynchronism.Value : true;
                this.Name = this.dataInfo.Name.Value;
            }
        } 

    }
}
