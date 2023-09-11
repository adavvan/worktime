using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worktime.Core;

namespace Worktime.MVVM.ViewModels
{
    internal class MainViewModel : ObservableObject
    {
        public RelayCommand ActivityViewCommand { get; set; }
        public RelayCommand WorkersViewCommand { get; set; }
        public RelayCommand ExportViewCommand { get; set; }


        public ActivityViewModel ActivityVM { get; set; }
        public WorkersViewModel WorkersVM { get; set; }
        public ExportViewModel ExportVM { get; set; }

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
            ActivityVM = new ActivityViewModel();
            WorkersVM = new WorkersViewModel();
            ExportVM = new ExportViewModel();

            _currentView = ActivityVM;

            ActivityViewCommand = new RelayCommand(o =>
            {
                CurrentView = ActivityVM;
            });

            WorkersViewCommand = new RelayCommand(o =>
            {
                CurrentView = WorkersVM;
            });

            ExportViewCommand = new RelayCommand(o =>
            {
                CurrentView = ExportVM;
            });
        }
    }
}
