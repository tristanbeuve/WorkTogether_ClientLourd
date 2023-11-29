using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Modules;
using WorkTogetherDBLib.Class;
using Prism.Commands;
using System.Windows;

namespace WpfApp1.ViewModels
{
    class MainWindowsViewModel : ObservableObject
    {
        #region Fields
        //BAIE

        private ObservableCollection<Baie> _Baies;

        private Baie? _SelectedBaies;

        private DelegateCommand<object> _CommandAddBaie;

        private DelegateCommand<object> _CommandRemoveBaie;

        private DelegateCommand<object> _CommandUpdateBaie;

        //UNITE

        private ObservableCollection<Unite> _Unites;

        private Unite? _SelectedUnites;

        private DelegateCommand<object> _CommandUpdateUnite;

        private DelegateCommand<object> _CommandRemoveUnite;

        //TYPE UNITE

        private ObservableCollection<TypeUnite> _TypeUnites;

        private DelegateCommand<object> _SelectedTypeUnite;

        //RESERVATION

        private ObservableCollection<Reservation> _Reservation;

        private Reservation? _SelectedReservation;

        private DelegateCommand<object> _CommandAddReservation;

        private DelegateCommand<object> _CommandRemoveReservation;

        private DelegateCommand<object> _CommandUpdateReservation;

        //USERS

        private ObservableCollection<User> _Users;

        private User? _SelectedUser;

        private DelegateCommand<object> _CommandAddUser;

        private DelegateCommand<object> _CommandRemoveUser;

        private DelegateCommand<object> _CommandUpdateUser;

        #endregion

        #region Properties

        public ObservableCollection<Baie> Baies { get => _Baies; set => _Baies = value; }
        public Baie? SelectedBaies
        {
            get => _SelectedBaies;
            set => _SelectedBaies = value;
        }

        public ObservableCollection<Unite> Unites
        {
            get => _Unites;
            set => _Unites = value;
        }

        public Unite? SelectedUnites
        {
            get => _SelectedUnites;
            set => _SelectedUnites = value;
        }
        public ObservableCollection<Reservation> Reservation
        {
            get => _Reservation;
            set => _Reservation = value;
        }
        public Reservation? SelectedReservation
        {
            get => _SelectedReservation;
            set => _SelectedReservation = value;
        }
        public DelegateCommand<object> CommandAddBaie { get => _CommandAddBaie; set => _CommandAddBaie = value; }
        public DelegateCommand<object> CommandRemoveBaie { get => _CommandRemoveBaie; set => _CommandRemoveBaie = value; }
        public DelegateCommand<object> CommandUpdateBaie { get => _CommandUpdateBaie; set => _CommandUpdateBaie = value; }
        public ObservableCollection<User> Users { get => _Users; set => _Users = value; }
        public User? SelectedUser { get => _SelectedUser; set => _SelectedUser = value; }
        public DelegateCommand<object> CommandUpdateUnite { get => _CommandUpdateUnite; set => _CommandUpdateUnite = value; }
        public DelegateCommand<object> CommandAddReservation { get => _CommandAddReservation; set => _CommandAddReservation = value; }
        public DelegateCommand<object> CommandRemoveReservation { get => _CommandRemoveReservation; set => _CommandRemoveReservation = value; }
        public DelegateCommand<object> CommandUpdateReservation { get => _CommandUpdateReservation; set => _CommandUpdateReservation = value; }
        public ObservableCollection<TypeUnite> TypeUnites { get => _TypeUnites; set => _TypeUnites = value; }
        public DelegateCommand<object> SelectedTypeUnite { get => _SelectedTypeUnite; set => _SelectedTypeUnite = value; }
        public DelegateCommand<object> CommandRemoveUnite { get => _CommandRemoveUnite; set => _CommandRemoveUnite = value; }
        public DelegateCommand<object> CommandAddUser { get => _CommandAddUser; set => _CommandAddUser = value; }
        public DelegateCommand<object> CommandRemoveUser { get => _CommandRemoveUser; set => _CommandRemoveUser = value; }
        public DelegateCommand<object> CommandUpdateUser { get => _CommandUpdateUser; set => _CommandUpdateUser = value; }

        #endregion

        #region Constructor

