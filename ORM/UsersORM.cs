using System;
using System.Collections.ObjectModel;
using ProjetTransDev.Ctrl;

namespace ProjetTransDev.ORM
{
    public class UsersORM
    {

        public static UsersViewModel getUsers(int idUsers)
        {
            UsersDAO pDAO = UsersDAO.getUsers(idUsers);
            UsersViewModel p = new UsersViewModel(pDAO.idUsersDAO, pDAO.nomUsersDAO, pDAO.prenomUsersDAO, pDAO.identifiantUsersDAO, pDAO.adresseMailUsersDAO, pDAO.motDePasseUsersDAO, pDAO.administrateurUsersDAO);
            return p;
        }
        public static UsersViewModel getUsersIdentifiant(string identifiantUsers)
        {
            UsersDAO pDAO = UsersDAO.getUsersIdentifiant(identifiantUsers);
            UsersViewModel p = new UsersViewModel(pDAO.idUsersDAO, pDAO.nomUsersDAO, pDAO.prenomUsersDAO, pDAO.identifiantUsersDAO, pDAO.adresseMailUsersDAO, pDAO.motDePasseUsersDAO, pDAO.administrateurUsersDAO);
            return p;
        }
        public static UsersViewModel getUsersMotdePasse(string motDePasseUsers)
        {
            UsersDAO pDAO = UsersDAO.getUsersMotdePasse(motDePasseUsers);
            UsersViewModel p = new UsersViewModel(pDAO.idUsersDAO, pDAO.nomUsersDAO, pDAO.prenomUsersDAO, pDAO.identifiantUsersDAO, pDAO.adresseMailUsersDAO, pDAO.motDePasseUsersDAO, pDAO.administrateurUsersDAO);
            return p;
        }

        public static ObservableCollection<UsersViewModel> listeUsers()
        {
            ObservableCollection<UsersDAO> lDAO = UsersDAO.listeUsers();
            ObservableCollection<UsersViewModel> l = new ObservableCollection<UsersViewModel>();
            foreach (UsersDAO element in lDAO)
            {
                UsersViewModel p = new UsersViewModel(element.idUsersDAO, element.nomUsersDAO, element.prenomUsersDAO, element.identifiantUsersDAO, element.adresseMailUsersDAO, element.motDePasseUsersDAO, element.administrateurUsersDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateUsers(UsersViewModel p)
        {
            UsersDAO.updateUsers(new UsersDAO(p.idUsersProperty, p.nomUsersProperty, p.prenomUsersProperty, p.identifiantUsersProperty, p.adresseMailUsersProperty, p.motDePasseUsersProperty, p.administrateurUsersProperty));
        }

        public static void supprimerUsers(int id)
        {
            UsersDAO.supprimerUsers(id);
        }

        public static void insertUsers(UsersViewModel p)
        {
            UsersDAO.insertUsers(new UsersDAO(p.idUsersProperty, p.nomUsersProperty, p.prenomUsersProperty, p.identifiantUsersProperty, p.adresseMailUsersProperty, p.motDePasseUsersProperty, p.administrateurUsersProperty));
        }
    }
}
