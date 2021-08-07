using Analogy.DataProviders;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Analogy.Managers;

namespace Analogy.Plotting
{
    public class AnalogyFilePlotting : IAnalogyPlotting
    {
        private string FileName { get; set; }
        public bool FirstRowIsTitle { get; }
        public bool FirsColumnIsDateTime { get; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FactoryId { get; set; } = AnalogyBuiltInFactory.AnalogyGuid;
        public string Title
        {
            get => FileName;
            set => FileName = value;
        }
        public event EventHandler<AnalogyPlottingPointData>? OnNewPointData;
        private CancellationToken token;
        private long processed;
        private List<string> headers;
        private char[] seperators = { '\t', ' ' };
       
        public AnalogyFilePlotting(string fileName, bool firstRowIsTitle, bool firsColumnIsDateTime, CancellationToken token)
        {
            FileName = fileName;
            FirstRowIsTitle = firstRowIsTitle;
            FirsColumnIsDateTime = firsColumnIsDateTime;
            this.token = token;
            using StreamReader file = new StreamReader(FileName);
            if (File.Exists(fileName))
            {
                var firstLine = file.ReadLine();
                if (!string.IsNullOrEmpty(firstLine))
                {
                    var items = firstLine.Split(seperators);
                    if (firstRowIsTitle)
                    {
                        headers = items.ToList();
                    }
                    else
                    {
                        int nowOfRows = items.Length;
                        headers = Enumerable.Range(0, nowOfRows).Select(i => $"Series {i}").ToList();
                    }

                }
            }
        }
        public IEnumerable<(string SeriesName, AnalogyPlottingSeriesType SeriesViewType)> GetChartSeries()
        {
            foreach (string seriesName in headers)
            {
                if (FirsColumnIsDateTime)
                {
                   continue;
                }
                yield return (seriesName, AnalogyPlottingSeriesType.Line);
            }
        }
        public Task InitializePlottingAsync(IAnalogyPlottingInteractor uiInteractor, IAnalogyLogger logger)
        {
            return Task.CompletedTask;
        }

        public Task StartPlotting()
        {
            return Task.Run(async () =>
            {
                using StreamReader file = new StreamReader(FileName);
                string line = await file.ReadLineAsync();
                if (!FirstRowIsTitle)
                {
                    ProcessLine(line);
                }
                while ((line = await file.ReadLineAsync()) != null)
                {
                    ProcessLine(line);
                    if (token.IsCancellationRequested)
                    {
                        AnalogyLogManager.Instance.LogInformation($"File {FileName} processing cancelled", nameof(AnalogyFilePlotting));
                        return;
                    }
                }
            });
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ProcessLine(string line)
        {
            try
            {
                var items = line.Split(seperators);
                if (FirsColumnIsDateTime)
                {
                    DateTime time = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(items[0])).DateTime;
                    for (int i = 1; i < items.Length; i++)
                    {
                        var str = items[i];
                        double val = double.Parse(str);
                        string series = headers[i];
                        var data = new AnalogyPlottingPointData(series, val, time);
                        OnNewPointData?.Invoke(this, data);
                    }
                }
                else
                {
                    for (int i = 0; i < items.Length; i++)
                    {
                        var str = items[i];
                        double val = double.Parse(str);
                        string series = headers[i];
                        var data = new AnalogyPlottingPointData(series, val, processed);
                        OnNewPointData?.Invoke(this, data);
                    }
                }
                processed++;
            }
            catch (Exception e)
            {
               AnalogyLogManager.Instance.LogError(e.ToString(),nameof(AnalogyFilePlotting));
            }
         
        }

        public Task StopPlotting()
        {
            return Task.CompletedTask;
        }

    }
}
