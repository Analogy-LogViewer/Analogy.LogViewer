namespace Analogy
{
    partial class XtraUCFileSystem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colFullPath = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSize = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colType = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName,
            this.colFullPath,
            this.colSize,
            this.colType});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.FixedLineWidth = 3;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Margin = new System.Windows.Forms.Padding(4);
            this.treeList1.MinWidth = 27;
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsFind.AlwaysVisible = true;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.Size = new System.Drawing.Size(396, 296);
            this.treeList1.TabIndex = 1;
            this.treeList1.TreeLevelWidth = 24;
            this.treeList1.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeList1_GetStateImage);
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeList1_CustomDrawNodeCell);
            this.treeList1.VirtualTreeGetChildNodes += new DevExpress.XtraTreeList.VirtualTreeGetChildNodesEventHandler(this.treeList1_VirtualTreeGetChildNodes);
            this.treeList1.VirtualTreeGetCellValue += new DevExpress.XtraTreeList.VirtualTreeGetCellValueEventHandler(this.treeList1_VirtualTreeGetCellValue);
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 44;
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 129;
            // 
            // colFullPath
            // 
            this.colFullPath.Caption = "Path";
            this.colFullPath.FieldName = "Path";
            this.colFullPath.MinWidth = 27;
            this.colFullPath.Name = "colFullPath";
            this.colFullPath.Visible = true;
            this.colFullPath.VisibleIndex = 1;
            this.colFullPath.Width = 124;
            // 
            // colSize
            // 
            this.colSize.Caption = "Size(Bytes)";
            this.colSize.FieldName = "Size";
            this.colSize.MinWidth = 27;
            this.colSize.Name = "colSize";
            this.colSize.Visible = true;
            this.colSize.VisibleIndex = 2;
            this.colSize.Width = 123;
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 3;
            // 
            // XtraUCFileSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Name = "XtraUCFileSystem";
            this.Size = new System.Drawing.Size(396, 296);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFullPath;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSize;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colType;
    }
}
