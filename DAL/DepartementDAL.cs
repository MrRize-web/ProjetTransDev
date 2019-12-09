using System;
using System.Collections.ObjectModel;
using System.Windows;
using MySql.Data.MySqlClient;
using ProjetTransDev.ORM;

namespace ProjetTransDev.DAL
{
    public class DepartementDAL
        {
            private static MySqlConnection connection;
            public DepartementDAL()
            {
                DALConnection.OpenConnection();
                connection = DALConnection.OpenConnection();
            }

            public static ObservableCollection<CommunePlageDAO> selectDepartements()
            {
                ObservableCollection<CommunePlageDAO> l = new ObservableCollection<CommunePlageDAO>();
                string query = "SELECT * FROM departement;";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                try
                {
                    cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                    CommunePlageDAO p = new CommunePlageDAO(reader.GetInt32(0), reader.GetString(1));
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

            public static void updateDepartement(CommunePlageDAO p)
            {
                string query = "UPDATE departement set nomDepartement=\"" + p.nomDepartementDAO + "\" where Departement=" + p.idDepartementDAO + ";";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
            public static void insertDepartement(CommunePlageDAO p)
            {
                string query = "INSERT INTO departement (Nom) VALUES (\"" + p.nomDepartementDAO + "\");";
                MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
                cmd2.ExecuteNonQuery();
            }
            public static void selectDepartement(int id)
            {
                string query = "DELETE FROM departement WHERE Departement = \"" + id + "\";";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
        public static void SelectDepartement(int id)
        {
            string query = "SELECT * FROM Departement WHERE Departement= \"" + id + "\";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
        public static CommunePlageDAO getDepartement(int idDepartement)
            {
             
            string query = "SELECT * FROM Users departement id=" + idDepartement + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            CommunePlageDAO pers = new CommunePlageDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return pers;
        }
        }
    }




