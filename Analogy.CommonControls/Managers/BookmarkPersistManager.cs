using Analogy.CommonControls.LogLoaders;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using DevExpress.XtraEditors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analogy.CommonControls.Managers
{
    public class BookmarkPersistManager : ILogMessageCreatedHandler
    {
        public EventHandler<LogMessageArgs> MessageReceived;
        public EventHandler<LogMessageArgs> MessageRemoved;
        private bool ContentChanged;
        private bool fileLoaded;
        private List<IAnalogyLogMessage> Messages { get; set; }
        private string BookmarkFileName { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AnalogyBookmarks.log");
        public bool ForceNoFileCaching { get; set; }
        public bool DoNotAddToRecentHistory { get; set; }
        private ILogger Logger { get; set; }
        public BookmarkPersistManager()
        {
            Messages = new List<IAnalogyLogMessage>();
        }

        public void AppendMessage(IAnalogyLogMessage message, string dataSource)
        {
            Messages.Add(message);
        }

        public void AppendMessages(List<IAnalogyLogMessage> messages, string dataSource)
        {
            Messages.AddRange(messages);
        }

        public void AppendMessage(DataRow dtr, string dataSource)
        {
            AnalogyLogMessage message = (AnalogyLogMessage)dtr[Common.CommonUtils.AnalogyMessageColumn];
            AppendMessage(message, dataSource);
        }
        public void SetLogger(ILogger logger) => Logger = logger;
        public async Task<List<IAnalogyLogMessage>> GetMessages()
        {
            if (fileLoaded || !File.Exists(BookmarkFileName))
            {
                return Messages;
            }

            //todo: which format;
            try
            {
                AnalogyJsonLogFile read = new AnalogyJsonLogFile();
                Messages = (await read.ReadFromFile(BookmarkFileName, new CancellationToken(), null)).ToList();
                fileLoaded = true;
            }
            catch (Exception e)
            {
                Logger?.LogError("Error reading file: " + e, nameof(BookmarkPersistManager));
                XtraMessageBox.Show(e.Message, @"Error reading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return Messages;
        }

        public void AddBookmarkedMessage(AnalogyLogMessage message, string dataSource)
        {
            if (!Messages.Contains(message))
            {
                Messages.Add(message);
                ContentChanged = true;
                MessageReceived?.Invoke(this, new LogMessageArgs(message, Environment.MachineName, dataSource));
            }
        }

        public void RemoveBookmark(AnalogyLogMessage message)
        {
            if (Messages.Contains(message))
            {
                Messages.Remove(message);
                ContentChanged = true;
                MessageRemoved?.Invoke(this, new LogMessageArgs(message, Environment.MachineName, ""));
            }
        }

        public void SaveFile()
        {
            if (!ContentChanged)
            {
                return;
            }

            if (!Messages.Any())
            {
                if (File.Exists(BookmarkFileName))
                {
                    try
                    {
                        File.Delete(BookmarkFileName);
                    }
                    catch (Exception e)
                    {
                        Logger?.LogError("Error deleting file: " + e, nameof(BookmarkPersistManager));
                    }
                }
            }
            else
            {
                try
                {
                    AnalogyJsonLogFile save = new AnalogyJsonLogFile();
                    _ = save.Save(Messages, BookmarkFileName);
                }
                catch (Exception e)
                {
                    Logger?.LogError("Error saving file: " + e, nameof(BookmarkPersistManager));
                    XtraMessageBox.Show(e.Message, @"Error Saving file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public void ClearBookmarks()
        {
            if (Messages.Any())
            {
                Messages.Clear();
                ContentChanged = true;
            }
        }
        public void ReportFileReadProgress(AnalogyFileReadProgress progress)
        {
            //noop
        }
    }
}