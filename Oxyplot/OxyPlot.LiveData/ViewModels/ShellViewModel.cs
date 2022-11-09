using Caliburn.Micro;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using System;
using System.Linq;
using System.Windows.Threading;

namespace OxyPlot.LiveData.ViewModels;

public class ShellViewModel:Screen
{
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
        });

        SensorPlotModel.Axes.Add(new LinearAxis
        {
            Title = "Data Value",
            Position = AxisPosition.Left
        });

        SensorPlotModel.Series.Add(new LineSeries
        {
            DataFieldX = "X",
            DataFieldY = "Y"
        });
    }

    private void SensorData_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        if (e.NewItems is null) return;

        var series = SensorPlotModel.Series.OfType<LineSeries>().First();
        foreach (var newItem in e.NewItems)
        {
            if(newItem is SensorData sensorData)
            {
                series.Points.Add(new DataPoint(sensorData.Data, DateTimeAxis.ToDouble(sensorData.TimeStamp)));
            }
        }

        NotifyOfPropertyChange(nameof(SensorPlotModel));
    }

    public bool CanStartAcquisition => _timer?.IsEnabled != true;
    public void StartAcquisition()
    {
        if(_timer is null)
        {
            _timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 3),
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
