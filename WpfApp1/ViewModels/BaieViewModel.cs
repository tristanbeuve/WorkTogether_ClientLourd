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
    internal class BaieViewModel 
    {
        #region Fields
        private ObservableCollection<Baie> _Baie;

        private Baie? _SelectedBaie;

        private DelegateCommand<object> _CommandAddBaie;

        private DelegateCommand<object> _CommandRemoveBaie;

        private DelegateCommand<object> _CommandUpdateBaie;

        #endregion

        #region Properties
        public ObservableCollection<Baie> Baie { get => _Baie; set => _Baie = value; }
        public Baie? SelectedBaie { get => _SelectedBaie; set => _SelectedBaie = value; }
        public DelegateCommand<object> CommandAddBaie { get => _CommandAddBaie; set => _CommandAddBaie = value; }
        public DelegateCommand<object> CommandRemoveBaie { get => _CommandRemoveBaie; set => _CommandRemoveBaie = value; }
        public DelegateCommand<object> CommandUpdateBaie { get => _CommandUpdateBaie; set => _CommandUpdateBaie = value; }

        #endregion

        #region Constructor
        public BaieViewModel() 
        {
            CommandAddBaie = new DelegateCommand<object>(AddBaie, CanAddBaie).ObservesProperty(() => this.SelectedBaie);
            CommandRemoveBaie = new DelegateCommand<object>(RemoveBaie, CanRemoveBaie).ObservesProperty(() => this.SelectedBaie);
            CommandUpdateBaie = new DelegateCommand<object>(RemoveBaie, CanRemoveBaie).ObservesProperty(() => this.SelectedBaie);

            using (PpeContext context = new())
            {
                this.Baie = new ObservableCollection<Baie>(context.Baies);
            }
        }
        #endregion

        #region Methods
        internal void AddBaie(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                Baie Baies = new Baie();
                Baies.NbrEmplacement = 42;
                Baies.Status = false;
                context.Baies.Add(Baies);
                this._Baie.Add(Baies);
                context.SaveChanges();

                for (int i = 0; i < 42; i++)
                {
                    Unite Unites = new Unite();
                    Unites.IdentifiantBaieId = Baies.Id;
                    Unites.IdentifiantTypeUniteId = 1;
                    Unites.Status = false;
                    Unites.Numero = "111";
                    context.Unites.Add(Unites);
                    //Problème de ref
                    //this.Unite.Add(Unites);

                }
                context.SaveChanges();
            }
        }

        internal bool CanAddBaie(object? parameter = null) => this.SelectedBaie != null;

        //Marche pas
        internal void RemoveBaie(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedBaie != null)
                {
                    Baie? Baies = SelectedBaie;
                    context.Baies.Remove(Baies);
                    this._Baie.Remove(Baies);
                    context.SaveChanges();
                    //for (int i = 0; i < Baies.NbrEmplacement; i++)
                    //{
                    //    Unite Unites = SelectedUnite;
                    //    if (Baies.Id == Unites.IdentifiantBaieId)
                    //    {
                    //        context.Unites.Remove(Unites);
                    //        this.Unite.Remove(Unites);
                    //    }
                    //}
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs");
                }

                context.SaveChanges();
            }
        }

        internal bool CanRemoveBaie(object? parameter = null) => this.SelectedBaie != null;


        internal void UpdateBaie(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if (SelectedBaie != null)
                {
                    context.Baies.Find(SelectedBaie.Id).NbrEmplacement = SelectedBaie.NbrEmplacement;
                    context.Baies.Find(SelectedBaie.Id).Status = SelectedBaie.Status;
                    context.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Erreur veuillez selectionner un champs");
                }
            }
        }

        internal bool CanUpdateBaie(object? parameter = null) => this.SelectedBaie != null;
        #endregion
    }
}
