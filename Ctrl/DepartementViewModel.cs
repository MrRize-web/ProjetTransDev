using System;
using ProjetTransDev.ORM;
using System.ComponentModel;

namespace ProjetTransDev.Ctrl
{

    public class DepartementViewModel : INotifyPropertyChanged
            {
                private string CodePostale;
                private string nomDepartement;
                private int idDepartement;
                public DepartementViewModel() { }

                public DepartementViewModel(int id, string nom, string CodePostale)
                {
                    this.idDepartement = id;
                    this.nomDepartementProperty = nom;
                    this.CodePostalePropertie = CodePostale;
                 }
                public int idDepartementProperty
                {
                    get { return idDepartement; }
                    set
                    {
                        idDepartement = value;             
                    }
                }

  

        public String nomDepartementProperty
        {
                    get { return nomDepartement; }
                    set
                    {
                        nomDepartement = value.ToUpper();
                        OnPropertyChanged("nomDepartementProperty");
                    }

                }

        public String CodePostalePropertie
        {
            get { return CodePostale; }
            set
            {
                CodePostale = value;
                OnPropertyChanged("CodePostaleProperty");
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
                        DepartementORM.updateDepartement(this);
                    }
                }
            }
        }

 


