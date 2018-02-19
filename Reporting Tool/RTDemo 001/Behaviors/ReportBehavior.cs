using Stimulsoft.Report.WpfDesign;
using System.Windows;
using System.Windows.Interactivity;

namespace RTDemo_001.Behaviors
{
    public class ReportBehavior : Behavior<StiWpfDesignerControl>
    {
        public static readonly DependencyProperty ReportSourceProperty = DependencyProperty.RegisterAttached("ReportSource", typeof(object), typeof(ReportBehavior), new PropertyMetadata(ReportSourceChanged));

        private static void ReportSourceChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs propertyChangedEvent)
        {
            if (dependencyObject is StiWpfDesignerControl stidesigner)
            {
                stidesigner.Report = propertyChangedEvent.NewValue as Stimulsoft.Report.StiReport;
            }
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
