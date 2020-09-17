using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraBars.Ribbon;
using Newtonsoft.Json.Linq;

namespace Analogy.Tools.JsonViewer
{
    class JsonTreeNodeCreator
    {
        internal static JsonTreeNode CreateNode(string property, JToken item)
        {
            JsonNodeType type;
            string text;
            string textWhenSelected = null;

            if (item.Type == JTokenType.Object || item.Type == JTokenType.Array)
            {
                text = property;
                textWhenSelected = text;
            }
            else
            {
                type = JsonNodeType.Value;
                string value = item.ToString();
                text = property == null ?
                    value :
                    string.Format($"{property}: {value}");
                textWhenSelected = string.Format($"{text} (type: {item.Type})");
            }

            type = item.Type == JTokenType.Object ? JsonNodeType.Object :
                item.Type == JTokenType.Array ? JsonNodeType.Array :
                JsonNodeType.Value;

            var node = new JsonTreeNode(type, text, textWhenSelected) {ImageKey = item.Type.ToString()};
            node.SelectedImageKey = node.ImageKey;

            return node;
        }
    }
}
