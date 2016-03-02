using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdvancedAgilityPack
{

    public static class AdvancedHtmlNodeExtensions
    {

        public static AdvancedHtmlNode ElementById<T>(this T node, string id) where T : AdvancedHtmlNode
        {
            return node.Descendants.SingleById(id);
        }

        public static T SingleById<T>(this IEnumerable<T> nodes, string id) where T : AdvancedHtmlNode
        {
            return nodes.FirstOrDefault(x => x.Id == id);
        }

        public static AdvancedNodeCollection<T> ToAdvancedCollection<T>(this IEnumerable<T> nodes) where T : AdvancedHtmlNode
        {
            return new AdvancedNodeCollection<T>(nodes);
        }

        public static AdvancedNodeCollection<T> WithTag<T>(this IEnumerable<T> nodes, string tag) where T : AdvancedHtmlNode
        {
            return nodes.Where(x => x.Tag == tag).ToAdvancedCollection();
        }

        public static AdvancedNodeCollection<T> WithName<T>(this IEnumerable<T> nodes, string name) where T : AdvancedHtmlNode
        {
            return nodes.Where(x => x.Name == name).ToAdvancedCollection();
        }

        public static AdvancedNodeCollection<T> WithCssClass<T>(this IEnumerable<T> nodes, string cssClass) where T : AdvancedHtmlNode
        {
            return nodes.Where(x => x.HasClass(cssClass)).ToAdvancedCollection();
        }

        public static AdvancedNodeCollection<T> WithoutAnyCssClass<T>(this IEnumerable<T> nodes) where T : AdvancedHtmlNode
        {
            return nodes.Where(x => !x.HasAnyClass).ToAdvancedCollection();
        }

        public static AdvancedNodeCollection<T> WhereFirstChildIs<T>(this IEnumerable<T> nodes, string tagName) where T : AdvancedHtmlNode
        {
            return nodes.Where(x => x.HasChilds).Where(x => x.FirstChild.Tag == tagName).ToAdvancedCollection();
        }

        public static AdvancedNodeCollection<T> WhereInnerTextContains<T>(this IEnumerable<T> nodes, string text) where T : AdvancedHtmlNode
        {
            return nodes.Where(x => x.InnerText.Contains(text)).ToAdvancedCollection();
        }

        public static AdvancedNodeCollection<T> WhereParentIs<T>(this IEnumerable<T> nodes, string tagName) where T : AdvancedHtmlNode
        {
            return nodes.Where(x => x.Parent != null).Where(x => x.Parent.Tag == tagName).ToAdvancedCollection();
        }

        public static IEnumerable<T> DownCast<T>(this IEnumerable<AdvancedHtmlNode> nodes) where T : AdvancedHtmlNode, new()
        {
            foreach (var node in nodes)
                yield return node.DownCast<T>();
        }

        public static T DownCast<T>(this AdvancedHtmlNode node) where T : AdvancedHtmlNode, new()
        {
            var htmlNode = node.AsHtmlNode();
            var tt = new T();
            tt.htmlNode = htmlNode;
            return tt;
        }
    }
}
