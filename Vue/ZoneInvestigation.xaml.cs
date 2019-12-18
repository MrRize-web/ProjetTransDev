using ProjetTransDev.Ctrl;
using ProjetTransDev.DAL;
using ProjetTransDev.ORM;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace ProjetTransDev.Vue
{
    public partial class ZoneInvestigation : Page
    {
        int selectedZoneInvestigationId;

        int compteur = 0;

        ZoneInvestigationViewModel myDataObject7; // Objet de liaison
        ObservableCollection<ZoneInvestigationViewModel> lp7;
        PlageViewModel myDataObject1; // Objet de liaison
        ObservableCollection<PlageViewModel> lp1;
        UsersViewModel myDataObject; // Objet de liaison
        ObservableCollection<UsersViewModel> lp;
        EtudeViewModel myDataObject4; // Objet de liaison
        ObservableCollection<EtudeViewModel> lp4;

        public ZoneInvestigation()
        {
            InitializeComponent();
            lp = UsersORM.listeUsers();
            listeUsersCombo.ItemsSource = lp;
            lp1 = PlageORM.listePlages();
            listePlageCombo.ItemsSource = lp1;
            lp4 = EtudeORM.ListeEtude();
            listeEtudesCombo.ItemsSource = lp4;
            listeDateCombo.ItemsSource = lp4;
            ListeEtudeZone.ItemsSource = lp4;

            lp7 = ZoneInvestigationORM.ListeZoneInvestigation();

            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd-HH-mm-ss"; //Format BDD
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;

        }
        private void VlideAngle_Click(object sender, RoutedEventArgs e)
        {
            myDataObject7 = new ZoneInvestigationViewModel();

            myDataObject7.PlageProperty = (PlageViewModel)listePlageCombo.SelectedItem;
            myDataObject7.EtudeProperty = (EtudeViewModel)listeEtudesCombo.SelectedItem;
            myDataObject7.UsersProperty = (UsersViewModel)listeUsersCombo.SelectedItem;
            myDataObject7.Angle1Property = Convert.ToDecimal(Angle1.Text);
            myDataObject7.Angle2Property = Convert.ToDecimal(Angle2.Text);
            myDataObject7.Angle3Property = Convert.ToDecimal(Angle3.Text);
            myDataObject7.Angle4Property = Convert.ToDecimal(Angle4.Text);

            ZoneInvestigationViewModel nouveau = new ZoneInvestigationViewModel(ZoneInvestigationDAL.getMaxIdZoneInvestigation() + 1, myDataObject7.EtudeProperty, myDataObject7.PlageProperty, myDataObject7.UsersProperty, myDataObject7.EtudeDate, myDataObject7.Angle1Property, myDataObject7.Angle2Property, myDataObject7.Angle3Property, myDataObject7.Angle4Property);
            lp7.Add(nouveau);
            ZoneInvestigationORM.insertZoneInvestigation(nouveau);
            compteur = lp7.Count();

            ListeEtudeZone.ItemsSource = lp7;

            ((TextBox)Angle1).Text = string.Empty;
            ((TextBox)Angle2).Text = string.Empty;
            ((TextBox)Angle3).Text = string.Empty;
            ((TextBox)Angle4).Text = string.Empty;

            MessageBox.Show("Etude ajoutée avec succes ! ");
        }
        private void ListeEtudeZone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((ListeEtudeZone.SelectedIndex < lp7.Count) && (ListeEtudeZone.SelectedIndex >= 0))
            {
                selectedZoneInvestigationId = (lp7.ElementAt<ZoneInvestigationViewModel>(ListeEtudeZone.SelectedIndex)).EtudeProperty.idEtudeProperty;
            }
        }
        private void supprimerButton_MouseDoubleClick4(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ZoneInvestigationViewModel toRemove = (ZoneInvestigationViewModel)ListeEtudeZone.SelectedItem;
            lp7.Remove(toRemove);

            EtudeORM.supprimerEtude(selectedZoneInvestigationId);

            MessageBox.Show("Etude supprimée avec succes ! ");
        }
        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelection();
        }
    }
}
