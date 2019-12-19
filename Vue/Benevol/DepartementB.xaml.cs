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
    /// Logique d'interaction pour Departement.xaml
    /// </summary>
    public partial class DepartementB : Page
    {
        int selectedDepartementsId;
        int compteur = 0;

        ObservableCollection<DepartementViewModel> lp3;


        public DepartementB()
        {
            InitializeComponent();
            lp3 = DepartementORM.ListeDepartements();
            listeDepartements.ItemsSource = lp3;
        }
        /////////////////////////////////////   Departement     /////////////////////////////////////
        /////////////////////////////////////   Departement     /////////////////////////////////////
      
        private void listeDepartements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeDepartements.SelectedIndex < lp3.Count) && (listeDepartements.SelectedIndex >= 0))
            {
                selectedDepartementsId = (lp3.ElementAt<DepartementViewModel>(listeDepartements.SelectedIndex)).idDepartementProperty;

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
