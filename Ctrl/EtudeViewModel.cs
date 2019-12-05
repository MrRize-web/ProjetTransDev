using System;
using ProjetTransDev.ORM;
using System.ComponentModel;
namespace ProjetTransDev.Ctrl
{
    public class EtudeViewModel : INotifyPropertyChanged
    {
        private int idEtude;
        private decimal NbPersonne;
        private decimal NbPlage;
        private string Titre;


        //private string concat;

        public EtudeViewModel() { }

        public EtudeViewModel(int id, decimal NbPersonne, decimal NbPlage, string Titre)
        {
            this.idEtude = id;
            this.NbPersonneEtudeProperty = NbPersonne;
            this.NbPlageEtudeProperty = NbPlage;
            this.TitreEtudeProperty = Titre;
        }
        public int idEtudeProperty
        {
            get { return idEtude; }
        }


        public Decimal NbPersonneEtudeProperty
        {
            get { return NbPersonne; }
            set
            {
                NbPersonne = value;
                this.concatProperty = this.NbPersonne + " " + value;
                OnPropertyChanged("NbPersonneEtudeProperty");
            }

        }
        public Decimal NbPlageEtudeProperty
        {
            get { return NbPlage; }
            set
            {
                this.NbPlage = value;
                this.concatProperty = this.NbPlage + " " + value;
                OnPropertyChanged("NbPlageEtudeProperty");
            }
        }
        public String TitreEtudeProperty
        {
            get { return Titre; }
            set
            {
                this.Titre = value;
                this.concatProperty = this.Titre + " " + value;

                //this.concatProperty = value.ToUpper() + " " + prenomUsers;
                OnPropertyChanged("TitreEtudeProperty");
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
                UsersORM.updateEtude(this);
            }
        }
    }
}