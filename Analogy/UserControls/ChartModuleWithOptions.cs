using DevExpress.Utils;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraCharts.Demos;

namespace Analogy.UserControls {

    public partial class ChartModuleWithOptions : ChartModule {
        NavigationPaneState optionsPanelStateField;

        public NavigationPaneState OptionsPanelState {
            get { return optionsPanelStateField; }
            set {
                optionsPanelStateField = value;
                this.tabPaneOptions.State = optionsPanelStateField;
            }
        }
        public ChartModuleWithOptions() {
            InitializeComponent();
            this.tabPaneOptions.AllowCollapse = DefaultBoolean.True;
            this.tabPaneOptions.State = optionsPanelStateField;
            this.tabPaneOptions.StateChanged += tabPaneOptions_StateChanged;
        }

        void tabPaneOptions_StateChanged(object sender, StateChangedEventArgs e) {
            optionsPanelStateField = e.State;
        }
    }

}
