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
            EtudeViewModel p = new EtudeViewModel(pDAO.idEtudeDAO, pDAO.NbPersonneEtudeDAO,pDAO.NbPlageEtudeDAO, pDAO.TitreEtudeEtudeDAO);
            return p;
        }

        public static ObservableCollection<EtudeViewModel> ListeEtude()
        {
            ObservableCollection<EtudeDAO> lDAO = EtudeDAO.listeEtudes();
            ObservableCollection<EtudeViewModel> l = new ObservableCollection<EtudeViewModel>();
            foreach (EtudeDAO element in lDAO)
            {
                EtudeViewModel p = new EtudeViewModel(element.idEtudeDAO, element.NbPersonneEtudeDAO, element.NbPlageEtudeDAO, element.TitreEtudeEtudeDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updateEtude(EtudeViewModel p)
        {
            EtudeDAO.updateEtude(new EtudeDAO(p.idEtudeProperty, p.NbPersonneEtudeProperty, p.NbPlageEtudeProperty, p.TitreEtudeProperty));
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAO.supprimerEtude(id);
        }

        public static void insertEtude(EtudeViewModel p)
        {
            EtudeDAO.insertEtude(new EtudeDAO(p.idEtudeProperty, p.NbPersonneEtudeProperty, p.NbPlageEtudeProperty, p.TitreEtudeProperty));
        }
    }
}
