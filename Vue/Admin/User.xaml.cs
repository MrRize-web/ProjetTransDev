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
    public partial class User : Page
    {
        int selectedUsersId;
        int compteur = 0;
        UsersViewModel myDataObject; // Objet de liaison
        ObservableCollection<UsersViewModel> lp;



        public User()
        {

            InitializeComponent();
            lp = UsersORM.listeUsers();
            listeUsers.ItemsSource = lp;


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

            if (administrateurUsers.IsChecked ?? true)
            {
                myDataObject.administrateurUsersProperty = 1;
            }
            else
            {
                myDataObject.administrateurUsersProperty = 0;
            }

            UsersViewModel nouveau = new UsersViewModel(UsersDAL.getMaxIdUsers() + 1, myDataObject.nomUsersProperty, myDataObject.prenomUsersProperty, myDataObject.identifiantUsersProperty, myDataObject.adresseMailUsersProperty, myDataObject.motDePasseUsersProperty, myDataObject.administrateurUsersProperty);
            lp.Add(nouveau);
            UsersORM.insertUsers(nouveau);

            listeUsers.Items.Refresh();

            ((TextBox)nomUsers).Text = string.Empty;
            ((TextBox)prenomUsers).Text = string.Empty;
            ((TextBox)AdresseMailUsers).Text = string.Empty;
            ((TextBox)Identifiant).Text = string.Empty;
            ((PasswordBox)MotDePasse).Password = string.Empty;
            compteur = lp.Count();

            MessageBox.Show("Utilisateur ajouté avec succes ! ");
        }
        private void supprimerButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            UsersViewModel toRemove = (UsersViewModel)listeUsers.SelectedItem;
            lp.Remove(toRemove);
            listeUsers.Items.Refresh();
            UsersORM.supprimerUsers(selectedUsersId);
            MessageBox.Show("Utilisateur supprimée avec succes ! ");
        }
        private void listeUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         if ((listeUsers.SelectedIndex < lp.Count) && (listeUsers.SelectedIndex >= 0))
                {
                    selectedUsersId = (lp.ElementAt<UsersViewModel>(listeUsers.SelectedIndex)).idUsersProperty;
            } 
        }
        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelection();
        }

  
 
    }
}
