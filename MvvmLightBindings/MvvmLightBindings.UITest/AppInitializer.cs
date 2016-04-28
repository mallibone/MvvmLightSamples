using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace MvvmLightBindings.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                    .Android
                    .Debug()
                    .StartApp(Xamarin.UITest.Configuration.AppDataMode.Clear);
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

