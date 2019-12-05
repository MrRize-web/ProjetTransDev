using ProjetTransDev.ORM;
using System;
using System.ComponentModel;
namespace ProjetTransDev
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        private int idUsers;
        private string nomUsers;
        private string prenomUsers;
        private byte administrateurUsers;
        private string identifiantUsers;
        private string motDePasseUsers;
        private string adresseMailUsers;

        //private string concat;

        public UsersViewModel() { }

        public UsersViewModel(int id, string nom, string prenom, string identifiant, string adresseMail, string motDePasse, byte administrateur)
        {
            this.idUsers = id;
            this.nomUsersProperty = nom;
            this.prenomUsersProperty = prenom;
            this.administrateurUsersProperty = administrateur;
            this.adresseMailUsersProperty = adresseMail;
            this.motDePasseUsersProperty = motDePasse;
            this.identifiantUsersProperty = identifiant;
        }
        public int idUsersProperty
        {
            get { return idUsers; }
        }

       
        public String nomUsersProperty
        {
            get { return nomUsers; }
            set
            {
                nomUsers = value.ToUpper();
                //this.concatProperty = value.ToUpper() + " " + prenomUsers;
                OnPropertyChanged("nomUsersProperty");
            }

        }
        public String prenomUsersProperty
        {
            get { return prenomUsers; }
            set
            {
                this.prenomUsers = value;
                this.concatProperty = this.nomUsers + " " + value;
                OnPropertyChanged("prenomUsersProperty");
            }
        }
        public String adresseMailUsersProperty
        {
            get { return adresseMailUsers; }
            set
            {
                this.adresseMailUsers = value;
                this.concatProperty = this.adresseMailUsers + " " + value;
            
                //this.concatProperty = value.ToUpper() + " " + prenomUsers;
                OnPropertyChanged("adresseMailUsersProperty");
            }

        }
        public String motDePasseUsersProperty
        {
            get { return motDePasseUsers; }
            set
            {
                this.motDePasseUsers = value;
                this.concatProperty = this.motDePasseUsers + " " + value;
             
                //this.concatProperty = value.ToUpper() + " " + prenomUsers;
                OnPropertyChanged("motDePasseUsersProperty");
            }

        }
        public String identifiantUsersProperty
        {
            get { return identifiantUsers; }
            set
            {
                this.identifiantUsers = value;
                this.concatProperty = this.identifiantUsers + " " + value;
                //this.concatProperty = value.ToUpper() + " " + prenomUsers;
                OnPropertyChanged("identifiantUsersProperty");
            }

        }
        public byte administrateurUsersProperty
        {
            get { return administrateurUsers; }
            set
            {
                this.administrateurUsers = value;
                OnPropertyChanged("administrateurUsers");
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
                UsersORM.updateUsers(this);
            }
        }
    }
}