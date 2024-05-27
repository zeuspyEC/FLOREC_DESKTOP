using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFMVVMSideBar.MVVM.Model;

namespace WPFMVVMSideBar.Service
{
    public class AProxy : IProxyTest
    {
        private ObservableCollection<Item> _itemsList;
        public AProxy()
        {
            _itemsList = new ObservableCollection<Item>
            {
                new Item { Name = "Papa", Description = "Descripción del Item 1" , Price=50},
                new Item { Name = "Quesino", Description = "Descripción del Item 2" , Price=75},
                new Item { Name = "Item Random", Description = "Descripción del Item 3" , Price=80},
                new Item { Name = "Soda", Description = "Descripción del Item 4" , Price=300},
                new Item { Name = "Stereo", Description = "Descripción del Item 5" , Price=85},
                new Item { Name = "Paper", Description = "Descripción del Item 6" , Price=500}

            };

        }

        public ObservableCollection<Item> GetAllItems()
        {
            return _itemsList;
        }

    }
}
