﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ValueCoercion.Controls
{
    /// <summary>
    /// Interaction logic for Configuration.xaml
    /// </summary>
    public partial class Configuration : UserControl
    {
        public Configuration()
        {
            InitializeComponent();
        }

        public int MinimumValue
        {
            get { return (int)GetValue(MinimumValueProperty); }
            set { SetValue(MinimumValueProperty, value); }
        }

        public static readonly DependencyProperty MinimumValueProperty = 
            DependencyProperty.Register(nameof(MinimumValue), typeof(int), typeof(Configuration), new PropertyMetadata(0, new PropertyChangedCallback(OnMinimumValueChanged)));

        private static void OnMinimumValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if(d is Configuration config)
            {
                config.CoerceValue(MaximumValueProperty);
            }
        }

        public int MaximumValue
        {
            get { return (int)GetValue(MaximumValueProperty); }
            set { SetValue(MaximumValueProperty, value); }
        }

        public static readonly DependencyProperty MaximumValueProperty =
            DependencyProperty.Register(nameof(MaximumValue), typeof(int), typeof(Configuration), new PropertyMetadata(0,null,new CoerceValueCallback(OnMaximumCoerce)));

        private static object OnMaximumCoerce(DependencyObject d, object baseValue)
        {
            if(d is Configuration config && baseValue is int newValue)
            {
                var minValue = config.MinimumValue;
                return newValue > minValue ? newValue : minValue;
            }
            return baseValue;
        }
    }
}
