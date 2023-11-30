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
        private User _User;

        public User User
        {
            get { return _User; }
            set { _User = value; }
        }
    }

}
