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
    /// </summary>
    public partial class WindowLogin : Window
    {
        public WindowLogin()
        {
            InitializeComponent();
            Log.Focus();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string useremail = txtUsername.Text;
            string password = txtPassword.Password;


            bool isValidUser = AuthenticateUser(useremail, password);

            if (isValidUser)
            {
                this.DialogResult = true;
                this.Close();

            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.");
            }
        }

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
    }
}

