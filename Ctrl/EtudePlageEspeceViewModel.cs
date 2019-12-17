using ProjetTransDev.Ctrl;
using ProjetTransDev.ORM;
using System;
using System.ComponentModel;

namespace ProjetTransDev
{
    public class EtudePlageEspeceViewModel : INotifyPropertyChanged
    {
        public EtudeViewModel IdEtude;
        public PlageViewModel IdPlage;
        public EspeceViewModel IdEspece;
        public EtudePlageViewModel IdZone;
        private Decimal Nombre;
        private int IdNombreE;
        public EtudePlageEspeceViewModel() { }

        public EtudePlageEspeceViewModel(int IdNombreE, EtudePlageViewModel IdZone, EspeceViewModel idEspece, PlageViewModel idPlage, EtudeViewModel idEtude, Decimal Nombre )
        {
            this.IdNombreE = IdNombreE;
            this.IdZone = IdZone;
            this.IdEtude = idEtude;
            this.IdPlage = idPlage;
            this.IdEspece = idEspece;
            this.Nombre = Nombre;
        }
        public int IdNombreEProperty
        {
            get { return IdNombreE; }
            set
            {
                IdNombreE = value;
                OnPropertyChanged("IdNombreEProperty");
            }
        }
        public EtudePlageViewModel IdZoneProperty
        {
            get { return IdZone; }
        }
        public EtudeViewModel EtudeProperty
        {
            get { return IdEtude; }
        }
        public String EtudeNameProperty
        {
            get { return IdEtude.TitreEtudeProperty; }
        }
        public PlageViewModel PlageProperty
        {
            get { return IdPlage; }
        }
        public String PlageNameProperty
        {
            get { return IdPlage.nomPlageProperty; }
        }
        public EspeceViewModel EspeceProperty
        {
            get { return IdEspece; }
        }
        public String EspeceNameProperty
        {
            get { return IdEspece.nomEspeceProperty; }
        }

        public Decimal NombreProperty
        {
            get { return Nombre; }
            set
            {
                Nombre = value;
                OnPropertyChanged("NombreProperty");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EtudePlageEspeceORM.updateEtudePlageEspece(this);
            }
        }
    }
}