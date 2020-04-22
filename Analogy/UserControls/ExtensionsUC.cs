using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Analogy.Interfaces;

namespace Analogy
{
    public partial class ExtensionsUC : UserControl
    {
        public event EventHandler<EventArgs> OnClicked;
        public ExtensionsUC()
        {
            InitializeComponent();
        }

        private void ExtensionsUC_Load(object sender, EventArgs e)
        {
            if (DesignMode) return;
            var extensions = ExtensionsManager.Instance.GetExtensions();
            foreach (var ex in extensions)
            {
                chklItems.Items.Add(ex);
                chklItems.DisplayMember = "DisplayName";
            }
        }



        private void chklItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            IAnalogyExtension analogyExtension = (IAnalogyExtension)chklItems.SelectedItem;
            if (analogyExtension == null) return;
            lblExtension.Text = $"Name: {analogyExtension.Title}";
            lblDescription.Text = $"Description: {analogyExtension.Description}";
            lblType.Text = $"Type: {analogyExtension.ExtensionType}";
            lblAuthor.Text = $"Author: {analogyExtension.Author} (Mail: {analogyExtension.AuthorMail})";
        }

        private void sBtnLoad_Click(object sender, EventArgs e)
        {
            List<IAnalogyExtension> components = new List<IAnalogyExtension>();
            foreach (var item in chklItems.CheckedItems)
            {
                components.Add(item as IAnalogyExtension);

            }

            if (components.Any())
            {
                var manager = ExtensionsManager.Instance;
                foreach (IAnalogyExtension analogyExtension in components)
                {
                    manager.RegisterExtension(analogyExtension);
                }

                sBtnLoad.Text = "Loaded";
            }

            OnClicked?.Invoke(this, new EventArgs());
        }
    }
}
