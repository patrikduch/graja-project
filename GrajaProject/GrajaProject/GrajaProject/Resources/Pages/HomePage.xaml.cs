using GrajaProjekt.Resources.Pages.LLParsers.Arithmetic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrajaProject.Resources.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Navigation redirect to arithmetic parser page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new ArithmeticParserPage());
        }

        /// <summary>
        /// Disable mobile back button functionality
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
}