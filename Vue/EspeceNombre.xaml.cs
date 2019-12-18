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
    /// Logique d'interaction pour EspeceNombre.xaml
    /// </summary>
    public partial class EspeceNombre : Page
    {
        int selectedEspeceNombreId;
        int compteur = 0;

        EspeceNombreViewModel myDataObject8;
        ObservableCollection<EspeceNombreViewModel> lp8;
        ZoneInvestigationViewModel myDataObject7; // Objet de liaison
        ObservableCollection<ZoneInvestigationViewModel> lp7;
        EtudeViewModel myDataObject4; // Objet de liaison
        ObservableCollection<EtudeViewModel> lp4;
        PlageViewModel myDataObject1; // Objet de liaison
        ObservableCollection<PlageViewModel> lp1;

        EspeceViewModel myDataObject5;
        ObservableCollection<EspeceViewModel> lp5;
        public EspeceNombre()
        {

            InitializeComponent();
            lp8 = EspeceNombreORM.ListeEspeceNombres();
            listeEspecesNombres.ItemsSource = lp8;

            lp1 = PlageORM.listePlages();
            listePlagesCombo.ItemsSource = lp1;

            lp4 = EtudeORM.ListeEtude();
            listeEtudesCombo.ItemsSource = lp4;

            lp5 = EspeceORM.listeEspeces();
            listeEspeceCombo.ItemsSource = lp5;
            
            lp7 = ZoneInvestigationORM.ListeZoneInvestigation();
            listeZonesCombo.ItemsSource = lp7;

            lp8 = EspeceNombreORM.ListeEspeceNombres();
        }

        private void VlideNombreEspece_Click(object sender, RoutedEventArgs e)
        {
            myDataObject8 = new EspeceNombreViewModel();
            myDataObject8.NombreProperty = Convert.ToDecimal(NbAnimaux.SelectionBoxItem);
            myDataObject8.PlageProperty = (PlageViewModel)listePlagesCombo.SelectedItem;
            myDataObject8.EtudeProperty = (EtudeViewModel)listeEtudesCombo.SelectedItem;
            myDataObject8.IdZoneProperty = (ZoneInvestigationViewModel)listeZonesCombo.SelectedItem;
            myDataObject8.EspeceProperty = (EspeceViewModel)listeEspeceCombo.SelectedItem;
                            
             EspeceNombreViewModel nouveau = new EspeceNombreViewModel(EspeceNombreDAL.getMaxIdEspeceNombre() + 1,myDataObject8.IdZoneProperty,myDataObject8.EspeceProperty, myDataObject8.PlageProperty,myDataObject8.EtudeProperty,myDataObject8.NombreProperty);
             lp8.Add(nouveau);
             EspeceNombreORM.insertEspeceNombre(nouveau);
            compteur = lp8.Count();

            listeEspecesNombres.Items.Refresh();
            listeEspecesNombres.ItemsSource = lp8;
            MessageBox.Show("Nombre ajoutée avec succes ! ");

        }

        private void listeEspecesNombres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEspecesNombres.SelectedIndex < lp8.Count) && (listeEspecesNombres.SelectedIndex >= 0))
            {
                selectedEspeceNombreId = (lp8.ElementAt<EspeceNombreViewModel>(listeEspecesNombres.SelectedIndex)).IdNombreEProperty;
            }
        }
        private void supprimerButton_MouseDoubleClick4(object sender, System.Windows.Input.MouseButtonEventArgs e)
             {EspeceNombreViewModel toRemove = (EspeceNombreViewModel)listeEspecesNombres.SelectedItem;
            lp8.Remove(toRemove);
            listeEspecesNombres.Items.Refresh();
            listeEspecesNombres.ItemsSource = lp8;

            ZoneInvestigationORM.supprimerZoneInvestigation(selectedEspeceNombreId);
            MessageBox.Show("Espece supprimée avec succes ! ");
        }
        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelection();
        }
    }
}
