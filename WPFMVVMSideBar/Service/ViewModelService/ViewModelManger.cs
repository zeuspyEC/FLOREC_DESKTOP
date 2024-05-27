using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMSideBar.Core;
using WPFMVVMSideBar.MVVM.ViewModel;

namespace WPFMVVMSideBar.Service.ViewModelService
{
    public class ViewModelManger : IViewModelManager
    {
        private readonly ViewModelMapper _viewModelMapper;

        public ViewModelManger(ViewModelMapper viewModelMapper)
        {
            _viewModelMapper = viewModelMapper;
        }

        public ViewModelBase GetNewViewModel<TviewModel>() where TviewModel : ViewModelBase
        {
            return _viewModelMapper.GetNewViewModel<TviewModel>();
        }

        public ViewModelBase GetPersistantViewModel<TviewModel>() where TviewModel : ViewModelBase
        {
            return _viewModelMapper.GetPersistantViewModel<TviewModel>();
        }

        public ViewModelBase GetViewModel<TviewModel>() where TviewModel : ViewModelBase
        {

            if (_viewModelMapper.MapperHasKey<TviewModel>())
            {
                return _viewModelMapper.GetPersistantViewModel<TviewModel>();

            }
            return _viewModelMapper.GetNewViewModel<TviewModel>();

        }
    }
}
