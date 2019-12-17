using System;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetTransDev.DAO;
using ProjetTransDev.ORM;

namespace ProjetTransDev.DAL
{
   public class EtudePlageDAL
   {
       private static MySqlConnection connection;
       public EtudePlageDAL()
       {
           DALConnection.OpenConnection();
           connection = DALConnection.OpenConnection();
       }

     public static ObservableCollection<EtudePlageDAO> selectEtudePlages()
       {
           ObservableCollection<EtudePlageDAO> l = new ObservableCollection<EtudePlageDAO>();
           string query = "SELECT * FROM etude_has_plage;";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
           try
           {
               cmd.ExecuteNonQuery();
               MySqlDataReader reader = cmd.ExecuteReader();

               while (reader.Read())
               {
                   EtudePlageDAO p = new EtudePlageDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4), reader.GetDecimal(5), reader.GetDecimal(6), reader.GetDecimal(7), reader.GetDecimal(8));
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

       public static void updateEtudePlage(EtudePlageDAO p)
       {
           string query = "UPDATE etude_has_plage set Angle1=\"" + p.Angle1DAO + "\",Angle2=\"" + p.Angle2DAO + "\",Angle3=\"" + p.Angle3DAO + "\",Angle4=\"" + p.Angle4DAO + "\"  where Etude_has_Plage_Etude_idEtude=" + p.IdZoneDAO + ";";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
           MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
           cmd.ExecuteNonQuery();
       }
       public static void insertEtudePlage(EtudePlageDAO p)
       {
            int id = getMaxIdEtudePlage() + 1;
            string query = "INSERT INTO etude_has_plage VALUES (\"" + id + "\",\"" + p.IdEtudeDAO + "\",\"" + p.IdPlageDAO + "\",\"" + p.EtudeDateDAO + "\",\"" + p.Angle1DAO + "\",\"" + p.Angle2DAO + "\",\"" + p.Angle3DAO + "\",\"" + p.Angle4DAO + "\",\"" + p.IdUsersDAO + "\");";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
           MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
           cmd.ExecuteNonQuery();
       }
       public static void supprimerEtudePlage(int id)
       {
           string query = "DELETE FROM etude_has_plage WHERE IdZone = \"" + id + "\";";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
           MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
           cmd.ExecuteNonQuery();
       }
       public static int getMaxIdEtudePlage()
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
       public static EtudePlageDAO getEtudePlage(int IdZone)
       {
           string query = " SELECT * FROM Plage WHERE IdZone =" + IdZone + ";";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
           cmd.ExecuteNonQuery();
           MySqlDataReader reader = cmd.ExecuteReader();
           reader.Read();
           EtudePlageDAO com;
           if (reader.HasRows)
           {
               com = new EtudePlageDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetDateTime(4), reader.GetDecimal(5), reader.GetDecimal(6), reader.GetDecimal(7), reader.GetDecimal(8));
           }
           else
           {
               com = new EtudePlageDAO(1,1,1,1, DateTime.Today,0,0,0,0);
           }
           reader.Close();
           return com;
       }
   }
}
