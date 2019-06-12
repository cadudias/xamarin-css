using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace FiapCoin.Model
{
    public class MoedaModel : INotifyPropertyChanged
    {
        public MoedaModel()
        {

        }

        public MoedaModel(int _id, String _nome, double _valor, double _percentual )
        {
            this.IdMoeda = _id;
            this.NomeMoeda = _nome;
            this.Saldo = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", _valor);// string.Format("{0:0,0.00}", _valor);
            this.PercentualCarteira = _percentual.ToString() + "%";
        }


        private int idMoeda;
        public int IdMoeda
        {
            get { return idMoeda; }
            set
            {
                if (idMoeda != value)
                {
                    idMoeda = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private String nomeMoeda;
        public String NomeMoeda
        {
            get { return nomeMoeda; }
            set
            {
                if (nomeMoeda != value)
                {
                    nomeMoeda = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private string saldo;
        public string Saldo
        {
            get { return saldo; }
            set
            {
                if (saldo != value)
                {
                    saldo = value;
                    NotifyPropertyChanged();
                }
            }
        }


        private string percentualCarteira;
        public string PercentualCarteira
        {
            get { return percentualCarteira; }
            set
            {
                if (percentualCarteira != value)
                {
                    percentualCarteira = value;
                    NotifyPropertyChanged();
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
