using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Philips.Analogy.Interfaces.Interfaces
{
    public interface IAnalogyExtension
    {
        Guid ExtensionID { get; }
        string Author { get; }
        string AuthorMail { get; }
        List<string> AdditionalContributors { get; }
        string DisplayName { get; }
        string Description { get; }
        AnalogyExtensionType AnalogyExtensionType { get; }

        void CellClicked(object sender, AnalogyCellClickedEventArgs args);
        object GetValueForCellColumn(AnalogyLogMessage message, string columnName);
        List<AnalogyColumnInfo> GetColumnsInfo();
        void NewMessage(AnalogyLogMessage message);
        void NewMessages(List<AnalogyLogMessage> messages);
        UserControl GetUserControl();
    }
}
