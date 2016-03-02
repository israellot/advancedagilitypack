using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace AdvancedAgilityPack
{
    public class AdvancedHtmlNode
    {
        internal HtmlNode htmlNode;

        #region Properties

        public HtmlAttributeCollection Attributes
        {
            get
            {
                return htmlNode.Attributes;
            }
        }

        public string Id
        {
            get { return htmlNode.Id; }
            set { htmlNode.Id = value; }
        }

        public string Tag
        {
            get { return htmlNode.Name; }
            set { htmlNode.Name = value; }
        }

        public string Name
        {
            get { return htmlNode.GetAttributeValue("name", null); }
            set { htmlNode.SetAttributeValue("name", value); }
        }

        public string Class
        {
            get
            {
                return this.htmlNode.GetAttributeValue("class", string.Empty);

            }
            set
            {
                this.htmlNode.SetAttributeValue("class", value);
            }
        }

        public string InnerText
        {
            get { return htmlNode.InnerText; }
            
        }

        public string InnerHtml
        {
            get { return htmlNode.InnerHtml; }
            set { htmlNode.InnerHtml = value; }
        }

        public bool HasChilds
        {
            get { return htmlNode.HasChildNodes; }
        }

        public bool HasAnyClass
        {
            get
            {
                if (!htmlNode.HasAttributes)
                    return false;

                return htmlNode.GetAttributeValue("class", string.Empty) != string.Empty;

            }
        }

        public bool HasAttributes
        {
            get
            {
                return htmlNode.HasAttributes;
            }
        }

        #endregion


        #region Methods

        public string GetData(string key)
        {
            return this.htmlNode.GetAttributeValue("data-" + key, null);
        }

        public void SetData(string key, string value)
        {
            this.htmlNode.SetAttributeValue("data-" + key, value);

        }

        public bool HasAttribute(string name)
        {
            if (!this.htmlNode.HasAttributes)
                return false;
            else return this.htmlNode.Attributes.Contains(name);            
        }

        public void SetAttribute(string name, string value)
        {
            this.htmlNode.SetAttributeValue(name, value);
        }

        #endregion


        #region Constructor and Cast

        public AdvancedHtmlNode()
        {

        }

        public AdvancedHtmlNode(HtmlNode node)
        {
            this.htmlNode = node;
        }

        public static explicit operator AdvancedHtmlNode(HtmlNode node)
        {
            if (node != null)
                return new AdvancedHtmlNode(node);
            else
                return null;
        }

        public static explicit operator HtmlNode(AdvancedHtmlNode node)
        {
            if (node != null)
                return node.htmlNode;
            else
                return null;
        }

        #endregion

        //Questions
        public bool HasClass(string className)
        {

            if (!HasAnyClass)
                return false;

            var nodeClass = this.Class;

            if (nodeClass != string.Empty)
            {
                var classesToSearch = className.Split(' ').Select(x => x.Trim()).ToList();

                var classesOnNode = nodeClass.Split(' ').Select(x => x.Trim()).ToList();

                if (classesToSearch.All(x => classesOnNode.Contains(x)))
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }

        }

        //Navigation

        public AdvancedHtmlNode FirstChild
        {
            get { return (AdvancedHtmlNode)htmlNode.FirstChild; }
        }

        public AdvancedHtmlNode Parent
        {
            get
            {
                return (AdvancedHtmlNode)htmlNode.ParentNode;
            }
        }

        public AdvancedHtmlNode NextNode
        {
            get
            {
                var node = htmlNode.NextSibling;
                while (node.NodeType != HtmlNodeType.Element)
                    node = node.NextSibling;

                return (AdvancedHtmlNode)node;
            }
        }

        public IEnumerable<AdvancedHtmlNode> DescendantNodesAndSelf()
        {
            return htmlNode.DescendantsAndSelf().AsAdvanced();
        }

        public AdvancedNodeCollection<AdvancedHtmlNode> Descendants
        {
            get { return htmlNode.Descendants().AsAdvanced().ToAdvancedCollection(); }
        }

        public AdvancedNodeCollection<AdvancedHtmlNode> Children
        {
            get
            {
                return htmlNode.HasChildNodes ? htmlNode.ChildNodes.AsAdvanced().ToAdvancedCollection() : new AdvancedNodeCollection<AdvancedHtmlNode>();
            }
        }


    }




    public class AHtmlNode : AdvancedHtmlNode
    {
        public string Href
        {
            get
            {
                return this.htmlNode.GetAttributeValue("href", null);

            }
            set
            {
                if(value!=null)
                    this.htmlNode.SetAttributeValue("href", value);
            }
        }

        public string Target
        {
            get
            {
                return this.htmlNode.GetAttributeValue("target", string.Empty);

            }
            set
            {
                this.htmlNode.SetAttributeValue("target", value);
            }
        }

        public AHtmlNode()
        {

        }

        public AHtmlNode(HtmlNode node) : base(node) { }
    }

    public class LinkHtmlNode : AdvancedHtmlNode
    {
        public string Href
        {
            get
            {
                return this.htmlNode.GetAttributeValue("href", null);

            }
            set
            {
                if(value!=null)
                    this.htmlNode.SetAttributeValue("href", value);
            }
        }

        public string Rel
        {
            get
            {
                return this.htmlNode.GetAttributeValue("rel", string.Empty);

            }
            set
            {
                this.htmlNode.SetAttributeValue("rel", value);
            }
        }

        public LinkHtmlNode()
        {

        }

        public LinkHtmlNode(HtmlNode node) : base(node) { }
    }

    public class ImgHtmlNode : AdvancedHtmlNode
    {
        public string Src
        {
            get
            {
                return this.htmlNode.GetAttributeValue("src", string.Empty);

            }
            set
            {
                this.htmlNode.SetAttributeValue("src", value);
            }
        }

        public string Width
        {
            get
            {
                return this.htmlNode.GetAttributeValue("width", string.Empty);
            }
            set
            {
                this.htmlNode.SetAttributeValue("width", value);
            }
        }

        public string Height
        {
            get
            {
                return this.htmlNode.GetAttributeValue("height", string.Empty);
            }
            set
            {
                this.htmlNode.SetAttributeValue("height", value);
            }
        }

        public string Alt
        {
            get
            {
                return this.htmlNode.GetAttributeValue("alt", string.Empty);
            }
            set
            {
                this.htmlNode.SetAttributeValue("alt", value);
            }
        }

        public ImgHtmlNode()
        {

        }

        public ImgHtmlNode(HtmlNode node) : base(node) { }
    }

    public class TableHtmlNode : AdvancedHtmlNode
    {
        public AdvancedNodeCollection<TableRowHtmlNode> Rows
        {
            get
            {
                return this.Descendants.TR;
            }
        }

        public TableHtmlNode() { }
        public TableHtmlNode(HtmlNode node) : base(node) { }
    }

    public class LabelHtmlNode : AdvancedHtmlNode
    {
        public string For
        {
            get
            {
                return this.htmlNode.GetAttributeValue("for", string.Empty);

            }
            set
            {
                this.htmlNode.SetAttributeValue("for", value);
            }
        }
        

        public LabelHtmlNode()
        {

        }

        public LabelHtmlNode(HtmlNode node) : base(node) { }
    }

    public class TableRowHtmlNode : AdvancedHtmlNode
    {
        public AdvancedNodeCollection<TableCellHtmlNode> Cells
        {
            get
            {
                return this.Descendants.TD;
            }
        }

        public TableRowHtmlNode() { }
        public TableRowHtmlNode(HtmlNode node) : base(node) { }
    }

    public class TableCellHtmlNode : AdvancedHtmlNode
    {


        public TableCellHtmlNode() { }
        public TableCellHtmlNode(HtmlNode node) : base(node) { }
    }

    public class ListHtmlNode : AdvancedHtmlNode
    {
        public AdvancedNodeCollection<ListItemHtmlNode> Items
        {
            get
            {
                return this.Descendants.LI;
            }
        }

        public ListHtmlNode() { }
        public ListHtmlNode(HtmlNode node) : base(node) { }
    }

    public class ListItemHtmlNode : AdvancedHtmlNode
    {

        public ListItemHtmlNode() { }
        public ListItemHtmlNode(HtmlNode node) : base(node) { }
    }

    public class InputHtmlNode : AdvancedHtmlNode
    {
        public InputHtmlNode(){}
        public InputHtmlNode(HtmlNode node) : base(node) { }

        public string Value
        {
            get
            {
                return this.htmlNode.GetAttributeValue("value", string.Empty);

            }
            set
            {
                this.htmlNode.SetAttributeValue("value", value);
            }
        }

        public string Type
        {
            get
            {
                return this.htmlNode.GetAttributeValue("type", string.Empty);

            }
            set
            {
                this.htmlNode.SetAttributeValue("type", value);
            }
        }

        public new string Name
        {
            get
            {
                return this.htmlNode.GetAttributeValue("name", string.Empty);

            }
            set
            {
                this.htmlNode.SetAttributeValue("name", value);
            }
        }

    }

    public class SelectHtmlNode : AdvancedHtmlNode
    {
        public SelectHtmlNode() { }
        public SelectHtmlNode(HtmlNode node) : base(node) { }
                
        public new string Name
        {
            get
            {
                return this.htmlNode.GetAttributeValue("name", string.Empty);

            }
            set
            {
                this.htmlNode.SetAttributeValue("name", value);
            }
        }

        public AdvancedNodeCollection<OptionHtmlNode> Options
        {
            get
            {
                return this.Descendants.OPTION;
            }
        }

    }

    public class OptionHtmlNode : AdvancedHtmlNode
    {

        public OptionHtmlNode() { }
        public OptionHtmlNode(HtmlNode node) : base(node) { }

        public new string Value
        {
            get
            {
                return this.htmlNode.GetAttributeValue("value", string.Empty);

            }
            set
            {
                this.htmlNode.SetAttributeValue("value", value);
            }
        }

        public new string Label
        {
            get
            {
                return this.htmlNode.InnerText;

            }
            set
            {
                this.htmlNode.InnerHtml = value;
            }
        }

    }

    public class FormHtmlNode : AdvancedHtmlNode
        {
        public FormHtmlNode(){}
        public FormHtmlNode(HtmlNode node) : base(node) { }

        public string Action
        {
            get
            {
                return this.htmlNode.GetAttributeValue("action", null);

            }
            set
            {
                if(value!=null)
                    this.htmlNode.SetAttributeValue("action", value);
            }
        }

        public string Method
        {
            get
            {
                return this.htmlNode.GetAttributeValue("method", string.Empty);

            }
            set
            {
                this.htmlNode.SetAttributeValue("method", value);
            }
        }

    }

    public class ScriptHtmlNode : AdvancedHtmlNode
    {
        public ScriptHtmlNode() { }
        public ScriptHtmlNode(HtmlNode node) : base(node) { }

        public string Src
        {
            get
            {
                return this.htmlNode.GetAttributeValue("src", null);

            }
            set
            {
                if(value!=null)
                    this.htmlNode.SetAttributeValue("src", value);
            }
        }

        public string Type
        {
            get
            {
                return this.htmlNode.GetAttributeValue("type", string.Empty);

            }
            set
            {
                this.htmlNode.SetAttributeValue("type", value);
            }
        }

    }
}
