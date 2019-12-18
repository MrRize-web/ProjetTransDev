using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProjetTransDev.DAL;

namespace ProjetTransDev.ORM
{
    public class ZoneInvestigationDAO
    {

        public Decimal Angle1DAO;
        public Decimal Angle2DAO;
        public Decimal Angle3DAO;
        public Decimal Angle4DAO;
        public DateTime EtudeDateDAO;
        public int IdZoneDAO;
        public int  IdEtudeDAO;   
        public int  IdUsersDAO;
        public int  IdPlageDAO;
        public ZoneInvestigationDAO(int IdZoneDAO, int IdEtudeDAO, int IdPlageDAO,   DateTime EtudeDateDAO, Decimal Angle1DAO, Decimal Angle2DAO, Decimal Angle3DAO, Decimal Angle4DAO,int IdUsersDAO)
        {
            this.IdZoneDAO = IdZoneDAO;
            this.IdPlageDAO = IdPlageDAO;
            this.IdUsersDAO = IdUsersDAO;
            this.IdEtudeDAO = IdEtudeDAO;
            this.EtudeDateDAO = EtudeDateDAO;
            this.Angle1DAO = Angle1DAO;
            this.Angle2DAO = Angle2DAO;
            this.Angle3DAO = Angle3DAO;
            this.Angle4DAO = Angle4DAO;
        }

        public static ObservableCollection<ZoneInvestigationDAO> listeZoneInvestigations()
        {
            ObservableCollection<ZoneInvestigationDAO> l = ZoneInvestigationDAL.selectZoneInvestigation();
            return l;
        }

        public static ZoneInvestigationDAO getZoneInvestigation(int IdZoneDAO)
        {
            ZoneInvestigationDAO p = ZoneInvestigationDAL.getZoneInvestigation(IdZoneDAO);
            return p;
        }

        public static void updateZoneInvestigation(ZoneInvestigationDAO p)
        {
            ZoneInvestigationDAL.updateZoneInvestigation(p);
        }

        public static void supprimerZoneInvestigation(int id)
        {
            ZoneInvestigationDAL.supprimerZoneInvestigation(id);
        }

        public static void insertZoneInvestigation(ZoneInvestigationDAO p)
        {
            ZoneInvestigationDAL.insertZoneInvestigation(p);
        }
    }
}
