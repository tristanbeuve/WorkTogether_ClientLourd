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
        /// <summary>
        /// getter de la liste de réservation
        /// </summary>
        private ObservableCollection<Reservation> _Reservation;
        /// <summary>
        /// getter de la reservtaion séléctionné par l'utilisateur
        /// </summary>
        private Reservation? _SelectedReservation;
        /// <summary>
        /// getter de la commande AddReservation
        /// </summary>
        private DelegateCommand<object> _CommandAddReservation;
        /// <summary>
        /// getter de la commande RemoveReservation
        /// </summary>
        private DelegateCommand<object> _CommandRemoveReservation;
        /// <summary>
        /// getter de la commande UpdateReservation
        /// </summary>
        private DelegateCommand<object> _CommandUpdateReservation;
        #endregion

        #region Properties
        /// <summary>
        /// setter de la liste de Reservation
        /// </summary>
        public ObservableCollection<Reservation> Reservation { get => _Reservation; set => _Reservation = value; }
        /// <summary>
        /// setter de la reservation séléctionné par l'utilisateur
        /// </summary>
        public Reservation? SelectedReservation { get => _SelectedReservation; set => _SelectedReservation = value; }
        /// <summary>
        /// setter de la commande AddReservation
        /// </summary>
        public DelegateCommand<object> CommandAddReservation { get => _CommandAddReservation; set => _CommandAddReservation = value; }
        /// <summary>
        /// setter de la commande RemoveReservation
        /// </summary>
        public DelegateCommand<object> CommandRemoveReservation { get => _CommandRemoveReservation; set => _CommandRemoveReservation = value; }
        /// <summary>
        /// setter de la commande UpdateReservation
        /// </summary>
        public DelegateCommand<object> CommandUpdateReservation { get => _CommandUpdateReservation; set => _CommandUpdateReservation = value; }
        #endregion

        #region Constructor
        /// <summary>
        /// constructeur du viewmodel et des commandes AddReservation, RemoveReservation, UpdateReservation
        /// </summary>
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
        /// <summary>
        /// définition de la méthode RemoveReservation
        /// </summary>
        /// <param name="parameter"></param>
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
        /// <summary>
        /// définie si une baie à été séléctionné au préalable
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        internal bool CanRemoveReservation(object? parameter = null) => this.SelectedReservation != null;


        /// <summary>
        /// définition de la méthode UpdateReservation
        /// </summary>
        /// <param name="parameter"></param>
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
        /// <summary>
        /// définie si une baie à été séléctionné au préalable
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        internal bool CanUpdateReservation(object? parameter = null) => this.SelectedReservation != null;


        #endregion
    }
}
