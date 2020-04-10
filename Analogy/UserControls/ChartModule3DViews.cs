using System;
using DevExpress.XtraEditors;

namespace DevExpress.XtraCharts.Demos {
    public class ChartModule3DViews : ChartDemoModuleLabelViews {
        const string DefaultPerspectiveText = "Default";
        
        Diagram3D Diagram3D => ChartControl.Diagram as Diagram3D;

        protected virtual SimpleButton DefaultAnglesButton => null;

        protected virtual ComboBoxEdit PerspectiveAngleComboBoxEdit => null;

        protected virtual int DefaultPerspective => 50;

        void OnDefaultAnglesButtonClick(object sender, EventArgs e) {
            if(Diagram3D == null)
                return;
            Diagram3D.RotationType = RotationType.UseAngles;
            UpdateRotationAngles(Diagram3D);
            Diagram3D.RotationType = RotationType.UseMouseAdvanced;
        }
        void OnPerspectiveAngleComboBoxEditSelectedIndexChanged(object sender, EventArgs e) {
            if(Diagram3D == null || PerspectiveAngleComboBoxEdit.SelectedIndex == -1)
                return;
            string perspectiveText = PerspectiveAngleComboBoxEdit.Text;
            Diagram3D.PerspectiveAngle = perspectiveText == DefaultPerspectiveText ? DefaultPerspective : Int32.Parse(perspectiveText); ;
        }

        protected virtual void UpdateRotationAngles(Diagram3D diagram) {
        }
        protected override void InitControls() {
            base.InitControls();
            PerspectiveAngleComboBoxEdit.Properties.Items.AddRange(new object[] { DefaultPerspectiveText, 0, 30, 45, 60, 90, 120, 135, 150 });
            PerspectiveAngleComboBoxEdit.SelectedIndex = 0;
            PerspectiveAngleComboBoxEdit.SelectedIndexChanged += OnPerspectiveAngleComboBoxEditSelectedIndexChanged;
            DefaultAnglesButton.Click += OnDefaultAnglesButtonClick;
        }
        protected override void UpdateControlsCore() {
            base.UpdateControlsCore();
            if(Diagram3D == null)
                return;
            if(Diagram3D.PerspectiveAngle == DefaultPerspective)
                PerspectiveAngleComboBoxEdit.SelectedItem = DefaultPerspectiveText;
            else
                PerspectiveAngleComboBoxEdit.SelectedItem = Diagram3D.PerspectiveAngle;
        }
    }
}
