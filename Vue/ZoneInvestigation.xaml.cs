using ProjetTransDev.Ctrl;
using ProjetTransDev.DAL;
using ProjetTransDev.ORM;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjetTransDev.Vue
{
    /// <summary>
    /// Logique d'interaction pour ZoneInvestigation.xaml
    /// </summary>
    public partial class ZoneInvestigation : Page
    {
        int selectedEtudePlageId;

        int compteur = 0;




        EtudePlageViewModel myDataObject9; // Objet de liaison
        ObservableCollection<EtudePlageViewModel> lp9;
        public ZoneInvestigation()
        {
            InitializeComponent();


            lp9 = EtudePlageORM.ListeEtudePlages();
        }
        private void VlideAngle_Click(object sender, RoutedEventArgs e)
        {
            myDataObject9 = new EtudePlageViewModel();

            myDataObject9.PlageProperty = (PlageViewModel)listePlageCombo.SelectedItem;
            myDataObject9.EtudeProperty = (EtudeViewModel)listeEtudesCombo.SelectedItem;
            myDataObject9.UsersProperty = (UsersViewModel)listeUsersCombo.SelectedItem;
            myDataObject9.Angle1Property = Convert.ToDecimal(Angle1.Text);
            myDataObject9.Angle2Property = Convert.ToDecimal(Angle2.Text);
            myDataObject9.Angle3Property = Convert.ToDecimal(Angle3.Text);
            myDataObject9.Angle4Property = Convert.ToDecimal(Angle4.Text);

            EtudePlageViewModel nouveau = new EtudePlageViewModel(EtudePlageDAL.getMaxIdEtudePlage() + 1, myDataObject9.EtudeProperty, myDataObject9.PlageProperty, myDataObject9.UsersProperty, myDataObject9.EtudeDate, myDataObject9.Angle1Property, myDataObject9.Angle2Property, myDataObject9.Angle3Property, myDataObject9.Angle4Property);
            lp9.Add(nouveau);
            EtudePlageORM.insertEtudePlage(nouveau);
            compteur = lp9.Count();


            ListeEtudeZone.ItemsSource = lp9;

            ((TextBox)Angle1).Text = string.Empty;
            ((TextBox)Angle2).Text = string.Empty;
            ((TextBox)Angle3).Text = string.Empty;
            ((TextBox)Angle4).Text = string.Empty;

            MessageBox.Show("Etude ajoutée avec succes ! ");
        }
        private void ListeEtudeZone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((ListeEtudeZone.SelectedIndex < lp9.Count) && (ListeEtudeZone.SelectedIndex >= 0))
            {
                selectedEtudePlageId = (lp9.ElementAt<EtudePlageViewModel>(ListeEtudeZone.SelectedIndex)).EtudeProperty.idEtudeProperty;
            }
        }
        private void supprimerButton_MouseDoubleClick4(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EtudePlageViewModel toRemove = (EtudePlageViewModel)ListeEtudeZone.SelectedItem;
            lp9.Remove(toRemove);

            EtudeORM.supprimerEtude(selectedEtudePlageId);

            MessageBox.Show("Etude supprimée avec succes ! ");
        }
        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelection();
        }
    }
}
