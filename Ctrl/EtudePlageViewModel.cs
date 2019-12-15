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
  
        public class EtudePlageViewModel : INotifyPropertyChanged
        {
            private string Angle1;
            private string Angle2;
            private string Angle3;
            private string Angle4;
            public EtudeViewModel Etude;
            public EtudeViewModel EtudeDate;
            public UsersViewModel Users;
            public PlageViewModel Plage;

        public EtudePlageViewModel() { }

            public EtudePlageViewModel(EtudeViewModel Etude, PlageViewModel Plage, EtudeViewModel EtudeDate, string Angle1, string Angle2, string Angle3, string Angle4, UsersViewModel Users)
            {
                this.Etude = Etude;
                this.Plage = Plage;
                this.EtudeDate = EtudeDate;
                this.Angle1 = Angle1;
                this.Angle2 = Angle2;
                this.Angle3 = Angle3;
                this.Angle4 = Angle4;
                this.Users = Users;
        }
        public EtudeViewModel EtudeProperty
            {
                get { return Etude; }
            }
        public String EtudeNameProperty
        {
            get { return Etude.TitreEtudeProperty; }
        }

        public PlageViewModel PlageProperty
        {
                get { return Plage; }
            }
            public String PlageNameProperty
        {
                get { return Plage.nomPlageProperty; }
            }
            public DateTime EtudeDateProperty
            {
                get { return Etude.dateCreationProperty; }
            }
            public String Angle1Property
        {
                get { return Angle1; }
                set
                {
                    Angle1 = value.ToUpper();
                    OnPropertyChanged("Angle1Property");
                }

            }
        public String Angle2Property
        {
            get { return Angle2; }
            set
            {
                Angle2 = value.ToUpper();
                OnPropertyChanged("Angle2Property");
            }

        }
        public String Angle3Property
        {
            get { return Angle3; }
            set
            {
                Angle3 = value.ToUpper();
                OnPropertyChanged("Angle3Property");
            }

        }
        public String Angle4Property
        {
            get { return Angle4; }
            set
            {
                Angle4 = value.ToUpper();
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
                 //   EtudePlageORM.updateEtudePlage(this);
                }
            }
        }
    }

