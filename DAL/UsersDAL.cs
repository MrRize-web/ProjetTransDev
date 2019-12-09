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
            connection = DALConnection.connection;
        }

        public static ObservableCollection<UsersDAO> selectUsers()
        {
            ObservableCollection<UsersDAO> l = new ObservableCollection<UsersDAO>();
            string query = "SELECT * FROM users;";
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
            string query = "UPDATE users (Nom,Prenom,Identifiant,MotDePasse,AdresseMail,Administrateur) set ( Nom=\"" + p.nomUsersDAO + "\", Prenom=\"" + p.prenomUsersDAO + "\", Identifiant=\"" + p.identifiantUsersDAO + "\", MotDePasse=\"" + p.motDePasseUsersDAO + "\", AdresseMail=\"" + p.adresseMailUsersDAO + "\", Administrateur=\"" + p.administrateurUsersDAO +"\" where idUsers=" + p.idUsersDAO + ");";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertUsers(UsersDAO p)
        {   
            string query = "INSERT INTO users (Nom,Prenom,Identifiant,MotDePasse,AdresseMail,Administrateur) VALUES (\"" + p.nomUsersDAO + "\",\"" + p.prenomUsersDAO + "\",\"" + p.identifiantUsersDAO + "\",\"" + p.motDePasseUsersDAO + "\",\"" + p.adresseMailUsersDAO + "\",\"" + p.administrateurUsersDAO + "\");";
            MySqlCommand cmd1 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd1);
            cmd1.ExecuteNonQuery();
        }
        public static void supprimerUsers(int id)
        {
            string query = "DELETE FROM users WHERE idUsers = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
 
        public static UsersDAO getUsers(int idUsers)
        {
            string query = "SELECT * FROM Users WHERE id=" + idUsers + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            UsersDAO pers = new UsersDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetByte(6));
            reader.Close();
            return pers;
        }
    }
}
