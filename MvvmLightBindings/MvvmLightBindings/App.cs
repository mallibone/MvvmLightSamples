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
