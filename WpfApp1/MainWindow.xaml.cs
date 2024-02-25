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
        /// <summary>
        /// Ouvre la fenetre de login et affiche la mainWindow que si l'utilisateur est correctemment authentifié
        /// </summary>
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
        /// <summary>
        /// Cette fonction affiche le dockpanel Home lorsque l'utilisateur click sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new Home());
        }
        /// <summary>
        /// Cette fonction affiche le dockpanel Baies lorsque l'utilisateur click sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListBaies_Click(object sender, RoutedEventArgs e)
        {
            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new WpfApp1.View.Baies());
        }

        /// <summary>
        /// Cette fonction affiche le dockpanel Unite lorsque l'utilisateur click sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListUnite_Click(object sender, RoutedEventArgs e)
        {

            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new WpfApp1.View.Unite());
        }
        /// <summary>
        /// Cette fonction affiche le dockpanel Reservation lorsque l'utilisateur click sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListReservation_Click(object sender, RoutedEventArgs e)
        {

            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new WpfApp1.View.Reservation());
        }
        /// <summary>
        /// Cette fonction affiche le dockpanel Users lorsque l'utilisateur click sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListUser_Click(object sender, RoutedEventArgs e)
        {
            DockPanelMain.Children.Clear();
            DockPanelMain.Children.Add(new WpfApp1.View.Users());
        }
        /// <summary>
        /// Cette fonction ferme l'application lorsque l'utilisateur click sur le bouton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        
    }
}