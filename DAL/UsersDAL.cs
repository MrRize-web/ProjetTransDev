using System;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetTransDev.ORM;

namespace ProjetTransDev.DAL
{
    public class UsersDAL
    {
        private static MySqlConnection connection;
        public UsersDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            DALConnection.OpenConnection();
            connection = DALConnection.OpenConnection();
        }

        public static ObservableCollection<UsersDAO> selectUsers()
        {
            ObservableCollection<UsersDAO> l = new ObservableCollection<UsersDAO>();
            string query = "SELECT * FROM Users;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UsersDAO p = new UsersDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetByte(6));
                    l.Add(p);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("La base de données n'est pas connectée");
            }
            return l;
        }

        public static void updateUsers(UsersDAO p)
        {
            string query = "UPDATE Users set ( Nom=@NomUsers, Prenom=@PrenomUsers, AdresseMail=@Mail,Identifiant=@Identifiant, MotDePasse=@MDP,  Administrateur=@ADMIN where idUsers=@IdUsers);";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@NomUsers", p.nomUsersDAO);
            cmd.Parameters.AddWithValue("@PrenomUsers", p.prenomUsersDAO);
            cmd.Parameters.AddWithValue("@Mail", p.adresseMailUsersDAO);
            cmd.Parameters.AddWithValue("@Identifiant", p.identifiantUsersDAO);
            cmd.Parameters.AddWithValue("@MDP", p.motDePasseUsersDAO);
            cmd.Parameters.AddWithValue("@ADMIN", p.administrateurUsersDAO);
            cmd.Parameters.AddWithValue("@IdUsers", p.idUsersDAO);

            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
     
        public static void insertUsers(UsersDAO p)
        {
            int id = getMaxIdUsers() + 1;
            string query = "INSERT INTO Users VALUES (@ID,@NomUsers,@PrenomUsers,@Mail,@Identifiant,@MDP,@ADMIN);";   
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@NomUsers", p.nomUsersDAO);
            cmd.Parameters.AddWithValue("@PrenomUsers", p.prenomUsersDAO);
            cmd.Parameters.AddWithValue("@Mail", p.adresseMailUsersDAO);
            cmd.Parameters.AddWithValue("@Identifiant", p.identifiantUsersDAO);
            cmd.Parameters.AddWithValue("@MDP", p.motDePasseUsersDAO);
            cmd.Parameters.AddWithValue("@ADMIN", p.administrateurUsersDAO);
         
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerUsers(int id)
        {
            string query = "DELETE FROM Users WHERE idUsers = @ID;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", id);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static int getMaxIdUsers()
        {
            string query = "SELECT IFNULL(MAX(idUsers),0) FROM Users;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdUsers = reader.GetInt32(0);
            reader.Close();
            return maxIdUsers;
        }
        public static UsersDAO getUsers(int idUsers)
        {
            string query = "SELECT * FROM users WHERE id=@ID;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", idUsers);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            UsersDAO pers = new UsersDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetByte(6));
            reader.Close();
            return pers;
        }
        public static UsersDAO getUsersIdentifiant(string identifiantUsers)
        {
            string query = "SELECT * FROM users WHERE Identifiant=@Identifiant;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@Identifiant", identifiantUsers);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            UsersDAO user;
            if (reader.HasRows)
            {
                user = new UsersDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetByte(6));
            }
            else
            {
                user = new UsersDAO(1, "Name", "First Name", "Identifiant", "@Mail", "MDP",0);
            }
            reader.Close();
            return user;
        }
        public static UsersDAO getUsersMotdePasse(string motDePasseUsers)
        {
            string query = "SELECT * FROM users WHERE MotDePasse=@MDP;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@MDP", motDePasseUsers);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            UsersDAO user;
            if (reader.HasRows)
            {
                user = new UsersDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetByte(6));
            }
            else
            {
                user = new UsersDAO(1, "Name", "First Name", "Identifiant", "@Mail", "MDP", 0);
            }
            reader.Close();
            return user;
        }
    }
}
