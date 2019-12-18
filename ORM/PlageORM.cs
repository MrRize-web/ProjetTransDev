using System;
using System.Collections.ObjectModel;
using ProjetTransDev.Ctrl;
using ProjetTransDev.Ctrl.ProjetTransDev.Ctrl;

namespace ProjetTransDev.ORM
{
    public class PlageORM
    {

        public static PlageViewModel getPlage(int idPlage)
        {      
            PlageDAO pDAO = PlageDAO.getPlage(idPlage);
            int idCommune = pDAO.CommuneDAO;
            CommuneViewModel m = CommuneORM.getCommune(idCommune);
            PlageViewModel p = new PlageViewModel(pDAO.idPlageDAO, pDAO.nomPlageDAO,pDAO.superficEtudePlageDAO, m);
            return p;
        }

        public static ObservableCollection<PlageViewModel> listePlages()
        {
            ObservableCollection<PlageDAO> lDAO = PlageDAO.listePlages();
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (PlageDAO element in lDAO)
            {
                int idCommune = element.CommuneDAO;
                CommuneViewModel m = CommuneORM.getCommune(idCommune);
                PlageViewModel p = new PlageViewModel(element.idPlageDAO, element.nomPlageDAO, element.superficEtudePlageDAO, m);
                l.Add(p);
             
            }
            return l;
        }

        public static void updatePlage(PlageViewModel p)
        {
            PlageDAO.updatePlage(new PlageDAO(p.idPlageProperty, p.nomPlageProperty, p.superficEtudePlageProperty, p.CommunePlageProperty.idCommuneProperty));
        }

        public static void supprimerPlage(int id)
        {
            PlageDAO.supprimerPlage(id);
        }

        public static void insertPlage(PlageViewModel p)
        {
            PlageDAO.insertPlage(new PlageDAO(p.idPlageProperty, p.nomPlageProperty, p.superficEtudePlageProperty, p.CommunePlageProperty.idCommuneProperty));
        }

     
    }
}
