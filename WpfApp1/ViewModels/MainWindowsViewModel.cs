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
        #endregion

        #region Constructor

        public MainWindowsViewModel()
        {
            using (PpeContext context = new()) {
                this.Baies = new ObservableCollection<Baie>(context.Baies);
            }
        }

        #endregion

    }
}
