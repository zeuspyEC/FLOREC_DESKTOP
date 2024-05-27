using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFMVVMSideBar.MVVM.Model;

namespace WPFMVVMSideBar.Service
{
    public class ProxyService : IProxyTest
    {
        private readonly IProxyTest _proxyTestA;
        private readonly IProxyTest _proxyTestB;

        public ProxyService(AProxy aProxy , BProxy bProxy)
        {
            _proxyTestA = aProxy;
            _proxyTestB = bProxy;
        }

        private IProxyTest GetConfigureProxy()
        {
            string serverLocation = GlobalState.GetInstance().ServerLocation;
            if ( serverLocation == "Quito" )
            {
                return _proxyTestA;
            }

            if (serverLocation == "Guayakill")
            {
                return _proxyTestB;
            }
            return _proxyTestA;
            
        }

        public ObservableCollection<Item> GetAllItems()
        {
            return GetConfigureProxy().GetAllItems();
        }

    }
}
