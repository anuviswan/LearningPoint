using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using combit.ListLabel23;
using Caliburn.Micro;
using RTDemo_001.Contracts;
using RTDemo_001.Models;
using RTDemo_001.Utils;

namespace RTDemo_001.ViewModels
{
    [ExportReportDesignerTag(Enums.EReportingTool.ListAndLabel)]
    public class LLReportDesignerViewModel :Screen, IReportDesignerViewModel
    {
        private ListLabel _listLabel;
        public void RegisterData<T>(IList<T> productCollection)
        {
            throw new NotImplementedException();
        }

        public void Show<T>(bool isModal, IList<T> productCollection)
        {
            List <ProductModel> lllist = productCollection.Cast<ProductModel>().ToList<ProductModel>();
            _listLabel = new ListLabel();
            _listLabel.SetDataBinding(lllist,string.Empty);
            _listLabel.AutoProjectType = LlProject.FileAlsoNew | LlProject.List;
            _listLabel.Design();
        }
    }
}
