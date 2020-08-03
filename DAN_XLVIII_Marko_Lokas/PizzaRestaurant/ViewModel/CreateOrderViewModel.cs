using PizzaRestaurant.Commands;
using PizzaRestaurant.Models;
using PizzaRestaurant.Services;
using PizzaRestaurant.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace PizzaRestaurant.ViewModel
{
    class CreateOrderViewModel : ViewModelBase
    {
        readonly CreateOrder createOrder;

        #region Properties
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

        private List<vwOrder> allOrderItemList;
        public List<vwOrder> AllOrderItemList
        {
            get
            {
                return allOrderItemList;
            }
            set
            {
                allOrderItemList = value;
                OnPropertyChanged("AllOrderItemList");
            }
        }
        #endregion

        #region Constructor
        public CreateOrderViewModel(CreateOrder createOrder)
        {
            this.createOrder = createOrder;

            Service s = new Service();

            AllMenuList = s.GetAllMenu().ToList();

            string jmbg = LoggedGuest.jmbg;
            List<vwOrder> orderList = s.GetWaitingOrder(jmbg);
            if (orderList != null)
            {
                if (orderList.Count < 1)
                {
                    createOrder.gridWaiting.Visibility = Visibility.Collapsed;
                }
                else
                {
                    createOrder.gridWaiting.Visibility = Visibility.Visible;
                }
            }
            else
            {
                createOrder.gridWaiting.Visibility = Visibility.Collapsed;
            }

            RefreshViewList();
        }
        #endregion

        /// <summary>
        /// List refresh method
        /// </summary>
        private void RefreshViewList()
        {
            Service s = new Service();
            AllOrderItemList = s.GetOrderItemGuestHoldOn(LoggedGuest.id);

            if (AllOrderItemList != null)
            {
                if (AllOrderItemList.Count > 0)
                {
                    createOrder.lvOrderHoldOn.ItemsSource = AllOrderItemList;
                    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(createOrder.lvOrderHoldOn.ItemsSource);
                    PropertyGroupDescription groupDescription = new PropertyGroupDescription("HeaderHoldOn");
                    view.GroupDescriptions.Add(groupDescription);
                }
            }

        }

        #region Comands
        private ICommand createOrderbtn;
        public ICommand CreateOrderbtn
        {
            get
            {
                if (createOrderbtn == null)
                {
                    createOrderbtn = new RelayCommand(param => CreateOrderExecute(), param => CanCreateOrderExecute());
                }
                return createOrderbtn;
            }
        }

        /// <summary>
        /// A method for creating a new order
        /// </summary>
        private void CreateOrderExecute()
        {
            CreateNewOrder createNewOrder = new CreateNewOrder();
            createNewOrder.ShowDialog();
            Service s = new Service();
            if ((createNewOrder.DataContext as CreateNewOrderViewModel).IsUpdateItem == true)
            {
                string jmbg = LoggedGuest.jmbg;
                List<vwOrder> orderList = s.GetWaitingOrder(jmbg);
                if (orderList.Count < 1)
                {
                    createOrder.gridWaiting.Visibility = Visibility.Collapsed;
                }
                else
                {
                    createOrder.gridWaiting.Visibility = Visibility.Visible;
                }
                RefreshViewList();
            }
        }

        private bool CanCreateOrderExecute()
        {
            Service s = new Service();
            string jmbg = LoggedGuest.jmbg;
            List<vwOrder> orderList = s.GetWaitingOrder(jmbg);
            if (orderList != null)
            {
                if (orderList.Count < 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
