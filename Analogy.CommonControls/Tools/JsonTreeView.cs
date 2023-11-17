using Analogy.CommonControls.Properties;
using DevExpress.Office.Utils;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.CommonControls.Tools
{
    [Browsable(false)]
    [DesignTimeVisible(false)]
    [Designer("JSON Tree View")]
    public class JsonTreeView : TreeView
    {
        private TreeNode previouslySelectedNode;
        private ContextMenuStrip treeContextMenu;
        private IContainer components;
        private ToolStripMenuItem expandAllMenuItem;
        private StatusStrip statusStrip1;
        private string previouslySelectedNodeText;
        private CancellationTokenSource cancellationTokenSource;
        public event EventHandler<string> OnNodeChanged;
        public string Message { get; set; }
        public JsonTreeView()
        {
            InitializeComponent();
            cancellationTokenSource = new CancellationTokenSource();
            AfterSelect += this_AfterSelect;
            DoubleClick += (s, e) =>
            {
                if (SelectedNode != null)
                {
                    Clipboard.SetText(SelectedNode.Text, TextDataFormat.UnicodeText);
                }
            };
            MouseDown += this_MouseDown;
            expandAllMenuItem.Click += expandAllMenuItem_Click;

            LoadImageList();
        }

        private void LoadImageList()
        {
            ImageList treeImages = new ImageList();
            treeImages.ImageSize = new Size(16, 16);
            foreach (JTokenType type in Enum.GetValues(typeof(JTokenType)))
            {
                Bitmap image;
                switch (type)
                {
                    case JTokenType.None:
                        image = Resources.None;
                        break;
                    case JTokenType.Object:
                        image = Resources.Object;
                        break;
                    case JTokenType.Array:
                        image = Resources.Array;
                        break;
                    case JTokenType.Constructor:
                        image = Resources.None;
                        break;
                    case JTokenType.Property:
                        image = Resources.None;
                        break;
                    case JTokenType.Comment:
                        image = Resources.None;
                        break;
                    case JTokenType.Integer:
                        image = Resources.Integer;
                        break;
                    case JTokenType.Float:
                        image = Resources.Float;
                        break;
                    case JTokenType.String:
                        image = Resources.String;
                        break;
                    case JTokenType.Boolean:
                        image = Resources.Boolean;
                        break;
                    case JTokenType.Null:
                        image = Resources.None;
                        break;
                    case JTokenType.Undefined:
                        image = Resources.Undefined;
                        break;
                    case JTokenType.Date:
                        image = Resources.Date;
                        break;
                    case JTokenType.Raw:
                        image = Resources.Object;
                        break;
                    case JTokenType.Bytes:
                        image = Resources.Object;
                        break;
                    case JTokenType.Guid:
                        image = Resources.Guid;
                        break;
                    case JTokenType.Uri:
                        image = Resources.Object;
                        break;
                    case JTokenType.TimeSpan:
                        image = Resources.TimeSpan;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                treeImages.Images.Add(type.ToString(), image ?? Resources.Undefined);
            }
            ImageList = treeImages;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        private (bool valid, List<TreeNode> result) LoadTree(object jsonData, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return (false, new());
            }
            List<TreeNode> nodes = new();
            if (jsonData is JArray jsonArray)
            {
                var rootNode = new JsonTreeNode(JsonNodeType.Object, "(root array)");
                foreach (JToken jToken in jsonArray)
                {
                    var node = new JsonTreeNode(JsonNodeType.Array, jToken.Type.ToString());
                    rootNode.Nodes.Add(node);
                    LoadObject(jToken as JObject, node, cancellationToken);
                }
                TreeNode[] rootNodeArray = new TreeNode[rootNode.Nodes.Count];
                rootNode.Nodes.CopyTo(rootNodeArray, 0);
                nodes.Add(rootNode);
                SelectedNode = rootNodeArray.First() as JsonTreeNode;
                rootNode.ImageKey = rootNode.NodeType.ToString();
                rootNode.SelectedImageKey = rootNode.ImageKey;
                rootNode.ExpandAll();
            }

            if (jsonData is JObject json)
            {
                var rootNode = new JsonTreeNode(JsonNodeType.Object, "(root)");
                nodes.Add(rootNode);
                SelectedNode = rootNode;
                rootNode.ImageKey = rootNode.NodeType.ToString();
                rootNode.SelectedImageKey = rootNode.ImageKey;
                LoadObject(json, rootNode, cancellationToken);
                rootNode.ExpandAll();
            }

            return (!cancellationToken.IsCancellationRequested, nodes);
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool TryParse(string strInput, out JToken output)
        {
            if (String.IsNullOrWhiteSpace(strInput))
            {
                output = null;
                return false;
            }
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    output = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    //optional: LogError(jex);
                    output = null;
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    //optional: LogError(ex);
                    output = null;
                    return false;
                }
            }
            else
            {
                output = null;
                return false;
            }
        }
        private void AddNode(JsonTreeNode parentNode, string property, JToken item, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            var node = JsonTreeNodeCreator.CreateNode(property, item);
            parentNode.Nodes.Add(node);
            if (item.Type == JTokenType.Array)
            {
                LoadArray(item, node, cancellationToken);
            }

            else if (item.Type == JTokenType.Object)
            {
                LoadObject(item as JObject, node, cancellationToken);
            }
            else if (TryParse(item.ToString(), out var token))
            {
                node.Text = property;
                if (token.Type == JTokenType.Array)
                {
                    LoadArray(token, node, cancellationToken);
                }

                else if (token.Type == JTokenType.Object)
                {
                    LoadObject(token as JObject, node, cancellationToken);
                }
            }
        }

        private void LoadArray(JToken value, JsonTreeNode node, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }
            foreach (var item in value)
            {
                AddNode(node, null, item, cancellationToken);
            }
        }

        private void LoadObject(JObject obj, JsonTreeNode node, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            if (obj is null)
            {
                return;
            }

            foreach (var item in obj)
            {
                AddNode(node, item.Key, item.Value, cancellationToken);
            }
        }

        private void InitializeComponent()
        {
            components = new Container();
            treeContextMenu = new ContextMenuStrip(components);
            expandAllMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            treeContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // treeContextMenu
            // 
            treeContextMenu.ImageScalingSize = new Size(20, 20);
            treeContextMenu.Items.AddRange(new ToolStripItem[] {
            expandAllMenuItem,});
            treeContextMenu.Name = "treeContextMenu";
            treeContextMenu.Size = new Size(147, 30);
            treeContextMenu.Opening += new CancelEventHandler(treeContextMenu_Opening);
            // 
            // expandAllMenuItem
            // 
            expandAllMenuItem.Name = "expandAllMenuItem";
            expandAllMenuItem.ShortcutKeys = ((Keys)((Keys.Control | Keys.E)));
            expandAllMenuItem.ShowShortcutKeys = false;
            expandAllMenuItem.Size = new Size(146, 26);
            expandAllMenuItem.Text = "&Expand All";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Location = new Point(0, 0);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(200, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // JsonTreeView
            // 
            ContextMenuStrip = treeContextMenu;
            FullRowSelect = true;
            treeContextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        private new JsonTreeNode? SelectedNode
        {
            get => base.SelectedNode as JsonTreeNode;
            set => base.SelectedNode = value;
        }

        private void this_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // restore previous seelcted node text and store the next
            if (previouslySelectedNode != null)
            {
                previouslySelectedNode.Text = previouslySelectedNodeText;
            }
            previouslySelectedNode = e.Node;
            previouslySelectedNodeText = e.Node.Text;

            e.Node.Text = ((JsonTreeNode)e.Node).TextWhenSelected;
            OnNodeChanged?.Invoke(this, e.Node.Text);
        }

        private void this_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode node = GetNodeAt(e.Location);
                if (node != null)
                {
                    base.SelectedNode = node;
                }
            }
        }

        private void treeContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (SelectedNode != null)
            {
                expandAllMenuItem.Visible = SelectedNode.IsExpandable;
                expandAllMenuItem.Enabled = SelectedNode.Nodes.Count > 0;
            }
        }

        private void expandAllMenuItem_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null)
            {
                BeginUpdate();
                SelectedNode.ExpandAll();
                EndUpdate();
            }
        }

        public void ClearList()
        {
            Nodes.Clear();
        }
        public async Task ShowJson(string jsonString)
        {
            Message = jsonString;
            try
            {
                BeginUpdate();
                Nodes.Clear();
                cancellationTokenSource?.Cancel();
                cancellationTokenSource = new CancellationTokenSource();
                var token = cancellationTokenSource.Token;
                var nodes = await Task.Run(() =>
                {
                    object json = JsonConvert.DeserializeObject(jsonString);
                    return LoadTree(json, token);
                });
                if (nodes.valid)
                {
                    Nodes.AddRange(nodes.result.ToArray());
                }
                EndUpdate();
            }
            catch (Exception e)
            {
            }
        }
    }
}