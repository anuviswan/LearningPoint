using System;
using Caliburn.Micro;

namespace FodyUnusualBehavior.ViewModels
{
    public class ShellViewModel:Screen
    {
        private Random _random;

        public ShellViewModel()
        {
            _random = new Random();
            //PropertyChanged += HandlePropertyChanged;
            PropertyChanged += OnPropertyChanged;
        }

        //private void HandlePropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Do something here
        }

        public long RandomNumber { get; set; }

        public void Randomize()
        {
            RandomNumber = _random.Next();
        }
    }
}
