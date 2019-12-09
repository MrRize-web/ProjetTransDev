using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using ProjetTransDev.DAL;
using ProjetTransDev.ORM;
using ProjetTransDev.Ctrl;
using ProjetTransDev.Ctrl.ProjetTransDev.Ctrl;
using System;
using Google.Protobuf.WellKnownTypes;

namespace ProjetTransDev
{
    public partial class MainWindow : Window
    {
        int selectedUsersId;
        int selectedPlagesId;
        int selectedCommunesId;
        int selectedEspeceId;
        int selectedEtudeId;
        int selectedDepartementsId;
        int compteur = 0;

        UsersViewModel myDataObject; // Objet de liaison
        ObservableCollection<UsersViewModel> lp;
      

        PlageViewModel myDataObject1; // Objet de liaison
        ObservableCollection<PlageViewModel> lp1;


        CommuneViewModel myDataObject2; // Objet de liaison
        ObservableCollection<CommuneViewModel> lp2;


        DepartementViewModel myDataObject3; // Objet de liaison
        ObservableCollection<DepartementViewModel> lp3;

        EtudeViewModel myDataObject4; // Objet de liaison
        ObservableCollection<EtudeViewModel> lp4;

        EspeceViewModel myDataObject5; // Objet de liaison
        ObservableCollection<EspeceViewModel> lp5;

    
        public MainWindow()
        {
            InitializeComponent();

            DALConnection.OpenConnection();

            lp = UsersORM.listeUserss();
            listeUsers.ItemsSource = lp;

            lp1 = PlageORM.listePlages();
            listePlages.ItemsSource = lp1;

            
            lp2 = CommuneORM.ListeCommunes();
            listeCommunes.ItemsSource = lp2;

            lp2 = CommuneORM.ListeCommunes();
            listeCommunesCombo.ItemsSource = lp2;

            lp3 = DepartementORM.ListeDepartements();
            listeDepartementsCombo2.ItemsSource = lp3;

            lp3 = DepartementORM.ListeDepartements();
            listeDepartements.ItemsSource = lp3;

            lp4 = EtudeORM.ListeEtude();
            listeEtudes.ItemsSource = lp4;

            lp4 = EtudeORM.ListeEtude();
            listePlagesCombo.ItemsSource = lp4;
            
            lp5 = EspeceORM.listeEspeces();
            listeEspeces.ItemsSource = lp5;
        }
       
        /////////////////////////////////////        /////////////////////////////////////
        ///        /////////////////////////////////////        /////////////////////////////////////
        private void nomPrenomButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
            UsersViewModel nouveau = new UsersViewModel(myDataObject.idUsersProperty, myDataObject.nomUsersProperty, myDataObject.prenomUsersProperty, myDataObject.identifiantUsersProperty, myDataObject.motDePasseUsersProperty, myDataObject.adresseMailUsersProperty, myDataObject.administrateurUsersProperty);
            lp.Add(nouveau);
            UsersORM.insertUsers(nouveau);
    
