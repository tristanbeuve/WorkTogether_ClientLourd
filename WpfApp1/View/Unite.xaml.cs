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
    /// Logique d'interaction pour Unite.xaml
    /// </summary>
    public partial class Unite : UserControl
    {
        public Unite()
        {
            InitializeComponent();
            this.DataContext = new UniteViewModel();
        }

        /// <summary>
        /// cette fonction permet de déclencher la fonction AddBaie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Ajouter_Click(object sender, RoutedEventArgs e)
        {
            ((BaieViewModel)this.DataContext).AddBaie();
        }

        /// <summary>
        /// cette fonction permet de déclencher la fonction RemoveUnite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {

            ((UniteViewModel)this.DataContext).RemoveUnite();
        }
        /// <summary>
        /// cette fonction permet de déclencher la fonction UpdateUnite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Modifier_Click(object sender, RoutedEventArgs e)
        {
            ((UniteViewModel)this.DataContext).UpdateUnite();
        }
    }
}
