using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjetTransDev.Ctrl;
using ProjetTransDev.Ctrl.ProjetTransDev.Ctrl;
using ProjetTransDev.DAL;
using ProjetTransDev.ORM;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace ProjetTransDev.Vue.Benevol
{
    /// <summary>
    /// Logique d'interaction pour Plage.xaml
    /// </summary>
    public partial class PlageB : Page
    {
        int selectedPlagesId;
        int selectedCommunesId;
        int compteur = 0;


        PlageViewModel myDataObject1; // Objet de liaison
        ObservableCollection<PlageViewModel> lp1;

        public PlageB()
        {
            InitializeComponent();
            lp1 = PlageORM.listePlages();
            listePlages.ItemsSource = lp1;
        }


        /////////////////////////////////////   Plage     /////////////////////////////////////
        /////////////////////////////////////    Plage    /////////////////////////////////////
   
        private void listePlages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePlages.SelectedIndex < lp1.Count) && (listePlages.SelectedIndex >= 0))
            {
                selectedPlagesId = (lp1.ElementAt<PlageViewModel>(listePlages.SelectedIndex)).idPlageProperty;
                listePlages.Items.Refresh();
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
