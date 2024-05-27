using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFMVVMSideBar.Core;
using WPFMVVMSideBar.Service;
using WPFMVVMSideBar.Service.WindowService;

namespace WPFMVVMSideBar.MVVM.ViewModel
{
    public class LoginViewModel : Core.ViewModelBase
    {
        private readonly IWindowManager _windowManger;
        public ObservableCollection<string> Options { get; }

        //Location
        private string _serverLocation;
        public string ServerLocation
        {
            get
            {
                return _serverLocation;
            }
            set
            {
                _serverLocation = value;
                GlobalState.GetInstance().ServerLocation = value;
            }
        }

        //Commands
        public ICommand OpenMainWiewWindow { get; }

        public LoginViewModel(IWindowManager windowManger)
        {
            _windowManger = windowManger;
            OpenMainWiewWindow = new RelayCommand(o => OpenMainWindow());
            Options = new ObservableCollection<string>
            {
                "Quito",
                "Guayakill"
            };
            ServerLocation = "Quito";
        }

        private void OpenMainWindow()
        {
            _windowManger.ShowWindow<MainViewModel>();
            _windowManger.CloseWindow(this);
        }
    }
}
