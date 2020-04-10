using System;
using DevExpress.Utils;
using DevExpress.Utils.Design;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraBars.Docking2010.Views;
using DevExpress.XtraBars.Docking2010.Views.Tabbed;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;

namespace DevExpress.XtraCharts.Demos {
    public class ChartDemoModuleLabelViews : ChartDemoModuleWithOptions {
        protected const string PiePercentPattern = "{A}: {VP:P2}";
        protected const string FunnelPercentPattern = "{A}: {VP:P0}";
        protected const string PercentPattern = "{VP:P0}";
        
        ChartControl activeChart = new ChartControl();

        protected virtual SeriesBase ActiveSeries {
            get {
                if(ChartControl.Series.Count > 0)
                    return ChartControl.Series[0];
                return ChartControl.SeriesTemplate;
            }
        }
        protected virtual SpinEdit LabelAngleSpinEdit => null;

        protected virtual CheckEdit ValueAsPercentCheckEdit => null;

        protected virtual CheckEdit LabelVisibleCheckEdit => null;

        protected virtual LayoutControl OptionsLayoutControl => null;

        protected virtual DefaultBoolean ToolTipEnabled => DefaultBoolean.Default;

        protected virtual DefaultBoolean CrosshairEnabled => DefaultBoolean.Default;

        protected virtual bool AnimationEnabled => true;

        protected virtual TabbedView TabbedView => null;

        internal override ChartControl ChartControl => activeChart;

        public ChartDemoModuleLabelViews() {
            Load += ChartDemoModuleLabelViews_Load;
        }
        
        void ChartDemoModuleLabelViews_Load(object sender, EventArgs e) {
            if(!DesignTimeTools.IsDesignMode)
                InitControls();
        }
        bool IsFullStackedBarView(SeriesViewBase view) {
            return view is FullStackedBarSeriesView || view is FullStackedBar3DSeriesView;
        }
        bool IsSideBySideFullStackedBarView(SeriesViewBase view) {
            return view is SideBySideFullStackedBarSeriesView || view is SideBySideFullStackedBar3DSeriesView;
        }
        bool IsFullStackedView(SeriesViewBase view) {
            return view is FullStackedAreaSeriesView ||
                   view is FullStackedLineSeriesView ||
                   view is FullStackedArea3DSeriesView ||
                   view is FullStackedLine3DSeriesView;
        }
        bool IsFunnelView(SeriesViewBase view) {
            return view is FunnelSeriesView || view is Funnel3DSeriesView;
        }
        bool IsPieView(SeriesViewBase view) {
            return view is PieSeriesView || view is Pie3DSeriesView;
        }
        void ValueAsPercentCheckedEditCheckedChanged(object sender, EventArgs e) {
            OnValueAsPercentChanged(ValueAsPercentCheckEdit.Checked);
        }
        void LabelAngleSpinEditEditValueChanged(object sender, EventArgs e) {
            OnLabelAngleChanged((int)LabelAngleSpinEdit.Value);
        }
        void OnLabelVisibilityChanged(LayoutControlItem[] items) {
            SetEnabledLayoutControlItems(LabelVisibleCheckEdit.Checked, items);
            ChartControl.CrosshairEnabled = LabelVisibleCheckEdit.Checked ? DefaultBoolean.False : CrosshairEnabled;
            ChartControl.ToolTipEnabled = LabelVisibleCheckEdit.Checked ? DefaultBoolean.False : ToolTipEnabled;
        }
        void UpdateControls() {
            if(OptionsLayoutControl == null)
                return;
            OptionsLayoutControl.BeginUpdate();
            UpdateControlsCore();
            OptionsLayoutControl.EndUpdate();
        }
        void SetLabelAngle(int labelAngle) {
            foreach (Series series in ChartControl.Series) 
                SetLabelAngle(series.Label, labelAngle);
        }
        void TabbedView_PopupMenuShowing(object sender, XtraBars.Docking2010.Views.PopupMenuShowingEventArgs e) {
            e.Cancel = e.GetDocument() != null;
        }

