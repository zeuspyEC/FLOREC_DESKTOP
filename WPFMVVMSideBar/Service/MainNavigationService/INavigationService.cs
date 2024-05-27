using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMSideBar.Core;

namespace WPFMVVMSideBar.Service.MainNavigationService
{
    public interface INavigationService
    {
        ViewModelBase CurrentViewModelChild { get; }
        void NavigateTo<T>() where T : ViewModelBase;
    }
}
