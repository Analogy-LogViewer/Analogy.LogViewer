using System.Windows.Forms;

namespace Analogy.CommonControls.Tools
{
    class JsonTreeNode : TreeNode
    {
        public JsonNodeType NodeType { get; }

        public string TextWhenSelected { get; }

        public bool IsExpandable => NodeType == JsonNodeType.Object || NodeType == JsonNodeType.Array;

        public JsonTreeNode(JsonNodeType nodeType, string text, string? textWhenSelected = null)
        {
            NodeType = nodeType;
            Text = text;
            TextWhenSelected = textWhenSelected ?? text;
        }
    }
}