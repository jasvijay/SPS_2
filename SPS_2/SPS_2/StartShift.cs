using Xamarin.Forms;
using System;

namespace SPS_2
{
    class StartShift : ContentPage
    {
        private Entry location = new Entry { Text = "Brisbane" };
        private Entry ZoneID = null;
        private Button ShiftStart = null;
        private static string location_s, zoneid;
        private static DateTime starttime;
        public StartShift()
        {
            Title = "Shift Start";
            NavigationPage.SetHasBackButton(this, false);
            Padding = new Thickness(50);
            location = new Entry { Placeholder = "Brisbane" };
            ZoneID = new Entry { Placeholder = "Zone ID" };
            ShiftStart = new Button { Text = "Start Shift" };
            location_s = location.Text;
            zoneid = ZoneID.Text;
            ShiftStart.Clicked += Start_shift;
            Content = new StackLayout
            {
                Spacing = 100,
                VerticalOptions = LayoutOptions.Start,
                Children =
                {
                   new Label {
                       FontSize=Device.GetNamedSize(NamedSize.Large,typeof(Label)),
                       Text ="Shift Start",
                       HorizontalOptions =LayoutOptions.Center
                   },
                   new StackLayout
                   {
                       Spacing=20,
                       Children=
                       {
                           location,
                           ZoneID,
                           ShiftStart
                       }
                   }
                }
            };
        }
        private async void Start_shift(object sender, EventArgs e)
        {
            starttime = DateTime.Now;
            await Navigation.PushAsync(new Tabs(location_s, zoneid, starttime));
        }
    }
}
