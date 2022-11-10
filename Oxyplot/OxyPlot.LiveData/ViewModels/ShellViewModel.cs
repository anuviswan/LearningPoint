using Caliburn.Micro;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.Wpf;
using System;
using System.Linq;
using System.Windows.Threading;
using DateTimeAxis = OxyPlot.Axes.DateTimeAxis;
using LinearAxis = OxyPlot.Axes.LinearAxis;
using LineSeries = OxyPlot.Series.LineSeries;

namespace OxyPlot.LiveData.ViewModels;

public class ShellViewModel:Screen
{
    private const int MaxSecondsToShow = 20;
    private DispatcherTimer? _timer;
    private Random _randomGenerator;
    public BindableCollection<SensorData> SensorData { get; set; }
    public PlotModel SensorPlotModel { get; set; }

    public ShellViewModel()
    {
        InitializePlotModel();
        _randomGenerator = new Random();
        SensorData = new BindableCollection<SensorData>();
        SensorData.CollectionChanged += SensorData_CollectionChanged;
    }

    public void InitializePlotModel()
    {
        SensorPlotModel = new() 
        { 
            Title = "Demo Live Tracking",
        };

        SensorPlotModel.Axes.Add(new DateTimeAxis
        {
            Title = "TimeStamp",
            Position = AxisPosition.Bottom,
            StringFormat = "HH:mm:ss",
            IntervalLength = 60,
            Minimum = DateTimeAxis.ToDouble(DateTime.Now),
            Maximum = DateTimeAxis.ToDouble(DateTime.Now.AddSeconds(MaxSecondsToShow)),
            IsPanEnabled = true,
            IsZoomEnabled = true,
            IntervalType = DateTimeIntervalType.Seconds,
            MajorGridlineStyle = LineStyle.Solid,
            MinorGridlineStyle = LineStyle.Solid,
        });

        SensorPlotModel.Axes.Add(new LinearAxis
        {
            Title = "Data Value",
            Position = AxisPosition.Left,
            IsPanEnabled = true,
            IsZoomEnabled = true,
            Minimum = 0,
            Maximum = 1
        });

        SensorPlotModel.Series.Add(new LineSeries()
        {
            MarkerType = MarkerType.Circle,
        });
    }

    private void SensorData_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems is null) return;

        var series = SensorPlotModel.Series.OfType<LineSeries>().First();

        var dateTimeAxis = SensorPlotModel.Axes.OfType<DateTimeAxis>().First();

        if (!series.Points.Any())
        {
            dateTimeAxis.Minimum = DateTimeAxis.ToDouble(DateTime.Now);
            dateTimeAxis.Maximum = DateTimeAxis.ToDouble(DateTime.Now.AddSeconds(MaxSecondsToShow));
        }

        foreach (var newItem in e.NewItems)
        {
            if(newItem is SensorData sensorData)
            {
                series.Points.Add(new DataPoint(DateTimeAxis.ToDouble(sensorData.TimeStamp), sensorData.Data));
            }
        }



        // if (series.Points.Last().X > dateTimeAxis.Maximum)
        if (DateTimeAxis.ToDateTime(series.Points.Last().X) > DateTimeAxis.ToDateTime(dateTimeAxis.Maximum))
        {
            dateTimeAxis.Minimum = DateTimeAxis.ToDouble(DateTime.Now.AddSeconds(-1 * MaxSecondsToShow));
            dateTimeAxis.Maximum = DateTimeAxis.ToDouble(DateTime.Now);
            dateTimeAxis.Reset();
        }

        SensorPlotModel.InvalidatePlot(true);

        NotifyOfPropertyChange(nameof(SensorPlotModel));
    }

    public bool CanStartAcquisition => _timer?.IsEnabled != true;
    public void StartAcquisition()
    {
        if(_timer is null)
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromMilliseconds(500),
            };

            _timer.Tick += MockSensorRecievedData;
        }
        
        _timer.Start();
        NotifyOfPropertyChange(nameof(CanStartAcquisition));
        NotifyOfPropertyChange(nameof(CanStopAcquisition));

    }

    private void MockSensorRecievedData(object? sender, EventArgs e)
    {
        SensorData.Add(new()
        {
            TimeStamp = DateTime.Now,
            Data = _randomGenerator.NextDouble()
        });

    }

    public bool CanStopAcquisition => _timer?.IsEnabled == true;
    public void StopAcquisition()
    {
        _timer?.Stop();
        NotifyOfPropertyChange(nameof(CanStartAcquisition));
        NotifyOfPropertyChange(nameof(CanStopAcquisition));
    }
}


public class SensorData
{
    public DateTime TimeStamp { get; set; }
    public double Data { get; set; }
}
