using Caliburn.Micro;
using CheckListwithEnumFlag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckListwithEnumFlag.ViewModels
{
    public class ShellViewModel:Screen
    {
        public FlaggedDayOfWeek SelectedWeekOfDay { get; set; }
    }
}
