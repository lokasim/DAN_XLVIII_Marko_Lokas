using PizzaRestaurant.Models;
using PizzaRestaurant.Services;
using PizzaRestaurant.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaRestaurant.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        readonly MainWindow mainWindow;

        private vwMenu allMenu;
        public vwMenu AllMenu
        {
            get
            {
                return allMenu;
            }
            set
            {
                allMenu = value;
                OnPropertyChanged("AllMenu");
            }
        }

        private List<vwMenu> allMenuList;
        public List<vwMenu> AllMenuList
        {
            get
            {
                return allMenuList;
            }
            set
            {
                allMenuList = value;
                OnPropertyChanged("AllMenuList");
            }
        }

        Login login = new Login();

        #region Constructor
        public MainWindowViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;

            Service s = new Service();

            AllMenuList = s.GetAllMenu().ToList();
            
        }
        #endregion
    }
}
