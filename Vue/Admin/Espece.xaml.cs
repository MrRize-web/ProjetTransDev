using ProjetTransDev.Ctrl;
using ProjetTransDev.ORM;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjetTransDev.Vue
{
    /// <summary>
    /// Logique d'interaction pour Espece.xaml
    /// </summary>
    public partial class Espece : Page
    {
        int selectedEspeceId;
        int compteur = 0;

        EspeceViewModel myDataObject5;
        ObservableCollection<EspeceViewModel> lp5;

        public Espece()
        {
            InitializeComponent();

            lp5 = EspeceORM.listeEspeces();
            listeEspeces.ItemsSource = lp5;


        }
        /////////////////////////////////////    ESPECE    /////////////////////////////////////
        /////////////////////////////////////     ESPECE      /////////////////////////////////////
        private void VlideEspece_Click(object sender, RoutedEventArgs e)
        {
            myDataObject5 = new EspeceViewModel();
            myDataObject5.nomEspeceProperty = nomEspece.Text;

            EspeceViewModel nouveau = new EspeceViewModel(myDataObject5.idEspeceProperty, myDataObject5.nomEspeceProperty);
            lp5.Add(nouveau);
            EspeceORM.insertEspece(nouveau);
            compteur = lp5.Count();

            listeEspeces.ItemsSource = lp5;

            ((TextBox)nomEspece).Text = string.Empty;
            MessageBox.Show("Espece ajoutée avec succes ! ");

        }
      
        private void listeEspeceSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEspeces.SelectedIndex < lp5.Count) && (listeEspeces.SelectedIndex >= 0))
            {
                selectedEspeceId = (lp5.ElementAt<EspeceViewModel>(listeEspeces.SelectedIndex)).idEspeceProperty;
            }
        }
 
        private void supprimerButton_MouseDoubleClick5(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EspeceViewModel toRemove = (EspeceViewModel)listeEspeces.SelectedItem;
            lp5.Remove(toRemove);

            listeEspeces.Items.Refresh();

            EspeceORM.supprimerEspece(selectedEspeceId);
            MessageBox.Show("Espece supprimée avec succes ! ");
        }

        private void ouvrirAcceuil(object sender, RoutedEventArgs e)
        {
            Window pageAcceuil = Window.GetWindow(this);
            pageAcceuil.Content = new MenuSelection();
        }
    }
}
