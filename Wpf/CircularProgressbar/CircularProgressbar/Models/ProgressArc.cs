using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;

namespace CircularProgressbar.Models
{
    public class ProgressArc : PropertyChangedBase
    {
        public Point StartPosition { get; set; } = new Point(50, 0);
        public Point EndPosition { get; set; } = new Point(100, 0);
        public Size Radius { get; set; }
        public double Thickness { get; set; } = 2;
        public double Angle { get; set; }
    }
}
