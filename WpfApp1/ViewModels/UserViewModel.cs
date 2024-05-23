using Microsoft.EntityFrameworkCore;
using Modules;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkTogetherDBLib.Class;
using WpfApp1.View;
using WpfApp1.Windows;

namespace WpfApp1.ViewModels
{
    internal class UserViewModel : ObservableObject
    {
        #region Fields
        /// <summary>
        /// getter de la liste des Users
        /// </summary>
        private ObservableCollection<User> _Users;
        /// <summary>
        /// getter du User sélectionné
        /// </summary>
        private User? _SelectedUser;
        /// <summary>
        /// getter de la commande AddUser
        /// </summary>
        private DelegateCommand<object> _CommandAddUser;
        /// <summary>
        /// getter de la commande RemoveUser
        /// </summary>
        private DelegateCommand<object> _CommandRemoveUser;
        /// <summary>
        /// getter de la commande UpdateUser
        /// </summary>
        private DelegateCommand<object> _CommandUpdateUser;

        #endregion

        #region Properties
        /// <summary>
        /// setter de la liste Users
        /// </summary>
        public ObservableCollection<User> Users { get => _Users; set => _Users = value; }
        /// <summary>
        /// setter du User sélectionné
        /// </summary>
        public User? SelectedUser { get => _SelectedUser; set => _SelectedUser = value; }
        /// <summary>
        /// setter de la commande AddUser
        /// </summary>
        public DelegateCommand<object> CommandAddUser { get => _CommandAddUser; set => _CommandAddUser = value; }
        /// <summary>
        /// setter de la commande RemoveUser
        /// </summary>
        public DelegateCommand<object> CommandRemoveUser { get => _CommandRemoveUser; set => _CommandRemoveUser = value; }
        /// <summary>
        /// setter de la commande UpdateUser
        /// </summary>
        public DelegateCommand<object> CommandUpdateUser { get => _CommandUpdateUser; set => _CommandUpdateUser = value; }
        #endregion

        #region Constructer
        /// <summary>
        /// constructeur du viewmodel et des commandes AddUser, RemoveUser, UpdateUser
        /// </summary>
        public UserViewModel()
        {
            CommandAddUser = new DelegateCommand<object>(AddUser, CanAddUser).ObservesProperty(() => this.SelectedUser);
            CommandRemoveUser = new DelegateCommand<object>(RemoveUser, CanRemoveUser).ObservesProperty(() => this.SelectedUser);
            CommandUpdateUser = new DelegateCommand<object>(UpdateUser, CanUpdateUser).ObservesProperty(() => this.SelectedUser);

            using (PpeContext context = new())
            {
                this.Users = new ObservableCollection<User>(context.Users.Include(u => u.Reservations));
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// définition de la commande AddUser
        /// </summary>
        /// <param name="parameter"></param>
        internal void AddUser(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                FormUser form = new FormUser();
                form.ShowDialog();
                if(form.DialogResult == true)
                {
                    User Users = new User();
                    Users.Email = form.Email;
                    Users.Password = BCrypt.Net.BCrypt.HashPassword(form.Password);
                    BCrypt.Net.BCrypt.HashPassword(form.Password, 13);
                    Users.Roles = form.Role;
                    Users.Prenom = form.Prenom;
                    Users.Nom = form.Nom;
                    context.Users.Add(Users);
                    this.Users.Add(Users);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("L'ajout a été interrompu");
                }
            }
        }
        /// <summary>
        /// définie si une baie à été séléctionné au préalable
        /// </summary>
        internal bool CanAddUser(object? parameter = null) => this.SelectedUser != null;

        /// <summary>
        /// définition de la commande RemoveUser
        /// </summary>
        /// <param name="parameter"></param>
        internal void RemoveUser(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedUser != null)
                {
                    //User user = context.Users.Include(u => u.Reservations).SingleOrDefault(u => u.Id == SelectedUser.Id);
                    User? User = SelectedUser;
                    if (User.Reservations.Any() && User.Roles.Equals("[\"ROLE_ADMIN\"]"))
                    {
                        MessageBox.Show("Erreur ! Il semblerait que cet utilisateur possède des réservations");
                        
                    }
                    else
                    {

                        context.Users.Remove(User);
                        this.Users.Remove(User);
                        context.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs");
                }
            }
        }
        /// <summary>
        /// définie si une baie à été séléctionné au préalable
        /// </summary>
        internal bool CanRemoveUser(object? parameter = null) => this.SelectedUser != null;

        /// <summary>
        /// définition de la commande UpdateUser
        /// </summary>
        /// <param name="parameter"></param>
        internal void UpdateUser(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedUser != null)
                {
                    UpdateFormUser form = new UpdateFormUser();
                    form.Email = SelectedUser.Email;
                    form.Nom = SelectedUser.Nom;
                    form.Prenom = SelectedUser.Prenom;
                    form.ShowDialog();
                    if (form.DialogResult == true)
                    {
                        User User = SelectedUser;
                        User.Email = form.Email;
                        User.Prenom = form.Prenom;
                        User.Nom = form.Nom;
                        context.Users.Update(User);
                        context.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs valide");
                }
            }
        }
        /// <summary>
        /// définie si une baie à été séléctionné au préalable
        /// </summary>
        internal bool CanUpdateUser(object? parameter = null) => this.SelectedUser != null;
        #endregion
    }
}
