using ProjetTransDev.Vue.Benevol;
using System.Windows;
using System.Windows.Controls;

namespace ProjetTransDev.Vue
{
    /// <summary>
    /// Logique d'interaction pour MenuSelection.xaml
    /// </summary>
    public partial class MenuSelectionB : Page
    {
        public MenuSelectionB()
        {
            InitializeComponent();
        }

        private void ouvrirCommune(object sender, RoutedEventArgs e)
        {
            Window pageCommune = Window.GetWindow(this);
            pageCommune.Content = new CommuneB();
        }
        private void ouvrirDepartement(object sender, RoutedEventArgs e)
        {
            Window pageDepartement = Window.GetWindow(this);
            pageDepartement.Content = new DepartementB();
        }

        private void ouvrirEspece(object sender, RoutedEventArgs e)
        {
            Window pageEspece = Window.GetWindow(this);
            pageEspece.Content = new EspeceB();
        }
        private void ouvrirNombre(object sender, RoutedEventArgs e)
        {
            Window pageNombre = Window.GetWindow(this);
            pageNombre.Content = new EspeceNombreB();
        }
        private void ouvrirZone(object sender, RoutedEventArgs e)
        {
            Window pageZone = Window.GetWindow(this);
            pageZone.Content = new ZoneInvestigationB();
        }
        private void ouvrirEtude(object sender, RoutedEventArgs e)
        {
            Window pageEtude = Window.GetWindow(this);
            pageEtude.Content = new EtudeB();
        }
        private void ouvrirPlage(object sender, RoutedEventArgs e)
        {
            Window pagePlage = Window.GetWindow(this);
            pagePlage.Content = new PlageB();
        }
 
        private void ouvrirDeconnexion(object sender, RoutedEventArgs e)
        {
            //DALConnection.Close();
            Window pageDeconnection = Window.GetWindow(this);
            pageDeconnection.Content = new Login();

        }
    }
}
