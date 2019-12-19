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
    /// Logique d'interaction pour Commune.xaml
    /// </summary>
    public partial class Commune : Page
    {
        int selectedCommunesId;
        int compteur = 0;

        CommuneViewModel myDataObject2; // Objet de liaison
        ObservableCollection<CommuneViewModel> lp2;


        DepartementViewModel myDataObject3; // Objet de liaison
        ObservableCollection<DepartementViewModel> lp3;


        public Commune()
        {
            InitializeComponent();

            lp2 = CommuneORM.ListeCommunes();
            listeCommunes.ItemsSource = lp2;

            lp3 = DepartementORM.ListeDepartements();
            listeDepartementsCombo.ItemsSource = lp3;
        }
        /////////////////////////////////////   Commune     /////////////////////////////////////
        /////////////////////////////////////   Commune     /////////////////////////////////////
        private void ValideCommune_Click(object sender, RoutedEventArgs e)
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
        private void supprimerButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
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
