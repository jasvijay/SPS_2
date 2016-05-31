using System;
using Xamarin.Forms;

namespace SPS_2
{
    class EndShift : ContentPage
    {
        private static DateTime endtime;
        private Button endshift = null;
        private static DateTime start;
        public EndShift(DateTime starttime)
        {
            start = starttime;
            Title = "End Shift";
            Icon = "Settings.png";
            endshift = new Button { Text = "End Shift" };
            endshift.Clicked += shiftend;
            Label clockLabel = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.StartAndExpand
            };


            Content = new StackLayout
            {
                Spacing = 100,
                VerticalOptions = LayoutOptions.Start,
                Children =
                {
                    new Label
                    {
                        FontSize=Device.GetNamedSize(NamedSize.Large,typeof(Label)),
                        Text ="End Shift",
                        HorizontalOptions =LayoutOptions.Center
                    },
                    new StackLayout
                    {
                        Spacing=20,
                        Children=
                        {
                            endshift,
                        }
                    }
                }
            };

        }
        private async void shiftend(object sender, EventArgs e)
        {
            endtime = DateTime.Now;
            TimeSpan ts = endtime - start;
            await DisplayAlert("Shift End", string.Format("Shift Length {0}Hrs {1}Min", ts.Hours, ts.Minutes), "OK!");
            await Navigation.PushAsync(new StartShift());
        }
    }
}
