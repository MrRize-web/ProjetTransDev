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
                connection = DALConnection.connection;
            }

            public static ObservableCollection<DepartementDAO> selectDepartements()
            {
                ObservableCollection<DepartementDAO> l = new ObservableCollection<DepartementDAO>();
                string query = "SELECT * FROM departement;";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                try
                {
                    cmd.ExecuteNonQuery();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                    DepartementDAO p = new DepartementDAO(reader.GetInt32(0), reader.GetString(1));
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

            public static void updateDepartement(DepartementDAO p)
            {
                string query = "UPDATE departement set nomDepartement=\"" + p.nomDepartementDAO + "\" where Departement=" + p.idDepartementDAO + ";";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
            public static void insertDepartement(DepartementDAO p)
            {
                string query = "INSERT INTO departement (Nom) VALUES (\"" + p.nomDepartementDAO + "\");";
                MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.connection);
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
                cmd2.ExecuteNonQuery();
            }
            public static void supprimerDepartement(int id)
            {
                string query = "DELETE FROM departement WHERE Departement = \"" + id + "\";";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }

            public static DepartementDAO getDepartement(int idDepartement)
            {
                string query = "SELECT * FROM departement WHERE Departement =" + idDepartement + ";";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.connection);
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                DepartementDAO pers = new DepartementDAO(reader.GetInt32(0), reader.GetString(1));
                reader.Close();
                return pers;
            }
        }
    }




