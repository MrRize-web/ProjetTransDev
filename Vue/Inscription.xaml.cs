using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjetTransDev.Ctrl;
using ProjetTransDev.Ctrl.ProjetTransDev.Ctrl;
using ProjetTransDev.DAL;
using ProjetTransDev.ORM;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjetTransDev.Vue
{
    /// <summary>
    /// Logique d'interaction pour User.xaml
    /// </summary>
    public partial class Inscription : Page
    {
        int selectedUsersId;
        int compteur = 0;
        UsersViewModel myDataObject; // Objet de liaison
        ObservableCollection<UsersViewModel> lp;



        public Inscription()
        {

            InitializeComponent();
            lp = UsersORM.listeUsers();


        }
        /////////////////////////////////////     Users   /////////////////////////////////////
        ////////////////////////////////////////   Users     /////////////////////////////////////

        private void nomPrenomButton_Click(object sender, RoutedEventArgs e)
        {

            myDataObject = new UsersViewModel();
            myDataObject.nomUsersProperty = nomUsers.Text;
            myDataObject.prenomUsersProperty = prenomUsers.Text;
            myDataObject.adresseMailUsersProperty = AdresseMailUsers.Text;
            myDataObject.identifiantUsersProperty = Identifiant.Text;
            myDataObject.motDePasseUsersProperty = MotDePasse.Password;


            UsersViewModel nouveau = new UsersViewModel(UsersDAL.getMaxIdUsers() + 1, myDataObject.nomUsersProperty, myDataObject.prenomUsersProperty, myDataObject.identifiantUsersProperty, myDataObject.adresseMailUsersProperty, myDataObject.motDePasseUsersProperty,0);
            lp.Add(nouveau);
            UsersORM.insertUsers(nouveau);


            ((TextBox)nomUsers).Text = string.Empty;
            ((TextBox)prenomUsers).Text = string.Empty;
            ((TextBox)AdresseMailUsers).Text = string.Empty;
            ((TextBox)Identifiant).Text = string.Empty;
            ((PasswordBox)MotDePasse).Password = string.Empty;
            compteur = lp.Count();

            MessageBox.Show("Utilisateur ajouté avec succes ! ");
        }

        private void ouvrirLogin(object sender, RoutedEventArgs e)
        {
            //DALConnection.Close();
            Window pageLogin = Window.GetWindow(this);
            pageLogin.Content = new Login();

        }
    }
}
