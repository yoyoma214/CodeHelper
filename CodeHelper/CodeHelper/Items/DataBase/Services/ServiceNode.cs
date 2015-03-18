using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeHelper.DataBaseHelper.Repository;
using System.ComponentModel;
using CodeHelper.DataBaseHelper.UI.PropertyGrids;
using CodeHelper.Items;

namespace CodeHelper.DataBaseHelper.Items.Services
{
    class ServiceNode : BaseNode
    {
        private Service service;

        public Service Service
        {
            get
            {
                return service;
            }
            set
            {
                this.Text = this.Name = value.Name;
                this.service = value;

                this.service.OnName_ProperyChanged += new CodeHelper.Xml.ProperyChanged<string>(service_Name_ProperyChanged);
            }
        }

        void service_Name_ProperyChanged(string oldValue, string newVal)
        {
            this.Text = this.Name = newVal;
        }

        [TypeConverter(typeof(MyConverter)), ConnectionListAttribute()]
        public string ConnectionString
        {
            get
            {
                if (this.service != null)
                    return this.service.ConnectionString;
                return "";
                //return this.connectionString;
            }
            set
            {
                //this.connectionString = value;
                if (service != null)
                {
                    service.ConnectionString = value;
                }
            }
        }
        public override string Name
        {
            get
            {
                return base.Name;
            }
            set
            {
                base.Name = value;
                if (this.service != null)
                {
                    this.service.Name = value;
                }
            }
        }

        protected override void OnDelete(object sender, EventArgs args)
        {
            base.OnDelete(sender, args);

            this.Service.RemoveSelf();
        }

        protected override void OnEdit(object sender, EventArgs args)
        {
            //base.OnEdit(sender, args);

            var frm = new ServiceFrm(this.service);

            frm.ShowDialog();

            //frm.Text
        }
    }
}
