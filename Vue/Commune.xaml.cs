using ProjetTransDev.Ctrl;
using ProjetTransDev.Ctrl.ProjetTransDev.Ctrl;
using ProjetTransDev.DAL;
using ProjetTransDev.ORM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ProjetTransDev.Vue
{
    /// <summary>
    /// Logique d'interaction pour Commune.xaml
    /// </summary>
    public partial class Commune : Page
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


        public Commune()
        {
            InitializeComponent();

            DALConnection.OpenConnection();

            lp2 = CommuneORM.ListeCommunes();
            listeCommunes.ItemsSource = lp2;

            lp3 = DepartementORM.ListeDepartements();
            listeDepartementsCombo.ItemsSource = lp3;
        }
        /////////////////////////////////////   Commune     /////////////////////////////////////
        /////////////////////////////////////   Commune     /////////////////////////////////////
        private void VlideCommune_Click(object sender, RoutedEventArgs e)
        {
            myDataObject2 = new CommuneViewModel();
            myDataObject2.nomCommuneProperty = NomCommune.Text;
            myDataObject2.CodePostaleProperty = CodePostale.Text;
            myDataObject2.DepartementCommune = (DepartementViewModel)listeDepartementsCombo.SelectedItem;
            CommuneViewModel nouveau = new CommuneViewModel(CommuneDAL.getMaxIdCommune() + 1, myDataObject2.nomCommuneProperty, myDataObject2.CodePostaleProperty, myDataObject2.DepartementCommune);
            lp2.Add(nouveau);

            CommuneORM.insertCommune(nouveau);

            listeDepartementsCombo.ItemsSource = lp3;
            listeCommunes.Items.Refresh();
            listeDepartementsCombo.Items.Refresh();
            listeCommunes.ItemsSource = lp2;
            compteur = lp2.Count();

            ((TextBox)NomCommune).Text = string.Empty;
            ((TextBox)CodePostale).Text = string.Empty;

            MessageBox.Show("Commune ajoutée avec succes ! ");
        }
        private void listeCommunes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if ((listeCommunes.SelectedIndex < lp2.Count) && (listeCommunes.SelectedIndex >= 0))
            {
                listeDepartementsCombo.ItemsSource = lp3;
                listeCommunes.Items.Refresh();
                listeDepartementsCombo.Items.Refresh();

                selectedCommunesId = (lp2.ElementAt<CommuneViewModel>(listeCommunes.SelectedIndex)).idCommuneProperty;

            }
        }
        private void supprimerButton_MouseDoubleClick2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            CommuneViewModel toRemove = (CommuneViewModel)listeCommunes.SelectedItem;
            lp2.Remove(toRemove);

            listeDepartementsCombo.ItemsSource = lp3;
            listeCommunes.Items.Refresh();
            listeDepartementsCombo.Items.Refresh();

            CommuneORM.supprimerCommune(selectedCommunesId);
            MessageBox.Show("Commune supprimée avec succes ! ");
        }
        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelection();
        }
    }
}
