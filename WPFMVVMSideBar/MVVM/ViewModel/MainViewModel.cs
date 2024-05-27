using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using WPFMVVMSideBar.Core;
using WPFMVVMSideBar.MVVM.View;
using WPFMVVMSideBar.Service;
using WPFMVVMSideBar.Service.MainNavigationService;
using WPFMVVMSideBar.Service.WindowService;
namespace WPFMVVMSideBar.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModelBase
    {

        private readonly INavigationService _navigationService;
        private readonly IWindowManager _windowManager;

        public INavigationService NavigationService
        {
            get { return _navigationService; }
        }
        //Commands
        public ICommand NaviageteToHomeViewCommand { get; }
        public ICommand NaviageteToSettingsViewCommand { get; }
        public ICommand LogOutCommand { get; }

        public MainViewModel(INavigationService navigationService, IWindowManager windowManager)
        {
            _navigationService = navigationService;
            _windowManager = windowManager;
            NaviageteToHomeViewCommand = new RelayCommand(o => ChangeChildView<HomeViewModel>());
            NaviageteToSettingsViewCommand = new RelayCommand(o => ChangeChildView<SettingsViewModel>());
            LogOutCommand = new RelayCommand(o => ChangeToLogIn());
        }

        private void ChangeToLogIn()
        {
            _windowManager.ShowWindow<LoginViewModel>();
            _windowManager.CloseWindow(this);
        }

        private void ChangeChildView<TviewModel>() where TviewModel : ViewModelBase
        {
            ViewModelBase currentViewModel = NavigationService.CurrentViewModelChild;

            if (currentViewModel == null || currentViewModel.GetType() != typeof(TviewModel))
            {
                NavigationService.NavigateTo<TviewModel>();
            }
        }
    }
}
