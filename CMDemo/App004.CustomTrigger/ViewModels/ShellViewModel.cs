using Caliburn.Micro;

namespace App004.CustomTrigger.ViewModels
{
    public class ShellViewModel:Screen
    {
        public ShellViewModel() => Count = 0;
        public int Count { get; set; }
        public void Increment()
        {
            Count++;
            NotifyOfPropertyChange(nameof(Count));
        }
    }

    
}
