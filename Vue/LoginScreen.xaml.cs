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
        public LoginScreen()
        {
            InitializeComponent();

            DALConnection.OpenConnection();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=localhost\sqle2012; Initial Catalog=LoginDB; Integrated Security=True;");
     
            try
            {
                if (sqlCon.State == ConnectionState.Closed)
                    sqlCon.Open();
                String query = "SELECT COUNT(1) FROM users WHERE Identifiant=@Username AND MotDePasse=@Password";
                SqlCommand sqlCmd = new SqlCommand(query);

                sqlCmd.CommandType = CommandType.Text;

                sqlCmd.Parameters.AddWithValue("@Username", Identifiant.Text);
                sqlCmd.Parameters.AddWithValue("@Password", MotDePasse.Password);

                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
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
            finally
            {
                sqlCon.Close();
            }
        }
    }
}
