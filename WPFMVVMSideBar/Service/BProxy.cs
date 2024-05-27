using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMSideBar.MVVM.Model;

namespace WPFMVVMSideBar.Service
{
    public class BProxy : IProxyTest
    {
        private ObservableCollection<Item> _itemsList;
        public BProxy()
        {
            _itemsList = new ObservableCollection<Item>
            {
                new Item { Name = "Item 1", Description = "Descripción del Item 1" , Price=50},
                new Item { Name = "Item 2", Description = "Descripción del Item 2" , Price=75},
                new Item { Name = "Item 3", Description = "Descripción del Item 3" , Price=80},
                new Item { Name = "Item 4", Description = "Descripción del Item 4" , Price=300},
                new Item { Name = "Item 5", Description = "Descripción del Item 5" , Price=85},
                new Item { Name = "Item 6", Description = "Descripción del Item 6" , Price=500},
                new Item { Name = "Item 7", Description = "Descripción del Item 7" , Price=850},
                new Item { Name = "Item 8", Description = "Descripción del Item 8" , Price=10},
                new Item { Name = "Item 9", Description = "Descripción del Item 9" , Price=30},
                new Item { Name = "Item 10", Description = "Descripción del Item 10" , Price=400},
                new Item { Name = "Item 11", Description = "Descripción del Item 11" , Price=60},
                new Item { Name = "Item 12", Description = "Descripción del Item 12" , Price=55},

            };

        }

        public ObservableCollection<Item> GetAllItems()
        {
            return _itemsList;
        }
    }
}
