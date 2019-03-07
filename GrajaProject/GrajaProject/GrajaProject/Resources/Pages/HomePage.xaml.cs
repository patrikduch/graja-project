//---------------------------------------------------------------------------------
// <copyright file="ParserTests" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
// Home page of application
//--------------------------------------------------------------------------------

namespace GrajaProject.Resources.Pages
{
    using GrajaProjekt.Resources.Pages.LLParsers.Arithmetic;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        #region Constructors
        public HomePage()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
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
        #endregion
    }
}