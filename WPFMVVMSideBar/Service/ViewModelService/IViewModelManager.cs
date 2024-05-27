using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMSideBar.Core;

namespace WPFMVVMSideBar.Service.ViewModelService
{
    public interface IViewModelManager
    {
        ViewModelBase GetViewModel<TviewModel>() where TviewModel : ViewModelBase;
        ViewModelBase GetNewViewModel<TviewModel>() where TviewModel : ViewModelBase;
        ViewModelBase GetPersistantViewModel<TviewModel>() where TviewModel : ViewModelBase;

    }
}
