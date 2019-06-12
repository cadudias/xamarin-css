using Xamarin.Forms;

namespace FiapCoin
{
    public partial class App : Application
	{
        

		public App ()
		{
			InitializeComponent();

            MainPage = new FiapCoin.Views.LoginPage();

        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        internal static void MensagemAlerta(string texto)
        {
            App.Current.MainPage.DisplayAlert("Título", texto, "Ok");
        }

	}
}
