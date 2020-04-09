using DevExpress.Utils;
using DevExpress.XtraBars.Navigation;

namespace DevExpress.XtraCharts.Demos {

    public partial class ChartDemoModuleWithOptions : ChartDemoModule {
        NavigationPaneState optionsPanelStateField;

        public NavigationPaneState OptionsPanelState {
            get { return optionsPanelStateField; }
            set {
                optionsPanelStateField = value;
                this.tabPaneOptions.State = optionsPanelStateField;
            }
        }
        public ChartDemoModuleWithOptions() {
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
