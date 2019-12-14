/* using System;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
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
                   EtudePlageDAO p = new EtudePlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
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

       public static void updatePlage(EtudePlageDAO p)
       {
           string query = "UPDATE etude_has_plage set Angle1=\"" + p.Angle1DAO + "\",Angle2=\"" + p.Angle2DAO + "\",Angle3=\"" + p.Angle3DAO + "\",Angle4=\"" + p.Angle4DAO + "\"  where Etude_idEtude=" + p.EtudeDAO + ";";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
           MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
           cmd.ExecuteNonQuery();
       }
       public static void insertPlage(EtudePlageDAO p)
       {
           string query = "INSERT INTO etude_has_plage VALUES (\"" + p.Angle1DAO + "\",\"" + p.Angle2DAO + "\",\"" + p.Angle3DAO + "\",\"" + p.Angle4DAO + "\");";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
           MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
           cmd.ExecuteNonQuery();
       }
       public static void supprimerPlage(int id)
       {
           string query = "DELETE FROM etude_has_plage WHERE idPlage = \"" + id + "\";";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
           MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
           cmd.ExecuteNonQuery();
       }
       public static int getMaxIdEtudePlage()
       {
           string query = "SELECT IFNULL(MAX(idPlage),0) FROM etude_has_plage;";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
           cmd.ExecuteNonQuery();

           MySqlDataReader reader = cmd.ExecuteReader();
           reader.Read();
           int maxIdPlage = reader.GetInt32(0);
           reader.Close();
           return maxIdPlage;
       }
       public static EtudePlageDAO getEtudePlage(int idPlage)
       {
           string query = " SELECT * FROM Plage WHERE idPlage =" + idPlage + ";";
           MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
           cmd.ExecuteNonQuery();
           MySqlDataReader reader = cmd.ExecuteReader();
           reader.Read();
           EtudePlageDAO com;
           if (reader.HasRows)
           {
               com = new EtudePlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
           }
           else
           {
               com = new EtudePlageDAO(1, "Mauvais Nom de Plage", "Mauvaise superficie d'etude", 1);
           }
           reader.Close();
           return com;
       }
   }
}
*/
