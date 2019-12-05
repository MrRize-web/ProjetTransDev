﻿using ProjetTransDev.ORM;
using System;
using System.ComponentModel;

namespace ProjetTransDev.Ctrl
{
    public class PlageViewModel : INotifyPropertyChanged
    {
        private int idPlage;
        private string nomPlage;
        private string superficEtudePlage;
            //private string concat;

            public PlageViewModel() { }

            public PlageViewModel(int id, string nom, string superficEtude)
            {
                this.idPlage = id;
                this.nomPlageProperty = nom;
                this.superficEtudePlageProperty = superficEtude;
        }
            public int idPlageProperty
        {
                get { return idPlage; }
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
                   PlageORM.updatePlage(this);
                }
            }
        }
    }