            listeUsers.Items.Refresh();
            listeDepartements.Items.Refresh();
            listeCommunes.Items.Refresh();
            listePlages.Items.Refresh();
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
            listeDepartements.Items.Refresh();
            listeCommunes.Items.Refresh();
            listePlages.Items.Refresh();
            UsersORM.supprimerUsers(selectedUsersId);
            MessageBox.Show("Utilisateur supprimée avec succes ! ");
        }
        private void listeUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         if ((listeUsers.SelectedIndex < lp1.Count) && (listeUsers.SelectedIndex >= 0))
                {
                    selectedUsersId = (lp.ElementAt<UsersViewModel>(listeUsers.SelectedIndex)).idUsersProperty;
                    listeDepartements.Items.Refresh();
                    listeCommunes.Items.Refresh();
                    listePlages.Items.Refresh();
            } 
        }
        /////////////////////////////////////        /////////////////////////////////////
        /////////////////////////////////////        /////////////////////////////////////
        private void VlidePlage_Click(object sender, RoutedEventArgs e)
        {
            myDataObject1 = new PlageViewModel();
            myDataObject1.nomPlageProperty = nomPlage.Text;
            myDataObject1.superficEtudePlageProperty = SuperficiePlage.Text;
            myDataObject1.CommunePlageProperty= (CommuneViewModel)listeCommunesCombo.SelectedItem;

            PlageViewModel nouveau = new PlageViewModel(myDataObject1.idPlageProperty, myDataObject1.nomPlageProperty, myDataObject1.superficEtudePlageProperty, myDataObject1.CommunePlage);
            lp1.Add(nouveau);
            PlageORM.insertPlage(nouveau);
            CommuneORM.selectCommune(selectedCommunesId);

            listePlages.Items.Refresh();
            listeDepartements.Items.Refresh();
            listeCommunes.Items.Refresh();
            compteur = lp1.Count();

            ((TextBox)nomPlage).Text = string.Empty;
            ((TextBox)SuperficiePlage).Text = string.Empty;

            MessageBox.Show("Plage ajoutée avec succes ! ");
        }
        private void listePlages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePlages.SelectedIndex < lp1.Count) && (listePlages.SelectedIndex >= 0))
            {
                selectedPlagesId = (lp1.ElementAt<PlageViewModel>(listePlages.SelectedIndex)).idPlageProperty;
                listeDepartements.Items.Refresh();
                listeCommunes.Items.Refresh();
                listePlages.Items.Refresh();
            }
        }
        private void supprimerButton_MouseDoubleClick1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlageViewModel toRemove = (PlageViewModel)listePlages.SelectedItem;
            lp1.Remove(toRemove);

            listeDepartements.Items.Refresh();
            listeCommunes.Items.Refresh();
            listePlages.Items.Refresh();

            PlageORM.supprimerPlage(selectedPlagesId);
            MessageBox.Show("Plage supprimée avec succes ! ");
        }
        /////////////////////////////////////   Commune     /////////////////////////////////////
        /////////////////////////////////////   Commune     /////////////////////////////////////
        private void VlideCommune_Click(object sender, RoutedEventArgs e)
        {
            myDataObject2 = new CommuneViewModel();
            myDataObject2.nomCommuneProperty = NomCommune.Text;
            myDataObject2.CodePostaleProperty = CodePostale.Text;
            myDataObject2.DepartementCommuneProperty = (DepartementViewModel)listeDepartementsCombo2.SelectedItem;
             CommuneViewModel nouveau = new CommuneViewModel(myDataObject2.idCommuneProperty, myDataObject2.nomCommuneProperty, myDataObject2.CodePostaleProperty, myDataObject2.DepartementCommune);
            lp2.Add(nouveau);

            CommuneORM.insertCommune(nouveau);
            CommuneORM.selectCommune(selectedCommunesId);

            listeDepartements.Items.Refresh();
            listeCommunes.Items.Refresh();
            listePlages.Items.Refresh();
            compteur = lp2.Count();

            ((TextBox)NomCommune).Text = string.Empty;
            ((TextBox)CodePostale).Text = string.Empty;

            MessageBox.Show("Commune ajoutée avec succes ! ");
        }
        private void listeCommunes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeCommunes.SelectedIndex < lp3.Count) && (listeCommunes.SelectedIndex >= 0))
            {
                selectedCommunesId = (lp2.ElementAt<CommuneViewModel>(listeCommunes.SelectedIndex)).idCommuneProperty;
                listeDepartements.Items.Refresh();
                listeCommunes.Items.Refresh();
                listePlages.Items.Refresh();
            }
        }
        private void supprimerButton_MouseDoubleClick2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CommuneViewModel toRemove = (CommuneViewModel)listeCommunes.SelectedItem;
            lp2.Remove(toRemove);

            listeDepartements.Items.Refresh();
            listeCommunes.Items.Refresh();
            listePlages.Items.Refresh();

            CommuneORM.supprimerCommune(selectedCommunesId);
            MessageBox.Show("Commune supprimée avec succes ! ");
        }
        /////////////////////////////////////   Departement     /////////////////////////////////////
        /////////////////////////////////////   Departement     /////////////////////////////////////
        private void VlideDepartement_Click(object sender, RoutedEventArgs e)
        {
            myDataObject3 = new DepartementViewModel();
            myDataObject3.nomDepartementProperty = NomDepartement.Text;

            DepartementViewModel nouveau = new DepartementViewModel(myDataObject3.idDepartementProperty, myDataObject3.nomDepartementProperty);
            lp3.Add(nouveau);
            DepartementORM.insertDepartement(nouveau);
            DepartementORM.getDepartement(selectedDepartementsId);
            CommuneORM.selectCommune(selectedCommunesId);
            CommuneORM.getCommune(selectedCommunesId);
            PlageORM.getPlage(selectedPlagesId);
            CommuneORM.selectCommune(selectedCommunesId);

            listeDepartements.Items.Refresh();
            listeCommunes.Items.Refresh();
            listePlages.Items.Refresh();
            compteur = lp3.Count();

            ((TextBox)NomDepartement).Text = string.Empty;

            MessageBox.Show("Département ajouté avec succes ! ");
        }
        private void listeDepartements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeDepartements.SelectedIndex < lp3.Count) && (listeDepartements.SelectedIndex >= 0))
            {
                selectedDepartementsId = (lp3.ElementAt<DepartementViewModel>(listeDepartements.SelectedIndex)).idDepartementProperty;
                listeDepartements.Items.Refresh();
                listeCommunes.Items.Refresh();
                listePlages.Items.Refresh();
            }
        }
        private void supprimerButton_MouseDoubleClick3(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DepartementViewModel toRemove = (DepartementViewModel)listeDepartements.SelectedItem;
            lp3.Remove(toRemove);

            listeDepartements.Items.Refresh();
            listeCommunes.Items.Refresh();
            listePlages.Items.Refresh();

            DepartementORM.supprimerDepartement(selectedDepartementsId);

            MessageBox.Show("Departement supprimé avec succes ! ");
        }
        /////////////////////////////////////    Etudes    /////////////////////////////////////
        /////////////////////////////////////    Etudes    /////////////////////////////////////
        ///
        private void VlideEtude_Click(object sender, RoutedEventArgs e)
        {
            myDataObject4 = new EtudeViewModel();
            myDataObject4.NbPersonneEtudeProperty = Convert.ToDecimal(NbEtude.Text);
            myDataObject4.PlageEtudeProperty = (PlageViewModel)listePlagesCombo.SelectedItem;
            myDataObject4.TitreEtudeProperty = Titre.Text;
            EtudeViewModel nouveau = new EtudeViewModel(myDataObject4.idEtudeProperty, myDataObject4.NbPersonneEtudeProperty, myDataObject4.PlageEtudeProperty, myDataObject4.TitreEtudeProperty);
            lp4.Add(nouveau);
            EtudeORM.insertEtude(nouveau);

            listeDepartements.Items.Refresh();
            listeCommunes.Items.Refresh();
            listePlages.Items.Refresh();

            compteur = lp4.Count();

            ((TextBox)NbEtude).Text = string.Empty;
            ((TextBox)Titre).Text = string.Empty;

            MessageBox.Show("Etude ajoutée avec succes ! ");
        }
        private void listeCommunesCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEtudes.SelectedIndex < lp4.Count) && (listeEtudes.SelectedIndex >= 0))
            {
                selectedEtudeId = (lp4.ElementAt<EtudeViewModel>(listeEtudes.SelectedIndex)).idEtudeProperty;
            }
        }
        private void supprimerButton_MouseDoubleClick4(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EtudeViewModel toRemove = (EtudeViewModel)listeEtudes.SelectedItem;
            lp4.Remove(toRemove);

            listeDepartements.Items.Refresh();
            listeCommunes.Items.Refresh();
            listePlages.Items.Refresh();

            EtudeORM.supprimerEtude(selectedEtudeId);

            MessageBox.Show("Etude supprimée avec succes ! ");
        }
        /////////////////////////////////////    ESPECE    /////////////////////////////////////
        /////////////////////////////////////     ESPECE      /////////////////////////////////////
        private void VlideEspece_Click(object sender, RoutedEventArgs e)
        {
            myDataObject5 = new EspeceViewModel();
            myDataObject5.nomEspeceProperty = nomEspece.Text;

            EspeceViewModel nouveau = new EspeceViewModel(myDataObject5.idEspeceProperty, myDataObject5.nomEspeceProperty);
            lp5.Add(nouveau);
            EspeceORM.insertEspece(nouveau);
            listeEspeces.Items.Refresh();
            compteur = lp5.Count();
            ((TextBox)nomEspece).Text = string.Empty;
            MessageBox.Show("Espece ajoutée avec succes ! ");

        }
        private void listeEspece_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEspeces.SelectedIndex < lp5.Count) && (listeEspeces.SelectedIndex >= 0))
            {
                selectedEspeceId = (lp5.ElementAt<EspeceViewModel>(listeEspeces.SelectedIndex)).idEspeceProperty;
            }
        }
        private void supprimerButton_MouseDoubleClick5(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EspeceViewModel toRemove = (EspeceViewModel)listeEspeces.SelectedItem;
            lp5.Remove(toRemove);

            listeEspeces.Items.Refresh();

            EspeceORM.supprimerEspece(selectedEspeceId);
            MessageBox.Show("Espece supprimée avec succes ! ");
        }

      
    }
}
