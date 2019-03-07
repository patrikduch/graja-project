//---------------------------------------------------------------------------------
// <copyright file="ArithmeticParserPage" website="Patrikduch.com">
//     Copyright 2019 (c) Patrikduch.com
// </copyright>
// <author>Patrik Duch</author>
// Code behind for Arithmetic parser page
//--------------------------------------------------------------------------------

using LLParsers.Arithmetic.Parser;

namespace GrajaProjekt.Resources.Pages.LLParsers.Arithmetic
{
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;


    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ArithmeticParserPage : ContentPage
	{

		public ArithmeticParserPage ()
		{
			InitializeComponent ();
        }


        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PopAsync();
        }


        private void Button_EnterInput_Event(object sender, EventArgs e)
        {
            var button = (Button)sender;
            input.Text += button.Text;
        }

        private bool ParserProcess ()
        {
            return PolishNotation.IsParseable(PolishNotation.PostFixFormat(input.Text));
        }


        private async void Entry_InputChanged_Event(object sender, EventArgs e)
        {
            var entry = (Entry)sender;

            try
            {
                bool isParseable;
                isParseable = await Task.Factory.StartNew(ParserProcess);

                entry.BackgroundColor = isParseable ? Color.Green : Color.Red;

            } catch (Exception)
            {
                entry.BackgroundColor = Color.Red;
            }

           

        }


    }
}
