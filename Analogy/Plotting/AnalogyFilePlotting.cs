using Analogy.DataProviders;
using Analogy.Interfaces;
using Analogy.Interfaces.DataTypes;
using Analogy.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Analogy.DataTypes;

namespace Analogy.Plotting
{
    public class AnalogyFilePlotting : IAnalogyPlotting
    {
        private string FileName { get; set; }
        public bool FirstRowIsTitle { get; }
        public bool CustomXAxis { get; }
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid FactoryId { get; set; } = AnalogyBuiltInFactory.AnalogyGuid;
        public string Title
        {
            get => FileName;
            set => FileName = value;
        }
        public event EventHandler<AnalogyPlottingPointData>? OnNewPointData;
        public event EventHandler<List<AnalogyPlottingPointData>>? OnNewPointsData;
        private readonly AnalogyCustomXAxisPlot _xAxisType;
        private CancellationToken token;
        private long processed;
        private List<string> headers;
        private char[] seperators = { '\t', ' ' };

        public AnalogyFilePlotting(string fileName, bool firstRowIsTitle, bool customXAxis,
            AnalogyCustomXAxisPlot xAxisType, CancellationToken token)
        {
            FileName = fileName;
            FirstRowIsTitle = firstRowIsTitle;
            CustomXAxis = customXAxis;
            _xAxisType = xAxisType;
            this.token = token;
            if (File.Exists(fileName))
            {
                using StreamReader file = new StreamReader(FileName);
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
            foreach (string seriesName in headers.Skip(CustomXAxis ? 1 : 0))
            {
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
                if (CustomXAxis)
                {
                    switch (_xAxisType)
                    {
                        case AnalogyCustomXAxisPlot.Numerical:
                            var x = double.Parse(items[0]);
                            for (int i = 1; i < items.Length; i++)
                            {
                                var str = items[i];
                                double val = double.Parse(str);
                                string series = headers[i];
                                var data = new AnalogyPlottingPointData(series, val, x);
                                OnNewPointData?.Invoke(this, data);
                            }
                            break;
                        case AnalogyCustomXAxisPlot.DateTimeUnixMillisecond:
                            DateTime timeMili = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(items[0])).DateTime;
                            for (int i = 1; i < items.Length; i++)
                            {
                                var str = items[i];
                                double val = double.Parse(str);
                                string series = headers[i];
                                var data = new AnalogyPlottingPointData(series, val, timeMili);
                                OnNewPointData?.Invoke(this, data);
                            }
                            break;
                        case AnalogyCustomXAxisPlot.DateTimeUnixSecond:
                            DateTime timeSecond = DateTimeOffset.FromUnixTimeSeconds(long.Parse(items[0])).DateTime;
                            for (int i = 1; i < items.Length; i++)
                            {
                                var str = items[i];
                                double val = double.Parse(str);
                                string series = headers[i];
                                var data = new AnalogyPlottingPointData(series, val, timeSecond);
                                OnNewPointData?.Invoke(this, data);
                            }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
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
                AnalogyLogManager.Instance.LogError(e.ToString(), nameof(AnalogyFilePlotting));
            }

        }

        public Task StopPlotting()
        {
            return Task.CompletedTask;
        }

    }
}
