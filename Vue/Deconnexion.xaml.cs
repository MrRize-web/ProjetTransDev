using ProjetTransDev.DAL;
using System.Windows;
using System.Windows.Controls;

namespace ProjetTransDev.Vue
{
    /// <summary>
    /// Logique d'interaction pour Deconnexion.xaml
    /// </summary>
    public partial class Deconnexion : Page
    {
        
        public Deconnexion()
        {
            InitializeComponent();
            DALConnection.Close();
            MessageBox.Show("Deconnecté ! ");
            this.Content = new PageDeconnecte();
        }
    }
}
