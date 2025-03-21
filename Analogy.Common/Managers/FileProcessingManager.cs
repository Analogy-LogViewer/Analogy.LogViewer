﻿using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analogy.Common.Managers
{
    public class FileProcessingManager
    {
        private List<string> ProcessedFileNames { get; set; } = new List<string>();
        private List<string> Processing { get; set; } = new List<string>();
        private readonly object _lockObject = new object();

        private Dictionary<string, List<IAnalogyLogMessage>> Messages { get; } = new Dictionary<string, List<IAnalogyLogMessage>>(StringComparer.OrdinalIgnoreCase);
        public bool AlreadyProcessed(string filename) => ProcessedFileNames.Contains(filename, StringComparer.OrdinalIgnoreCase);

        public bool IsFileCurrentlyBeingProcessed(string filename) => Processing.Contains(filename, StringComparer.OrdinalIgnoreCase);

        public void AddProcessingFile(string filename)
        {
            lock (_lockObject)
            {
                if (!Processing.Contains(filename, StringComparer.OrdinalIgnoreCase))
                {
                    Processing.Add(filename);
                }
            }
        }

        public void DoneProcessingFile(List<IAnalogyLogMessage> messages, string filename)
        {
            lock (_lockObject)
            {
                if (Processing.Contains(filename))
                {
                    Processing.Remove(filename);
                }

                if (ProcessedFileNames.Contains(filename))
                {
                    ProcessedFileNames.Remove(filename);
                }

                ProcessedFileNames.Add(filename);
                if (Messages.ContainsKey(filename))
                {
                    Messages.Remove(filename);
                }

                Messages.Add(filename, messages);
            }
        }

        public bool StillProcessingFiles() => Processing.Any();

        public List<IAnalogyLogMessage> GetMessages(string filename) => Messages[filename];

        public void Reset()
        {
            ProcessedFileNames.Clear();
            Messages.Clear();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}