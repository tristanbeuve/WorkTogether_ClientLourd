using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using WorkTogetherDBLib.Class;

namespace WpfApp1.ViewModels
{
    internal class LoginViewModels
    {
        #region Fields
        /// <summary>
        /// getter de l'objet User
        /// </summary>

        private ObservableCollection<User> _User;

        #endregion

        #region Properties
        /// <summary>
        /// setter de l'objet user
        /// </summary>
        public ObservableCollection<User> User { get => _User; set => _User = value; }

        #endregion


        #region Constructors
        /// <summary>
        /// Construction de la liste d'objet User
        /// </summary>
        /// <param name="context"></param>
        public LoginViewModels(PpeContext context)
        {
            this.User = new ObservableCollection<User>(context.Users);
        }

        #endregion
    }
}
