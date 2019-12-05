using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProjetTransDev.DAL;

namespace ProjetTransDev.DAO
{
    public class EtudeDAO
    {
        public int idEtudeDAO;
        public Decimal NbPersonneEtudeDAO;
        public Decimal NbPlageEtudeDAO;
        public string TitreEtudeEtudeDAO;

        public EtudeDAO(int idEtudeDAO, Decimal NbPersonneEtudeDAO, Decimal NbPlageEtudeDAO, string TitreEtudeEtudeDAO)
        {
            this.idEtudeDAO = idEtudeDAO;
            this.NbPersonneEtudeDAO = NbPersonneEtudeDAO;
            this.NbPlageEtudeDAO = NbPlageEtudeDAO;
            this.TitreEtudeEtudeDAO = TitreEtudeEtudeDAO;
        }

        public static ObservableCollection<EtudeDAO> listeEtudes()
        {
            ObservableCollection<EtudeDAO> l = EtudeDAL.selectEtude();
            return l;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            EtudeDAO p = EtudeDAL.getEtude(idEtude);
            return p;
        }

        public static void updateEtude(EtudeDAO p)
        {
            EtudeDAL.updateEtude(p);
        }

        public static void supprimerEtude(int id)
        {
            EtudeDAL.supprimerEtude(id);
        }

        public static void insertEtude(EtudeDAO p)
        {
            EtudeDAL.insertEtude(p);
        }
    }
}
