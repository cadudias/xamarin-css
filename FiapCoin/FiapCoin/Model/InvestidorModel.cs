using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace FiapCoin.Model
{
    public class InvestidorModel : INotifyPropertyChanged
    {
        [ForeignKey(typeof(PerfilModel))]
        public int IdPerfil
        {
            get; set;
        }

        private PerfilModel perfilInvestidor;
        [OneToOne(foreignKey: "IdPerfil")]
        public PerfilModel PerfilInvestidor
        {
            get { return perfilInvestidor; }
            set
            {
                if (perfilInvestidor != value)
                {
                    perfilInvestidor = value;
                    NotifyPropertyChanged();
                }
            }
        }



        private int idUsuario;

        [PrimaryKey]
        public int IdUsuario
        {
            get { return idUsuario; }
            set
            {
                if (idUsuario != value)
                {
                    idUsuario = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String nomeInvestidor;
        public String NomeInvestidor
        {
            get { return nomeInvestidor; }
            set
            {
                if (nomeInvestidor != value)
                {
                    nomeInvestidor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private String emailInvestidor;
        public String EmailInvestidor
        {
            get { return emailInvestidor; }
            set
            {
                if (emailInvestidor != value)
                {
                    emailInvestidor = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private String telefoneInvestidor;
        public String TelefoneInvestidor
        {
            get { return telefoneInvestidor; }
            set
            {
                if (telefoneInvestidor != value)
                {
                    telefoneInvestidor = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private double valorPatrimonioInvestidor;
        public double ValorPatrimonioInvestidor
        {
            get { return valorPatrimonioInvestidor; }
            set
            {
                if (valorPatrimonioInvestidor != value)
                {
                    valorPatrimonioInvestidor = value;
                    NotifyPropertyChanged();
                }
            }
        }





        public InvestidorModel()
        {
        }

        public InvestidorModel(int _id)
        {
            this.IdUsuario = _id;
        }

        public InvestidorModel(int Id, String Nome, String Email, String Fone, double Valor, PerfilModel Perfil)
        {
            this.IdUsuario = Id;
            this.NomeInvestidor = Nome;
            this.EmailInvestidor = Email;
            this.TelefoneInvestidor = Fone;
            this.ValorPatrimonioInvestidor = Valor;
            this.PerfilInvestidor = Perfil;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
