using PizzaRestaurant.Models;
using PizzaRestaurant.Services;
using PizzaRestaurant.Views;
using System.Collections.Generic;
using System.Windows;

namespace PizzaRestaurant.ViewModel
{
    class PendingOrderViewModel : ViewModelBase
    {
        readonly PendingOrder pendingOrder;

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
        public PendingOrderViewModel(PendingOrder pendingOrder)
        {
            this.pendingOrder = pendingOrder;

            Service s = new Service();

            AllOrderList = s.GetOrderEmployee();

            //Display the list if there is data
            if (AllOrderList != null)
            {
                if (AllOrderList.Count < 1)
                {
                    pendingOrder.msgNoOrder.Visibility = Visibility.Visible;
                    pendingOrder.msgOrder.Visibility = Visibility.Collapsed;
                }
                else
                {
                    pendingOrder.msgNoOrder.Visibility = Visibility.Collapsed;
                    pendingOrder.msgOrder.Visibility = Visibility.Visible;
                }
            }
            else
            {
                pendingOrder.msgNoOrder.Visibility = Visibility.Visible;
                pendingOrder.msgOrder.Visibility = Visibility.Collapsed;
            }

        }
        #endregion
    }
}
