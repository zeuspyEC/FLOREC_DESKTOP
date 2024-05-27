using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMSideBar.Core;

namespace WPFMVVMSideBar.Service.ViewModelService
{
    public class ViewModelMapper
    {
        private readonly Dictionary<Type, ViewModelBase> _persistentModelMapper = new();
        private readonly IServiceProvider _serviceProvider;
        public ViewModelMapper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ViewModelBase GetPersistantViewModel<TviewModel>() where TviewModel : ViewModelBase
        {
            _persistentModelMapper.TryGetValue(typeof(TviewModel), out var viewModelBase);
            return viewModelBase;
        }

        public ViewModelBase GetNewViewModel<TviewModel>() where TviewModel : ViewModelBase
        {
            var viewModel = _serviceProvider.GetService<TviewModel>();
            RegisterMapping<TviewModel>(viewModel);
            return viewModel;
        }

        public bool MapperHasKey<TviewModel>() where TviewModel : ViewModelBase
        {
            return _persistentModelMapper.ContainsKey(typeof(TviewModel));
        }

        private void RegisterMapping<TViewModel>(ViewModelBase viewModelBase) where TViewModel : ViewModelBase
        {
            _persistentModelMapper[typeof(TViewModel)] = viewModelBase;
        }
    }

}
