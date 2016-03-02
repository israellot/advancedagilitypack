using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;

namespace AdvancedAgilityPack
{
    public static class HtmlDocumentExtensions
    {

        public static IEnumerable<HtmlNode> WithCssClass(this IEnumerable<HtmlNode> nodes, string cssClass)
        {

            return nodes.Where(x => x.GetAttributeValue("class", string.Empty).Contains(cssClass));

        }

        public static bool HasClass(this HtmlNode node, string cssClass)
        {
            if (node == null)
                return false;

            if (!node.HasAttributes)
                return false;


            //Regex r = new Regex(@"(^|\b)"+cssClass+@"($|\b)");
            var nodeClass = node.GetAttributeValue("class", string.Empty);

            if (nodeClass != string.Empty)
            {
                var classesToSearch = cssClass.Split(' ').Select(x => x.Trim()).ToList();

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

        public static IEnumerable<AdvancedHtmlNode> AsAdvanced(this IEnumerable<HtmlNode> node)
        {
            foreach (var n in node)
                yield return (AdvancedHtmlNode)n;
        }

        public static AdvancedHtmlNode AsAdvanced(this HtmlNode node)
        {
            return (AdvancedHtmlNode)node;
        }

        public static IEnumerable<HtmlNode> AsHtmlNode<T>(this IEnumerable<T> nodes) where T : AdvancedHtmlNode
        {
            return nodes.Cast<HtmlNode>();
        }

        public static HtmlNode AsHtmlNode<T>(this T node) where T : AdvancedHtmlNode
        {
            var n = node as AdvancedHtmlNode;
            return (HtmlNode)n;
        }

    }

         
       

}
