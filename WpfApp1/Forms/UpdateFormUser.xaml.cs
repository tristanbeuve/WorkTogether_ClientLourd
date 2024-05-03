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
    /// Logique d'interaction pour UpdateFormUser.xaml
    /// </summary>
    public partial class UpdateFormUser : Window
    {
        /// <summary>
        /// fait référence au nom du nouvelle utilisateur
        /// </summary>
        public string Nom { get; set; }
        /// <summary>
        /// fait référence au prénom du nouvelle utilisateur
        /// </summary>
        public string Prenom { get; set; }
        /// <summary>
        /// fait référence à l'adresse email du nouvelle utilisateur
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// on initialise le formulaire
        /// </summary>
        public UpdateFormUser()
        {
            InitializeComponent();
            this.DataContext = this;
            annuler.Focus();
        }

        /// <summary>
        /// Si le champs le champs "Role" n'est pas égale ni à "", "" ou "" alors on ferme la fenetre en laissant la variable "DialogResult" égale à "False"
        /// </summary>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Valid_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            this.Close();
        }
    }
}
