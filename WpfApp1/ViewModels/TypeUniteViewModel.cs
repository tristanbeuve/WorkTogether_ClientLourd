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
        private ObservableCollection<TypeUnite> _TypeUnites;

        private TypeUnite? _SelectedTypeUnite;

        private DelegateCommand<object> _CommandAddTypeUnite;

        private DelegateCommand<object> _CommandRemoveTypeUnite;

        private DelegateCommand<object> _CommandUpdateTypeUnite;
        #endregion

        #region Properties

        public TypeUnite? SelectedTypeUnite { get => _SelectedTypeUnite; set => _SelectedTypeUnite = value; }

        public ObservableCollection<TypeUnite> TypeUnites { get => _TypeUnites; set => _TypeUnites = value; }
        public DelegateCommand<object> CommandRemoveTypeUnite { get => _CommandRemoveTypeUnite; set => _CommandRemoveTypeUnite = value; }
        public DelegateCommand<object> CommandUpdateTypeUnite { get => _CommandUpdateTypeUnite; set => _CommandUpdateTypeUnite = value; }
        public DelegateCommand<object> CommandAddTypeUnite { get => _CommandAddTypeUnite; set => _CommandAddTypeUnite = value; }
        #endregion

        #region Constructor
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
        internal void AddTypeUnite(object? parameter = null)
        {
            using (PpeContext context = new())
            {
                TypeUnite type = new();
                type.Nom = "NewType";
                context.SaveChanges();
            }
        }

        internal bool CanAddTypeUnite(object? parameter = null) => this.SelectedTypeUnite != null;

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

        internal bool CanRemoveTypeUnite(object? parameter = null) => this.SelectedTypeUnite != null;
        #endregion
    }
}
