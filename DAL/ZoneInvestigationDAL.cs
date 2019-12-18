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

     public static ObservableCollection<ZoneInvestigationDAO> selectZoneInvestigations()
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
           string query = "UPDATE etude_has_plage set Angle1=\"" + p.Angle1DAO + "\",Angle2=\"" + p.Angle2DAO + "\",Angle3=\"" + p.Angle3DAO + "\",Angle4=\"" + p.Angle4DAO + "\"  where Etude_has_Plage_Etude_idEtude=" + p.IdZoneDAO + ";";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
           MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
           cmd.ExecuteNonQuery();
       }
       public static void insertZoneInvestigation(ZoneInvestigationDAO p)
       {
            int id = getMaxIdZoneInvestigation() + 1;
            string query = "INSERT INTO etude_has_plage VALUES (\"" + id + "\",\"" + p.IdEtudeDAO + "\",\"" + p.IdPlageDAO + "\",\"" + p.EtudeDateDAO + "\",\"" + p.Angle1DAO + "\",\"" + p.Angle2DAO + "\",\"" + p.Angle3DAO + "\",\"" + p.Angle4DAO + "\",\"" + p.IdUsersDAO + "\");";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
           MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
           cmd.ExecuteNonQuery();
       }
       public static void supprimerZoneInvestigation(int id)
       {
           string query = "DELETE FROM etude_has_plage WHERE IdZone = \"" + id + "\";";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
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
           int maxIdPlage = reader.GetInt32(0);
           reader.Close();
           return maxIdPlage;
       }
       public static ZoneInvestigationDAO getZoneInvestigation(int IdZone)
       {
           string query = " SELECT * FROM Plage WHERE IdZone =" + IdZone + ";";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
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
               com = new ZoneInvestigationDAO(1,1,1,1, DateTime.Today,0,0,0,0);
           }
           reader.Close();
           return com;
       }
   }
}
