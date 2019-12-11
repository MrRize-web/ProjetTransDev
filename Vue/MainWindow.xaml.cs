using System.Windows;
using ProjetTransDev.DAL;
using ProjetTransDev.Vue;

namespace ProjetTransDev
{
    public partial class MainWindow : Window
    {
    
        public MainWindow()
        {
            DALConnection.OpenConnection();
            InitializeComponent();
            this.Content = new Login();   
        }
    }
}
