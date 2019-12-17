using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProjetTransDev.DAL;

namespace ProjetTransDev.ORM
{
    public class EtudePlageDAO
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
        public EtudePlageDAO(int IdZoneDAO, int IdEtudeDAO, int IdPlageDAO, int IdUsersDAO,  DateTime EtudeDateDAO, Decimal Angle1DAO, Decimal Angle2DAO, Decimal Angle3DAO, Decimal Angle4DAO)
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

        public static ObservableCollection<EtudePlageDAO> listeEtudePlages()
        {
            ObservableCollection<EtudePlageDAO> l = EtudePlageDAL.selectEtudePlages();
            return l;
        }

        public static EtudePlageDAO getEtudePlage(int IdZoneDAO)
        {
            EtudePlageDAO p = EtudePlageDAL.getEtudePlage(IdZoneDAO);
            return p;
        }

        public static void updateEtudePlage(EtudePlageDAO p)
        {
            EtudePlageDAL.updateEtudePlage(p);
        }

        public static void supprimerEtudePlage(int id)
        {
            EtudePlageDAL.supprimerEtudePlage(id);
        }

        public static void insertEtudePlage(EtudePlageDAO p)
        {
            EtudePlageDAL.insertEtudePlage(p);
        }
    }
}
