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
    /// Ce formulaire est destiné à l'dministrateur qui souhaiterais ajouter un utilisateur
    /// </summary>
    public partial class FormUser : Window
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
        /// fait référence au mot de passe du nouvelle utilisateur
        /// </summary>
        public string Password { get; set; }
        
        /// <summary>
        /// sert à confirmer le mot de passe
        /// </summary>
        public string ConfirmPassword { get; set; }
        
        /// /// <summary>
        /// fait référence au rôle du nouvelle utilisateur
        /// </summary>
        public string Role { get; set; }
        
        /// <summary>
        /// on initialise le formulaire
        /// </summary>
        public FormUser()
        {
            InitializeComponent();
            this.DataContext = this;
            annuler.Focus();
        }

        /// <summary>
        /// on va rérifier si ce que contient le champs "Password" et "ConfirmPassword" sont bien identique
        /// si c'est le cas on vérifie que le champs "Role" soit bien égale à "["ROLE_ADMIN"]", si oui on set le dialogResult à true et ferme la fenetre
        /// </summary>
        private void Submitadmin_Click(object sender, RoutedEventArgs e)
        {
            if (Password == ConfirmPassword)
            {
                Role = "[\"ROLE_ADMIN\"]";
                this.DialogResult = true;
                this.Close();
            }
        }
        /// <summary>
        /// on va rérifier si ce que contient le champs "Password" et "ConfirmPassword" sont bien identique
        /// si c'est le cas on vérifie que le champs "Role" soit bien égale à "["ROLE_COMPTA"]", si oui on set le dialogResult à true et ferme la fenetre
        /// </summary>
        private void Submitcompta_Click(object sender, RoutedEventArgs e)
        {
            if (Password == ConfirmPassword)
            {
                Role = "[\"ROLE_COMPTA\"]";
                this.DialogResult = true;
                this.Close();
            }
            
        }
        /// <summary>
        /// on va rérifier si ce que contient le champs "Password" et "ConfirmPassword" sont bien identique
        /// si c'est le cas on vérifie que le champs "Role" soit bien égale à "["ROLE_CUSTOMER"]", si oui on set le dialogResult à true et ferme la fenetre
        /// </summary>
        private void Submitcustomer_Click(object sender, RoutedEventArgs e)
        {
            if (Password == ConfirmPassword)
            {
                Role = "[\"ROLE_CUSTOMER\"]";
                this.DialogResult = true;
                this.Close();
            }
            
        }
        /// <summary>
        /// Si le champs le champs "Role" n'est pas égale ni à "", "" ou "" alors on ferme la fenetre en laissant la variable "DialogResult" égale à "False"
        /// </summary>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
