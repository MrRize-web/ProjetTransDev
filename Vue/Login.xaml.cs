using ProjetTransDev.DAL;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace ProjetTransDev.Vue
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        UsersViewModel myDataObject;
        UsersDAL u = new UsersDAL();
        public Login()
        {
            InitializeComponent();
        }
        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            if (DALConnection.OpenConnection().State == ConnectionState.Closed)
            {
                DALConnection.OpenConnection();
            }
            String query = "SELECT COUNT(1) FROM users WHERE Identifiant=@Username AND MotDePasse=@Password";
                MySqlCommand sqlCmd = new MySqlCommand(query, DALConnection.OpenConnection());
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", Identifiant.Text);
                sqlCmd.Parameters.AddWithValue("@Password", MotDePasse.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
            
                    String query1 = " SELECT COUNT(1) FROM users WHERE Identifiant=@Username AND MotDePasse=@Password AND Administrateur=@Administrateur";
                    MySqlCommand sqlCmd1 = new MySqlCommand(query1, DALConnection.OpenConnection());
                    sqlCmd1.CommandType = CommandType.Text;
                    sqlCmd1.Parameters.AddWithValue("@Username", Identifiant.Text);
                    sqlCmd1.Parameters.AddWithValue("@Password", MotDePasse.Password);
                    sqlCmd1.Parameters.AddWithValue("@Administrateur", "1");
                    int count1 = Convert.ToInt32(sqlCmd1.ExecuteScalar());
                    if (count1 == 1)
                    {
                        window.Content = new MenuSelection();
                    }
                    else
                    {
                        window.Content = new MenuSelectionB();
                    }
                }
                else
                {
                    MessageBox.Show("Identifiant ou mot de passe est incorrecte.");
                    window.Content = new Login();
                }
            }
        
        private void btnRegistre_Click(object sender, RoutedEventArgs e)
        {
            Window pageRegister = Window.GetWindow(this);
            pageRegister.Content = new Inscription();

        }
    }
}
