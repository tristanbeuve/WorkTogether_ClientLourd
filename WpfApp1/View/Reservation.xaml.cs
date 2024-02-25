using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.ViewModels;

namespace WpfApp1.View
{
    /// <summary>
    /// Logique d'interaction pour Reservation.xaml
    /// </summary>
    public partial class Reservation : UserControl
    {
        public Reservation()
        {
            InitializeComponent();

            this.DataContext = new ReservationViewModel();
        }

        /// <summary>
        /// cette fonction permet de déclencher la fonction RemoveReservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            ((ReservationViewModel)this.DataContext).RemoveReservation();
        }
        /// <summary>
        /// cette fonction permet de déclencher la fonction UpdateReservation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            ((ReservationViewModel)this.DataContext).UpdateReservation();
        }
    }
}
