using System;
using System.Collections.ObjectModel;
using ProjetTransDev.Ctrl;

namespace ProjetTransDev.ORM
{
    public class DepartementORM
    {

        public static DepartementViewModel getDepartement(int idDepartement)
        {
            CommunePlageDAO pDAO = CommunePlageDAO.getDepartement(idDepartement);
            DepartementViewModel p = new DepartementViewModel(pDAO.idDepartementDAO, pDAO.nomDepartementDAO);
            return p;
        }
        internal static DepartementViewModel getDepartement(object idDepartement)
        {
            throw new NotImplementedException();
        }

        public static ObservableCollection<DepartementViewModel> ListeDepartements()
        {
            ObservableCollection<CommunePlageDAO> lDAO = CommunePlageDAO.listeDepartements();
            ObservableCollection<DepartementViewModel> l = new ObservableCollection<DepartementViewModel>();
            foreach (CommunePlageDAO element in lDAO)
            {
                DepartementViewModel p = new DepartementViewModel(element.idDepartementDAO, element.nomDepartementDAO);
                l.Add(p);
            }
            return l;
        }

        public static void updateDepartement(DepartementViewModel p)
        {
            CommunePlageDAO.updateDepartement(new CommunePlageDAO(p.idDepartementProperty, p.nomDepartementProperty));
        }

        public static void supprimerDepartement(int id)
        {
            CommunePlageDAO.supprimerDepartement(id);
        }
        public static void insertDepartement(DepartementViewModel p)
        {
            CommunePlageDAO.insertDepartement(new CommunePlageDAO(p.idDepartementProperty, p.nomDepartementProperty));
        }

    }
}
