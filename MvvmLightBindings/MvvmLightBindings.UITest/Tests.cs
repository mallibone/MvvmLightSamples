using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;

namespace MvvmLightBindings.UITest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Repl();
        }

        [Test]
        public void EnterAndSubmitText_ItAppearsInTheSubmittedTextLabel()
        {
            app.EnterText(q => q.Marked("InputMessageEntry"), "Hello from Xamarin Test Cloud");
            app.Screenshot("Has entered text");
            app.Tap(q => q.Marked("SubmitMessageButton"));
            app.Screenshot("Has taped the submit button.");
            Assert.IsFalse(string.IsNullOrEmpty(app.Query(q => q.Marked("SubmittedMessageLabel")).First().Text));
        }
    }
}

