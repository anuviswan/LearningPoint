using Stimulsoft.Report.WpfDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace Stimulsoft002.Behaviors
{
    public class ReportBehavior : Behavior<StiWpfDesignerControl>
    {
        public static readonly DependencyProperty ReportSourceProperty = DependencyProperty.RegisterAttached("ReportSource", typeof(object), typeof(ReportBehavior), new PropertyMetadata(ReportSourceChanged));

        private static void ReportSourceChanged(DependencyObject DependencyObject, DependencyPropertyChangedEventArgs PropertyChangedEvent)
        {
            var stidesigner = DependencyObject as StiWpfDesignerControl;

            if (stidesigner != null)
                stidesigner.Report = PropertyChangedEvent.NewValue as Stimulsoft.Report.StiReport;
        }

        public static void SetReportSource(DependencyObject target, object value)
        {
            target.SetValue(ReportSourceProperty, value);
        }

        public static object GetReportSource(DependencyObject target)
        {
            return target.GetValue(ReportSourceProperty);
        }
    }
}
