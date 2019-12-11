using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetTransDev.Vue
{
    /// <summary>
    /// Logique d'interaction pour MenuSelection.xaml
    /// </summary>
    public partial class MenuSelection : Page
    {
        public MenuSelection()
        {
            InitializeComponent();
        }

        private void ouvrirCommune(object sender, RoutedEventArgs e)
        {
            Window pageCommune = Window.GetWindow(this);
            pageCommune.Content = new Commune();
        }
        private void ouvrirDepartement(object sender, RoutedEventArgs e)
        {
            Window pageDepartement = Window.GetWindow(this);
            pageDepartement.Content = new Departement();
        }
  
        private void ouvrirEspece(object sender, RoutedEventArgs e)
        {
            Window pageEspece = Window.GetWindow(this);
            pageEspece.Content = new Espece();
        }
        private void ouvrirEtude(object sender, RoutedEventArgs e)
        {
            Window pageEtude = Window.GetWindow(this);
            pageEtude.Content = new Etude();
        }
        private void ouvrirPlage(object sender, RoutedEventArgs e)
        {
            Window pagePlage = Window.GetWindow(this);
            pagePlage.Content = new Plage();
        }
        private void ouvrirUtilisateur(object sender, RoutedEventArgs e)
        {
            Window pageUtilisateur = Window.GetWindow(this);
            pageUtilisateur.Content = new User();
        }
        private void ouvrirDeconnexion(object sender, RoutedEventArgs e)
        {
            Window pageDeconnexion = Window.GetWindow(this);
            pageDeconnexion.Content = new Deconnexion();
        }
    }
}
