using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProjetTransDev.DAL;

namespace ProjetTransDev.ORM
{
    public class DepartementDAO
    {
        public int idDepartementDAO;
        public string nomDepartementDAO;
        public string CodePostaleDAO;
        public string departementDepartementDAO;
    
        public DepartementDAO(int idDepartementDAO, string nomDepartementDAO, string CodePostaleDAO)
        {
            this.idDepartementDAO = idDepartementDAO;
            this.nomDepartementDAO = nomDepartementDAO;
            this.CodePostaleDAO = CodePostaleDAO;
        }

        public static ObservableCollection<DepartementDAO> listeDepartements()
        {
            ObservableCollection<DepartementDAO> l = DepartementDAL.selectDepartements();
            return l;
        }

        public static DepartementDAO getDepartement(int idDepartement)
        {
            DepartementDAO p = DepartementDAL.getDepartement(idDepartement);
            return p;
        }

        public static void updateDepartement(DepartementDAO p)
        {
            DepartementDAL.updateDepartement(p);
        }

        public static void supprimerDepartement(int id)
        {
            DepartementDAL.supprimerDepartement(id);
        }

            public static void insertDepartement(DepartementDAO p)
        {
            DepartementDAL.insertDepartement(p);
        }
    }
}
