using Caliburn.Micro;
using RTDemo_001.Contracts;
using RTDemo_001.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;

namespace RTDemo_001.ViewModels
{
    [Export(typeof(IPreviewDataViewModel))]
    public class PreviewDataViewModel : Screen, IPreviewDataViewModel, IHandle<DataEventModel>
    {
        #region Constructor
        [ImportingConstructor]
        public PreviewDataViewModel(IEventAggregator eventAggregator) => eventAggregator.Subscribe(this);
        #endregion

        public ObservableCollection<ProductModel> ProductCollection { get; set; }


        #region IPreviewData
        public void Show(IList<ProductModel> dataCollection)
        {
            ProductCollection = new ObservableCollection<ProductModel>(dataCollection);
            NotifyOfPropertyChange(nameof(dataCollection));
        }
        #endregion

        #region Event Handlers
        public void Handle(DataEventModel message) => Show(message.ProductCollection);

        #endregion
    }
}
