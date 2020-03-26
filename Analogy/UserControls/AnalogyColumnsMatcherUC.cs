using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Analogy.Interfaces;

namespace Analogy.UserControls
{
    public partial class AnalogyColumnsMatcherUC : UserControl
    {
        public Dictionary<int, AnalogyLogMessagePropertyName> Mapping => GetMapping();
        public AnalogyColumnsMatcherUC()
        {
            InitializeComponent();
        }


        private void SBtnMoveUp_Click(object sender, EventArgs e)
        {
            if (lstBAnalogyColumns.SelectedIndex <= 0) return;
            var selectedIndex = lstBAnalogyColumns.SelectedIndex;
            var currentValue = lstBAnalogyColumns.Items[selectedIndex];
            lstBAnalogyColumns.Items[selectedIndex] = lstBAnalogyColumns.Items[selectedIndex - 1];
            lstBAnalogyColumns.Items[selectedIndex - 1] = currentValue;
            lstBAnalogyColumns.SelectedIndex = lstBAnalogyColumns.SelectedIndex - 1;
        }

        private void SBtnMoveDown_Click(object sender, EventArgs e)
        {
            if (lstBAnalogyColumns.SelectedIndex == lstBAnalogyColumns.ItemCount - 1) return;
            var selectedIndex = lstBAnalogyColumns.SelectedIndex;
            var currentValue = lstBAnalogyColumns.Items[selectedIndex + 1];
            lstBAnalogyColumns.Items[selectedIndex + 1] = lstBAnalogyColumns.Items[selectedIndex];
            lstBAnalogyColumns.Items[selectedIndex] = currentValue;
            lstBAnalogyColumns.SelectedIndex = lstBAnalogyColumns.SelectedIndex + 1;
        }

        private void lstBAnalogyColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                if (lstBAnalogyColumns.SelectedIndex > lstBoxItemsNlog.ItemCount - 1) return;
                lstBoxItemsNlog.SelectedIndex = lstBAnalogyColumns.SelectedIndex;
            

        }

        public void SetColumns(string[] columns)
        {
            lstBoxItemsNlog.Items.Clear();
            lstBoxItemsNlog.Items.AddRange(columns);
        }

        public void LoadMapping(ILogParserSettings parser)
        {
            lstBAnalogyColumns.Items.Clear();
            for (int i = 0; i < 21; i++)
            {
                if (parser.Maps.ContainsKey(i))
                    lstBAnalogyColumns.Items.Add(parser.Maps[i]);
                else
                    lstBAnalogyColumns.Items.Add("__ignore__");
            }

        }
        private Dictionary<int, AnalogyLogMessagePropertyName> GetMapping()
        {
            Dictionary<int, AnalogyLogMessagePropertyName> maps =
                new Dictionary<int, AnalogyLogMessagePropertyName>(lstBAnalogyColumns.ItemCount);
            for (int i = 0; i < lstBAnalogyColumns.ItemCount; i++)
            {
                if (lstBAnalogyColumns.Items[i].ToString()
                    .Contains("ignore", StringComparison.InvariantCultureIgnoreCase)) continue;
                maps.Add(i, (AnalogyLogMessagePropertyName)Enum.Parse(typeof(AnalogyLogMessagePropertyName),
                    lstBAnalogyColumns.Items[i].ToString()));
            }

            return maps;
        }
    }
}
