using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Validations.ViewModels
{
    public  class ShellViewModel:Conductor<object>
    {
        public List<ViewModelBase> ViewModels => this.GetType().Assembly.GetTypes()
                                                .Where(x => x.IsSubclassOf(typeof(ViewModelBase)))
                                                .Select(x=> (ViewModelBase)Activator.CreateInstance(x,null))
                                                .ToList();
        public void ShowViewModel(object item)
        {
            ChangeActiveItem(item,true);
        }
    }
}
