﻿using ProjetTransDev.Ctrl;
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
    public partial class Etude : Page
    {

        int selectedEtudeId;

        int compteur = 0;

        ObservableCollection<PlageViewModel> lp1;
        EtudeViewModel myDataObject4; // Objet de liaison
        ObservableCollection<EtudeViewModel> lp4;

        public Etude()
        {
            InitializeComponent();

            lp1 = PlageORM.listePlages();
            listePlagesCombo.ItemsSource = lp1;
            lp4 = EtudeORM.ListeEtude();
            listeEtudes.ItemsSource = lp4;


           CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
           culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd-HH-mm-ss"; //Format BDD
           culture.DateTimeFormat.LongTimePattern = "";
           Thread.CurrentThread.CurrentCulture = culture;
        }
        /////////////////////////////////////    Etudes    /////////////////////////////////////
        /////////////////////////////////////    Etudes    /////////////////////////////////////
        ///
        private void ValideEtude_Click(object sender, RoutedEventArgs e)
        {
            myDataObject4 = new EtudeViewModel();
            myDataObject4.NbPersonneEtudeProperty = Convert.ToDecimal(NbPersonne.SelectionBoxItem);
            myDataObject4.dateCreationProperty = Convert.ToDateTime(dateCreationDatePicker.SelectedDate); 
            myDataObject4.dateFinProperty = Convert.ToDateTime(dateFinDatePicker1.SelectedDate);
            myDataObject4.PlageEtude = (PlageViewModel)listePlagesCombo.SelectedItem;
            myDataObject4.TitreEtudeProperty = Titre.Text;

            EtudeViewModel nouveau = new EtudeViewModel(EtudeDAL.getMaxIdEtude() + 1, myDataObject4.NbPersonneEtudeProperty,  myDataObject4.TitreEtudeProperty, myDataObject4.PlageEtudeProperty, myDataObject4.dateCreationProperty, myDataObject4.dateFinProperty);
            lp4.Add(nouveau);
            EtudeORM.insertEtude(nouveau);
            compteur = lp4.Count();

            listeEtudes.ItemsSource = lp4;

            ((TextBox)Titre).Text = string.Empty;

            MessageBox.Show("Etude ajoutée avec succes ! ");
        }
        private void listeCommunesCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEtudes.SelectedIndex < lp4.Count) && (listeEtudes.SelectedIndex >= 0))
            {
                selectedEtudeId = (lp4.ElementAt<EtudeViewModel>(listeEtudes.SelectedIndex)).idEtudeProperty;
            }
        }
        private void supprimerButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EtudeViewModel toRemove = (EtudeViewModel)listeEtudes.SelectedItem;
            lp4.Remove(toRemove);

            EtudeORM.supprimerEtude(selectedEtudeId);

            MessageBox.Show("Etude supprimée avec succes ! ");
        }

        /// <summary>
        /// ////TEST classe association
        /// </summary>
        ///
        

        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelection();
        }
    }
}
