using ModernVPN.Core;
using System.Windows;

namespace ModernVPN.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        /* Commands */
        public RelayCommand MoveWindowCommand { get; set; }
        public RelayCommand ShutdownWindowCommand { get; set; }
        public RelayCommand MaximizeWindowCommand { get; set; }
        public RelayCommand MinimizeWindowCommand { get; set; }


        public RelayCommand ShowProtectionView { get; set; }
        public RelayCommand ShowSettingsView { get; set; }


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

        public ProtectionViewModel ProtectionVM { get; set; }
        public SettingsViewModel SettingsVM { get; set; }

        public MainViewModel()
        {

            ProtectionVM = new ProtectionViewModel();
            SettingsVM = new SettingsViewModel();
            CurrentView = ProtectionVM;

            Application.Current.MainWindow.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            MoveWindowCommand = new RelayCommand(x => { Application.Current.MainWindow.DragMove(); });
            ShutdownWindowCommand = new RelayCommand(x => { Application.Current.Shutdown(); });
            MaximizeWindowCommand = new RelayCommand(x =>
            {
                if (Application.Current.MainWindow.WindowState == WindowState.Maximized)
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                else
                    Application.Current.MainWindow.WindowState = WindowState.Maximized;
            });
            MinimizeWindowCommand = new RelayCommand(x => { Application.Current.MainWindow.WindowState = WindowState.Minimized; });

            ShowProtectionView = new RelayCommand (x => { CurrentView = ProtectionVM; });
            ShowSettingsView = new RelayCommand(x => { CurrentView = SettingsVM; });

        }
    }
}

