using System;
using Xamarin.Forms;

namespace SPS_2
{
    class Tabs : TabbedPage
    {
        public Tabs(string location, string zoneid, DateTime starttime)
        {
            NavigationPage.SetHasBackButton(this, false);
            this.Children.Add(new Jobs(zoneid) { Title = "Jobs", Icon = "Tasks.png" });
            this.Children.Add(new EndShift(starttime) { Title = "EndShift", Icon = "Schedule.png" });
        }
    }
}
