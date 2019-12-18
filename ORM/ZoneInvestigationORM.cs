using ProjetTransDev.Ctrl;
using System;
using System.Collections.ObjectModel;
namespace ProjetTransDev.ORM
{
    public class ZoneInvestigationORM
    {

        public static ZoneInvestigationViewModel getEtudePlage(int idEtudePlage)
        {

            EtudePlageDAO pDAO = EtudePlageDAO.getEtudePlage(idEtudePlage);

            int idEtude = pDAO.IdEtudeDAO;
            EtudeViewModel a = EtudeORM.getEtude(idEtude);

            DateTime EtudeDate = pDAO.EtudeDateDAO;
            EtudeViewModel b = EtudeORM.getEtude(idEtude);

            int idUsers = pDAO.IdUsersDAO;
            UsersViewModel c =  UsersORM.getUsers(idUsers);

            int idPlage = pDAO.IdPlageDAO;
            PlageViewModel d = PlageORM.getPlage(idPlage);

        ZoneInvestigationViewModel p = new ZoneInvestigationViewModel(pDAO.IdZoneDAO,a,d,c,b,pDAO.Angle1DAO,pDAO.Angle2DAO,pDAO.Angle3DAO,pDAO.Angle4DAO);
            return p;
        }

        public static ObservableCollection<ZoneInvestigationViewModel> ListeEtudePlages()
        {
            ObservableCollection<EtudePlageDAO> lDAO = EtudePlageDAO.listeEtudePlages();
            ObservableCollection<ZoneInvestigationViewModel> l = new ObservableCollection<ZoneInvestigationViewModel>();
            foreach (EtudePlageDAO element in lDAO)
            {
                int idEtude = element.IdEtudeDAO;
                EtudeViewModel a = EtudeORM.getEtude(idEtude);

                DateTime EtudeDate = element.EtudeDateDAO;
                EtudeViewModel b = EtudeORM.getEtude(idEtude);

                int idUsers = element.IdUsersDAO;
                UsersViewModel c = UsersORM.getUsers(idUsers);

                int idPlage = element.IdPlageDAO;
                PlageViewModel d = PlageORM.getPlage(idPlage);
                ZoneInvestigationViewModel p = new ZoneInvestigationViewModel(element.IdZoneDAO,a, d, c, b, element.Angle1DAO, element.Angle2DAO, element.Angle3DAO, element.Angle4DAO);
                l.Add(p);
            }
            return l;
        }
        public static void updateEtudePlage(ZoneInvestigationViewModel p)
        {
            EtudePlageDAO.updateEtudePlage(new EtudePlageDAO(p.IdZoneProperty,p.EtudeProperty.idEtudeProperty,p.PlageProperty.idPlageProperty,p.UsersProperty.idUsersProperty,p.EtudeProperty.dateCreationProperty,p.Angle1Property,p.Angle2Property,p.Angle3Property,p.Angle4Property));
        }

        public static void supprimerEtudePlage(int id)
        {
            EtudePlageDAO.supprimerEtudePlage(id);
        }
        public static void insertEtudePlage(ZoneInvestigationViewModel p)
        {
            EtudePlageDAO.insertEtudePlage(new EtudePlageDAO(p.IdZoneProperty, p.EtudeProperty.idEtudeProperty, p.PlageProperty.idPlageProperty, p.UsersProperty.idUsersProperty, p.EtudeProperty.dateCreationProperty, p.Angle1Property, p.Angle2Property, p.Angle3Property, p.Angle4Property));
        }
    }
}
