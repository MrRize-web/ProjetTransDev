using MySql.Data.MySqlClient;
using ProjetTransDev.DAL;
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
    /// Logique d'interaction pour Deconnexion.xaml
    /// </summary>
    public partial class Deconnexion : Page
    {
        public Deconnexion()
        {
            DALConnection.OpenConnection().Close();
            this.Content = new Login();
            MessageBox.Show("Deconnecté ! ");
        }       
    }
}
