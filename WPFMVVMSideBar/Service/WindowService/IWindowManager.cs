using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMSideBar.Core;

namespace WPFMVVMSideBar.Service.WindowService
{
    public interface IWindowManager
    {
        void ShowWindow<T>() where T : ViewModelBase;
        void CloseWindow(ViewModelBase viewMode);
    }
}
