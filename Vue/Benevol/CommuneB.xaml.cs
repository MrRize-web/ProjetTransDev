﻿using ProjetTransDev.Ctrl;
using ProjetTransDev.Ctrl.ProjetTransDev.Ctrl;
using ProjetTransDev.ORM;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjetTransDev.Vue.Benevol
{

    public partial class CommuneB : Page
    {
        int selectedCommunesId;
        int compteur = 0;

        CommuneViewModel myDataObject2; // Objet de liaison
        ObservableCollection<CommuneViewModel> lp2;


        DepartementViewModel myDataObject3; // Objet de liaison
        ObservableCollection<DepartementViewModel> lp3;


        public CommuneB()
        {
            InitializeComponent();

            lp2 = CommuneORM.ListeCommunes();
            listeCommunes.ItemsSource = lp2;

            lp3 = DepartementORM.ListeDepartements();

        }
        /////////////////////////////////////   Commune     /////////////////////////////////////
        /////////////////////////////////////   Commune     /////////////////////////////////////
       
        private void listeCommunes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            if ((listeCommunes.SelectedIndex < lp2.Count) && (listeCommunes.SelectedIndex >= 0))
            {
                listeCommunes.Items.Refresh();
                selectedCommunesId = (lp2.ElementAt<CommuneViewModel>(listeCommunes.SelectedIndex)).idCommuneProperty;

            }
        }
        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelectionB();
        }
    }
}
