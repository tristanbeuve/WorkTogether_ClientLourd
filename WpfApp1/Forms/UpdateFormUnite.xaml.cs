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
    /// Logique d'interaction pour UpdateFormUnite.xaml
    /// </summary>
    public partial class UpdateFormUnite : Window
    {
        public int? IdentifiantTypeUniteId { get; set; }
        public bool Status {  get; set; }

        public UpdateFormUnite()
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
            DialogResult = true;
            this.Close();
        }
    }
}
