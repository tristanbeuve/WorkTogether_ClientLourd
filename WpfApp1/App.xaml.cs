using System.Configuration;
using System.Data;
using System.Windows;
using WorkTogetherDBLib.Class;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// getter de l'objet user
        /// </summary>
        private User _User;
        /// <summary>
        /// setter de l'objet user
        /// </summary>
        public User User
        {
            get { return _User; }
            set { _User = value; }
        }
    }

}
