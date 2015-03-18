using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.Items;
using CodeHelper.Items.DataModel;

namespace CodeHelper.Commond
{
    interface IReceiver
    {
        void OpenDataModel(DataModelNode node);

    }
}
