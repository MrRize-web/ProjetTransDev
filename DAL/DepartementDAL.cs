﻿using System;
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
                    DepartementDAO p = new DepartementDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
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
            string query = "UPDATE departement set Nom=@NomDepartement,CodePostale=@CodePOSTALE where Departement=@IdDepartement;";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                cmd.Parameters.AddWithValue("@NomDepartement", p.nomDepartementDAO);
                cmd.Parameters.AddWithValue("@CodePOSTALE", p.CodePostaleDAO);
                cmd.Parameters.AddWithValue("@IdDepartement", p.idDepartementDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
                cmd.ExecuteNonQuery();
            }
            public static void insertDepartement(DepartementDAO p)
            {
                int id = getMaxIdDepartement() + 1;
                string query = "INSERT INTO departement VALUES (@ID,@NomDepartement,@CodePostale);";
                MySqlCommand cmd2 = new MySqlCommand(query, DALConnection.OpenConnection());
                cmd2.Parameters.AddWithValue("@ID", id);
                cmd2.Parameters.AddWithValue("@NomDepartement", p.nomDepartementDAO);
                cmd2.Parameters.AddWithValue("@CodePostale", p.CodePostaleDAO);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2);
                cmd2.ExecuteNonQuery();
            }
            public static void supprimerDepartement(int id)
            {
                string query = "DELETE FROM departement WHERE Departement = @ID; ";
                MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
                cmd.Parameters.AddWithValue("@ID", id);
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
            string query = " SELECT * FROM departement WHERE Departement =@IdDepartement;";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.Parameters.AddWithValue("@IdDepartement", idDepartement);
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            DepartementDAO com;
            if (reader.HasRows)
            {
                com = new DepartementDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
            }
            else
            {
                com = new DepartementDAO(1, "Mauvais Nom Departement", "Mauvais Code Postale");
            }
            reader.Close();
            return com;
        }
    }
    }




