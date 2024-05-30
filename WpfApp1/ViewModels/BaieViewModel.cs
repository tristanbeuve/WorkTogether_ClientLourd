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
using WpfApp1.Windows.Forms;


namespace WpfApp1.ViewModels
{
    internal class BaieViewModel : ObservableObject
    {
        #region Fields
        /// <summary>
        /// getter de la liste de baie
        /// </summary>
        private ObservableCollection<Baie> _Baie;
        /// <summary>
        /// getter d'une baie séléctionné par l'utilisateur
        /// </summary>
        private Baie? _SelectedBaie;
        /// <summary>
        /// getter de la commande AddBaie
        /// </summary>
        private DelegateCommand<object> _CommandAddBaie;
        /// <summary>
        /// getter de la commande RemoveBaie
        /// </summary>
        private DelegateCommand<object> _CommandRemoveBaie;
        /// <summary>
        /// getter de la commande UpdateBaie
        /// </summary>
        private DelegateCommand<object> _CommandUpdateBaie;

        #endregion

        #region Properties
        /// <summary>
        /// setter de la liste de baie
        /// </summary>
        public ObservableCollection<Baie> Baie { get => _Baie; set => _Baie = value; }
        /// <summary>
        /// setter de la baie selectionné par l'utilisateur
        /// </summary>
        public Baie? SelectedBaie { get => _SelectedBaie; set => _SelectedBaie = value; }
        /// <summary>
        /// setter de la commande AddBaie
        /// </summary>
        public DelegateCommand<object> CommandAddBaie { get => _CommandAddBaie; set => _CommandAddBaie = value; }
        /// <summary>
        /// setter de la commande RemoveBaie
        /// </summary>
        public DelegateCommand<object> CommandRemoveBaie { get => _CommandRemoveBaie; set => _CommandRemoveBaie = value; }
        /// <summary>
        /// setter de la commande UpdateBaie
        /// </summary>
        public DelegateCommand<object> CommandUpdateBaie { get => _CommandUpdateBaie; set => _CommandUpdateBaie = value; }

        #endregion

        #region Constructor
        /// <summary>
        /// constructeur du viewmodel et des commandes AddBaie, RemoveBaie, UpdateBaie
        /// </summary>
        public BaieViewModel() 
        {
            CommandAddBaie = new DelegateCommand<object>(AddBaie, CanAddBaie).ObservesProperty(() => this.SelectedBaie);
            CommandRemoveBaie = new DelegateCommand<object>(RemoveBaie, CanRemoveBaie).ObservesProperty(() => this.SelectedBaie);
            CommandUpdateBaie = new DelegateCommand<object>(UpdateBaie, CanUpdateBaie).ObservesProperty(() => this.SelectedBaie);

            using (PpeContext context = new())
            {
                this.Baie = new ObservableCollection<Baie>(context.Baies.Include(u => u.Unites).ThenInclude(u => u.IdentifiantReservation));
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// définition de la commande AddBaie
        /// </summary>
        /// <param name="parameter"></param>
        internal void AddBaie(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                Baie baie = new Baie();
                baie.NbrEmplacement = 42;
                baie.Status = false;
                baie.Numero="B"+baie.Id.ToString("D3");
                context.Baies.Add(baie);
                this._Baie.Add(baie);
                context.SaveChanges();

                for (int i = 0; i < 42; i++)
                {
                    WorkTogetherDBLib.Class.Unite unite = new WorkTogetherDBLib.Class.Unite();
                    unite.IdentifiantBaieId = baie.Id;
                    unite.IdentifiantTypeUniteId = 1;
                    unite.Status = false;
                    unite.Numero = baie.Id+"-"+(i+1);
                    context.Unites.Add(unite);
                }
                context.SaveChanges();
            }
        }

    /// <summary>
    /// définie si une baie à été séléctionné au préalable
    /// </summary>
    /// <param name="parameter"></param>
    /// <returns></returns>
    internal bool CanAddBaie(object? parameter = null) => this.SelectedBaie != null;

        /// <summary>
        /// définition de la commande RemoveBaie
        /// </summary>
        /// <param name="parameter"></param>
        internal void RemoveBaie(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedBaie != null)
                {
                    if (SelectedBaie.Unites.All(u => u.Status == false))
                    {
                        context.Unites.RemoveRange(SelectedBaie.Unites);
                        context.Baies.Remove(SelectedBaie);
                        Baie.Remove(SelectedBaie);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Erreur : Vous ne pouvez pas supprimer une ou plusieurs unité(s) réservé(s)");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur : veuillez selectionner un champs");
                }

                context.SaveChanges();
            }
        }
        /// <summary>
        /// définie si une baie à été séléctionné au préalable
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        internal bool CanRemoveBaie(object? parameter = null) => this.SelectedBaie != null;

        /// <summary>
        /// définition de la commande UpdateBaie
        /// </summary>
        /// <param name="parameter"></param>
        internal void UpdateBaie(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedBaie != null)
                {
                    int nbrEmplacement = SelectedBaie.NbrEmplacement;
                    UpdateFormBaie form = new UpdateFormBaie();
                    form.Numero = SelectedBaie.Numero;
                    form.Status = SelectedBaie.Status;
                    form.NbrEmplacement = SelectedBaie.NbrEmplacement;
                    form.ShowDialog();
                    if (form.DialogResult == true)
                    {
                        if (nbrEmplacement>form.NbrEmplacement)
                        {
                            int soussUnite = nbrEmplacement - form.NbrEmplacement;
                            for (int i = 0; i < soussUnite; i++)
                            {
                                WorkTogetherDBLib.Class.Unite unite = SelectedBaie.Unites.Last();
                                if (unite.Status == false)
                                {
                                    context.Unites.Remove(unite);
                                    context.SaveChanges();
                                }
                                else
                                {
                                    MessageBox.Show("Erreur : Vous ne pouvez pas supprimer une ou plusieurs unité(s) réservé(s)");
                                }
                            }
                        }
                        Baie Baie = SelectedBaie;
                        if (form.Numero.StartsWith("B"))
                        {
                            Baie.Numero = form.Numero;
                        }
                        Baie.Status = form.Status;
                        Baie.NbrEmplacement = form.NbrEmplacement;
                        context.Baies.Update(Baie);
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Erreur : le nombre d'emplacement saisie ne peut pas être enregistré");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur : veuillez selectionner un champs");
                }
            }
        }
        /// <summary>
        /// définie si une baie à été séléctionné au préalable
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        internal bool CanUpdateBaie(object? parameter = null) => this.SelectedBaie != null;
        #endregion
    }
}
