using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProjetTransDev.DAL;

namespace ProjetTransDev.ORM
{
    public class EspeceDAO
    {
        public int idEspeceDAO;
        public string nomEspeceDAO;
        public string departementEspeceDAO;
        public string superficEtudeEspeceDAO;

        public EspeceDAO(int idEspeceDAO, string nomEspeceDAO)
        {
            this.idEspeceDAO = idEspeceDAO;
            this.nomEspeceDAO = nomEspeceDAO;
        }

        public static ObservableCollection<EspeceDAO> listeEspeces()
        {
            ObservableCollection<EspeceDAO> l = EspeceDAL.selectEspeces();
            return l;
        }

        public static EspeceDAO getEspece(int idEspece)
        {
            EspeceDAO p = EspeceDAL.getEspece(idEspece);
            return p;
        }

        public static void updateEspece(EspeceDAO p)
        {
            EspeceDAL.updateEspece(p);
        }

        public static void supprimerEspece(int id)
        {
            EspeceDAL.supprimerEspece(id);
        }

        public static void insertEspece(EspeceDAO p)
        {
            EspeceDAL.insertEspece(p);
        }
    }
}
