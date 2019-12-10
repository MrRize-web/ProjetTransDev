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
                string query = "UPDATE departement set Nom=\"" + p.nomDepartementDAO + "\" where Departement=" + p.idDepartementDAO + ";";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
            public static void insertDepartement(DepartementDAO p)
            {
                int id = getMaxIdDepartement() + 1;
                string query = "INSERT INTO departement VALUES (\"" + id + "\",\"" + p.nomDepartementDAO + "\");";
                MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
                cmd2.ExecuteNonQuery();
            }
            public static void supprimerDepartement(int id)
            {
                string query = "DELETE FROM departement WHERE Departement = \"" + id + "\";";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
        public static int getMaxIdDepartement()
        {
            string query = "SELECT IFNULL(MAX(Departement),0) FROM departement;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int maxIdDepartement = reader.GetInt32(0);
            reader.Close();
            return maxIdDepartement;
        }

        public static DepartementDAO getDepartement(int idDepartement)
        {
            string query = " SELECT * FROM departement WHERE Departement =" + idDepartement + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DepartementDAO com;
            if (reader.HasRows)
            {
                com = new DepartementDAO(reader.GetInt32(0), reader.GetString(1));
            }
            else
            {
                com = new DepartementDAO(1, "Mauvais Num Commune");
            }
            reader.Close();
            return com;
        }
    }
    }




