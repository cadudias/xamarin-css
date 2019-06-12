using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace FiapCoin.Model
{
    public class PerfilModel : INotifyPropertyChanged
    {

        private int idPerfil;

        [PrimaryKey]
        public int IdPerfil
        {
            get { return idPerfil; }
            set
            {
                if (idPerfil != value)
                {
                    idPerfil = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String nomePerfil;
        public String NomePerfil
        {
            get { return nomePerfil; }
            set
            {
                if (nomePerfil != value)
                {
                    nomePerfil = value;
                    NotifyPropertyChanged();
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public PerfilModel()
        {
        }

        public PerfilModel(int Id, String Nome)
        {
            this.IdPerfil = Id;
            this.NomePerfil = Nome;
        }



    }
}
