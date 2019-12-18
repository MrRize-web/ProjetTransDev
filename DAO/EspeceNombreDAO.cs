using ProjetTransDev.DAL;
using System;
using System.Collections.ObjectModel;

namespace ProjetTransDev.ORM
{
    public class EspeceNombreDAO
    {

        public Decimal NombreDAO;
        public int IdNombreEDAO;
        public int IdZoneDAO;
        public int IdEtudeDAO;
        public int IdEspeceDAO;
        public int IdPlageDAO;
        public EspeceNombreDAO(int IdNombreEDAO, int IdZoneDAO, int IdEtudeDAO, int IdPlageDAO, int IdEspeceDAO,  Decimal NombreDAO)
        {
            this.IdPlageDAO = IdPlageDAO;
            this.IdEspeceDAO = IdEspeceDAO;
            this.IdNombreEDAO = IdNombreEDAO;
            this.IdZoneDAO = IdZoneDAO;
            this.IdEtudeDAO = IdEtudeDAO;
            this.NombreDAO = NombreDAO;
        }

        public static ObservableCollection<EspeceNombreDAO> listeEspeceNombres()
        {
            ObservableCollection<EspeceNombreDAO> l = EspeceNombreDAL.selectEspeceNombres();
            return l;
        }

        public static EspeceNombreDAO getEspeceNombre(int IdNombreEDAO)
        {
            EspeceNombreDAO p = EspeceNombreDAL.getEspeceNombre(IdNombreEDAO);
            return p;
        }

        public static void updateEspeceNombre(EspeceNombreDAO p)
        {
            EspeceNombreDAL.updateEspeceNombre(p);
        }

        public static void supprimerEspeceNombre(int id)
        {
            EspeceNombreDAL.supprimerEspeceNombre(id);
        }

        public static void insertEspeceNombre(EspeceNombreDAO p)
        {
            EspeceNombreDAL.insertEspeceNombre(p);
        }
    }
}
