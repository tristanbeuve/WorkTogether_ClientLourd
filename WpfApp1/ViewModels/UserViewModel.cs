﻿using Modules;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WorkTogetherDBLib.Class;
using WpfApp1.Windows;

namespace WpfApp1.ViewModels
{
    internal class UserViewModel : ObservableObject
    {
        #region Fields
        private ObservableCollection<User> _Users;

        private User? _SelectedUser;

        private DelegateCommand<object> _CommandAddUser;

        private DelegateCommand<object> _CommandRemoveUser;

        private DelegateCommand<object> _CommandUpdateUser;

        #endregion

        #region Properties
        public ObservableCollection<User> Users { get => _Users; set => _Users = value; }
        public User? SelectedUser { get => _SelectedUser; set => _SelectedUser = value; }
        public DelegateCommand<object> CommandAddUser { get => _CommandAddUser; set => _CommandAddUser = value; }
        public DelegateCommand<object> CommandRemoveUser { get => _CommandRemoveUser; set => _CommandRemoveUser = value; }
        public DelegateCommand<object> CommandUpdateUser { get => _CommandUpdateUser; set => _CommandUpdateUser = value; }

        #endregion

        #region Constructer
        public UserViewModel()
        {
            CommandAddUser = new DelegateCommand<object>(AddUser, CanAddUser).ObservesProperty(() => this.SelectedUser);
            CommandRemoveUser = new DelegateCommand<object>(RemoveUser, CanRemoveUser).ObservesProperty(() => this.SelectedUser);
            CommandUpdateUser = new DelegateCommand<object>(UpdateUser, CanUpdateUser).ObservesProperty(() => this.SelectedUser);

            using (PpeContext context = new())
            {
                this.Users = new ObservableCollection<User>(context.Users);
            }
        }
        #endregion

        #region Methods
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
                    Users.Password.Replace("$2a$11$", "$2y$13$");
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

        internal bool CanAddUser(object? parameter = null) => this.SelectedUser != null;


        internal void RemoveUser(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedUser != null)
                {
                    User? User = SelectedUser;
                    context.Users.Remove(User);
                    this.Users.Remove(User);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs");
                }
            }
        }

        internal bool CanRemoveUser(object? parameter = null) => this.SelectedUser != null;


        internal void UpdateUser(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedUser != null)
                {
                    context.Users.Find(SelectedUser.Id).Email = SelectedUser.Email;
                    context.Users.Find(SelectedUser.Id).Nom = SelectedUser.Nom;
                    context.Users.Find(SelectedUser.Id).Prenom = SelectedUser.Prenom;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs valide");
                }
            }
        }

        internal bool CanUpdateUser(object? parameter = null) => this.SelectedUser != null;
        #endregion
    }
}
