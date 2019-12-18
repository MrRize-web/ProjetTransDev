using ProjetTransDev.Ctrl;
using System.Collections.ObjectModel;
namespace ProjetTransDev.ORM
{
    public class EtudePlageEspeceORM
    {

        public static EtudePlageEspeceViewModel getEtudePlageEspece(int idEtudePlageEspece)
        {

            EtudePlageEspeceDAO pDAO = EtudePlageEspeceDAO.getEtudePlageEspece(idEtudePlageEspece);


            int idEtude = pDAO.IdEtudeDAO;
            EtudeViewModel a = EtudeORM.getEtude(idEtude);

            int idZone = pDAO.IdZoneDAO;
            ZoneInvestigationViewModel b = ZoneInvestigationORM.getEtudePlage(idZone);

            int idEspece = pDAO.IdEspeceDAO;
            EspeceViewModel c = EspeceORM.getEspece(idEspece);

            int idPlage = pDAO.IdPlageDAO;
            PlageViewModel d = PlageORM.getPlage(idPlage);

            EtudePlageEspeceViewModel p = new EtudePlageEspeceViewModel(pDAO.IdNombreEDAO,b,c, d, a, pDAO.NombreDAO);
            return p;
        }

        public static ObservableCollection<EtudePlageEspeceViewModel> ListeEtudePlageEspeces()
        {
            ObservableCollection<EtudePlageEspeceDAO> lDAO = EtudePlageEspeceDAO.listeEtudePlageEspeces();
            ObservableCollection<EtudePlageEspeceViewModel> l = new ObservableCollection<EtudePlageEspeceViewModel>();
            foreach (EtudePlageEspeceDAO element in lDAO)
            {
                int idEtude = element.IdEtudeDAO;
                EtudeViewModel a = EtudeORM.getEtude(idEtude);

                int idZone = element.IdZoneDAO;
                ZoneInvestigationViewModel b = ZoneInvestigationORM.getEtudePlage(idZone);

                int idEspece = element.IdEspeceDAO;
                EspeceViewModel c = EspeceORM.getEspece(idEspece);

                int idPlage = element.IdPlageDAO;
                PlageViewModel d = PlageORM.getPlage(idPlage);
                EtudePlageEspeceViewModel p = new EtudePlageEspeceViewModel(element.IdNombreEDAO, b, c, d, a, element.NombreDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updateEtudePlageEspece(EtudePlageEspeceViewModel p)
        {
            EtudePlageEspeceDAO.updateEtudePlageEspece(new EtudePlageEspeceDAO(p.IdNombreEProperty,p.IdZoneProperty.IdZoneProperty,p.EtudeProperty.idEtudeProperty, p.PlageProperty.idPlageProperty, p.EspeceProperty.idEspeceProperty, p.NombreProperty));
        }

        public static void supprimerEtudePlageEspece(int id)
        {
            EtudePlageEspeceDAO.supprimerEtudePlageEspece(id);
        }
        public static void insertEtudePlageEspece(EtudePlageEspeceViewModel p)
        {
            EtudePlageEspeceDAO.insertEtudePlageEspece(new EtudePlageEspeceDAO(p.IdNombreEProperty, p.IdZoneProperty.IdZoneProperty, p.EtudeProperty.idEtudeProperty, p.PlageProperty.idPlageProperty, p.EspeceProperty.idEspeceProperty, p.NombreProperty));
        }
    }
}