        protected virtual void InitControls() {
            TabbedView.PopupMenuShowing += TabbedView_PopupMenuShowing;
            if(LabelAngleSpinEdit != null)
                LabelAngleSpinEdit.EditValueChanged += LabelAngleSpinEditEditValueChanged;
            if(ValueAsPercentCheckEdit != null)
                ValueAsPercentCheckEdit.CheckedChanged += ValueAsPercentCheckedEditCheckedChanged;
        }
        protected virtual void OnValueAsPercentChanged(bool valueAsPercent) {
            SetValueAsPercent(valueAsPercent);
        }
        protected virtual void OnLabelAngleChanged(int angle) {
            SetLabelAngle(angle);
        }
        protected virtual void UpdateControlsCore() { }
        protected virtual void OnDocumentActivatedCore(BaseDocument document) {
            UpdateControls();
            if(AnimationEnabled)
                activeChart.Animate();
        }
        protected void SetEnabledLayoutControlItems(bool enabled, params LayoutControlItem[] items) {
            foreach(LayoutControlItem item in items)
                item.Enabled = enabled;
        }
        protected void OnDocumentActivated(BaseDocument document) {
            if(!document.IsDockPanel)
                return;
            this.activeChart = ((DockPanel)document.Control).ControlContainer.Controls[0] as ChartControl;
            OnDocumentActivatedCore(document);
        }
        protected void SetLabelAngle(SeriesLabelBase label, int labelAngle) {
            if(label is PointSeriesLabel pointLabel) {
                pointLabel.Angle = labelAngle;
                return;
            }

            if(label is RangeAreaSeriesLabel rangeAreaLabel) {
                rangeAreaLabel.MinValueAngle = labelAngle;
                rangeAreaLabel.MaxValueAngle = labelAngle;
            }
        }
        protected void SetLabelVisibility(params LayoutControlItem[] items) {
            OnLabelVisibilityChanged(items);
            DefaultBoolean labelsVisibility = CovertBoolToDefaultBoolean(LabelVisibleCheckEdit.Checked);
            foreach(Series series in ChartControl.Series)
                series.LabelsVisibility = labelsVisibility;
        }
        protected void SetLabelVisibility(SeriesBase series, params LayoutControlItem[] items) {
            OnLabelVisibilityChanged(items);
            series.LabelsVisibility = CovertBoolToDefaultBoolean(LabelVisibleCheckEdit.Checked); ;
        }
        protected void SetValueAsPercent(bool valueAsPercent) {
            foreach(Series series in ChartControl.Series)
                SetValueAsPercent(series, valueAsPercent);
        }
        protected void SetValueAsPercent(SeriesBase series, bool valueAsPercent) {
            SeriesViewBase view = series.View;
            if (view is FullStackedStepAreaSeriesView) {
                series.Label.TextPattern = valueAsPercent ? PercentPattern : "{V:F0}";
                return;
            }
            if (IsPieView(view)) {
                series.Label.TextPattern = valueAsPercent ? PiePercentPattern : "{A}: {V:F1}";
                return;
            }
            if (IsFunnelView(view)) {
                series.Label.TextPattern = valueAsPercent ? FunnelPercentPattern : "{A}: {V:F0}";
                return;
            }
            if (IsFullStackedBarView(view)) {
                series.Label.TextPattern = valueAsPercent ? PercentPattern : "{V:F0}K";
                return;
            }
            if (IsSideBySideFullStackedBarView(view)) {
                series.Label.TextPattern = valueAsPercent ? PercentPattern : "{V:0,,.00}";
                return;
            }
            else if (IsFullStackedView(view)) {
                series.Label.TextPattern = valueAsPercent ? PercentPattern : "${V}M";
                return;
            }
        }
    }
}
