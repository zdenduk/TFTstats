using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace TFTstats.Support
{
    public class MatchControl : ToggleButton
    {
        static MatchControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MatchControl), new FrameworkPropertyMetadata(typeof(MatchControl)));
        }


        public string Placement
        {
            get
            {
                return (string)GetValue(PlacementProperty);

            }
            set
            {
                SetValue(PlacementProperty, value);
            }
        }

        public static readonly DependencyProperty PlacementProperty =
            DependencyProperty.Register("Placement", typeof(string), typeof(MatchControl));
    }
}
