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
using WorkTogetherDBLib.Class;

namespace WpfApp1.Windows
{
    /// <summary>
    /// Logique d'interaction pour WindowLogin.xaml
    /// Cette fenetre à pour but d'identifier l'utilisateur qui souhaiterais se connecter
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
            Log.Focus();
        }
        /// <summary>
        /// Déclenche l'annulation du login
        /// </summary>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        /// <summary>
        /// Vérifie dans la BDD si le password correspond bien à celui de l'identifient récuoérer grâce à la fonction AuthenticateUser
        /// Si AuthenticateUser retourne false un message d'erreur apparait
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string useremail = txtUsername.Text;
            string password = txtPassword.Password;


            bool isValidUser = AuthenticateUser(useremail, password);
            bool isValideRole = ValidationRole(useremail);

            if (isValidUser && isValideRole)
            {
                this.DialogResult = true;
                this.Close();

            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
            }
        }
        /// <summary>
        /// cette fonction récupère l'objet user qui correspond à cette adresse email et comparre la variable password avec le mot de passe décrypter de la base de donnée qui correspond au user grâce au plus-in BCrypt.Net
        /// </summary>
        /// <param name="useremail">Correspond à l'email fournie par l'utilisateur</param>
        /// <param name="password">Correspond au mot de passe fournie par l'utilisateur</param>
        /// <returns></returns>
        private bool AuthenticateUser(string useremail, string password)
        {

            using (PpeContext context = new PpeContext())
            {

                User? user = context.Users.FirstOrDefault(u => u.Email == useremail);

                bool isPasswordCorrect = BCrypt.Net.BCrypt.Verify(password, user.Password, false, BCrypt.Net.HashType.SHA256);

                ((App)Application.Current).User = user;

                return isPasswordCorrect;
            }
        }

        private bool ValidationRole(string useremail)
        {

            using (PpeContext context = new PpeContext())
            {
                User? user = context.Users.FirstOrDefault(u => u.Email == useremail);
                bool isValidateRole = false;

                if (user != null && (user.Roles.Contains("ROLE_ADMIN") || user.Roles.Contains("ROLE_COMPTA")))
                {
                    isValidateRole = true;
                }
                return isValidateRole;
            }
        }
    }
}

