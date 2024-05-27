using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using WPFMVVMSideBar.Core;
using WPFMVVMSideBar.MVVM.View;
using WPFMVVMSideBar.MVVM.ViewModel;
using WPFMVVMSideBar.Service;
using WPFMVVMSideBar.Service.MainNavigationService;
using WPFMVVMSideBar.Service.ViewModelService;
using WPFMVVMSideBar.Service.WindowService;



namespace WPFMVVMSideBar
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection service = new ServiceCollection();

            service.AddTransient<IWindowManager, WindowManager>();
            service.AddTransient<WindowMapper>();

            service.AddTransient<IViewModelManager , ViewModelManger>();
            service.AddTransient<ViewModelMapper>();
            service.AddTransient<MainViewModel>();
            service.AddTransient<LoginViewModel>();
            service.AddTransient<HomeViewModel>();
            service.AddSingleton<SettingsViewModel>();

            service.AddTransient<INavigationService, NavigationService>();

            service.AddTransient<IProxyTest , ProxyService>();
            service.AddTransient<AProxy>();
            service.AddTransient<BProxy>();

            _serviceProvider = service.BuildServiceProvider();
                
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var windowManager = _serviceProvider.GetRequiredService<IWindowManager>();
            windowManager.ShowWindow<LoginViewModel>();
            base.OnStartup(e);
        }

    }

}
