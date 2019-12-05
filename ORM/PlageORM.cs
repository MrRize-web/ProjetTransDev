using System;
using System.Collections.ObjectModel;
using ProjetTransDev.Ctrl;

namespace ProjetTransDev.ORM
{
    public class PlageORM
    {

        public static PlageViewModel getPlage(int idPlage)
        {
            PlageDAO pDAO = PlageDAO.getPlage(idPlage);
            PlageViewModel p = new PlageViewModel(pDAO.idPlageDAO, pDAO.nomPlageDAO, pDAO.superficEtudePlageDAO);
            return p;
        }

        public static ObservableCollection<PlageViewModel> listePlages()
        {
            ObservableCollection<PlageDAO> lDAO = PlageDAO.listePlages();
            ObservableCollection<PlageViewModel> l = new ObservableCollection<PlageViewModel>();
            foreach (PlageDAO element in lDAO)
            {
                PlageViewModel p = new PlageViewModel(element.idPlageDAO, element.nomPlageDAO, element.superficEtudePlageDAO);
                l.Add(p);
            }
            return l;
        }


        public static void updatePlage(PlageViewModel p)
        {
            PlageDAO.updatePlage(new PlageDAO(p.idPlageProperty, p.nomPlageProperty, p.superficEtudePlageProperty));
        }

        public static void supprimerPlage(int id)
        {
            PlageDAO.supprimerPlage(id);
        }

        public static void insertPlage(PlageViewModel p)
        {
            PlageDAO.insertPlage(new PlageDAO(p.idPlageProperty, p.nomPlageProperty, p.superficEtudePlageProperty));
        }

        internal static void UpdatePlage(PlageViewModel PlageViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
