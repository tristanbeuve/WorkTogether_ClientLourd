using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Windows;
using WpfApp1.ViewModels;
using WorkTogetherDBLib.Class;
using WpfApp1.View;
using System.Globalization;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowsViewModel();


            WindowLogin windowLogin = new WindowLogin();
            windowLogin.ShowDialog();

            if (windowLogin.DialogResult == false)
            {
                this.Close();
            }

            
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new Home());
        }

        private void ListBaies_Click(object sender, RoutedEventArgs e)
        {
            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new WpfApp1.View.Baies());
        }

        private void ListUnite_Click(object sender, RoutedEventArgs e)
        {

            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new WpfApp1.View.Unite());
        }

        private void ListReservation_Click(object sender, RoutedEventArgs e)
        {

            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new WpfApp1.View.Reservation());
        }

        private void ListUser_Click(object sender, RoutedEventArgs e)
        {
            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new WpfApp1.View.Users());
        }

        private void Fermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}