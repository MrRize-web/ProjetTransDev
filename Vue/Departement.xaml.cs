using ProjetTransDev.Ctrl;
using ProjetTransDev.DAL;
using ProjetTransDev.ORM;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjetTransDev.Vue
{
    /// <summary>
    /// Logique d'interaction pour Departement.xaml
    /// </summary>
    public partial class Departement : Page
    {
        int selectedDepartementsId;
        int compteur = 0;
        DepartementViewModel myDataObject3; // Objet de liaison
        ObservableCollection<DepartementViewModel> lp3;


        public Departement()
        {
            InitializeComponent();
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
            listeDepartements.ItemsSource = lp3;
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
