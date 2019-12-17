using ProjetTransDev.Ctrl;
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
        int selectedEspeceId;
        int compteur = 0;

        EtudePlageEspeceViewModel myDataObject8;
        ObservableCollection<EtudePlageEspeceViewModel> lp8;
        public EspeceNombre()
        {

            InitializeComponent();
            lp8 = EtudePlageEspeceORM.ListeEtudePlageEspeces();
            listeZonesCombo.ItemsSource = lp8;
        }

        private void VlideNombreEspece_Click(object sender, RoutedEventArgs e)
        {
            myDataObject8 = new EtudePlageEspeceViewModel();
            myDataObject8.NombreProperty = Convert.ToDecimal(NbAnimaux.SelectionBoxItem);

            /* EtudePlageEspeceViewModel nouveau = new EtudePlageEspeceViewModel(myDataObject8.EspeceProperty,myDataObject8.PlageProperty, myDataObject8.EtudeProperty,myDataObject8.NombreProperty);
             lp8.Add(nouveau);
             EtudePlageEspeceORM.insertEtudePlageEspece(nouveau);*/
            compteur = lp8.Count();
            MessageBox.Show("Nombre ajoutée avec succes ! ");

        }
        private void listeEspecesNombres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeZonesCombo.SelectedIndex < lp8.Count) && (listeZonesCombo.SelectedIndex >= 0))
            {
                selectedEspeceId = (lp8.ElementAt<EtudePlageEspeceViewModel>(listeZonesCombo.SelectedIndex)).IdNombreEProperty;
            }
        }

        private void supprimerButton_MouseDoubleClick5(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EtudePlageEspeceViewModel toRemove = (EtudePlageEspeceViewModel)listeZonesCombo.SelectedItem;
            lp8.Remove(toRemove);

            listeZonesCombo.Items.Refresh();

            EtudePlageEspeceORM.supprimerEtudePlageEspece(selectedEspeceId);
            MessageBox.Show("Espece supprimée avec succes ! ");
        }

        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelection();
        }
    }
}
