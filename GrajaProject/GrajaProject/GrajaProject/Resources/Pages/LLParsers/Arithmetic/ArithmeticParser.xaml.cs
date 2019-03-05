namespace GrajaProjekt.Resources.Pages.LLParsers.Arithmetic
{
    using global::LLParsers.Arithmetic.Lexer;
    using LLParser;
    using LLParser.Lexer;
    using System;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;


    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ArithmeticParser : ContentPage
	{

        private Analyze analyze;
        private Parser parser;

		public ArithmeticParser ()
		{
			InitializeComponent ();
        }
        


        private void Button_EnterInput_Event(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            this.input.Text += button.Text;


        }

        private bool testicek ()
        {

            var res = PolishNotation.PostFixFormat(this.input.Text);
            var result = PolishNotation.IsParseable(res);


            return result;
        }


        private async void Entry_InputChanged_Event(object sender, EventArgs e)
        {
            Entry entry = (Entry)sender;


            try
            {
                analyze = new Analyze(entry.Text);


                var test = await Task.Factory.StartNew<bool>(testicek);

                if (test)
                {

                    entry.BackgroundColor = Color.Green;

                }
                else
                {
                    entry.BackgroundColor = Color.Red;

                }

            } catch (Exception ex)
            {
                entry.BackgroundColor = Color.Red;
            }

           

        }


    }
}
