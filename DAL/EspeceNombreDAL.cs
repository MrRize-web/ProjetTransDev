using System;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetTransDev.ORM;

namespace ProjetTransDev.DAL
{
    public class EspeceNombreDAL
    {
        private static MySqlConnection connection;
        public EspeceNombreDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.OpenConnection();
        }

        public static ObservableCollection<EspeceNombreDAO> selectEspeceNombres()
        {
            ObservableCollection<EspeceNombreDAO> l = new ObservableCollection<EspeceNombreDAO>();
            string query = "SELECT * FROM etude_has_plage_has_Espece;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    EspeceNombreDAO p = new EspeceNombreDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetDecimal(5));
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

        public static void updateEspeceNombre(EspeceNombreDAO p)
        {
            string query = "UPDATE etude_has_plage_has_Espece  set Nombre=@Nombre where Etude_has_Plage_Etude_idEtude=@IdNombre;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@Nombre", p.NombreDAO);
            cmd.Parameters.AddWithValue("@IdNombre", p.IdNombreEDAO);
        
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEspeceNombre(EspeceNombreDAO p)
        {
            int id = getMaxIdEspeceNombre() + 1;
            string query = "INSERT INTO etude_has_plage_has_Espece  VALUES (@ID,@IdEspece,@IdZone,@IdEtude,@IdPlage,@Nombre);";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@IdEspece", p.IdEspeceDAO);
            cmd.Parameters.AddWithValue("@IdZone", p.IdZoneDAO);
            cmd.Parameters.AddWithValue("@IdEtude", p.IdEtudeDAO);
            cmd.Parameters.AddWithValue("@IdPlage", p.IdPlageDAO);
            cmd.Parameters.AddWithValue("@Nombre", p.NombreDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerEspeceNombre(int idEspeceNombre)
        {
            string query = "DELETE FROM etude_has_plage_has_Espece WHERE IdNombreE = @IdNombreE;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@IdNombreE", idEspeceNombre);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdEspeceNombre()
        {
            string query = "SELECT IFNULL(MAX(IdNombreE),0) FROM etude_has_plage_has_Espece ;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdPlage = reader.GetInt32(0);
            reader.Close();
            return maxIdPlage;
        }
        public static EspeceNombreDAO getEspeceNombre(int idEspeceNombre)
        {
            string query = " SELECT * FROM etude_has_plage_has_Espece WHERE IdNombreE = @IdNombreE;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@IdNombreE", idEspeceNombre);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            EspeceNombreDAO com;
            if (reader.HasRows)
            {
                com = new EspeceNombreDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetDecimal(5));
            }
            else
            {
                com = new EspeceNombreDAO(1, 1, 1, 1,1, 0);
            }
            reader.Close();
            return com;
        }
    }
}
