using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FiapCoin.Model
{
    public class Usuario : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int idUsuario;
        public int IdUsuario { 
            get { return idUsuario; }
            set {
                if (idUsuario != value) {
                    idUsuario = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String email;
        public String Email { 
            get { return email; }
            set
            {
                if (email != value)
                {
                    email = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private String senha;
        public String Senha { 
            get { return senha; }
            set
            {
                if (senha != value)
                {
                    senha = value;
                    NotifyPropertyChanged();
                }
            }
  
        }


        public Usuario()
        {

        }

        public Usuario(string _email, string _senha)
        {
            this.Email = _email;
            this.Senha = _senha;
        }

    }
}
