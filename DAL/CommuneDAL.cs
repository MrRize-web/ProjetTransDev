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
                string query = "UPDATE Commune set nom=\"" + p.nomCommuneDAO + "\",CodePostale=\"" + p.CodePostaleDAO + "\" where idCommune=" + p.idCommuneDAO + ";";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
            public static void insertCommune(CommuneDAO p)
            {
                string query = "INSERT INTO Commune (Nom,CodePostale,Departement_Departement) VALUES (\"" + p.nomCommuneDAO + "\",\"" + p.CodePostaleDAO + "\",\"" + p.DepartementCommuneDAO + "\");";
                MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
                cmd2.ExecuteNonQuery();
            }
        
        public static void supprimerCommune(int id)
        {
            string query = "DELETE FROM Commune WHERE idCommune = \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static void SelectCommune(int id)
        {
            string query = "SELECT * FROM Commune WHERE idCommune= \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }

        public static CommuneDAO getCommune(int idCommune)
            {
                string query = "SELECT * FROM Commune WHERE idCommune=" + idCommune + ";";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                CommuneDAO pers = new CommuneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                reader.Close();
                return pers;
            }
        }
    }
