using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace COVID
{
    public class GradientView : ContentView
    {
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
               nameof(StartColor),
               typeof(Color),
               typeof(GradientView),
               defaultBindingMode: BindingMode.OneWay,
               defaultValue: default(Color));

        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }

        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
               nameof(EndColor),
               typeof(Color),
               typeof(GradientView),
               defaultBindingMode: BindingMode.OneWay,
               defaultValue: default(Color));

        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty); }
            set { SetValue(EndColorProperty, value); }
        }

        public static readonly BindableProperty OrientationProperty = BindableProperty.Create(
               nameof(Orientation),
               typeof(StackOrientation),
               typeof(GradientView),
               defaultBindingMode: BindingMode.OneWay,
               defaultValue: StackOrientation.Horizontal);

        public StackOrientation Orientation
        {
            get { return (StackOrientation)GetValue(OrientationProperty); }
            set { SetValue(OrientationProperty, value); }
        }
    }
}