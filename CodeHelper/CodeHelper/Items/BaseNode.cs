using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeHelper.UI;
using CodeHelper.Core.Services;
using CodeHelper.Domain.Model;

namespace CodeHelper.Items
{
    public delegate void RefreshDelegate(BaseNode node);
    public delegate void GenerateDelegate(BaseNode node, StringBuilder builder);

    public abstract class BaseNode 
    {
    
        internal event RefreshDelegate Refresh;
        internal event GenerateDelegate Generate;
        
        public BaseNode(string name):this()
        {
            this.Name = name;
            this.Text = name;
        }
        public BaseNode(string name, string text)
            : this()
        {
            this.Name = name;
            this.Text = text;
        }

        bool _enableEdit = true;
        protected virtual bool EnableEdit
        {
            get { return _enableEdit; }
            set { _enableEdit = value; }
        }

        bool _enableRename = true;
        protected virtual bool EnableRename
        {
            get { return _enableRename; }
            set { _enableRename = value; }
        }

        bool _enableDelete = true;
        protected virtual bool EnableDelete
        {
            get { return _enableDelete; }
            set { _enableDelete = value; }
        }

        bool _enableRefresh = true;
        protected virtual bool EnableRefresh
        {
            get { return _enableRefresh; }
            set { _enableRefresh = value; }
        }

        public BaseNode()
        {
            this.treeNode = new TreeNode();
            this.treeNode.Tag = this;
            this._Children = new BaseNodeCollection(this);
            this.treeNode.ImageKey = "";
            this.treeNode.SelectedImageKey = "";
        }

        public virtual Control GetEditor()
        {
            return null;
        }

        public virtual Control GetPropertyEditor()
        {
            return null;
        }

        #region 字段，属性
        TreeNode treeNode = null;
        /// <summary>
        /// 树的事件源，任何一个节点都指向根节点
        /// </summary>
        protected BaseNode EventSource
        {
            get
            {
                BaseNode source = this;
                while (source.Parent != null)
                {
                    source = source.Parent;
                }
                return source;
            }
        }

