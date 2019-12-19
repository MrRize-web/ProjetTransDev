using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjetTransDev.Ctrl;
using ProjetTransDev.DAL;
using ProjetTransDev.ORM;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace ProjetTransDev.Vue.Benevol
{
    /// <summary>
    /// Logique d'interaction pour EspeceNombre.xaml
    /// </summary>
    public partial class EspeceNombreB : Page
    {
        int selectedEspeceNombreId;
        int compteur = 0;

        EspeceNombreViewModel myDataObject8;
        ObservableCollection<EspeceNombreViewModel> lp8;
        ObservableCollection<ZoneInvestigationViewModel> lp7;
        ObservableCollection<EtudeViewModel> lp4;
        ObservableCollection<PlageViewModel> lp1;
        ObservableCollection<EspeceViewModel> lp5;
        public EspeceNombreB()
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

        private void ValideNombreEspece_Click(object sender, RoutedEventArgs e)
        {
            myDataObject8 = new EspeceNombreViewModel();
            myDataObject8.NombreProperty = Convert.ToDecimal(NbAnimaux.SelectionBoxItem);
            myDataObject8.PlageProperty = (PlageViewModel)listePlagesCombo.SelectedItem;
            myDataObject8.EtudeProperty = (EtudeViewModel)listeEtudesCombo.SelectedItem;
            myDataObject8.IdZoneProperty = (ZoneInvestigationViewModel)listeZonesCombo.SelectedItem;
            myDataObject8.EspeceProperty = (EspeceViewModel)listeEspeceCombo.SelectedItem;

            EspeceNombreViewModel nouveau = new EspeceNombreViewModel(EspeceNombreDAL.getMaxIdEspeceNombre() + 1, myDataObject8.IdZoneProperty, myDataObject8.EspeceProperty, myDataObject8.PlageProperty, myDataObject8.EtudeProperty, myDataObject8.NombreProperty);
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
       
        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelectionB();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
