using ProjetTransDev.Ctrl;
using System;
using System.Collections.ObjectModel;
namespace ProjetTransDev.ORM
{
    public class ZoneInvestigationORM
    {

        public static ZoneInvestigationViewModel getZoneInvestigation(int idZoneInvestigation)
        {

            ZoneInvestigationDAO pDAO = ZoneInvestigationDAO.getZoneInvestigation(idZoneInvestigation);

            int idEtude = pDAO.IdEtudeDAO;
            EtudeViewModel a = EtudeORM.getEtude(idEtude);

            DateTime EtudeDate = pDAO.EtudeDateDAO;
            EtudeViewModel b = EtudeORM.getEtude(idEtude);

            int idUsers = pDAO.IdUsersDAO;
            UsersViewModel c =  UsersORM.getUsers(idUsers);

            int idPlage = pDAO.IdPlageDAO;
            PlageViewModel d = PlageORM.getPlage(idPlage);

        ZoneInvestigationViewModel p = new ZoneInvestigationViewModel(pDAO.IdZoneDAO, a,d, b, pDAO.NomZoneDAO, pDAO.Angle1DAO,pDAO.Angle2DAO,pDAO.Angle3DAO,pDAO.Angle4DAO, c);
            return p;
        }

        public static ObservableCollection<ZoneInvestigationViewModel> ListeZoneInvestigation()
        {
            ObservableCollection<ZoneInvestigationDAO> lDAO = ZoneInvestigationDAO.listeZoneInvestigations();
            ObservableCollection<ZoneInvestigationViewModel> l = new ObservableCollection<ZoneInvestigationViewModel>();
            foreach (ZoneInvestigationDAO element in lDAO)
            {
                int idEtude = element.IdEtudeDAO;
                EtudeViewModel a = EtudeORM.getEtude(idEtude);

                DateTime EtudeDate = element.EtudeDateDAO;
                EtudeViewModel b = EtudeORM.getEtude(idEtude);

                int idUsers = element.IdUsersDAO;
                UsersViewModel c = UsersORM.getUsers(idUsers);

                int idPlage = element.IdPlageDAO;
                PlageViewModel d = PlageORM.getPlage(idPlage);
                ZoneInvestigationViewModel p = new ZoneInvestigationViewModel(element.IdZoneDAO, a, d,  b, element.NomZoneDAO, element.Angle1DAO, element.Angle2DAO, element.Angle3DAO, element.Angle4DAO, c);
                l.Add(p);
            }
            return l;
        }
        public static void updateZoneInvestigation(ZoneInvestigationViewModel p)
        {
            ZoneInvestigationDAO.updateZoneInvestigation(new ZoneInvestigationDAO(p.IdZoneProperty,p.EtudeProperty.idEtudeProperty,p.PlageProperty.idPlageProperty,  p.EtudeProperty.dateCreationProperty, p.NameZoneProperty, p.Angle1Property,p.Angle2Property,p.Angle3Property,p.Angle4Property, p.UsersProperty.idUsersProperty));
        }

        public static void supprimerZoneInvestigation(int id)
        {
            ZoneInvestigationDAO.supprimerZoneInvestigation(id);
        }
        public static void insertZoneInvestigation(ZoneInvestigationViewModel p)
        {
            ZoneInvestigationDAO.insertZoneInvestigation(new ZoneInvestigationDAO(p.IdZoneProperty, p.EtudeProperty.idEtudeProperty, p.PlageProperty.idPlageProperty,  p.EtudeProperty.dateCreationProperty, p.NameZoneProperty, p.Angle1Property, p.Angle2Property, p.Angle3Property, p.Angle4Property, p.UsersProperty.idUsersProperty));
        }
    }
}
