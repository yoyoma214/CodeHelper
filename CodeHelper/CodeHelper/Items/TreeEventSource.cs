using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper.Items
{
    class TreeEventSource
    {
        public event RefreshDelegate Refresh;
        public event GenerateDelegate Generate;
        public TreeEventSource(BaseNode root)
        {
            root.Refresh += new RefreshDelegate(root_Refresh);
            root.Generate += new GenerateDelegate(root_Generate);
        }

        void root_Generate(BaseNode node, StringBuilder builder)
        {
            if (this.Generate != null)
            {
                this.Generate(node, builder);
            }
        }

        void root_Refresh(BaseNode node)
        {
            if (this.Refresh != null)
            { this.Refresh(node); }
        }
    }
}
