using ProjetTransDev.Ctrl;
using ProjetTransDev.DAL;
using ProjetTransDev.ORM;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjetTransDev.Vue
{
    /// <summary>
    /// Logique d'interaction pour Etude.xaml
    /// </summary>
    public partial class Etude : Page
    {

        int selectedEtudeId;
        int selectedDepartementsId;
        int compteur = 0;


        PlageViewModel myDataObject1; // Objet de liaison
        ObservableCollection<PlageViewModel> lp1;

        EtudeViewModel myDataObject4; // Objet de liaison
        ObservableCollection<EtudeViewModel> lp4;

        public Etude()
        {

            InitializeComponent();

            DALConnection.OpenConnection();

            lp1 = PlageORM.listePlages();
            listePlagesCombo.ItemsSource = lp1;

            lp4 = EtudeORM.ListeEtude();
            listeEtudes.ItemsSource = lp4;

        }
        /////////////////////////////////////    Etudes    /////////////////////////////////////
        /////////////////////////////////////    Etudes    /////////////////////////////////////
        ///
        private void VlideEtude_Click(object sender, RoutedEventArgs e)
        {
            myDataObject4 = new EtudeViewModel();
            myDataObject4.NbPersonneEtudeProperty = Convert.ToDecimal(NbPersonne.SelectionBoxItem);
            //myDataObject4.NbPersonneEtudeProperty = NbPersonne.SelectedValue.ToString();
            myDataObject4.PlageEtude = (PlageViewModel)listePlagesCombo.SelectedItem;
            myDataObject4.TitreEtudeProperty = Titre.Text;
            EtudeViewModel nouveau = new EtudeViewModel(EtudeDAL.getMaxIdEtude() + 1, myDataObject4.NbPersonneEtudeProperty, myDataObject4.PlageEtudeProperty, myDataObject4.TitreEtudeProperty, myDataObject4.dateCreationProperty, myDataObject4.dateFinProperty);
            lp4.Add(nouveau);
            EtudeORM.insertEtude(nouveau);
            compteur = lp4.Count();

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

            EtudeORM.supprimerEtude(selectedEtudeId);

            MessageBox.Show("Etude supprimée avec succes ! ");
        }
        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelection();
        }
    }
}
