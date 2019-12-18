
using System;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetTransDev.DAO;
using ProjetTransDev.ORM;

namespace ProjetTransDev.DAL
{
    public class ZoneInvestigationDAL
    {
        private static MySqlConnection connection;
        public ZoneInvestigationDAL()
        {
            DALConnection.OpenConnection();
            connection = DALConnection.OpenConnection();
        }

        public static ObservableCollection<ZoneInvestigationDAO> selectZoneInvestigation()
        {
            ObservableCollection<ZoneInvestigationDAO> l = new ObservableCollection<ZoneInvestigationDAO>();
            string query = "SELECT * FROM etude_has_plage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ZoneInvestigationDAO p = new ZoneInvestigationDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4), reader.GetDecimal(5), reader.GetDecimal(6), reader.GetDecimal(7), reader.GetDecimal(8));
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

        public static void updateZoneInvestigation(ZoneInvestigationDAO p)
        {
            string query = "UPDATE etude_has_plage set Angle1=@Angle1,Angle2=@Angle2,Angle3=@Angle3,Angle4=@Angle4 where IdZone=@IdZone;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@IdZone", p.IdZoneDAO);
            cmd.Parameters.AddWithValue("@Angle1", p.Angle1DAO);
            cmd.Parameters.AddWithValue("@Angle2", p.Angle2DAO);
            cmd.Parameters.AddWithValue("@Angle3", p.Angle3DAO);
            cmd.Parameters.AddWithValue("@Angle4", p.Angle4DAO);

            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertZoneInvestigation(ZoneInvestigationDAO p)
        {
            int id = getMaxIdZoneInvestigation() + 1;
            string query = "INSERT INTO etude_has_plage VALUES (@ID,@Nombre,@Titre,@Plage,@DateCrea,@DateFin);";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@Nombre", id);
            cmd.Parameters.AddWithValue("@Titre", p.IdEtudeDAO);
            cmd.Parameters.AddWithValue("@Plage", p.IdPlageDAO);
            cmd.Parameters.AddWithValue("@DateCrea", p.EtudeDateDAO);
            cmd.Parameters.AddWithValue("@Angle1", p.Angle1DAO);
            cmd.Parameters.AddWithValue("@Angle1", p.Angle2DAO);
            cmd.Parameters.AddWithValue("@Angle1", p.Angle3DAO);
            cmd.Parameters.AddWithValue("@Angle1", p.Angle4DAO);
            cmd.Parameters.AddWithValue("@IdUsers", p.IdUsersDAO);

            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void supprimerZoneInvestigation(int id)
        {
            string query = "DELETE FROM etude_has_plage WHERE IdZone = @ID;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", id);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static int getMaxIdZoneInvestigation()
        {
            string query = "SELECT IFNULL(MAX(IdZone),0) FROM etude_has_plage;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdEtude = reader.GetInt32(0);
            reader.Close();
            return maxIdEtude;
        }

        public static ZoneInvestigationDAO getZoneInvestigation(int IdZone)
        {
            string query = " SELECT * FROM etude_has_plage WHERE IdZone =@ID;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@ID", IdZone);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            ZoneInvestigationDAO com;
            if (reader.HasRows)
            {
                com = new ZoneInvestigationDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4), reader.GetDecimal(5), reader.GetDecimal(6), reader.GetDecimal(7), reader.GetDecimal(8));
            }
            else
            {
                com = new ZoneInvestigationDAO(1, 1, 1, 1, DateTime.Today, 0, 0, 0, 0);
            }
            reader.Close();
            return com;
        }
    }
}
