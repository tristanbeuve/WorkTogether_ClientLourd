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

            WindowLogin windowLogin =new WindowLogin();
            windowLogin.ShowDialog();

            if (windowLogin.DialogResult == false)
            {
                this.Close();
            }
        }

        private void ListBaies_Click(object sender, RoutedEventArgs e)
        {
            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new Baies());
        }

        private void ListUnite_Click(object sender, RoutedEventArgs e)
        {

            DockPanelMain.Children.Clear();
        }

        private void ListReservation_Click(object sender, RoutedEventArgs e)
        {

            DockPanelMain.Children.Clear();
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}