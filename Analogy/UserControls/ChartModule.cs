using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.Menu;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Printing;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using PrintImageFormat = DevExpress.XtraCharts.Printing.PrintImageFormat;

namespace Analogy.UserControls {

    public partial class ChartModule: XtraUserControl
    {
        class ImageFormatInfo {
            ImageCodecInfo imageCodecInfo;
            ImageFormat imageFormat;

            internal ImageCodecInfo ImageCodecInfo => imageCodecInfo;

            internal ImageFormat ImageFormat => imageFormat;

            internal ImageFormatInfo(ImageCodecInfo imageCodecInfo, ImageFormat imageFormat) {
                this.imageCodecInfo = imageCodecInfo;
                this.imageFormat = imageFormat;
            }
        }
        protected static class PieExplodingHelper
        {
            static SeriesPointFilter CreateFilter(string mode)
            {
                return new SeriesPointFilter(SeriesPointKey.Argument, DataFilterCondition.Equal, mode);
            }
            static void ApplyFilterMode(PieSeriesViewBase view, string mode)
            {
                view.ExplodedPointsFilters.Clear();
                view.ExplodedPointsFilters.Add(CreateFilter(mode));
                view.ExplodeMode = PieExplodeMode.UseFilters;
            }

            internal const string None = "None";
            internal const string All = "All";
            internal const string MinValue = "Min Value";
            internal const string MaxValue = "Max Value";
            internal const string Custom = "Custom";

            internal static List<string> CreateModeList(SeriesPointCollection points, bool supportCustom)
            {
                List<string> list = new List<string>();
                list.Add(None);
                list.Add(All);
                list.Add(MinValue);
                list.Add(MaxValue);
                foreach (SeriesPoint point in points)
                    list.Add(point.Argument);
                if (supportCustom)
                    list.Add(Custom);
                return list;
            }
            internal static void ApplyMode(PieSeriesViewBase view, string mode)
            {
                switch (mode)
                {
                    case Custom:
                        break;
                    case None:
                        view.ExplodeMode = PieExplodeMode.None;
                        break;
                    case All:
                        view.ExplodeMode = PieExplodeMode.All;
                        break;
                    case MinValue:
                        view.ExplodeMode = PieExplodeMode.MinValue;
                        break;
                    case MaxValue:
                        view.ExplodeMode = PieExplodeMode.MaxValue;
                        break;
                    default:
                        ApplyFilterMode(view, mode);
                        break;
                }
            }
        }
        protected static DefaultBoolean CovertBoolToDefaultBoolean(bool value)
        {
            return value ? DevExpress.Utils.DefaultBoolean.True : DevExpress.Utils.DefaultBoolean.False;
        }
        string paletteName = "Default";
        IDXMenuManager menuManager;

        internal virtual List<ChartControl> ChartControls => null;

        public string PaletteName {
            get => paletteName;
            set {
                List<ChartControl> chartControlsCache = ChartControls;
                if (chartControlsCache == null && ChartControl != null)
                    chartControlsCache = new List<ChartControl>() { ChartControl };
                if (chartControlsCache != null) {
                    foreach (ChartControl chart in chartControlsCache) {
                        try {
                            chart.PaletteName = value;
                            paletteName = value;
                        }
                        catch (ArgumentException exception) {
                            Debug.WriteLine(string.Format("Warning: impossible to set the '{0}' palette.\n{1}", value, exception.Message));
                        }
                    }
                }
                OnPaletteChanged();
            }
        }
        internal IDXMenuManager MenuManager {
            get => menuManager;
            set => menuManager = value;
        }
        internal virtual ChartControl ChartControl => null;

        internal virtual object ExportedObject => ChartControl;

        internal virtual bool ChartDesignerEnabled => true;

        internal virtual bool PaletteButtonEnabled => true;

        public bool AllowPrintOptions => ChartControl != null;

        internal ChartModule() {
            InitializeComponent();
        }

        List<ImageFormatInfo> GetSupportedImageFormats() {
            List<ImageFormat> formats = new List<ImageFormat>() { ImageFormat.Bmp, ImageFormat.Emf, ImageFormat.Exif, ImageFormat.Gif, ImageFormat.Icon, ImageFormat.Jpeg, ImageFormat.Png, ImageFormat.Tiff, ImageFormat.Wmf };
            List<ImageFormatInfo> result = new List<ImageFormatInfo>();
            ImageCodecInfo[] infos = ImageCodecInfo.GetImageEncoders();
            foreach (ImageFormat imageFormat in formats)
                foreach (ImageCodecInfo imageCodecInfo in infos)
                    if (imageCodecInfo.FormatID.Equals(imageFormat.Guid))
                        result.Add(new ImageFormatInfo(imageCodecInfo, imageFormat));
            return result;
        }

        protected virtual void OnPaletteChanged() {
        }
        protected internal virtual void OnChartDesignerClosed() {
        }
        protected void OnLookAndFeelChanged() {
            OnPaletteChanged();
        }
       
        protected  void ExportToCore(string filename, string ext) {
            ChartControl chart = ChartControl;
            if (chart != null) {
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                chart.OptionsPrint.SizeMode = PrintSizeMode.Zoom;
                if (ext == "rtf")
                    chart.ExportToRtf(filename);
                else if (ext == "pdf") {
                    chart.OptionsPrint.ImageFormat = PrintImageFormat.Metafile;
                    PdfExportOptions options = new PdfExportOptions();
                    options.ConvertImagesToJpeg = false;
                    chart.ExportToPdf(filename, options);
                }
                else if (ext == "mht")
                    chart.ExportToMht(filename);
                else if (ext == "html")
                    chart.ExportToHtml(filename);
                else if (ext == "xls")
                    chart.ExportToXls(filename);
                else if (ext == "xlsx")
                    chart.ExportToXlsx(filename);
                else if (ext == "svg")
                    chart.ExportToSvg(filename);
                else if (ext == "docx")
                    chart.ExportToDocx(filename);
                Cursor.Current = currentCursor;
            }
        }
        
        
    }

}
