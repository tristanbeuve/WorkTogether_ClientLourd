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
    /// Logique d'interaction pour Users.xaml
    /// </summary>
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
            this.DataContext = new UserViewModel();
        }
        /// <summary>
        /// cette fonction permet de déclencher la fonction AddUser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            ((UserViewModel)this.DataContext).AddUser();
        }
        /// <summary>
        /// cette fonction permet de déclencher la fonction RemoveUser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            ((UserViewModel)this.DataContext).RemoveUser();
        }
        /// <summary>
        /// cette fonction permet de déclencher la fonction UpdateUser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            ((UserViewModel)this.DataContext).UpdateUser();
        }
    }
}
