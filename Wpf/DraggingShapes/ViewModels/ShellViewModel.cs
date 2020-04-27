using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DraggingShapes.ViewModels
{
    public class ShellViewModel:PropertyChangedBase
    {
        public double Left { get; set; } = 10;
        public double Top { get; set; } = 10;

        public bool IsShapeCaptured { get; set; }

        public void MouseDown()
        {
            IsShapeCaptured = true;
            NotifyOfPropertyChange(nameof(IsShapeCaptured));
        }

        public void MouseMove()
        {
            if (!IsShapeCaptured) return;
            NotifyOfPropertyChange(nameof(Left));
            NotifyOfPropertyChange(nameof(Top));
        }

        public void MouseUp()
        {
            IsShapeCaptured = false;
            NotifyOfPropertyChange(nameof(IsShapeCaptured));
        }

        public void DoNothing() { }
    }
}
