using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProjetTransDev.DAL;
using ProjetTransDev.Ctrl;

namespace ProjetTransDev.ORM
{
    public class CommuneDAO
    {
        public int idCommuneDAO;
        public int DepartementCommuneDAO;
        public string nomCommuneDAO;
        public string superficEtudePlageDAO;
    


        public CommuneDAO(int idCommuneDAO, string nomCommuneDAO, int DepartementDAO)
        {
            this.idCommuneDAO = idCommuneDAO;
            this.nomCommuneDAO = nomCommuneDAO;
            this.DepartementCommuneDAO = DepartementDAO;
        }

        public static ObservableCollection<CommuneDAO> listeCommunes()
        {
            ObservableCollection<CommuneDAO> l = CommuneDAL.selectCommunes();
            return l;
        }

        public static CommuneDAO getCommune(int idCommune)
        {
            CommuneDAO p = CommuneDAL.getCommune(idCommune);
            return p;
        }

        public static void updateCommune(CommuneDAO p)
        {
            CommuneDAL.updateCommune(p);
        }

        public static void supprimerCommune(int id)
        {
            CommuneDAL.supprimerCommune(id);
        }

        public static void insertCommune(CommuneDAO p)
        {
            CommuneDAL.insertCommune(p);
        }
    }
}
