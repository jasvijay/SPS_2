using Xamarin.Forms;

namespace SPS_2
{
    public class Jobs :ContentPage
    {
        ListView listview;
        static string zone;
        public Jobs(string zoneid)
        {
            Title = "Jobs";
            zone = zoneid;
            listview = new ListView();
            listview.ItemTemplate = new DataTemplate(typeof(JobItem));            
            listview.ItemSelected += (sender, e) =>
            {
                var jobitem = (Jobcell)e.SelectedItem;
                var jobpage = new JobPage();
                jobpage.BindingContext = jobitem;
                Navigation.PushAsync(jobpage);

            };
            var label = new Label { Text="Something"};
            var layout = new StackLayout();
            layout.Children.Add(listview);
            layout.Children.Add(label);
            layout.VerticalOptions = LayoutOptions.FillAndExpand;
            Content = layout;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listview.ItemsSource = App.Database.GetItems(zone);
        }
    }
}