        public MainWindowsViewModel()
        {
            CommandAddBaie = new DelegateCommand<object>(AddBaie, CanAddBaie).ObservesProperty(() => this.SelectedBaies);
            CommandRemoveBaie = new DelegateCommand<object>(RemoveBaie, CanRemoveBaie).ObservesProperty(() => this.SelectedBaies);
            CommandUpdateBaie = new DelegateCommand<object>(RemoveBaie, CanRemoveBaie).ObservesProperty(() => this.SelectedBaies);
            CommandRemoveUnite = new DelegateCommand<object>(RemoveUnite, CanRemoveUnite).ObservesProperty(() => this.SelectedUnites);
            CommandUpdateUnite = new DelegateCommand<object>(UpdateUnite, CanUpdateUnite).ObservesProperty(() => this.SelectedUnites);
            CommandAddUser = new DelegateCommand<object>(AddUser, CanAddUser).ObservesProperty(()=> this.SelectedUser);
            CommandRemoveUser = new DelegateCommand<object>(RemoveUser, CanRemoveUser).ObservesProperty(()=> this.SelectedUser);
            CommandUpdateUser = new DelegateCommand<object>(UpdateUser, CanUpdateUser).ObservesProperty(() => this.SelectedUser);

            using (PpeContext context = new())
            {
                this.Baies = new ObservableCollection<Baie>(context.Baies);
                this.Unites = new ObservableCollection<Unite>(context.Unites);
                this.Reservation = new ObservableCollection<Reservation>(context.Reservations);
                this.Users = new ObservableCollection<User>(context.Users);
                this.TypeUnites = new ObservableCollection<TypeUnite>(context.TypeUnites);
            }
        }

        #endregion

        #region Methods

        //BAIE

        internal void AddBaie(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                Baie Baies = new Baie();
                Baies.NbrEmplacement = 42;
                Baies.Status = false;
                context.Baies.Add(Baies);
                this._Baies.Add(Baies);
                context.SaveChanges();

                for (int i = 0; i < 42; i++)
                {
                    Unite Unites = new Unite();
                    Unites.IdentifiantBaieId = Baies.Id;
                    Unites.IdentifiantTypeUniteId = 1;
                    Unites.Status = false;
                    Unites.Numero = "111";
                    context.Unites.Add(Unites);
                    this.Unites.Add(Unites);

                }
                context.SaveChanges();
            }
        }

        internal bool CanAddBaie(object? parameter = null) => this.SelectedBaies != null || this.SelectedUnites != null;


        internal void RemoveBaie(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedBaies != null)
                {
                    Baie? Baies = SelectedBaies;
                    context.Baies.Remove(Baies);
                    this._Baies.Remove(Baies);
                    context.SaveChanges();
                    for (int i = 0; i < Baies.NbrEmplacement; i++)
                    {
                        Unite Unites = SelectedUnites;
                        if (Baies.Id == Unites.IdentifiantBaieId)
                        {
                            context.Unites.Remove(Unites);
                            this.Unites.Remove(Unites);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs");
                }

                context.SaveChanges();
            }
        }

        internal bool CanRemoveBaie(object? parameter = null) => this.SelectedBaies != null || this.SelectedUnites != null;


        internal void UpdateBaie(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedBaies != null)
                {
                    context.Baies.Find(SelectedBaies.Id).NbrEmplacement = SelectedBaies.NbrEmplacement;
                    context.Baies.Find(SelectedBaies.Id).Status = SelectedBaies.Status;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs");
                }
            }
        }

        internal bool CanUpdateBaie(object? parameter = null) => this.SelectedBaies != null;


        //UNITE


        internal void RemoveUnite(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedUnites != null)
                {
                    Unite? Unite = SelectedUnites;
                    context.Unites.Remove(Unite);
                    this._Unites.Remove(Unite);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs");
                }

            }
        }

        internal bool CanRemoveUnite(object? parameter = null) => this.SelectedUnites != null;


        internal void UpdateUnite(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedUnites != null)
                {
                    context.Unites.Find(SelectedUnites.Id).IdentifiantTypeUniteId = SelectedUnites.IdentifiantTypeUniteId;
                    context.Unites.Find(SelectedUnites.Id).IdentifiantReservationId = SelectedUnites.IdentifiantReservationId;
                    context.Unites.Find(SelectedUnites.Id).IdentifiantBaieId = SelectedUnites.IdentifiantBaieId;
                    context.Unites.Find(SelectedUnites.Id).Status = SelectedUnites.Status;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs");
                }
            }
        }

        internal bool CanUpdateUnite(object? parameter = null) => this.SelectedUnites != null;

        //USER

        internal void AddUser(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                User Users = new User();
                Users.Email = "admin@2admin.com";
                Users.Password = BCrypt.Net.BCrypt.HashPassword("Not24get");
                //Users.Password.Replace("$2a$13$", "$2y$13$");
                Users.Roles = "[\'ROLE_ADMIN\']";
                Users.Prenom = "Josselin";
                Users.Nom = "Yann";
                context.Users.Add(Users);
                this._Users.Add(Users);
                context.SaveChanges();
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
                    this._Users.Remove(User);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs");
                }
            }
        }

        internal bool CanRemoveUser(object? parameter = null) => this.SelectedBaies != null || this.SelectedUnites != null;


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
