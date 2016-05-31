using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Text;
using System.Threading.Tasks;

namespace SPS_2
{
    class Loginpage : ContentPage
    {
        private Entry username = null;
        private Entry password = null;
        private Button loginbutton = null;
        public Loginpage()
        {
            Title = "Officer Login";
            Padding = new Thickness(50);
            username = new Entry { Placeholder = "User Name" };
            password = new Entry { Placeholder = "Password", IsPassword = true };
            loginbutton = new Button { Text = "Login" };
            loginbutton.Clicked += login;
            Content = new StackLayout
            {
                Spacing = 100,
                VerticalOptions = LayoutOptions.Start,
                Children =
                {

                   new Label
                   {
                       FontSize=Device.GetNamedSize(NamedSize.Large,typeof(Label)),
                       Text ="Officer Login",
                       HorizontalOptions =LayoutOptions.Center
                   },
                    new StackLayout
                    {
                        Spacing = 20,
                        VerticalOptions =LayoutOptions.Center,
                        Children =
                        {
                            username,
                            password,
                            loginbutton,
                        }
                    }
                }
            };
        }
        private bool authenticate(string UserName, string Password)
        {
            return (UserName == "user" && Password == "password");
        }
        private async void login(object sender, EventArgs e)
        {
            bool authenticated = authenticate(username.Text, password.Text);
            if (!authenticated)
            {
                if (username.Text == "user")
                {
                    await DisplayAlert("Login", "Invalid Password", "OK");
                }
                else
                {
                    await DisplayAlert("Login", "Invalid User Name", "OK");
                }
            }
            else
            {
                await Navigation.PushAsync(new StartShift());
            }
        }
    }
}
