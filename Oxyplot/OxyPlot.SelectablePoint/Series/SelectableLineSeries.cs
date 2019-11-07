using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OxyPlot.SelectablePoint.Series
{
    public class SelectableLineSeries:LineSeries
    {
        public bool IsDataPointSelectable { get; set; }
        public SelectableLineSeries()
        {
            MouseDown += SelectableLineSeries_MouseDown;
        }

        private void SelectableLineSeries_MouseDown(object sender, OxyMouseDownEventArgs e)
        {
            if (IsDataPointSelectable)
            {

            }
        }
    }
}
