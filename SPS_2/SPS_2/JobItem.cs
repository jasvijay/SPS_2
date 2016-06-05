using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace SPS_2
{
    class JobItem :ViewCell
    {
        public JobItem()
        {
            var label = new Label
            {
                VerticalTextAlignment=TextAlignment.Center
            };
            label.SetBinding(Label.TextProperty, "Name");
            var tick = new Image
            {
                Source = FileImageSource.FromFile("check.png")
            };
            tick.SetBinding(Image.IsVisibleProperty, "Done");
            var layout = new StackLayout
            {
                Padding = new Thickness(20),
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children =
                {
                    label,
                    tick,
                }
            };
            View = layout;
        }
    }
}
