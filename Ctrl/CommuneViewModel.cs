using ProjetTransDev.ORM;
using System;
using System.ComponentModel;

namespace ProjetTransDev.Ctrl
{

    namespace ProjetTransDev.Ctrl
    {
        public class CommuneViewModel : INotifyPropertyChanged
        {
            public DepartementViewModel DepartementCommune;
            private int idCommune;
            private string nomCommune;
            
            public CommuneViewModel(int id, string nom, DepartementViewModel Departement)
            {
                this.idCommune = id;
                this.nomCommuneProperty = nom;
                this.DepartementCommuneProperty = Departement;
            }
            public int idCommuneProperty
            {
                get { return idCommune; }
            }
            public DepartementViewModel DepartementCommuneProperty
            {
                get { return DepartementCommune; }
                set
                {
                    DepartementCommune = value;              
                }
            }

            public String nomCommuneProperty
            {
                get { return nomCommune; }
                set
                {
                    nomCommune = value.ToUpper();
                    OnPropertyChanged("nomCommuneProperty");
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
                    CommuneORM.updateCommune(this);
                }
            }
        }
    }

}
