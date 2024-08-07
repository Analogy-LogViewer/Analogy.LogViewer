﻿using Analogy.DataTypes;
using Analogy.Interfaces;

namespace Analogy.Forms
{
    public partial class RibbonFormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RibbonFormMain()
        {
            InitializeComponent();
        }

        private void RibbonFormMain_Load(object sender, System.EventArgs e)
        {
            Icon = ServicesProvider.Instance.GetService<IAnalogyUserSettings>().GetIcon();
        }
    }
}