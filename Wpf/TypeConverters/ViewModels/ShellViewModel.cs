using System.Collections.Generic;
using System.ComponentModel;

namespace TypeConverters.ViewModels
{
    public class ShellViewModel
    {
        public string Background { get; set; } = "Red";

        public string[] UserListCollection { get; set; } = new[] { "Anu Viswan", "Jia Anu", "Naina Anu", "Sreena Anu" }; 
        
    }
}
