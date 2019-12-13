using System.Windows;
using ProjetTransDev.DAL;
using ProjetTransDev.Vue;

namespace ProjetTransDev
{
    public partial class MainWindow : Window
    {
    
        public MainWindow()
        {
            InitializeComponent();
            this.Content = new Login();   
        }
    }
}
