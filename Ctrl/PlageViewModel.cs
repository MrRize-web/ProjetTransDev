using ProjetTransDev.Ctrl.ProjetTransDev.Ctrl;
using ProjetTransDev.ORM;
using System;
using System.ComponentModel;

namespace ProjetTransDev.Ctrl
{
    public class PlageViewModel : INotifyPropertyChanged
    {
        private int idPlage;
        private string nomPlage;
        private string superficEtudePlage;
        public CommuneViewModel CommunePlage;

        public PlageViewModel() { }

            public PlageViewModel(int id, string nom, string superficEtude, CommuneViewModel CommunePlage)
            {
                this.idPlage = id;
                this.nomPlageProperty = nom;
                this.superficEtudePlageProperty = superficEtude;
                this.CommunePlage = CommunePlage;
        }
            public int idPlageProperty
        {
                get { return idPlage; }
            }
    
        public CommuneViewModel CommunePlageProperty
        {
            get { return CommunePlage; }
        }
        public String CommunePlageNameProperty
        {
            get { return CommunePlage.nomCommuneProperty; }
        }
        public String nomPlageProperty
        {
                get { return nomPlage; }
                set
                {
                    nomPlage = value.ToUpper();
                    OnPropertyChanged("nomPlageProperty");
                }

            }
        public String superficEtudePlageProperty
        {
            get { return superficEtudePlage; }
            set
            {
                superficEtudePlage = value.ToUpper();
                OnPropertyChanged("superficEtudePlageProperty");
            }

        }
            public event PropertyChangedEventHandler PropertyChanged;

            private void OnPropertyChanged(string info)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(info));
                   PlageORM.updatePlage(this);
                }
            }
        }
    }
