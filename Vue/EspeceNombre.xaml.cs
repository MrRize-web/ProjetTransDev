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
        int selectedEspeceNombreId;
        int compteur = 0;

        EspeceNombreViewModel myDataObject8;
        ObservableCollection<EspeceNombreViewModel> lp8;
        public EspeceNombre()
        {

            InitializeComponent();
            lp8 = EspeceNombreORM.ListeEspeceNombres();
            listeZonesCombo.ItemsSource = lp8;
        }

        private void VlideNombreEspece_Click(object sender, RoutedEventArgs e)
        {
            myDataObject8 = new EspeceNombreViewModel();
            myDataObject8.NombreProperty = Convert.ToDecimal(NbAnimaux.SelectionBoxItem);

            /* EspeceNombreViewModel nouveau = new EspeceNombreViewModel(myDataObject8.EspeceProperty,myDataObject8.PlageProperty, myDataObject8.EtudeProperty,myDataObject8.NombreProperty);
             lp8.Add(nouveau);
             EspeceNombreORM.insertEspeceNombre(nouveau);*/
            compteur = lp8.Count();
            MessageBox.Show("Nombre ajoutée avec succes ! ");

        }
        private void listeEspecesNombres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeZonesCombo.SelectedIndex < lp8.Count) && (listeZonesCombo.SelectedIndex >= 0))
            {
                selectedEspeceNombreId = (lp8.ElementAt<EspeceNombreViewModel>(listeZonesCombo.SelectedIndex)).IdNombreEProperty;
            }
        }

        private void supprimerButton_MouseDoubleClick5(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EspeceNombreViewModel toRemove = (EspeceNombreViewModel)listeZonesCombo.SelectedItem;
            lp8.Remove(toRemove);

            listeZonesCombo.Items.Refresh();

            EspeceNombreORM.supprimerEspeceNombre(selectedEspeceNombreId);
            MessageBox.Show("Espece supprimée avec succes ! ");
        }

        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelection();
        }
    }
}
