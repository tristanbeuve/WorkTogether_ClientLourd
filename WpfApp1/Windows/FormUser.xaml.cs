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

namespace WpfApp1.Windows
{
    /// <summary>
    /// Logique d'interaction pour FormUser.xaml
    /// </summary>
    public partial class FormUser : Window
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }

        public FormUser()
        {
            InitializeComponent();
            this.DataContext = this;
            annuler.Focus();
        }

        private void Submitadmin_Click(object sender, RoutedEventArgs e)
        {
            if (Password == ConfirmPassword)
            {
                Role = "[\"ROLE_ADMIN\"]";
                this.DialogResult = true;
                this.Close();
            }
        }

        private void Submitcompta_Click(object sender, RoutedEventArgs e)
        {
            if (Password == ConfirmPassword)
            {
                Role = "[\"ROLE_COMPTA\"]";
                this.DialogResult = true;
                this.Close();
            }
            
        }
        private void Submitcustomer_Click(object sender, RoutedEventArgs e)
        {
            if (Password == ConfirmPassword)
            {
                Role = "[\"ROLE_CUSTOMER\"]";
                this.DialogResult = true;
                this.Close();
            }
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
