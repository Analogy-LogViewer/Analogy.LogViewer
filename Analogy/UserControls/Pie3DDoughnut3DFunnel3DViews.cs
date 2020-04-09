using System;
using System.Collections.Generic;
using System.Linq;
using Analogy;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;

namespace DevExpress.XtraCharts.Demos {
    public partial class Pie3DDoughnut3DFunnel3DViewsDemo : ChartDemoModule3DViews {
        readonly string[] pieLabelPosition = new string[] { "Inside", "Outside", "TwoColumns", "Radial" };
        readonly string[] funnelLabelPosition = new string[] { "LeftColumn", "Left", "Center", "Right", "RightColumn" };

        bool IsPieActive {
            get { return ActiveSeries.View is Pie3DSeriesView; }
        }
        bool IsDoughnutActive {
            get { return ActiveSeries.View is Doughnut3DSeriesView; }
        }
   

        protected override int DefaultPerspective {
            get { return 20; }
        }
        protected override LayoutControl OptionsLayoutControl {
            get { return layoutControl; }
        }
        protected override SimpleButton DefaultAnglesButton {
            get { return simpleButtonRestoreDefaultAngles; }
        }
        protected override ComboBoxEdit PerspectiveAngleComboBoxEdit {
            get { return comboBoxEditPerspectiveAngle; }
        }
        protected override CheckEdit ValueAsPercentCheckEdit {
            get { return checkEditValueAsPercent; }
        }
        protected override CheckEdit LabelVisibleCheckEdit {
            get { return checkEditLabelVisible; }
        }
        protected override TabbedView TabbedView {
            get { return currentTabbedView; }
        }

        internal override List<ChartControl> ChartControls {
            get {
                return new List<ChartControl>() {
                    chartPie3D,
                    chartDoughnut3D,
                };
            }
        }

        public Pie3DDoughnut3DFunnel3DViewsDemo() {
            InitializeComponent();
        }

        void tabbedView_DocumentActivated(object sender, DocumentEventArgs e) {
            OnDocumentActivated(e.Document);
        }
        void checkEditLabelVisible_CheckedChanged(object sender, EventArgs e) {
            SetLabelVisibility(layoutControlItemPosition, layoutControlItemValueAsPercent);
        }
        void spinEditHoleRadius_EditValueChanged(object sender, EventArgs e) {
            SetHoleRadius(ChartControl.SeriesTemplate.View);
            foreach (Series series in ChartControl.Series)
                SetHoleRadius(series.View);
        }
        void comboBoxEditExplodedPoints_SelectedIndexChanged(object sender, EventArgs e) {
            Pie3DSeriesView view = ActiveSeries.View as Pie3DSeriesView;
            if (view != null) {
                string mode = (string)comboBoxEditExplodedPoints.SelectedItem;
                PieExplodingHelper.ApplyMode(view, mode);
                spinEditExplodedDistance.Enabled = mode != PieExplodingHelper.None;
                spinEditExplodedDistance.EditValue = ((Pie3DSeriesView)ChartControl.Series[0].View).ExplodedDistancePercentage;
            }
        }
        void comboBoxEditLabelPosition_SelectedIndexChanged(object sender, EventArgs e) {
            PieSeriesLabel pieLabel = ActiveSeries.Label as PieSeriesLabel;
            if (pieLabel != null) {
                pieLabel.Position = (PieSeriesLabelPosition)comboBoxEditLabelPosition.SelectedIndex;
                return;
            }
            FunnelSeriesLabel funnelLabel = ActiveSeries.Label as FunnelSeriesLabel;
            if (funnelLabel != null)
                funnelLabel.Position = (FunnelSeriesLabelPosition)comboBoxEditLabelPosition.SelectedIndex;
        }
        void comboBoxEditHeightToWidthRatio_SelectedIndexChanged(object sender, EventArgs e) {
            Funnel3DSeriesView view = ActiveSeries.View as Funnel3DSeriesView;
            if (view != null)
                view.HeightToWidthRatio = Convert.ToDouble(comboBoxEditHeightToWidthRatio.SelectedItem);
        }
        void spinEditPointDistance_EditValueChanged(object sender, EventArgs e) {
            Funnel3DSeriesView view = ActiveSeries.View as Funnel3DSeriesView;
            if (view != null)
                view.PointDistance = Convert.ToInt32(spinEditPointDistance.Value);
        }
        void spinEditExplodedDistance_EditValueChanged(object sender, EventArgs e) {
            if (ChartControl.Series.Count == 0)
                return;
            Pie3DSeriesView view = ChartControl.Series[0].View as Pie3DSeriesView;
            if (view != null)
                view.ExplodedDistancePercentage = Convert.ToDouble(spinEditExplodedDistance.EditValue);
        }
        void spinEditFunnelHoleRadius_EditValueChanged(object sender, EventArgs e) {
            Funnel3DSeriesView view = ActiveSeries.View as Funnel3DSeriesView;
            if (view != null)
                view.HoleRadiusPercent = Convert.ToInt32(spinEditFunnelHoleRadius.EditValue);
        }
        void SetHoleRadius(SeriesViewBase view) {
            Doughnut3DSeriesView doughnutView = view as Doughnut3DSeriesView;
            if (doughnutView != null)
                doughnutView.HoleRadiusPercent = Convert.ToInt32(spinEditHoleRadius.EditValue);
        }
        void UpdatePieOptions() {
            layoutControlItemExplodedPoints.Visibility = LayoutVisibility.Always;
            UpdateExplodePointsComboBoxEdit();
            comboBoxEditLabelPosition.Properties.Items.AddRange(pieLabelPosition);
            PieSeriesLabel pieLabel = ActiveSeries.Label as PieSeriesLabel;
            if (pieLabel != null)
                comboBoxEditLabelPosition.SelectedIndex = (int)pieLabel.Position;
        }
        void UpdateExplodePointsComboBoxEdit() {
            int explodeSelectedIndex = -1;
            Pie3DSeriesView view = (Pie3DSeriesView)ActiveSeries.View;
            switch (view.ExplodeMode) {
                case PieExplodeMode.Others:
                case PieExplodeMode.UsePoints:
                    break;
                case PieExplodeMode.UseFilters:
                    object filterValue = view.ExplodedPointsFilters[0].Value;
                    explodeSelectedIndex = comboBoxEditExplodedPoints.Properties.Items.IndexOf(filterValue);
                    break;
                default:
                    explodeSelectedIndex = (int)view.ExplodeMode;
                    break;
            }
            comboBoxEditExplodedPoints.SelectedIndex = explodeSelectedIndex;
        }
        void UpdateFunnelOptions() {
            layoutControlGroupFunnelGeneral.Visibility = LayoutVisibility.Always;
            layoutControlGroupPieDoughnutGeneral.Visibility = LayoutVisibility.Never;
            comboBoxEditLabelPosition.Properties.Items.AddRange(funnelLabelPosition);
            Funnel3DSeriesView view = (Funnel3DSeriesView)ActiveSeries.View;
            comboBoxEditHeightToWidthRatio.EditValue = view.HeightToWidthRatio;
            spinEditPointDistance.Value = view.PointDistance;
            comboBoxEditLabelPosition.SelectedIndex = (int)((FunnelSeriesLabel)ActiveSeries.Label).Position;
            spinEditFunnelHoleRadius.Value = view.HoleRadiusPercent;
        }

