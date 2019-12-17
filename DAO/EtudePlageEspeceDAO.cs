using ProjetTransDev.DAL;
using System;
using System.Collections.ObjectModel;

namespace ProjetTransDev.ORM
{
    public class EtudePlageEspeceDAO
    {

        public Decimal NombreDAO;
        public int IdNombreEDAO;
        public int IdZoneDAO;
        public int IdEtudeDAO;
        public int IdEspeceDAO;
        public int IdPlageDAO;
        public EtudePlageEspeceDAO(int IdNombreEDAO, int IdZoneDAO, int IdEtudeDAO, int IdPlageDAO, int IdEspeceDAO,  Decimal NombreDAO)
        {
            this.IdPlageDAO = IdPlageDAO;
            this.IdEspeceDAO = IdEspeceDAO;
            this.IdNombreEDAO = IdNombreEDAO;
            this.IdZoneDAO = IdZoneDAO;
            this.IdEtudeDAO = IdEtudeDAO;
            this.NombreDAO = NombreDAO;
        }

        public static ObservableCollection<EtudePlageEspeceDAO> listeEtudePlageEspeces()
        {
            ObservableCollection<EtudePlageEspeceDAO> l = EtudePlageEspeceDAL.selectEtudePlageEspeces();
            return l;
        }

        public static EtudePlageEspeceDAO getEtudePlageEspece(int IdNombreEDAO)
        {
            EtudePlageEspeceDAO p = EtudePlageEspeceDAL.getEtudePlageEspece(IdNombreEDAO);
            return p;
        }

        public static void updateEtudePlageEspece(EtudePlageEspeceDAO p)
        {
            EtudePlageEspeceDAL.updateEtudePlageEspece(p);
        }

        public static void supprimerEtudePlageEspece(int id)
        {
            EtudePlageEspeceDAL.supprimerEtudePlageEspece(id);
        }

        public static void insertEtudePlageEspece(EtudePlageEspeceDAO p)
        {
            EtudePlageEspeceDAL.insertEtudePlageEspece(p);
        }
    }
}
