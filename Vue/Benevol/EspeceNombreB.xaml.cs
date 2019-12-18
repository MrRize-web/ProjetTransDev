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
        public EspeceNombreB()
        {

            InitializeComponent();
            lp8 = EspeceNombreORM.ListeEspeceNombres();
            listeEspecesNombres.ItemsSource = lp8;
            lp8 = EspeceNombreORM.ListeEspeceNombres();
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
