
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GrajaProject
{
    using GrajaProjekt.Resources.Pages.LLParsers.Arithmetic;
    using Xamarin.Forms;

    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ArithmeticParser();
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
