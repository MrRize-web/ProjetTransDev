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
    /// Logique d'interaction pour Plage.xaml
    /// </summary>
    public partial class Plage : Page
    {
        int selectedPlagesId;
        int selectedCommunesId;
        int compteur = 0;


        PlageViewModel myDataObject1; // Objet de liaison
        ObservableCollection<PlageViewModel> lp1;


        CommuneViewModel myDataObject2; // Objet de liaison
        ObservableCollection<CommuneViewModel> lp2;

        public Plage()
        {
            InitializeComponent();

            DALConnection.OpenConnection();

            lp1 = PlageORM.listePlages();
            listePlages.ItemsSource = lp1;

            lp2 = CommuneORM.ListeCommunes();
            listeCommunesCombo.ItemsSource = lp2;
        }


        /////////////////////////////////////   Plage     /////////////////////////////////////
        /////////////////////////////////////    Plage    /////////////////////////////////////
        private void VlidePlage_Click(object sender, RoutedEventArgs e)
        {
            myDataObject1 = new PlageViewModel();
            myDataObject1.nomPlageProperty = nomPlage.Text;
            myDataObject1.superficEtudePlageProperty = SuperficiePlage.Text;
            myDataObject1.CommunePlage = (CommuneViewModel)listeCommunesCombo.SelectedItem;

            PlageViewModel nouveau = new PlageViewModel(PlageDAL.getMaxIdPlage() + 1, myDataObject1.nomPlageProperty, myDataObject1.superficEtudePlageProperty, myDataObject1.CommunePlage);
            lp1.Add(nouveau);
            PlageORM.insertPlage(nouveau);
            listePlages.Items.Refresh();
            listePlages.ItemsSource = lp1;
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
                listePlages.Items.Refresh();
            }
        }
        private void supprimerButton_MouseDoubleClick1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PlageViewModel toRemove = (PlageViewModel)listePlages.SelectedItem;
            lp1.Remove(toRemove);
            listePlages.Items.Refresh();
            PlageORM.supprimerPlage(selectedPlagesId);
            MessageBox.Show("Plage supprimée avec succes ! ");
        }
        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelection();
        }
    }
}
