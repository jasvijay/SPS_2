using Xamarin.Forms;

namespace SPS_2
{
    public class JobPage : ContentPage
    {
        public JobPage()
        {
            this.SetBinding(ContentPage.TitleProperty, "Name");
            var nameLabel = new Label { Text = "Name" };
            //var nameEntry = new Entry();
            //nameEntry.SetBinding(Entry.TextProperty, "Name");
            var notesLabel = new Label { Text = "Jobs" };
            var notesEntry = new Entry();
            notesEntry.SetBinding(Entry.TextProperty, "Jobs");
            var doneLabel = new Label { Text = "Done" };
            var doneEntry = new Switch();
            doneEntry.SetBinding(Switch.IsToggledProperty, "Done");
            var saveButton = new Button { Text = "Save" };
            saveButton.Clicked += (sender, e) =>
            {
                var jobitem = (Jobcell)BindingContext;
                App.Database.SaveItem(jobitem);
                this.Navigation.PopAsync();
            };

        }
    }
}