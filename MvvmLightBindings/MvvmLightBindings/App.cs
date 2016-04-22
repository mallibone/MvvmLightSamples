using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MvvmLightBindings.ViewModel;
using MvvmLightBindings.Views;
using Xamarin.Forms;

namespace MvvmLightBindings
{
    public class App : Application
    {
        private readonly static ViewModelLocator _locator = new ViewModelLocator();

        public static ViewModelLocator Locator => _locator;


        public App()
        {
            // The root page of your application
            //MainPage = new ContentPage
            //{
            //    Content = new StackLayout
            //    {
            //        VerticalOptions = LayoutOptions.Center,
            //        Children = {
            //            new Label {
            //                XAlign = TextAlignment.Center,
            //                Text = "Welcome to Xamarin Forms!"
            //            }
            //        }
            //    }
            //};

            MainPage = new MainView();
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
