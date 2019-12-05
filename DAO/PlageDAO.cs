using System.Collections.ObjectModel;
using ProjetTransDev.DAL;

namespace ProjetTransDev.ORM
{
    public class PlageDAO
    {
        public int idPlageDAO;
        public string nomPlageDAO;
        public string departementPlageDAO;
        public string superficEtudePlageDAO;
   
        public PlageDAO(int idPlageDAO, string nomPlageDAO, string superficEtudePlageDAO)
        {
            this.idPlageDAO = idPlageDAO;
            this.nomPlageDAO = nomPlageDAO;
            this.superficEtudePlageDAO = superficEtudePlageDAO;
        }

        public static ObservableCollection<PlageDAO> listePlages()
        {
            ObservableCollection<PlageDAO> l = PlageDAL.selectPlages();
            return l;
        }

        public static PlageDAO getPlage(int idPlage)
        {
            PlageDAO p = PlageDAL.getPlage(idPlage);
            return p;
        }

        public static void updatePlage(PlageDAO p)
        {
            PlageDAL.updatePlage(p);
        }

        public static void supprimerPlage(int id)
        {
            PlageDAL.supprimerPlage(id);
        }

        public static void insertPlage(PlageDAO p)
        {
            PlageDAL.insertPlage(p);
        }
    }
}
