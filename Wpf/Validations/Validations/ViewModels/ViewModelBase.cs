using Caliburn.Micro;

namespace Validations.ViewModels
{
    public class ViewModelBase:Screen
    {
        public virtual string Title { get;}
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
    }
}
