using System;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetTransDev.ORM;


namespace ProjetTransDev.DAL
{
    public class CommuneDAL
        {
            private static MySqlConnection connection;
            public CommuneDAL()
            {
                DALConnection.OpenConnection();
                connection = DALConnection.OpenConnection();
            }

            public static ObservableCollection<CommuneDAO> selectCommunes()
            {
                ObservableCollection<CommuneDAO> l = new ObservableCollection<CommuneDAO>();
                string query = "SELECT * FROM Commune;";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                try
                {
                    cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                    CommuneDAO p = new CommuneDAO(reader.GetInt32(0), reader.GetString(1),reader.GetString(2), reader.GetInt32(3));
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
            public static void updateCommune(CommuneDAO p)
            {
            string query = "UPDATE Commune set Nom=@NomCommune,CodePostale=@CodePostale where idCommune=@IdCommune;";
               MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                cmd.Parameters.AddWithValue("@NomCommune", p.nomCommuneDAO);
                cmd.Parameters.AddWithValue("@CodePostale", p.CodePostaleDAO);
                cmd.Parameters.AddWithValue("@IdCommune", p.idCommuneDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
            public static void insertCommune(CommuneDAO p)
            {
            int id = getMaxIdCommune() + 1;
            string query = "INSERT INTO Commune VALUES (@ID,@NomCommune,@CodePostale,@IdCommune);";
                MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd2.Parameters.AddWithValue("@ID", id);
            cmd2.Parameters.AddWithValue("@NomCommune", p.nomCommuneDAO);
            cmd2.Parameters.AddWithValue("@CodePostale", p.CodePostaleDAO);
            cmd2.Parameters.AddWithValue("@IdCommune", p.idCommuneDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
                cmd2.ExecuteNonQuery();
            }
        
        public static void supprimerCommune(int id)
        {
            string query = "DELETE FROM Commune WHERE idCommune = @ID;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", id);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void SelectCommune(int id)
        {
            string query = "SELECT * FROM Commune WHERE idCommune= @ID;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", id);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdCommune()
        {
            string query = "SELECT IFNULL(MAX(idCommune),0) FROM commune;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdCommune = reader.GetInt32(0);
            reader.Close();
            return maxIdCommune;
        }
        public static CommuneDAO getCommune(int idCommune)
        {
            string query = "SELECT * FROM commune WHERE idCommune=@IDCommune;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@IDCommune", idCommune);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CommuneDAO com;
            if (reader.HasRows)
            {
                com = new CommuneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            }
            else
            {
                com = new CommuneDAO(1, "Mauvais Num Commune","Mauvais Code Postale", 1);
            }
            reader.Close();
            return com;
        }
        }
    }