        protected override void InitControls() {
            base.InitControls();
            comboBoxEditLabelPosition.SelectedIndex = 2;
            comboBoxEditLabelPosition.SelectedIndexChanged += comboBoxEditLabelPosition_SelectedIndexChanged;
            comboBoxEditExplodedPoints.Properties.Items.AddRange(PieExplodingHelper.CreateModeList(chartPie3D.Series[0].Points, false));
            comboBoxEditExplodedPoints.SelectedIndex = 0;
            spinEditPointDistance.EditValueChanged += spinEditPointDistance_EditValueChanged;
            comboBoxEditHeightToWidthRatio.Properties.Items.AddRange(new double[] { 0.1, 0.25, 0.5, 0.75, 1, 2, 4, 6, 8, 10 });
            spinEditHoleRadius.EditValue = ((Doughnut3DSeriesView)chartDoughnut3D.Series[0].View).HoleRadiusPercent;
            spinEditHoleRadius.EditValueChanged += spinEditHoleRadius_EditValueChanged;
        }

        public void SetDataSources(ItemStatistics calculateGlobalStatistics)
        {
            chartPie3D.Series.Clear();
            chartPie3D.Titles.Add(new ChartTitle() {Text = calculateGlobalStatistics.Name});
            Series series1 = new Series(calculateGlobalStatistics.Name, ViewType.Pie3D)
            {
                DataSource = calculateGlobalStatistics.AsList().ToList(), ArgumentDataMember = "Name"
            };

            // Bind the series to data. 
            series1.ValueDataMembers.AddRange(new string[] { "Value" });
            // Add the series to the chart. 
            chartPie3D.Series.Add(series1);
            series1.LabelsVisibility = Utils.DefaultBoolean.True;
            checkEditLabelVisible.Checked = true;

            SetValueAsPercent(true);
            checkEditValueAsPercent.Checked = true;
        }

        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            documentManager.View.Controller.Activate(documentPie3D);
        }

        protected override void UpdateControlsCore()
        {
            base.UpdateControlsCore();
            layoutControl.BeginUpdate();
            checkEditLabelVisible.Checked = ActiveSeries.LabelsVisibility == DevExpress.Utils.DefaultBoolean.True;
            string actualPattern = ActiveSeries.Label.TextPattern;
            checkEditValueAsPercent.Checked =
                actualPattern == PiePercentPattern || actualPattern == FunnelPercentPattern;
            comboBoxEditLabelPosition.Properties.Items.Clear();
            layoutControlGroupFunnelGeneral.Visibility = LayoutVisibility.Never;
            layoutControlGroupPieDoughnutGeneral.Visibility = LayoutVisibility.Always;
            layoutControlGroupExplodedDistance.Visibility =
                IsDoughnutActive ? LayoutVisibility.Never : LayoutVisibility.Always;
            layoutControlItemDoughnutHoleRadius.Visibility =
                IsDoughnutActive ? LayoutVisibility.Always : LayoutVisibility.Never;
            UpdatePieOptions();
            layoutControl.EndUpdate();
        }

        protected override void UpdateRotationAngles(Diagram3D diagram) {
            diagram.RotationOrder = RotationOrder.ZXY;
            if (IsPieActive) {
                diagram.RotationAngleX = -35;
                diagram.RotationAngleY = 0;
                diagram.RotationAngleZ = 15;
            }
            else {
                diagram.RotationAngleX = 15;
                diagram.RotationAngleY = 0;
                diagram.RotationAngleZ = 0;
            }
        }
    }
}
