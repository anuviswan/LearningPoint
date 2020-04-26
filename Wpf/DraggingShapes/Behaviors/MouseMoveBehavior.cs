using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace DraggingShapes.Behaviors
{
    public class MouseMoveBehavior:Behavior<Canvas>
    {
        public double MouseTop
        {
            get { return (double)GetValue(MouseTopProperty); }
            set { SetValue(MouseTopProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MouseTop.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseTopProperty =
            DependencyProperty.Register("MouseTop", typeof(double), typeof(MouseMoveBehavior), new PropertyMetadata(0d));


        public double MouseLeft
        {
            get { return (double)GetValue(MouseLeftProperty); }
            set { SetValue(MouseLeftProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MouseLeft.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MouseLeftProperty =
            DependencyProperty.Register("MouseLeft", typeof(double), typeof(MouseMoveBehavior), new PropertyMetadata(0d));


        protected override void OnAttached()
        {
            AssociatedObject.MouseMove += AssociatedObject_MouseMove;
        }

        private void AssociatedObject_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var currentPosition = e.GetPosition(AssociatedObject);
            MouseLeft = currentPosition.X;
            MouseTop = currentPosition.Y;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.MouseMove -= AssociatedObject_MouseMove;
        }
    }
}
