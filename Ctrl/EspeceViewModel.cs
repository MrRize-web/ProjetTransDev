using System;
using ProjetTransDev.ORM;
using System.ComponentModel;

namespace ProjetTransDev.Ctrl
{
    public class EspeceViewModel : INotifyPropertyChanged
    {
        private int idEspece;
        private string nomEspece;
        //private string concat;

        public EspeceViewModel() { }

        public EspeceViewModel(int id, string nom)
        {
            this.idEspece = id;
            this.nomEspeceProperty = nom;
        }
        public int idEspeceProperty
        {
            get { return idEspece; }
        }

        public String nomEspeceProperty
        {
            get { return nomEspece; }
            set
            {
                nomEspece = value.ToUpper();
                OnPropertyChanged("nomEspeceProperty");
            }

        }
      
        public String concatProperty
        {
            get { return ""; }
            set
            {
                //     this.concat = "Ajouter " + value;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EspeceORM.updateEspece(this);
            }
        }
    }
}
