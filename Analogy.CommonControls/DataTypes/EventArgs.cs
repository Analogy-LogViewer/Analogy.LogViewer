using Analogy.Interfaces;
using System;
using System.Collections.Generic;

namespace Analogy.CommonControls.DataTypes
{
    public class FolderSelectionEventArgs : EventArgs
    {
        public string SelectedFolderPath { get; }

        public FolderSelectionEventArgs(string folder)
        {
            SelectedFolderPath = folder;
        }
    }

    public class SelectionEventArgs : EventArgs
    {
        public List<string> SelectedFileNames { get; private set; }

        public SelectionEventArgs(List<string> files)
        {
            SelectedFileNames = files;
        }
    }

    public class AnalogyClearedHistoryEventArgs : EventArgs
    {
        public List<IAnalogyLogMessage> ClearedMessages { get; }

        public AnalogyClearedHistoryEventArgs(List<IAnalogyLogMessage> clearedMessages)
        {
            ClearedMessages = clearedMessages;
        }
    }
}