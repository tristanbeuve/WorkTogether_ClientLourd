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

namespace WpfApp1.ViewModels
{
    internal class ReservationViewModel : ObservableObject
    {
        #region Fields
        private ObservableCollection<Reservation> _Reservation;

        private Reservation? _SelectedReservation;

        private DelegateCommand<object> _CommandAddReservation;

        private DelegateCommand<object> _CommandRemoveReservation;

        private DelegateCommand<object> _CommandUpdateReservation;
        #endregion

        #region Properties

        public ObservableCollection<Reservation> Reservation { get => _Reservation; set => _Reservation = value; }
        public Reservation? SelectedReservation { get => _SelectedReservation; set => _SelectedReservation = value; }
        public DelegateCommand<object> CommandAddReservation { get => _CommandAddReservation; set => _CommandAddReservation = value; }
        public DelegateCommand<object> CommandRemoveReservation { get => _CommandRemoveReservation; set => _CommandRemoveReservation = value; }
        public DelegateCommand<object> CommandUpdateReservation { get => _CommandUpdateReservation; set => _CommandUpdateReservation = value; }
        #endregion

        #region Constructor
        public ReservationViewModel() 
        {
            CommandRemoveReservation = new DelegateCommand<object>(RemoveReservation, CanRemoveReservation).ObservesProperty(() => this.SelectedReservation);
            CommandUpdateReservation = new DelegateCommand<object>(UpdateReservation, CanUpdateReservation).ObservesProperty(() => this.SelectedReservation);

            using (PpeContext context = new())
            {
                this.Reservation = new ObservableCollection<Reservation>(context.Reservations);
            }
        }
        #endregion

        #region Methods

        internal void RemoveReservation(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedReservation != null)
                {
                    Reservation? Reservation = SelectedReservation;
                    context.Reservations.Remove(Reservation);
                    this._Reservation.Remove(Reservation);
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs");
                }
            }
        }

        internal bool CanRemoveReservation(object? parameter = null) => this.SelectedReservation != null;


        internal void UpdateReservation(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedReservation != null)
                {
                    context.Reservations.Find(SelectedReservation.Id).Quantity = SelectedReservation.Quantity;
                    context.Reservations.Find(SelectedReservation.Id).IdentifiantAbonnementId = SelectedReservation.IdentifiantAbonnementId;
                    context.Reservations.Find(SelectedReservation.Id).RenouvellementId = SelectedReservation.RenouvellementId;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs valide");
                }
            }
        }

        internal bool CanUpdateReservation(object? parameter = null) => this.SelectedReservation != null;


        #endregion
    }
}
