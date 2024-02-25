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
    internal class TypeUniteViewModel : ObservableObject
    {
        #region Fields
        /// <summary>
        /// getter de la liste des type d'unités
        /// </summary>
        private ObservableCollection<TypeUnite> _TypeUnites;
        /// <summary>
        /// getter d'un type d'unite séléctionné 
        /// </summary>
        private TypeUnite? _SelectedTypeUnite;
        /// <summary>
        /// getter de la commande AddTypeUnite
        /// </summary>
        private DelegateCommand<object> _CommandAddTypeUnite;
        /// <summary>
        /// getter de la commande RemoveTypeUnite
        /// </summary>
        private DelegateCommand<object> _CommandRemoveTypeUnite;
        /// <summary>
        /// getter de la commande UpdateTypeUnite
        /// </summary>
        private DelegateCommand<object> _CommandUpdateTypeUnite;
        #endregion

        #region Properties
        /// <summary>
        /// setter du type d'unité sélectionné
        /// </summary>
        public TypeUnite? SelectedTypeUnite { get => _SelectedTypeUnite; set => _SelectedTypeUnite = value; }
        /// <summary>
        /// setter de la liste de type d'unité
        /// </summary>
        public ObservableCollection<TypeUnite> TypeUnites { get => _TypeUnites; set => _TypeUnites = value; }
        /// <summary>
        /// setter de la commande RemoveTypeUnite
        /// </summary>
        public DelegateCommand<object> CommandRemoveTypeUnite { get => _CommandRemoveTypeUnite; set => _CommandRemoveTypeUnite = value; }
        /// <summary>
        /// setter de la commande UpdateTypeUnite
        /// </summary>
        public DelegateCommand<object> CommandUpdateTypeUnite { get => _CommandUpdateTypeUnite; set => _CommandUpdateTypeUnite = value; }
        /// <summary>
        /// setter de la commande AddTypeUnite
        /// </summary>
        public DelegateCommand<object> CommandAddTypeUnite { get => _CommandAddTypeUnite; set => _CommandAddTypeUnite = value; }
        #endregion

        #region Constructor
        /// <summary>
        /// constructeur du viewmodel et des commandes AddTypeUnite, RemoveTypeUnite, UpdateTypeUnite
        /// </summary>
        TypeUniteViewModel()
        {
            CommandAddTypeUnite = new DelegateCommand<object>(AddTypeUnite, CanAddTypeUnite).ObservesProperty(() => this.SelectedTypeUnite);

            using (PpeContext context =new PpeContext())
            {
                this.TypeUnites = new ObservableCollection<TypeUnite>(context.TypeUnites);
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// définition de la commande AddTypeUnite
        /// </summary>
        /// <param name="parameter"></param>
        internal void AddTypeUnite(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                TypeUnite type = new();
                type.Nom = "NewType";
                context.SaveChanges();
            }
        }
        /// <summary>
        /// définie si une baie à été séléctionné au préalable
        /// </summary>
        internal bool CanAddTypeUnite(object? parameter = null) => this.SelectedTypeUnite != null;
        /// <summary>
        /// définition de la commande RemoveTypeUnite
        /// </summary>
        /// <param name="parameter"></param>
        internal void RemoveTypeUnite(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                if(SelectedTypeUnite != null)
                {
                    TypeUnite type = SelectedTypeUnite;
                    context.TypeUnites.Remove(type);
                    this._TypeUnites.Remove(type);
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
        internal bool CanRemoveTypeUnite(object? parameter = null) => this.SelectedTypeUnite != null;
        #endregion
    }
}
