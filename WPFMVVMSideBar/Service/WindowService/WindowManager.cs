using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMSideBar.Core;
using WPFMVVMSideBar.Service.ViewModelService;

namespace WPFMVVMSideBar.Service.WindowService
{
    public class WindowManager : IWindowManager
    {
        private readonly WindowMapper _mapper;
        private readonly IViewModelManager _viewModelManager;

        public WindowManager(WindowMapper mapper, IViewModelManager viewModelLocator)
        {
            _mapper = mapper;
            _viewModelManager = viewModelLocator;
        }

        public void CloseWindow(ViewModelBase viewModel)
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault(w => w.DataContext == viewModel);
            if (window == null)
            {
                return;
            }

            window.Close(); // Close window
        }

        public void ShowWindow<TViewModel>() where TViewModel : ViewModelBase
        {
            var windowType = _mapper.GetWindowTypeForViewModel<TViewModel>();
            if (windowType == null)
            {
                return;
            }

            var window = Activator.CreateInstance(windowType) as Window;
            window.DataContext = _viewModelManager.GetNewViewModel<TViewModel>();
            window.Show();
            window.Show();
        }
    }
}
