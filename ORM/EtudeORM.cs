using System.Collections.ObjectModel;
using ProjetTransDev.Ctrl;
using ProjetTransDev.DAO;

namespace ProjetTransDev.ORM
{
    public class EtudeORM
    {

        public static EtudeViewModel getEtude(int idEtude)
        {
            EtudeDAO pDAO = EtudeDAO.getEtude(idEtude);
            int idPlage = pDAO.PlageEtudeDAO;
            PlageViewModel m = PlageORM.getPlage(idPlage);
            EtudeViewModel p = new EtudeViewModel(pDAO.idEtudeDAO, pDAO.NbPersonneEtudeDAO, m, pDAO.TitreEtudeEtudeDAO, pDAO.dateCreationDAO, pDAO.dateFinDAO);
            return p;
        }

        public static ObservableCollection<EtudeViewModel> ListeEtude()
        {
            ObservableCollection<EtudeDAO> lDAO = EtudeDAO.listeEtudes();
            ObservableCollection<EtudeViewModel> l = new ObservableCollection<EtudeViewModel>();
            foreach (EtudeDAO element in lDAO)
            {
                int idPlage = element.PlageEtudeDAO;
                PlageViewModel m = PlageORM.getPlage(idPlage);
                EtudeViewModel p = new EtudeViewModel(element.idEtudeDAO, element.NbPersonneEtudeDAO, m , element.TitreEtudeEtudeDAO, element.dateCreationDAO, element.dateFinDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateEtude(EtudeViewModel p)
        {
            EtudeDAO.updateEtude(new EtudeDAO(p.idEtudeProperty, p.NbPersonneEtudeProperty, p.PlageEtudeProperty.idPlageProperty, p.TitreEtudeProperty, p.dateCreationProperty, p.dateFinProperty));
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAO.supprimerEtude(id);
        }

        public static void insertEtude(EtudeViewModel p)
        {
            EtudeDAO.insertEtude(new EtudeDAO(p.idEtudeProperty, p.NbPersonneEtudeProperty, p.PlageEtudeProperty.idPlageProperty, p.TitreEtudeProperty, p.dateCreationProperty, p.dateFinProperty));
        }
    }
}
