using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analogy.Interfaces;

namespace Analogy.DataProviders
{
    public static class CommonChangeLog
    {
        public static IEnumerable<AnalogyChangeLog> GetChangeLog()
        {
            yield return new AnalogyChangeLog("Update all dependencies nugets versions (issue #73)", AnalogChangeLogType.None, "Lior Banai", new DateTime(2019, 12, 14));
            yield return new AnalogyChangeLog("Shortcuts keys are not correct (issue #72)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 12, 14));
            yield return new AnalogyChangeLog("Search filtering: Add user predefined search queries (issue #11)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 12, 13));
            yield return new AnalogyChangeLog("Add individual colors rules (issue #03)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 12, 12));
            yield return new AnalogyChangeLog("File listing should be sorted from newest to oldest and customizable by the user (issue #69)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 12, 09));
            yield return new AnalogyChangeLog("Consolidate all data providers (per factory) under the ribbon UI (issue #63)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 12, 09));
            yield return new AnalogyChangeLog("changing log level checks include text & Exclude text boxes (issue #68)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 12, 08));
            yield return new AnalogyChangeLog("Performance: Improve performance when querying messages for count display (issue #67)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 12, 07));
            yield return new AnalogyChangeLog("Add an option to remember last opened data provider (issue #65)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 12, 03));
            yield return new AnalogyChangeLog("Add logging of errors during startup for better debugging (issue #66)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 12, 03));
            yield return new AnalogyChangeLog("Add Date/time option to filter the messages (issue #62)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 29));
            yield return new AnalogyChangeLog("Add export/import settings (issue #47)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 23));
            yield return new AnalogyChangeLog("Add default file-data provider associations (issue #45)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 23));
            yield return new AnalogyChangeLog("Allows disabling of data providers (issue #60)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 22));
            yield return new AnalogyChangeLog("User Settings: Add Export/Import of messages' color settings (Issue #56)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 19));
            yield return new AnalogyChangeLog("Bookmarks window is not customizable (font size). (issue #59)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 11, 19));
            yield return new AnalogyChangeLog("Detailed message window is ignoring in-place filtering (in the grid control) and shows incorrect number of messages (issue #58)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 11, 19));
            yield return new AnalogyChangeLog("Usability: add indication in the file list of the loaded file. (Issue #57))", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 19));
            yield return new AnalogyChangeLog("user settings: Add option to set default date sort option (ascend/descend) (issue #55)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 17));
            yield return new AnalogyChangeLog("File Pooling: add indication of number of new messages per update (issue #51)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 14));
            yield return new AnalogyChangeLog("File Pooling: Add an option to ignore global caching settings or adding to recent files history. (issue #54)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 14));
            yield return new AnalogyChangeLog("NLog Data Provider: Add import/export of settings. (issue #52)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 12));
            yield return new AnalogyChangeLog("Built-in Data providers are ignored when double clicking and log file. (issue #50)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 11, 10));
            yield return new AnalogyChangeLog("File pooling: duplicate entries are added (issue #49)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 11, 10));
            yield return new AnalogyChangeLog("Coloring: Add user settings for log level colors (issue #48)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 09));
            yield return new AnalogyChangeLog("Data Providers: Add NLog data Provider (issue #19)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 11, 07));
            yield return new AnalogyChangeLog("Performance: Load data providers asynchronously during startup (issue #40)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 21));
            yield return new AnalogyChangeLog("adding .net Core 3.0 Target", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 26));
            yield return new AnalogyChangeLog("Offline files: Add option for file pooling. (issue #36)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 24));
            yield return new AnalogyChangeLog("cleanup old namespaces (issue #34)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 18));
            yield return new AnalogyChangeLog("frameworks update: interface dll is not target .net standard 2.0 and Analogy UI is .net framework 4.7.2 (issues #32,#33)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 18));
            yield return new AnalogyChangeLog("UI: not all UI elements support themes (issue #28)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 10, 14));
            yield return new AnalogyChangeLog("UI: Add an option (user setting) to auto scroll to last message (Issue #26)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 13));
            yield return new AnalogyChangeLog("Fix: DevExpress Control: Sometimes an error occurs and the grid displays a big red X (Issue #4)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 10, 11));
            yield return new AnalogyChangeLog("UI: Add fast file caching switching (Issue #23)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 11));
            yield return new AnalogyChangeLog("UI: Add more information about messages in the Message's detail window (Issue #22)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 10, 09));
            yield return new AnalogyChangeLog("Fix: Online Data Providers are not disposed during shutdown of Analogy (Issue #21)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 10, 09));
            yield return new AnalogyChangeLog("Fix: Folder loading is ignoring data source supported files (Issue #18)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 26));
            yield return new AnalogyChangeLog("Add an option to un-dock current view and keep receiving new messages (Issue #16)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 25));
            yield return new AnalogyChangeLog("duplicate chrome tab behavior (close tab keyboard shortcut, close all other tabs, etc) (Issue #8)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 24));
            yield return new AnalogyChangeLog("remove Auto Start value form the interface and make it UI option", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 21));
            yield return new AnalogyChangeLog("Startup data sources: add a user setting to define list of startup data sources (Issue #10)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 21));
            yield return new AnalogyChangeLog("Windows Event logs: add support for custom logs in addition to Windows logs (Issue #7)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 20));
            yield return new AnalogyChangeLog("user settings are not saved between different versions (Issue #13)", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 09, 20));
            yield return new AnalogyChangeLog("Add resource usage indication and idle mode (Issue #6)", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 09, 20));
            yield return new AnalogyChangeLog("Fix unable to save logs for real time Data sources", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 09, 09));
            yield return new AnalogyChangeLog("Add more information in the offline files listing.", AnalogChangeLogType.Improvement, "Lior Banai", new DateTime(2019, 08, 31));
            yield return new AnalogyChangeLog("Fix about Page loading.", AnalogChangeLogType.Defect, "Lior Banai", new DateTime(2019, 08, 30));
            yield return new AnalogyChangeLog("First release as open source tool.", AnalogChangeLogType.Feature, "Lior Banai", new DateTime(2019, 08, 19));
        }
    }
}
