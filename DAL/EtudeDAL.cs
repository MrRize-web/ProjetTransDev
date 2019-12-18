using System;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetTransDev.DAO;
using ProjetTransDev.ORM;

namespace ProjetTransDev.DAL
{
    public class EtudeDAL
    {
        private static MySqlConnection connection;
        public EtudeDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.OpenConnection();
        }

        public static ObservableCollection<EtudeDAO> selectEtude()
        {
            ObservableCollection<EtudeDAO> l = new ObservableCollection<EtudeDAO>();
            string query = "SELECT * FROM Etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EtudeDAO p = new EtudeDAO(reader.GetInt32(0), reader.GetDecimal(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4), reader.GetDateTime(5));
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

        public static void updateEtude(EtudeDAO p)
        {
            string query = "UPDATE Etude set NbPersonne=@Nombre,Titre=@Titre,NbPlage=@Plage,dateCreation=@DateCrea, dateFin=@DateFin  where idEtude=@IdEude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@Nombre", p.NbPersonneEtudeDAO);
            cmd.Parameters.AddWithValue("@Titre", p.TitreEtudeEtudeDAO);
            cmd.Parameters.AddWithValue("@Plage", p.PlageEtudeDAO);
            cmd.Parameters.AddWithValue("@DateCrea", p.dateCreationDAO);
            cmd.Parameters.AddWithValue("@DateFin", p.dateFinDAO);
            cmd.Parameters.AddWithValue("@IdEude", p.idEtudeDAO);

            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEtude(EtudeDAO p)
        {
            int id = getMaxIdEtude() + 1;
            string query = "INSERT INTO Etude VALUES (@ID,@Nombre,@Titre,@Plage,@DateCrea,@DateFin);";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Nombre", p.NbPersonneEtudeDAO);
            cmd.Parameters.AddWithValue("@Titre", p.TitreEtudeEtudeDAO);
            cmd.Parameters.AddWithValue("@Plage", p.PlageEtudeDAO);
            cmd.Parameters.AddWithValue("@DateCrea", p.dateCreationDAO);
            cmd.Parameters.AddWithValue("@DateFin", p.dateFinDAO);
      
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerEtude(int id)
        {
            string query = "DELETE FROM Etude WHERE idEtude = @ID;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", id);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdEtude()
        {
            string query = "SELECT IFNULL(MAX(idEtude),0) FROM etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdEtude = reader.GetInt32(0);
            reader.Close();
            return maxIdEtude;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            string query = " SELECT * FROM etude WHERE idEtude =@ID;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", idEtude);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EtudeDAO com;
            if (reader.HasRows)
            {
                com = new EtudeDAO(reader.GetInt32(0), reader.GetDecimal(1), reader.GetString(2), reader.GetInt32(3), reader.GetDateTime(4), reader.GetDateTime(5));
            }
            else
            {
                com = new EtudeDAO(1, 0, "Mauvaise superficie d'etude", 1 , DateTime.Today, DateTime.Today);
            }
            reader.Close();
            return com;
        }
    }
}
