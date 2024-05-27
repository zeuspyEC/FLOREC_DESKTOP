using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMVVMSideBar.Service
{
    public class GlobalState
    {

        private static GlobalState _instance;
        private string _serverLocation;

        // Private constructor to prevent instantiation
        private GlobalState()
        {
        }

        // Public method to get the instance of GlobalState
        public static GlobalState GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GlobalState();
            }
            return _instance;
        }

        // Property to access the string attribute
        public string ServerLocation
        {
            get { return _serverLocation; }
            set { _serverLocation = value; }
        }
    }
}
