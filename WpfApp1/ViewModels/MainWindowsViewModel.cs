using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Modules;
using WorkTogetherDBLib.Class;

namespace WpfApp1.ViewModels
{
    class MainWindowsViewModel : ObservableObject
    {
        #region Fields

        private ObservableCollection<Baie> _Baies;

        private Baie? _SelectedBaies;

        private ObservableCollection<Unite> _Unites;

        private Unite? _SelectedUnites;

        private ObservableCollection<Reservation> _Reservation;

        private Reservation? _SelectedReservation;

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
        #endregion

        #region Constructor

        public MainWindowsViewModel()
        {
            using (PpeContext context = new()) {
                this.Baies = new ObservableCollection<Baie>(context.Baies);
                this.Unites = new ObservableCollection<Unite>(context.Unites);
                this.Reservation = new ObservableCollection<Reservation>(context.Reservations);
            }
        }

        #endregion

    }
}
