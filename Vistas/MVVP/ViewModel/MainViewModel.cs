using ClasesBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vistas.MVVP.View;
using Vistas.MVVP.ViewModel;

namespace Vistas.MVVP.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }

        public RelayCommand Punto3ViewCommand { get; set; }
        public RelayCommand CompetenciasListCommand { get; set; }
        public RelayCommand AtletaPanelCommand { get; set; }
        public RelayCommand CategoriaPanelCommand { get; set; }

        public RelayCommand DisciplinaPanelCommand { get; set; }


        public AtletaFormViewModel AtletaFormVM { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public AtletaPanelViewModel AtletaPanelVM { get; set; } 
        public UserPanelViewModel UserPanelVM { get; set;}
        public CategoriaFormViewModel CategoriaFormVM { get; set; }
        public DisciplinaFormViewModel DisciplinaFormVM { get; set; }

        public CompetenciasListView CompetenciasListVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();
            var EstadodeCompetenciaVM = new EstadosDeCompetencias();
            UserPanelVM = new UserPanelViewModel();
            AtletaFormVM = new AtletaFormViewModel();
            AtletaPanelVM = new AtletaPanelViewModel();
            CategoriaFormVM = new CategoriaFormViewModel();
            DisciplinaFormVM = new DisciplinaFormViewModel();

            CompetenciasListVM = new CompetenciasListView();

            CurrentView = CategoriaFormVM;


            Punto3ViewCommand = new RelayCommand(o =>
            {
                EstadodeCompetenciaVM.Show();
            });
            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            AtletaPanelCommand = new RelayCommand(o =>
            {
                CurrentView = AtletaFormVM;
            });

            CategoriaPanelCommand = new RelayCommand(o =>
            {
                CurrentView = CategoriaFormVM;
            });

            DisciplinaPanelCommand = new RelayCommand(o =>
            {
                CurrentView = DisciplinaFormVM;
            });
            CompetenciasListCommand = new RelayCommand(o =>
            {
                CurrentView = CompetenciasListVM;
               
            });
        }
    }
}
