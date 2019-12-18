using ProjetTransDev.Ctrl;
using System.Collections.ObjectModel;
namespace ProjetTransDev.ORM
{
    public class EspeceNombreORM
    {

        public static EspeceNombreViewModel getEspeceNombre(int idEspeceNombre)
        {

            EspeceNombreDAO pDAO = EspeceNombreDAO.getEspeceNombre(idEspeceNombre);


            int idEtude = pDAO.IdEtudeDAO;
            EtudeViewModel a = EtudeORM.getEtude(idEtude);
           
            int idZone = pDAO.IdZoneDAO;
            ZoneInvestigationViewModel b = ZoneInvestigationORM.getZoneInvestigation(idZone);

            int idEspece = pDAO.IdEspeceDAO;
            EspeceViewModel c = EspeceORM.getEspece(idEspece);

            int idPlage = pDAO.IdPlageDAO;
            PlageViewModel d = PlageORM.getPlage(idPlage);

            EspeceNombreViewModel p = new EspeceNombreViewModel(pDAO.IdNombreEDAO,b,c, d, a, pDAO.NombreDAO);
            return p;
        }

        public static ObservableCollection<EspeceNombreViewModel> ListeEspeceNombres()
        {
            ObservableCollection<EspeceNombreDAO> lDAO = EspeceNombreDAO.listeEspeceNombres();
            ObservableCollection<EspeceNombreViewModel> l = new ObservableCollection<EspeceNombreViewModel>();
            foreach (EspeceNombreDAO element in lDAO)
            {
                int idEtude = element.IdEtudeDAO;
                EtudeViewModel a = EtudeORM.getEtude(idEtude);

                int idZone = element.IdZoneDAO;
                ZoneInvestigationViewModel b = ZoneInvestigationORM.getZoneInvestigation(idZone);

                int idEspece = element.IdEspeceDAO;
                EspeceViewModel c = EspeceORM.getEspece(idEspece);

                int idPlage = element.IdPlageDAO;
                PlageViewModel d = PlageORM.getPlage(idPlage);
                EspeceNombreViewModel p = new EspeceNombreViewModel(element.IdNombreEDAO, b, c, d, a, element.NombreDAO);
                l.Add(p);
            }
            return l;
        }
        public static void updateEspeceNombre(EspeceNombreViewModel p)
        {
            EspeceNombreDAO.updateEspeceNombre(new EspeceNombreDAO(p.IdNombreEProperty,p.IdZoneProperty.IdZoneProperty,p.EtudeProperty.idEtudeProperty, p.PlageProperty.idPlageProperty, p.EspeceProperty.idEspeceProperty, p.NombreProperty));
        }

        public static void supprimerEspeceNombre(int id)
        {
            EspeceNombreDAO.supprimerEspeceNombre(id);
        }
        public static void insertEspeceNombre(EspeceNombreViewModel p)
        {
            EspeceNombreDAO.insertEspeceNombre(new EspeceNombreDAO(p.IdNombreEProperty, p.IdZoneProperty.IdZoneProperty, p.EtudeProperty.idEtudeProperty, p.PlageProperty.idPlageProperty, p.EspeceProperty.idEspeceProperty, p.NombreProperty));
        }
    }
}
