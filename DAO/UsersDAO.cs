﻿using System;
using System.Collections.ObjectModel;
using ProjetTransDev.DAL;

namespace ProjetTransDev.ORM
{
    public class UsersDAO
    {
        public int idUsersDAO;
        public string nomUsersDAO;
        public string prenomUsersDAO;
        public string identifiantDAOUsersDAO;
        public Byte administrateurUsersDAO;
        public string identifiantUsersDAO;
        public string adresseMailUsersDAO;
        public string motDePasseUsersDAO;

        public UsersDAO(int idUsersDAO, string nomUsersDAO, string prenomUsersDAO, string adresseMailDAO, string identifiantDAO,  string motDePasseDAO, Byte administrateurDAO)
        {
            this.idUsersDAO = idUsersDAO;
            this.nomUsersDAO = nomUsersDAO;
            this.prenomUsersDAO = prenomUsersDAO;
            this.identifiantUsersDAO = identifiantDAO;
            this.adresseMailUsersDAO = adresseMailDAO;
            this.motDePasseUsersDAO = motDePasseDAO;
            this.administrateurUsersDAO = administrateurDAO;
        }

        public static ObservableCollection<UsersDAO> listeUsers()
        {
            ObservableCollection<UsersDAO> l = UsersDAL.selectUsers();
            return l;
        }
      
        public static UsersDAO getUsers(int idUsers)
        {
            UsersDAO p = UsersDAL.getUsers(idUsers);
            return p;
        }
        public static UsersDAO getUsersIdentifiant(string identifiantUsers)
        {
          UsersDAO p = UsersDAL.getUsersIdentifiant(identifiantUsers);
            return p;
        }
        public static UsersDAO getUsersMotdePasse(string motDePasseUsers)
        {
            UsersDAO p = UsersDAL.getUsersMotdePasse(motDePasseUsers);
            return p;
        }

        public static void updateUsers(UsersDAO p)
        {
            UsersDAL.updateUsers(p);
        }

        public static void supprimerUsers(int id)
        {
            UsersDAL.supprimerUsers(id);
        }

        public static void insertUsers(UsersDAO p)
        {
            UsersDAL.insertUsers(p);
        }
    }
}
