using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMSideBar.Core;
using WPFMVVMSideBar.Service.ViewModelService;

namespace WPFMVVMSideBar.Service.MainNavigationService
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private ViewModelBase _currentViewChild;
        private readonly IViewModelManager _viewModelManager;

        public NavigationService(IViewModelManager viewModelManager)
        {
            _viewModelManager = viewModelManager;
        }

        public ViewModelBase CurrentViewModelChild
        {
            get
            {
                return _currentViewChild;
            }
            private set
            {
                _currentViewChild = value;
                OnPropertyChanged(nameof(CurrentViewModelChild));
            }
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            CurrentViewModelChild = _viewModelManager.GetViewModel<TViewModel>();
        }

    }
}
