using System.Windows;

namespace RTDemo_001.Behaviors
{
    public class RdlcSourceBehavior
    {
        public static readonly DependencyProperty ReportSourceProperty = DependencyProperty.RegisterAttached("RDLCSource", typeof(object), typeof(object), new PropertyMetadata(RdlcSourceChanged));

        private static void RdlcSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
        }
    }
}
