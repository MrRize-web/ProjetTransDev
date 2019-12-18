using System;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetTransDev.ORM;

namespace ProjetTransDev.DAL
{
    public class EspeceDAL
    {
        private static MySqlConnection connection;
        public EspeceDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.OpenConnection();
        }

        public static ObservableCollection<EspeceDAO> selectEspeces()
        {
            ObservableCollection<EspeceDAO> l = new ObservableCollection<EspeceDAO>();
            string query = "SELECT * FROM espece;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EspeceDAO p = new EspeceDAO(reader.GetInt32(0), reader.GetString(1));
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

        public static void updateEspece(EspeceDAO p)
        {
            string query = "UPDATE espece set nomEspece=@NomEspece  where idEspece=@IdEspece;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@NomEspece", p.nomEspeceDAO);
            cmd.Parameters.AddWithValue("@IdEspece", p.idEspeceDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEspece(EspeceDAO p)
        {
            string query = "INSERT INTO espece (Nom) VALUES (@NomEspece);";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd2.Parameters.AddWithValue("@NomEspece", p.nomEspeceDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEspece(int idEspece)
        {
            string query = "DELETE FROM espece WHERE idEspece = @ID;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", idEspece);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static EspeceDAO getEspece(int idEspece)
        {
            string query = "SELECT * FROM espece WHERE idEspece=@IdEspece;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@IdEspece", idEspece);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EspeceDAO pers = new EspeceDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return pers;
        }
    }
}
