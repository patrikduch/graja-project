//---------------------------------------------------------------------------------
// <copyright file="App" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
// Main entry to the application
//--------------------------------------------------------------------------------


using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GrajaProject
{
    using Resources.Pages;
    using Xamarin.Forms;

    /// <summary>
    /// Main entry to the application
    /// </summary>
    public partial class App : Application
    {
        #region Constructors

        /// <summary>
        /// Main constructor of application
        /// </summary>
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage()
            {
                BackgroundColor = Color.White
            })
            {
                BarBackgroundColor = Color.FromHex("#20c997")
            };
        }

        #endregion

        #region Methods
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
        #endregion
    }
}