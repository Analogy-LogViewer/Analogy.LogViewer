﻿using Analogy.Interfaces;
using DevExpress.XtraEditors;

namespace Analogy
{
    public partial class FormCombineFiles : XtraForm
    {
        private IAnalogyOfflineDataProvider offlineAnalogy;

        private FormCombineFiles()
        {
            InitializeComponent();
        }

        public FormCombineFiles(IAnalogyOfflineDataProvider offlineAnalogy) : this()
        {
            this.offlineAnalogy = offlineAnalogy;
            combineFilesUC1.SetDataSource(offlineAnalogy);
        }
    }
}
