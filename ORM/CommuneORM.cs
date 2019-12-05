using System.Collections.ObjectModel;
using ProjetTransDev.Ctrl.ProjetTransDev.Ctrl;

namespace ProjetTransDev.ORM
{
    public class CommuneORM
    {

        public static CommuneViewModel getCommune(int idCommune)
        {
            CommuneDAO pDAO = CommuneDAO.getCommune(idCommune);
            CommuneViewModel p = new CommuneViewModel(pDAO.idCommuneDAO, pDAO.nomCommuneDAO, pDAO.DepartementCommuneDAO);
            return p;
        }

        public static ObservableCollection<CommuneViewModel> ListeCommunes()
        {
            ObservableCollection<CommuneDAO> lDAO = CommuneDAO.listeCommunes();
            ObservableCollection<CommuneViewModel> l = new ObservableCollection<CommuneViewModel>();
            foreach (CommuneDAO element in lDAO)
            {
                CommuneViewModel p = new CommuneViewModel(element.idCommuneDAO, element.nomCommuneDAO, element.DepartementCommuneDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateCommune(CommuneViewModel p)
        {
            CommuneDAO.updateCommune(new CommuneDAO(p.idCommuneProperty, p.nomCommuneProperty, p.DepartementCommuneProperty));
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAO.supprimerCommune(id);
        }

        public static void insertCommune(CommuneViewModel p)
        {
            CommuneDAO.insertCommune(new CommuneDAO(p.idCommuneProperty, p.nomCommuneProperty, p.DepartementCommuneProperty));
        }
    }
}
