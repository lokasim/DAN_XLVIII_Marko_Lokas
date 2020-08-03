using PizzaRestaurant.Commands;
using PizzaRestaurant.Models;
using PizzaRestaurant.Services;
using PizzaRestaurant.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace PizzaRestaurant.ViewModel
{
    class ApproveRejectViewModel : ViewModelBase
    {
        readonly ApproveReject approveReject;

        #region Properties
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

        private vwOrder orderItem;
        public vwOrder OrderItem
        {
            get
            {
                return orderItem;
            }
            set
            {
                orderItem = value;
                OnPropertyChanged("OrderItem");
            }
        }

        private List<vwOrder> orderItemList;
        public List<vwOrder> OrderItemList
        {
            get
            {
                return orderItemList;
            }
            set
            {
                orderItemList = value;
                OnPropertyChanged("OrderItemList");
            }
        }
        #endregion

        #region Constructor
        public ApproveRejectViewModel(ApproveReject approveReject)
        {
            this.approveReject = approveReject;

            Service s = new Service();
            int order = PendingOrder.OrderID;

            OrderItemList = s.GetOrder(order);
            
        }
        #endregion

        #region Commands
        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (exit == null)
                {
                    exit = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
                }
                return exit;
            }
        }

        /// <summary>
        /// Exit form
        /// </summary>
        private void ExitExecute()
        {
            try
            {
                approveReject.Close();
            }
            catch (Exception)
            {

            }
        }

        private bool CanExitExecute()
        {
            return true;
        }


        private ICommand discardOrder;
        public ICommand DiscardOrder
        {
            get
            {
                if (discardOrder == null)
                {
                    discardOrder = new RelayCommand(param => DiscardOrderExecute(), param => CanDiscardOrderExecute());
                }
                return discardOrder;
            }
        }

        /// <summary>
        /// Order rejection method
        /// </summary>
        private void DiscardOrderExecute()
        {
            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblOrder order = (from r in context.tblOrders where r.OrderID == PendingOrder.OrderID select r).First();
                    order.OrderStatus = 3;
                    order.Archived = 1;
                    context.SaveChanges();
                    vwOrder OrderEmail = (from r in context.vwOrders where r.OrderID == PendingOrder.OrderID select r).First();
                }
                approveReject.Close();
            }
            catch (Exception)
            {

            }
        }

        private bool CanDiscardOrderExecute()
        {
            return true;
        }

        private ICommand acceptOrder;
        public ICommand AcceptOrder
        {
            get
            {
                if (acceptOrder == null)
                {
                    acceptOrder = new RelayCommand(param => AcceptOrderExecute(), param => CanAcceptOrderExecute());
                }
                return acceptOrder;
            }
        }

        /// <summary>
        /// Order acceptance method
        /// </summary>
        private void AcceptOrderExecute()
        {
            try
            {

                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    Service s = new Service();
                    tblOrder order = (from r in context.tblOrders where r.OrderID == PendingOrder.OrderID select r).First();
                    order.OrderStatus = 2;
                    order.Archived = 1;
                    context.SaveChanges();
                    vwOrder OrderEmail = (from r in context.vwOrders where r.OrderID == PendingOrder.OrderID select r).First();
                }
                approveReject.Close();
            }
            catch (Exception)
            {

            }
        }

        private bool CanAcceptOrderExecute()
        {
            return true;
        }
        #endregion
    }
}
