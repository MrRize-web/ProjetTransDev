using ProjetTransDev.Ctrl;
using ProjetTransDev.Ctrl.ProjetTransDev.Ctrl;
using ProjetTransDev.DAL;
using ProjetTransDev.ORM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetTransDev.Vue
{
    /// <summary>
    /// Logique d'interaction pour Departement.xaml
    /// </summary>
    public partial class Departement : Page
    {
        int selectedPlagesId;
        int selectedCommunesId;
        int selectedDepartementsId;
        int compteur = 0;



        PlageViewModel myDataObject1; // Objet de liaison
        ObservableCollection<PlageViewModel> lp1;


        CommuneViewModel myDataObject2; // Objet de liaison
        ObservableCollection<CommuneViewModel> lp2;


        DepartementViewModel myDataObject3; // Objet de liaison
        ObservableCollection<DepartementViewModel> lp3;


        public Departement()
        {
            InitializeComponent();

            DALConnection.OpenConnection();

            lp3 = DepartementORM.ListeDepartements();
            listeDepartements.ItemsSource = lp3;

        }
        /////////////////////////////////////   Departement     /////////////////////////////////////
        /////////////////////////////////////   Departement     /////////////////////////////////////
        private void VlideDepartement_Click(object sender, RoutedEventArgs e)
        {
            myDataObject3 = new DepartementViewModel();
            myDataObject3.nomDepartementProperty = NomDepartement.Text;
            myDataObject3.CodePostalePropertie = CodePostaleDep.Text;
            DepartementViewModel nouveau = new DepartementViewModel(DepartementDAL.getMaxIdDepartement() + 1, myDataObject3.nomDepartementProperty, myDataObject3.CodePostalePropertie);
            lp3.Add(nouveau);
            DepartementORM.insertDepartement(nouveau);
            compteur = lp3.Count();

            ((TextBox)NomDepartement).Text = string.Empty;

            MessageBox.Show("Département ajouté avec succes ! ");
        }
        private void listeDepartements_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeDepartements.SelectedIndex < lp3.Count) && (listeDepartements.SelectedIndex >= 0))
            {
                selectedDepartementsId = (lp3.ElementAt<DepartementViewModel>(listeDepartements.SelectedIndex)).idDepartementProperty;

            }
        }
        private void supprimerButton_MouseDoubleClick2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DepartementViewModel toRemove = (DepartementViewModel)listeDepartements.SelectedItem;
            lp3.Remove(toRemove);

            DepartementORM.supprimerDepartement(selectedDepartementsId);
            MessageBox.Show("Departement supprimé avec succes ! ");
        }
        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelection();
        }
    }
}
