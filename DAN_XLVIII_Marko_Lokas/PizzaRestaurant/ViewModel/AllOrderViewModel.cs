using PizzaRestaurant.Models;
using PizzaRestaurant.Services;
using PizzaRestaurant.Views;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;

namespace PizzaRestaurant.ViewModel
{
    class AllOrderViewModel : ViewModelBase
    {
        readonly AllOrder allOrderWindow;

        #region Properties
        private tblOrder allOrder;
        public tblOrder AllOrder
        {
            get
            {
                return allOrder;
            }
            set
            {
                allOrder = value;
                OnPropertyChanged("AllOrder");
            }
        }

        private vwOrder allOrderItem;
        public vwOrder AllOrderItem
        {
            get
            {
                return allOrderItem;
            }
            set
            {
                allOrderItem = value;
                OnPropertyChanged("AllOrderItem");
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

        private List<tblOrder> allOrderList;
        public List<tblOrder> AllOrderList
        {
            get
            {
                return allOrderList;
            }
            set
            {
                allOrderList = value;
                OnPropertyChanged("AllOrderList");
            }
        }
        #endregion

        #region Constructor
        public AllOrderViewModel(AllOrder allOrder)
        {
            this.allOrderWindow = allOrder;
            Service s = new Service();
            AllOrderItemList = s.GetOrderItemGuest(LoggedGuest.id);

            allOrderWindow.lvOrder.ItemsSource = AllOrderItemList;

            if (AllOrderItemList != null)
            {
                if (AllOrderItemList.Count > 0)
                {
                    allOrderWindow.lvOrder.Visibility = Visibility.Visible;
                    allOrderWindow.msgNoOrder.Visibility = Visibility.Collapsed;
                    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(allOrderWindow.lvOrder.ItemsSource);
                    PropertyGroupDescription groupDescription = new PropertyGroupDescription("Header");
                    view.GroupDescriptions.Add(groupDescription);
                }
                else
                {
                    allOrderWindow.lvOrder.Visibility = Visibility.Collapsed;
                    allOrderWindow.msgNoOrder.Visibility = Visibility.Visible;
                }
            }
            else
            {
                allOrderWindow.lvOrder.Visibility = Visibility.Collapsed;
                allOrderWindow.msgNoOrder.Visibility = Visibility.Visible;
            }
        }
        #endregion
    }
}
