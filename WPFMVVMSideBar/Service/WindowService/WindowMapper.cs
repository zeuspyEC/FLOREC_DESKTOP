using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMSideBar.Core;
using WPFMVVMSideBar.MVVM.View;
using WPFMVVMSideBar.MVVM.ViewModel;

namespace WPFMVVMSideBar.Service.WindowService
{
    public class WindowMapper
    {
        private readonly Dictionary<Type, Type> _windowMapper = new();

        public WindowMapper()
        {
            RegisterMapping<MainViewModel, MainWindow>();
            RegisterMapping<LoginViewModel, LoginMainWindow>();
        }

        public void RegisterMapping<TViewModel, TWindow>() where TViewModel : ViewModelBase where TWindow : Window
        {
            _windowMapper[typeof(TViewModel)] = typeof(TWindow);
        }

        public Type GetWindowTypeForViewModel<TviewModel>() where TviewModel : ViewModelBase
        {
            _windowMapper.TryGetValue(typeof(TviewModel), out var windowType);
            return windowType;
        }
    }
}
