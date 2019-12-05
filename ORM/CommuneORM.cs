using System.Collections.ObjectModel;
using ProjetTransDev.Ctrl;
using ProjetTransDev.Ctrl.ProjetTransDev.Ctrl;

namespace ProjetTransDev.ORM
{
    public class CommuneORM
    {

        public static CommuneViewModel getCommune(int idCommune)
        {
            CommuneDAO pDAO = CommuneDAO.getCommune(idCommune);
            int idDepartement = pDAO.DepartementCommuneDAO;
            DepartementViewModel m = DepartementORM.getDepartement(idDepartement);
            CommuneViewModel p = new CommuneViewModel(pDAO.idCommuneDAO, pDAO.nomCommuneDAO, m);
            return p;
        }

        public static ObservableCollection<CommuneViewModel> ListeCommunes()
        {
            ObservableCollection<CommuneDAO> lDAO = CommuneDAO.listeCommunes();
            ObservableCollection<CommuneViewModel> l = new ObservableCollection<CommuneViewModel>();
            foreach (CommuneDAO element in lDAO)
            {
                int idDepartement = element.DepartementCommuneDAO;
                DepartementViewModel m = DepartementORM.getDepartement(idDepartement);
                CommuneViewModel p = new CommuneViewModel(element.idCommuneDAO, element.nomCommuneDAO,m);
                l.Add(p);             
            }
            return l;
        }


        public static void updateCommune(CommuneViewModel p)
        {
            CommuneDAO.updateCommune(new CommuneDAO(p.idCommuneProperty, p.nomCommuneProperty, p.DepartementCommuneProperty.idDepartementProperty));
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAO.supprimerCommune(id);
        }

        public static void insertCommune(CommuneViewModel p)
        {
            CommuneDAO.insertCommune(new CommuneDAO(p.idCommuneProperty, p.nomCommuneProperty, p.DepartementCommuneProperty.idDepartementProperty));
        }
    }
}
