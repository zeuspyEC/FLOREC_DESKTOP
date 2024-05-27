using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using WPFMVVMSideBar.Core;
using WPFMVVMSideBar.MVVM.Model;
using WPFMVVMSideBar.MVVM.View.Utils;
using WPFMVVMSideBar.Service;

namespace WPFMVVMSideBar.MVVM.ViewModel
{

    public class HomeViewModel : Core.ViewModelBase
    {
        public ICollectionView Items { get; set; }
        public ObservableCollection<CheckBoxOptionItem> Options { get; }

        private IProxyTest _proxyTest;

        //Command
        public ICommand SortCommand { get;  set; }

        public void SortListByType(object parameter)
        {
            CheckBoxOptionItem checkbox = (CheckBoxOptionItem)parameter;
            Items.SortDescriptions.Clear();
            if ( checkbox.Content == "Price")
            {
                Items.SortDescriptions.Add(new SortDescription("Price", ListSortDirection.Ascending));
                return;
            }
            if (checkbox.Content == "Name")
            {
                Items.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
                return;
            }
        }

        public HomeViewModel(IProxyTest proxyTest)
        {
            SortCommand = new RelayCommand(SortListByType);
            _proxyTest = proxyTest;
            Options = new ObservableCollection<CheckBoxOptionItem>
            {
                new CheckBoxOptionItem { Content= "Price" , IsChecked=false},
                new CheckBoxOptionItem { Content= "Name" , IsChecked=false}
            };
            var itemlist = proxyTest.GetAllItems();
            Items = CollectionViewSource.GetDefaultView(itemlist);
        }

    }
}
