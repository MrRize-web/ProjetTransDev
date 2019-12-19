using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ProjetTransDev.Ctrl;
using ProjetTransDev.DAL;
using ProjetTransDev.ORM;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

namespace ProjetTransDev.Vue.Benevol
{
    public partial class ZoneInvestigationB : Page
    {
        int selectedZoneInvestigationId;

        int compteur = 0;

        ObservableCollection<ZoneInvestigationViewModel> lp7;

        public ZoneInvestigationB()
        {
            InitializeComponent();

  
            lp7 = ZoneInvestigationORM.ListeZoneInvestigation();
            ListeEtudeZone.ItemsSource = lp7;

            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd-HH-mm-ss"; //Format BDD
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;

        }
       
        private void ListeEtudeZone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((ListeEtudeZone.SelectedIndex < lp7.Count) && (ListeEtudeZone.SelectedIndex >= 0))
            {
                selectedZoneInvestigationId = (lp7.ElementAt<ZoneInvestigationViewModel>(ListeEtudeZone.SelectedIndex)).IdZoneProperty;
            }
        }  
        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelectionB();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
