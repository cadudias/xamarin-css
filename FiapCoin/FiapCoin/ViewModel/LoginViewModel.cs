using System.Windows.Input;
using Xamarin.Forms;
using FiapCoin.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FiapCoin.ViewModel
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ICommand EntrarClickedCommand { get; private set; }

        public ICommand ScannerClickedCommand { get; private set; }


        public Usuario _usuario;
        public Usuario Usuario { 
            get {
                return _usuario;
            }
            set {
                _usuario = value;
                NotifyPropertyChanged();
            }
        }



        public LoginViewModel() {

            Usuario = new Usuario();
            Usuario.Email = "admin@fiap.com.br";
            Usuario.Senha = "123456";


            EntrarClickedCommand = new Command(() => {
                App.MensagemAlerta("Logando .... ");
            });


            ScannerClickedCommand = new Command( () =>
            {
                App.MensagemAlerta("Scanning .... ");

            });

        }
    }
}
