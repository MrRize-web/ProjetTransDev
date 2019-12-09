using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProjetTransDev.DAL;

namespace ProjetTransDev.ORM
{
    public class CommunePlageDAO
    {
        public int idDepartementDAO;
        public string nomDepartementDAO;
        public string departementDepartementDAO;
    
        public CommunePlageDAO(int idDepartementDAO, string nomDepartementDAO)
        {
            this.idDepartementDAO = idDepartementDAO;
            this.nomDepartementDAO = nomDepartementDAO;

        }

        public static ObservableCollection<CommunePlageDAO> listeDepartements()
        {
            ObservableCollection<CommunePlageDAO> l = DepartementDAL.selectDepartements();
            return l;
        }

        public static CommunePlageDAO getDepartement(int idDepartement)
        {
            CommunePlageDAO p = DepartementDAL.getDepartement(idDepartement);
            return p;
        }

        public static void updateDepartement(CommunePlageDAO p)
        {
            DepartementDAL.updateDepartement(p);
        }

        public static void supprimerDepartement(int id)
        {
            DepartementDAL.selectDepartement(id);
        }
        public static void selectDepartement(int id)
        {
            DepartementDAL.selectDepartement(id);
        }
        public static void insertDepartement(CommunePlageDAO p)
        {
            DepartementDAL.insertDepartement(p);
        }
    }
}
