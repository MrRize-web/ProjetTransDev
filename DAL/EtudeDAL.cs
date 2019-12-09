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
            connection = DALConnection.connection;
        }

        public static ObservableCollection<DAO.EtudeDAO> selectEtude()
        {
            ObservableCollection<DAO.EtudeDAO> l = new ObservableCollection<DAO.EtudeDAO>();
            string query = "SELECT * FROM Etude;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DAO.EtudeDAO p = new DAO.EtudeDAO(reader.GetInt32(0), reader.GetDecimal(1), reader.GetDecimal(2), reader.GetString(3));
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

        public static void updateEtude(DAO.EtudeDAO p)
        {
            string query = "UPDATE Etude set nomEtude=\"" + p.TitreEtudeEtudeDAO + "\",NbPersonne=\"" + p.NbPersonneEtudeDAO + "\",NbPlage=\"" + p.NbPlageEtudeDAO + "\"  where idEtude=" + p.idEtudeDAO + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void insertEtude(DAO.EtudeDAO p)
        {
            string query = "INSERT INTO Etude (NbPersonne,NbEtude,Titre) VALUES (\"" + p.NbPersonneEtudeDAO + "\"+\"" + p.NbPlageEtudeDAO + "\",\"" + p.TitreEtudeEtudeDAO + "\");";
            MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
            cmd2.ExecuteNonQuery();
        }
        public static void supprimerEtude(int id)
        {
            string query = "DELETE FROM Etude WHERE idEtude = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            string query = "SELECT * FROM Etude WHERE id=" + idEtude + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DAO.EtudeDAO pers = new DAO.EtudeDAO(reader.GetInt32(0), reader.GetDecimal(1), reader.GetDecimal(2), reader.GetString(3));
            reader.Close();
            return pers;
        }
    }
}
