using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedAgilityPack
{
    public class AdvancedNodeCollection<T> : List<T> where T : AdvancedHtmlNode
    {
        public AdvancedHtmlNode HTML
        {
            get
            {
                return this.WithTag(HtmlElements.HTML).FirstOrDefault();
            }
        }

        public AdvancedHtmlNode HEAD
        {
            get
            {
                return this.WithTag(HtmlElements.HEAD).FirstOrDefault();
            }
        }

        public AdvancedHtmlNode BODY
        {
            get
            {
                return this.WithTag(HtmlElements.BODY).FirstOrDefault();
            }
        }

        public AdvancedNodeCollection<FormHtmlNode> FORM
        {
            get
            {
                return this.WithTag(HtmlElements.FORM).DownCast<FormHtmlNode>().ToAdvancedCollection();
            }

        }

        public AdvancedNodeCollection<AdvancedHtmlNode> DIV
        {
            get
            {
                return this.WithTag(HtmlElements.DIV).DownCast<AdvancedHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<InputHtmlNode> INPUT
        {
            get
            {
                return this.WithTag(HtmlElements.INPUT).DownCast<InputHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<SelectHtmlNode> SELECT
        {
            get
            {
                return this.WithTag(HtmlElements.SELECT).DownCast<SelectHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<OptionHtmlNode> OPTION
        {
            get
            {
                return this.WithTag(HtmlElements.OPTION).DownCast<OptionHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<ListHtmlNode> UL
        {
            get
            {
                return this.WithTag(HtmlElements.UL).DownCast<ListHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<ListItemHtmlNode> LI
        {
            get
            {
                return this.WithTag(HtmlElements.LI).DownCast<ListItemHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<AdvancedHtmlNode> P
        {
            get
            {
                return this.WithTag(HtmlElements.P).Cast<AdvancedHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<AHtmlNode> A
        {
            get
            {
                return this.WithTag(HtmlElements.A).DownCast<AHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<ImgHtmlNode> IMG
        {
            get
            {
                return this.WithTag(HtmlElements.IMG).DownCast<ImgHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<TableHtmlNode> TABLE
        {
            get
            {
                return this.WithTag(HtmlElements.TABLE).DownCast<TableHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<TableRowHtmlNode> TR
        {
            get
            {
                return this.WithTag(HtmlElements.TR).DownCast<TableRowHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<TableCellHtmlNode> TD
        {
            get
            {
                return this.WithTag(HtmlElements.TD).DownCast<TableCellHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<ScriptHtmlNode> SCRIPT
        {
            get
            {
                return this.WithTag(HtmlElements.SCRIPT).DownCast<ScriptHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<AdvancedHtmlNode> SPAN
        {
            get
            {
                return this.WithTag(HtmlElements.SPAN).DownCast<AdvancedHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<AdvancedHtmlNode> B
        {
            get
            {
                return this.WithTag(HtmlElements.B).DownCast<AdvancedHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<AdvancedHtmlNode> STRONG
        {
            get
            {
                return this.WithTag(HtmlElements.STRONG).DownCast<AdvancedHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<LabelHtmlNode> LABEL
        {
            get
            {
                return this.WithTag(HtmlElements.LABEL).DownCast<LabelHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection<LinkHtmlNode> LINK
        {
            get
            {
                return this.WithTag(HtmlElements.LINK).DownCast<LinkHtmlNode>().ToAdvancedCollection();
            }
        }

        public AdvancedNodeCollection()
        {

        }

        public AdvancedNodeCollection(IEnumerable<T> col)
            : base(col)
        {

        }

    }
}
