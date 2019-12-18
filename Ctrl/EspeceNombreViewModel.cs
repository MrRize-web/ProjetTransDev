using ProjetTransDev.Ctrl;
using ProjetTransDev.ORM;
using System;
using System.ComponentModel;

namespace ProjetTransDev
{
    public class EspeceNombreViewModel : INotifyPropertyChanged
    {
        public EtudeViewModel IdEtude;
        public PlageViewModel IdPlage;
        public EspeceViewModel IdEspece;
        public ZoneInvestigationViewModel IdZone;
        private Decimal Nombre;
        private int IdNombreE;
        public EspeceNombreViewModel() { }

        public EspeceNombreViewModel(int IdNombreE, ZoneInvestigationViewModel IdZone, EspeceViewModel idEspece, PlageViewModel idPlage, EtudeViewModel idEtude, Decimal Nombre )
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
        public ZoneInvestigationViewModel IdZoneProperty
        {
            get { return IdZone; }
            set
            {
                IdZone = value;
                OnPropertyChanged("IdZoneProperty");
            }
        }
        public EtudeViewModel EtudeProperty
        {
            get { return IdEtude; }
            set
            {
                IdEtude = value;
                OnPropertyChanged("EtudeProperty");
            }
        }
        public String EtudeNameProperty
        {
            get { return IdEtude.TitreEtudeProperty; }
        }
        public PlageViewModel PlageProperty
        {
            get { return IdPlage; }
            set
            {
                IdPlage = value;
                OnPropertyChanged("PlageProperty");
            }
        }
        public String PlageNameProperty
        {
            get { return IdPlage.nomPlageProperty; }
        }
        public EspeceViewModel EspeceProperty
        {
            get { return IdEspece; }
            set
            {
                IdEspece = value;
                OnPropertyChanged("EspeceProperty");
            }
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
                EspeceNombreORM.updateEspeceNombre(this);
            }
        }
    }
}