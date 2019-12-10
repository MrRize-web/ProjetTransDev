using MySql.Data.MySqlClient;
using ProjetTransDev.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Logique d'interaction pour LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        private static MySqlConnection connection;
        public LoginScreen()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            DALConnection.OpenConnection();
            try
            {
                if (DALConnection.OpenConnection().State == ConnectionState.Closed)
                    DALConnection.OpenConnection();
                String query = "SELECT COUNT(1) FROM users WHERE Identifiant=@Username AND MotDePasse=@Password";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", Identifiant.Text);
                cmd.Parameters.AddWithValue("@Password", MotDePasse.Password);
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count == 1)
                {
                    MainWindow dashboard = new MainWindow();
                    dashboard.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Identifiant ou mot de passe est incorrecte.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
