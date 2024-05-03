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
using System.Windows.Shapes;

namespace WpfApp1.Windows.Forms
{
    /// <summary>
    /// Logique d'interaction pour UpdateFormReservation.xaml
    /// </summary>
    public partial class UpdateFormReservation : Window
    {
        public DateTime DateDeb {  get; set; }
        public DateTime DateEnd {  get; set; }
        public bool RenAuto { get; set; }
        public int Quantity { get; set; }
        public bool Delaie { get; set; }

        public UpdateFormReservation()
        {
            InitializeComponent();
            this.DataContext = this;
            annuler.Focus();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void valider_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
