using System;
using System.Collections.ObjectModel;
using ProjetTransDev.Ctrl;

namespace ProjetTransDev.ORM
{
    public class DepartementORM
    {

        public static DepartementViewModel getDepartement(int idDepartement)
        {
            DepartementDAO pDAO = DepartementDAO.getDepartement(idDepartement);
            DepartementViewModel p = new DepartementViewModel(pDAO.idDepartementDAO, pDAO.nomDepartementDAO);
            return p;
        }

        internal static DepartementViewModel getDepartement(object idDepartement)
        {
            throw new NotImplementedException();
        }

        public static ObservableCollection<DepartementViewModel> ListeDepartements()
        {
            ObservableCollection<DepartementDAO> lDAO = DepartementDAO.listeDepartements();
            ObservableCollection<DepartementViewModel> l = new ObservableCollection<DepartementViewModel>();
            foreach (DepartementDAO element in lDAO)
            {
                DepartementViewModel p = new DepartementViewModel(element.idDepartementDAO, element.nomDepartementDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateDepartement(DepartementViewModel p)
        {
            DepartementDAO.updateDepartement(new DepartementDAO(p.idDepartementProperty, p.nomDepartementProperty));
        }

        public static void supprimerDepartement(int id)
        {
            DepartementDAO.supprimerDepartement(id);
        }

        public static void insertDepartement(DepartementViewModel p)
        {
            DepartementDAO.insertDepartement(new DepartementDAO(p.idDepartementProperty, p.nomDepartementProperty));
        }
    }
}
