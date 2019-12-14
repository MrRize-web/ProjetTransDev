
using System;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetTransDev.ORM;

namespace ProjetTransDev.DAL
{
    public class PlageDAL
    {
        private static MySqlConnection connection;
        public PlageDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.OpenConnection();
        }

        public static ObservableCollection<PlageDAO> selectPlages()
        {
            ObservableCollection<PlageDAO> l = new ObservableCollection<PlageDAO>();
            string query = "SELECT * FROM Plage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PlageDAO p = new PlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
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

        public static void updatePlage(PlageDAO p)
        {
            string query = "UPDATE Plage set Nom=@NomPlage,SuperficEtude=@Superfi  where idPlage=@IdPlage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@NomPlage", p.nomPlageDAO);
            cmd.Parameters.AddWithValue("@Superfi", p.superficEtudePlageDAO);
            cmd.Parameters.AddWithValue("@IdPlage", p.idPlageDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertPlage(PlageDAO p)
        {
            int id = getMaxIdPlage() + 1;
            string query = "INSERT INTO Plage VALUES (@ID,@NomPlage,@Superfi,@Commune);";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@NomPlage", p.nomPlageDAO);
            cmd.Parameters.AddWithValue("@Superfi", p.superficEtudePlageDAO);
            cmd.Parameters.AddWithValue("@Commune", p.CommuneDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerPlage(int id)
        {
            string query = "DELETE FROM Plage WHERE idPlage = @ID;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", id);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdPlage()
        {
            string query = "SELECT IFNULL(MAX(idPlage),0) FROM plage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdPlage = reader.GetInt32(0);
            reader.Close();
            return maxIdPlage;
        }
        public static PlageDAO getPlage(int idPlage)
        {
            string query = " SELECT * FROM Plage WHERE idPlage =@ID;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", idPlage);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            PlageDAO com;
            if (reader.HasRows)
            {
                com = new PlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            }
            else
            {
                com = new PlageDAO(1, "Mauvais Nom de Plage","Mauvaise superficie d'etude",1);
            }
            reader.Close();
            return com;
        }
    }
}
