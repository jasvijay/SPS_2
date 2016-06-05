using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SPS_2
{
    class EndShift : ContentPage
    {
        Label time;
        string[] length=new string[1];
        private static DateTime endtime;
        private Button endshift = null;
        private static DateTime start;
        private static TimeSpan ts1;
        StackLayout layout = new StackLayout();
        public EndShift(DateTime starttime)
        {
            start = starttime;
            Title = "End Shift";            
            Icon = "Settings.png";
            endshift = new Button { Text = "End Shift" };
            endshift.Clicked += shiftend;
            time = new Label { Text = string.Format("Shift Length {0}Hrs {1}Min", ts1.Hours, ts1.Minutes), };
            layout = new StackLayout
            {
                Spacing = 20,
                VerticalOptions = LayoutOptions.Start,
                Children =
                {
                    new Label
                    {
                        FontSize=Device.GetNamedSize(NamedSize.Large,typeof(Label)),
                        Text ="End Shift",
                        HorizontalOptions =LayoutOptions.Center
                    },
                    time,
                    new StackLayout
                    {
                        Padding =new Thickness (50),
                        Children =
                        {
                            endshift,
                        }
                    }
                }
            };
            Content = layout;
                updatetime();

        }
        private async void updatetime()
        {
            while (true)
            {
                await Task.Delay(60000);
                ts1 = DateTime.Now - start;
                time.Text = string.Format("Shift Length {0}Hrs {1}Min", ts1.Hours, ts1.Minutes);
                Content = layout;
            }
           
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
