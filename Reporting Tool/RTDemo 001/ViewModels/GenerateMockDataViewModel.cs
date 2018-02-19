using Caliburn.Micro;
using RTDemo_001.Contracts;
using RTDemo_001.Models;
using RTDemo_001.Utils;
using System.ComponentModel.Composition;

namespace RTDemo_001.ViewModels
{
    [Export(typeof(IDataViewModel))]
    public class GenerateMockDataViewModel :Screen, IDataViewModel
    {
        #region Private Variables
        private readonly IEventAggregator _eventAggregator;
        #endregion



        #region Constructor
        [ImportingConstructor]
        public GenerateMockDataViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);

        }
        #endregion

        #region IData
        public void CreateMockData()
        {
            var result = new MockData().Load();
            Message = "Data Generated Succesfully";
            
            _eventAggregator.PublishOnUIThread(new DataEventModel(result));
        }

        public void LoadFromXml()
        {
            var ofd = new Microsoft.Win32.OpenFileDialog() { Filter = "Xml Data Files (*.xml)|*.xml" };
            if (ofd.ShowDialog() == true)
            {
                IDataGeneration data = new XmlData();
                var result = data.Load(ofd.FileName);
                Message = "Data loaded from Xml";
                _eventAggregator.PublishOnUIThread(new DataEventModel(result));
            }
            
        } 
        #endregion

        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                NotifyOfPropertyChange(nameof(Message));
            }
        }

    }
}
