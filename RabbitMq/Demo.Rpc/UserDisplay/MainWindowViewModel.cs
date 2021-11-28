using System.Collections.Generic;

namespace UserDisplay
{
    internal class MainWindowViewModel
    {
        public IEnumerable<string> UserNames { get; set; }

        public int Count { get; set; } = 15;
    }
}
