﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace SPS_2
{
    public class App : Application
    {
        static JobDatabase database;        
        public static JobDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new JobDatabase();
                }
                return database;
            }
        }        
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new StartShift());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
