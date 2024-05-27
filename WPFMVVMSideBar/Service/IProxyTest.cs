using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMSideBar.MVVM.Model;

namespace WPFMVVMSideBar.Service
{
    public interface IProxyTest
    {
        ObservableCollection<Item> GetAllItems();

    }
}