        string _Name = null;
        public virtual string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                this.TreeNode.Text = value;
            }
        }

        string _Text = null;
        public virtual string Text
        {
            get
            {
                return _Text;
            }
            set
            {
                _Text = value;
                this.TreeNode.Text = value;
            }
        }

        BaseNode _Parent = null;
        public BaseNode Parent
        {
            get { return _Parent; }
            set
            {
                if (value != null)
                {
                    foreach (BaseNode node in value.Children)
                    {
                        if (node == this)
                        {
                            _Parent = value;
                            return;
                        }
                    }
                    value.Children.Add(this);
                }
                else
                {
                    if (this.Parent != null)
                    {
                        this.Parent.Children.Remove(this);
                    }
                }
                _Parent = value;
            }
        }

        BaseNodeCollection _Children = null;
        public BaseNodeCollection Children
        {
            get { return _Children; }
        }

        public TreeNode TreeNode
        {
            get
            {
                return this.treeNode;
            }
        }
         
        #endregion

        //public BaseNode(TreeNode treeNode):base()
        //{
        //    this.treeNode = treeNode;
        //}

        //public virtual void OnDoubleClick() { }

        public virtual void Save()
        {
            foreach (BaseNode node in this.Children)
            {
                node.Save();
            }
        }

        public virtual void Load()
        {
            foreach (BaseNode node in this.Children)
            {
                node.Load();
            }
        }

        public virtual ContextMenu GetPopMenu()
        {
            ContextMenu menu = new ContextMenu();
            if (this.EnableEdit)
            {
                menu.MenuItems.Add("编辑", this.OnEdit);
            }
            if (this.EnableRename)
            {
                menu.MenuItems.Add("重命名", this.OnRename);
            }
            if (this.EnableRefresh)
            {
                menu.MenuItems.Add("刷新", this.OnRefresh);
            }
            if (this.EnableDelete)
            {
                menu.MenuItems.Add("删除", this.OnDelete);
            }
            return menu;
        }

        protected virtual void OnRename(object sender, EventArgs args)
        {
            RenameFrm frm = new RenameFrm();
            frm.CurrentName = this.Name;

            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.Text = this.Name = frm.NewName;
                //this.Name = frm.NewName;
            }

        }

        protected virtual void OnEdit(object sender, EventArgs args)
        {

        }

        protected virtual void OnDelete(object sender, EventArgs args)
        {
            BaseNode parent = this.Parent;
            this.Parent = null;
            parent.OnRefresh(sender, args);
        }

        protected virtual void OnRefresh(object sender, EventArgs args)
        {
            if (this.EventSource.Refresh != null)
            {
                this.EventSource.Refresh(this);
            }
        }

        //protected virtual void OnGenerate(BaseNode sender, StringBuilder args)
        //{
        //    if (this.EventSource.Generate != null)
        //    {
        //        this.EventSource.Generate(sender, args);
        //    }
        //}

        protected virtual BaseNode OnReslove(Type nodeType, string name)
        {
            return null;
        }

        protected BaseNode Reslove(Type nodeType, string name)
        {
            BaseNode parent = this.Parent;
            while (parent != null)
            {
                var n = parent.OnReslove(nodeType, name);
                if (n != null)
                    return n;
                parent = parent.Parent;

            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnUpdate()
        {

        }

        protected virtual void OnDeleteChild(BaseNode child)
        {
            if (this.Parent.Children.Contains(child))
                this.Parent.OnDeleteChild(child);
        }

        public virtual void OnDoubleClick()
        {

        }

        public virtual bool IsFolder
        {
            get
            {
                return false;
            }
        }

        public int Index
        {
            get
            {
                return this.treeNode.Index;
            }
        }

        public virtual Dict.NodeType NodeType
        {
            get
            {
                return Dict.NodeType.Unknown;
            }
        }

        internal virtual void OnRenameSelf(string oldPath, string newPath)
        {
            foreach (var n in this.Children)
            {
                n.OnRenameSelf(oldPath, newPath);
            }
        }

        internal virtual void OnDeleteSelf()
        {
            foreach (var n in this.Children)
            {
                //ModelManager.Instance().Remove(n.mo
                n.OnDeleteSelf();                
            }

            TreeNode.Remove();
        }


        internal virtual CodeHelper.Xml.DataNode DataInfo { get; set; }

        protected virtual void OnGenerate(BaseNode sender, StringBuilder args)
        {
            if (this.EventSource.Generate != null)
            {
                if (!args.ToString().StartsWith("#region COPYRIGHT COMPANY"))
                {
                    var filename = "";
                    var content = args.ToString();

                    var tag = "public class";
                    var tagLength = tag.Length;

                    var tagIndex = content.IndexOf(tag);
                    if (tagIndex < 0)
                    {
                        tag = "public interface";
                        tagLength = tag.Length;
                        tagIndex = content.IndexOf(tag);
                    }
                    if (tagIndex < 0)
                    {
                        tag = "public static class";
                        tagLength = tag.Length;
                        tagIndex = content.IndexOf(tag);
                    }

                    if (tagIndex > -1)
                    {
                        try
                        {
                            content.Substring(tagIndex + tag.Length).ToList().ForEach(
                                c =>
                                {
                                    if (c == ':' || c == '\r' || c == '\n' || c == '{')
                                    {
                                        throw new Exception("终止查找");
                                    }
                                    else
                                    {
                                        filename += c;
                                    }
                                }
                                );
                        }
                        catch
                        {
                        }
                        var coreId = System.Configuration.ConfigurationManager.AppSettings["CoreId"];
                        var crno = System.Configuration.ConfigurationManager.AppSettings["CRNO"];
                        if (crno == null) crno = "";
                        crno = crno.PadLeft(14);

                        filename = filename.Trim();

                        args.Insert(0, string.Format(@"#region COPYRIGHT COMPANY
/*******************************************************************************
*                     COPYRIGHT 2014 COMPANY SOLUTIONS, INC
*                           ALL RIGHTS RESERVED.
*                     COMPANY SOLUTIONS CONFIDENTIAL PROPRIETARY
********************************************************************************
*
*   FILE NAME       : {0}.cs
*
*--------------------------------- REVISIONS -----------------------------------
* CR/PR             Core ID   Date        Description
* ---------------   --------  ----------  --------------------------------------
* {1}    {2}   {3}   Creation
*******************************************************************************/
#endregion", filename, crno, coreId, DateTime.Now.ToString("MM/dd/yyyy")) + "\r\n");
                    }
                }
                this.EventSource.Generate(sender, args);
            }
        }
    }
}
