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
    /// Logique d'interaction pour UpdateFormBaie.xaml
    /// </summary>
    public partial class UpdateFormBaie : Window
    {

        public int NbrEmplacement { get; set; }
        public bool Status { get; set; }



        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void valider_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
        public UpdateFormBaie()
        {
            InitializeComponent();
            this.DataContext = this;
            annuler.Focus();
        }
    }
}
