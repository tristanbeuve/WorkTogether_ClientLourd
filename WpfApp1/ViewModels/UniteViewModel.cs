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
    internal class UniteViewModel : ObservableObject
    {
        #region Fields
        private ObservableCollection<Unite> _Unites;

        private Unite? _SelectedUnites;

        private DelegateCommand<object> _CommandUpdateUnite;

        private DelegateCommand<object> _CommandRemoveUnite;

        #endregion

        #region Properties
        public ObservableCollection<Unite> Unites { get => _Unites; set => _Unites = value; }
        public Unite? SelectedUnites { get => _SelectedUnites; set => _SelectedUnites = value; }
        public DelegateCommand<object> CommandUpdateUnite { get => _CommandUpdateUnite; set => _CommandUpdateUnite = value; }
        public DelegateCommand<object> CommandRemoveUnite { get => _CommandRemoveUnite; set => _CommandRemoveUnite = value; }
        #endregion

        #region Constructor
        public UniteViewModel() 
        {
            CommandRemoveUnite = new DelegateCommand<object>(RemoveUnite, CanRemoveUnite).ObservesProperty(() => this.SelectedUnites);
            CommandUpdateUnite = new DelegateCommand<object>(UpdateUnite, CanUpdateUnite).ObservesProperty(() => this.SelectedUnites);
            using (PpeContext context = new())
            {
                this.Unites = new ObservableCollection<Unite>(context.Unites);
            }
        }
        #endregion

        #region Methods
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
        #endregion
    }
}
