using Caliburn.Micro;
using OxyPlot;
using System;
using System.Windows.Threading;

namespace OxyPlot.LiveData.ViewModels;

public class ShellViewModel:Screen
{
    private DispatcherTimer? _timer;
    private Random _randomGenerator;
    public BindableCollection<SensorData> SensorData { get; set; } = new BindableCollection<SensorData>();
    public PlotModel SensorPlotModel { get; set; }

    public ShellViewModel()
    {
        SensorPlotModel = new PlotModel();
        _randomGenerator = new Random();
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
