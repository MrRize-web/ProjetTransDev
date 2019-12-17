using System;
using ProjetTransDev.ORM;
using System.ComponentModel;
namespace ProjetTransDev.Ctrl
{
    public class EtudeViewModel : INotifyPropertyChanged
    {
        private int idEtude;
        private decimal NbPersonne;
        private string Titre;
        public DateTime date_creation;
        public DateTime date_fin;
        public PlageViewModel PlageEtude;

        public EtudeViewModel() { }

        public EtudeViewModel(int id, decimal NbPersonne,  string Titre, PlageViewModel PlageEtude, DateTime date_creation, DateTime date_fin)
        {
            this.idEtude = id;
            this.NbPersonneEtudeProperty = NbPersonne;
            this.PlageEtude = PlageEtude;
            this.TitreEtudeProperty = Titre;
            this.date_creation = date_creation;
            this.date_fin = date_fin;
        }
        public int idEtudeProperty
        {
            get { return idEtude; }
        }
        public DateTime dateCreationProperty
        {

            get { return date_creation; }
            set
            {
                date_creation = value;
            }
        }

        public DateTime dateFinProperty
        {
            get { return date_fin; }
            set
            {
                date_fin = value;
            }
        }

        public Decimal NbPersonneEtudeProperty
        {
            get { return NbPersonne; }
            set
            {
                NbPersonne = value;
                OnPropertyChanged("NbPersonneEtudeProperty");
            }

        }
        public PlageViewModel PlageEtudeProperty
        {
            get { return PlageEtude; }
        }
        public String PlageEtudeNameProperty
        {
            get { return PlageEtude.nomPlageProperty; }
        }

        public String TitreEtudeProperty
        {
            get { return Titre; }
            set
            {
                this.Titre = value;
                OnPropertyChanged("TitreEtudeProperty");
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EtudeORM.updateEtude(this);
            }
        }

    }
}