using ProjetTransDev.Ctrl.ProjetTransDev.Ctrl;
using ProjetTransDev.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTransDev.Ctrl
{
  
        public class ZoneInvestigationViewModel : INotifyPropertyChanged
        {
            private int IdZone;
            private Decimal Angle1;
            private Decimal Angle2;
            private Decimal Angle3;
            private Decimal Angle4;
            public EtudeViewModel Etude;
            public EtudeViewModel EtudeDate;
            public UsersViewModel Users;
            public PlageViewModel Plage;

        public ZoneInvestigationViewModel() { }

            public ZoneInvestigationViewModel(int IdZone, EtudeViewModel Etude, PlageViewModel Plage, UsersViewModel Users, EtudeViewModel EtudeDate, Decimal Angle1, Decimal Angle2, Decimal Angle3, Decimal Angle4)
            {
                this.IdZone = IdZone;
                this.Etude = Etude;
                this.Plage = Plage;
                this.EtudeDate = EtudeDate;
                this.Angle1 = Angle1;
                this.Angle2 = Angle2;
                this.Angle3 = Angle3;
                this.Angle4 = Angle4;
                this.Users = Users;
        }
        public int IdZoneProperty
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
                get { return Etude; }
            set
            {
                Etude = value;
                OnPropertyChanged("EtudeProperty");
            }
        }
        public String EtudeNameProperty
        {
            get { return Etude.TitreEtudeProperty; }
        }
        public DateTime EtudeDateProperty
        {
            get { return Etude.dateCreationProperty; }
            set
            {
                Etude.dateCreationProperty = value;
                OnPropertyChanged("EtudeDateProperty");
            }
        }
        public UsersViewModel UsersProperty
        {
            get { return Users; }
            set
            {
                Users = value;
                OnPropertyChanged("UsersProperty");
            }
        }
        public String UsersNameProperty
        {
            get { return Users.prenomUsersProperty; }
        }


        public PlageViewModel PlageProperty
        {
                get { return Plage; }
            set
            {
                Plage = value;
                OnPropertyChanged("PlageProperty");
            }
        }
            public String PlageNameProperty
        {
                get { return Plage.nomPlageProperty; }
            }
            public Decimal Angle1Property
        {
                get { return Angle1; }
                set
                {
                    Angle1 = value;
                    OnPropertyChanged("Angle1Property");
                }

            }
        public Decimal Angle2Property
        {
            get { return Angle2; }
            set
            {
                Angle2 = value;
                OnPropertyChanged("Angle2Property");
            }

        }
        public Decimal Angle3Property
        {
            get { return Angle3; }
            set
            {
                Angle3 = value;
                OnPropertyChanged("Angle3Property");
            }

        }
        public Decimal Angle4Property
        {
            get { return Angle4; }
            set
            {
                Angle4 = value;
                OnPropertyChanged("Angle4Property");
            }

        }
            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged(string info)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(info));
                   ZoneInvestigationORM.updateEtudePlage(this);
                }
            }
        }
    }

