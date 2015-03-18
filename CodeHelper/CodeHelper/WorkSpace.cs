using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeHelper.UI.DockPanels;
using CodeHelper.Core.Infrastructure.Command;

namespace CodeHelper
{
    class WorkSpace
    {
        public ProjectPanel ProjectView { get; set; }
        public DocumentViewManager DocumentViewManager { get; set; }
        public PropertyPanel PropertyView { get; set; }
        public ErrorPanel OutputView { get; set; }

    }

 
}
