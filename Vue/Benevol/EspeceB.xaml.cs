using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ProjetTransDev.Ctrl;
using ProjetTransDev.ORM;
using System.Collections.ObjectModel;

namespace ProjetTransDev.Vue.Benevol
{
    /// <summary>
    /// Logique d'interaction pour Espece.xaml
    /// </summary>
    public partial class EspeceB : Page
    {
        int selectedEspeceId;
        int compteur = 0;

        ObservableCollection<EspeceViewModel> lp5;

        public EspeceB()
        {
            InitializeComponent();
            lp5 = EspeceORM.listeEspeces();
            listeEspeces.ItemsSource = lp5;
        }
        /////////////////////////////////////    ESPECE    /////////////////////////////////////
        /////////////////////////////////////     ESPECE      /////////////////////////////////////

        private void listeEspeceSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEspeces.SelectedIndex < lp5.Count) && (listeEspeces.SelectedIndex >= 0))
            {
                selectedEspeceId = (lp5.ElementAt<EspeceViewModel>(listeEspeces.SelectedIndex)).idEspeceProperty;
            }
        }
        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelectionB();
        }
    }
}
