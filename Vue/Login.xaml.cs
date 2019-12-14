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
          //  try
           // {
                if (DALConnection.OpenConnection().State == ConnectionState.Closed)
                    DALConnection.OpenConnection();
                String query = "SELECT COUNT(1) FROM users WHERE Identifiant=@Username AND MotDePasse=@Password";
                MySqlCommand sqlCmd = new MySqlCommand(query, DALConnection.OpenConnection());
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@Username", Identifiant.Text);
                sqlCmd.Parameters.AddWithValue("@Password", MotDePasse.Password);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                if (count == 1)
                {
                    window.Content = new MenuSelection();
                }
                else
                {
                    MessageBox.Show("Identifiant ou mot de passe est incorrecte.");
                    window.Content = new MauvaisLogin();
                
                }
         //}
         //   catch (Exception ex)
          //  {
          //      MessageBox.Show(ex.Message);
          //  }
          //  finally
          //  {
           //     DALConnection.OpenConnection();
          //  }
        }
    }
}
