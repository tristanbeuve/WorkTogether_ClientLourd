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
using WpfApp1.Windows.Forms;

namespace WpfApp1.ViewModels
{
    internal class UniteViewModel : ObservableObject
    {
        #region Fields
        /// <summary>
        /// getter de la liste unites
        /// </summary>
        private ObservableCollection<Unite> _Unites;
        /// <summary>
        /// getter de l'unite séléctionné
        /// </summary>
        private Unite? _SelectedUnites;
        /// <summary>
        /// getter de la commande UpdateUnite
        /// </summary>
        private DelegateCommand<object> _CommandUpdateUnite;
        /// <summary>
        /// getter de la commande RemoveUnite
        /// </summary>
        private DelegateCommand<object> _CommandRemoveUnite;

        #endregion

        #region Properties
        /// <summary>
        /// setter de la liste d'Unites
        /// </summary>
        public ObservableCollection<Unite> Unites { get => _Unites; set => _Unites = value; }
        /// <summary>
        /// setter de l'Unite sélectionné
        /// </summary>
        public Unite? SelectedUnites { get => _SelectedUnites; set => _SelectedUnites = value; }
        /// <summary>
        /// setter de la commande Unite
        /// </summary>
        public DelegateCommand<object> CommandUpdateUnite { get => _CommandUpdateUnite; set => _CommandUpdateUnite = value; }
        /// <summary>
        /// setter de la commande Unite
        /// </summary>
        public DelegateCommand<object> CommandRemoveUnite { get => _CommandRemoveUnite; set => _CommandRemoveUnite = value; }
        #endregion

        #region Constructor
        /// <summary>
        /// constructeur du viewmodel et des commandes RemoveUnite, UpdateUnite
        /// </summary>
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
        /// <summary>
        /// définition de la commande RemoveUnite
        /// </summary>
        /// <param name="parameter"></param>
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
        /// <summary>
        /// définie si une baie à été séléctionné au préalable
        /// </summary>
        internal bool CanRemoveUnite(object? parameter = null) => this.SelectedUnites != null;

        /// <summary>
        /// définition de la commande UpdateUnite
        /// </summary>
        /// <param name="parameter"></param>
        internal void UpdateUnite(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedUnites != null)
                {
                    UpdateFormUnite form = new UpdateFormUnite();
                    form.Status = SelectedUnites.Status;
                    form.IdentifiantTypeUniteId = SelectedUnites.IdentifiantTypeUniteId;
                    form.ShowDialog();
                    if (form.DialogResult == true)
                    {
                        Unite Unite = SelectedUnites;
                        Unite.Status = form.Status;
                        Unite.IdentifiantTypeUniteId = form.IdentifiantTypeUniteId;
                        context.Unites.Update(Unite);
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
        internal bool CanUpdateUnite(object? parameter = null) => this.SelectedUnites != null;
        #endregion
    }
}
