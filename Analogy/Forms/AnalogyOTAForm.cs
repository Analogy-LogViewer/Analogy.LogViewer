using DevExpress.XtraEditors;

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using Analogy.Interfaces;
using Analogy.Interfaces.Factories;

namespace Analogy
{
    public partial class AnalogyOTAForm : XtraForm
    {
        private class ComboboxItem
        {
            public string Name { get; set; }
            public IAnalogyShareable Shareable { get; set; }
    
        }

        private List<AnalogyLogMessage> messages;
        public AnalogyOTAForm()
        {
            messages=new List<AnalogyLogMessage>();
            InitializeComponent();
        }

        public AnalogyOTAForm(DataTable data) : this()
        {
            List<ComboboxItem> items = new List<ComboboxItem>();
            foreach (DataRow dataRow in data.Rows)
            {
                messages.Add(dataRow["Object"] as AnalogyLogMessage);
            }

            foreach (var fc in FactoriesManager.Instance.Factories)
            {
                foreach (var sf in fc.ShareableFactories)
                {
                    foreach (var share in sf.Shareables)
                    {
                        items.Add(new ComboboxItem() {Name = sf.Title, Shareable = share});
                    }
                }
            }

            cbShares.DataSource = items;
            cbShares.DisplayMember = "Name";
        }

        private void AnalogyOTAForm_Load(object sender, EventArgs e)
        {
     
        }

        private void AnalogyOTAForm_FormClosing(object sender, FormClosingEventArgs e)
        {
     
        }
    }
}
