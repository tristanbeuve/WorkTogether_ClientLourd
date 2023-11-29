﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Modules;
using WorkTogetherDBLib.Class;
using Prism.Commands;

namespace WpfApp1.ViewModels
{
    class MainWindowsViewModel : ObservableObject
    {
        #region Fields

        private ObservableCollection<Baie> _Baies;

        private Baie? _SelectedBaies;

        private DelegateCommand<object> _CommandAddBaie;

        private DelegateCommand<object> _CommandRemoveBaie;

        private DelegateCommand<object> _CommandUpdateBaie;

        private ObservableCollection<Unite> _Unites;

        private Unite? _SelectedUnites;

        private ObservableCollection<Reservation> _Reservation;

        private Reservation? _SelectedReservation;

        private ObservableCollection<User> _Users;

        private User? _SelectedUser;

        #endregion

        #region Properties

        public ObservableCollection<Baie> Baies 
        { 
            get => _Baies; 
            set => _Baies = value; 
        }
        public Baie? SelectedBaies 
        { 
            get => _SelectedBaies; 
            set => _SelectedBaies = value; 
        }

        public ObservableCollection<Unite> Unites
        {
            get =>_Unites;
            set => _Unites = value;
        }

        public Unite? SelectedUnites {
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

        #endregion

        #region Constructor

        public MainWindowsViewModel()
        {
            CommandAddBaie = new DelegateCommand<object>(AddBaie, CanAddBaie).ObservesProperty(() => this.SelectedBaies);
            CommandRemoveBaie = new DelegateCommand<object>(RemoveBaie, CanRemoveBaie).ObservesProperty(() => this.SelectedBaies);
            CommandUpdateBaie = new DelegateCommand<object>(RemoveBaie, CanRemoveBaie).ObservesProperty(() => this.SelectedBaies);


            using (PpeContext context = new()) {
                this.Baies = new ObservableCollection<Baie>(context.Baies);
                this.Unites = new ObservableCollection<Unite>(context.Unites);
                this.Reservation = new ObservableCollection<Reservation>(context.Reservations);
                this.Users = new ObservableCollection<User>(context.Users);
            }
        }

        #endregion

        #region Methods

        internal void AddBaie(object ?parameter = null)
        {
            using (PpeContext context = new())
            {
                Baie Baies = new Baie();
                Baies.NbrEmplacement = 42;
                Baies.Status = false;
                context.Baies.Add(Baies);
                this._Baies.Add(Baies);
                context.SaveChanges();
            }
        }

        internal bool CanAddBaie(object ?parameter = null) => this.SelectedBaies != null;


        internal void RemoveBaie(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                Baie? Baies = SelectedBaies;
                context.Baies.Remove(Baies);
                this._Baies.Remove(Baies);
                context.SaveChanges();
            }
        }

        internal bool CanRemoveBaie(object? parameter = null) => this.SelectedBaies != null;


        internal void UpdateBaie(object? parameter = null)
        {
            using (PpeContext context = new())
            {

                context.Baies.Find(SelectedBaies.Id).NbrEmplacement = SelectedBaies.NbrEmplacement;
                context.Baies.Find(SelectedBaies.Id).Status = SelectedBaies.Status;
                context.SaveChanges();
            }
        }

        internal bool CanUpdateBaie(object? parameter = null) => this.SelectedBaies != null;


        #endregion

    }
}
