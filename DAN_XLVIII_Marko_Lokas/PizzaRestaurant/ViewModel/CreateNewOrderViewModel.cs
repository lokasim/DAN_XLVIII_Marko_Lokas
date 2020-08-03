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
using System.Windows.Input;

namespace PizzaRestaurant.ViewModel
{
    class CreateNewOrderViewModel : ViewModelBase
    {
        readonly CreateNewOrder createNewOrder;

        #region Properties
        public static bool enableButton = false;
        public static int TotalSum = 0;

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

        private tblOrderItem allOrderItem;
        public tblOrderItem AllOrderItem
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

        private List<tblOrderItem> allOrderItemList;
        public List<tblOrderItem> AllOrderItemList
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

        private bool isUpdateItem;
        public bool IsUpdateItem
        {
            get
            {
                return isUpdateItem;
            }
            set
            {
                isUpdateItem = value;
            }
        }

        private vwOrder order;
        public vwOrder Order
        {
            get
            {
                return order;
            }
            set
            {
                order = value;
                OnPropertyChanged("Order");
            }
        }

        private List<vwOrder> orderList;
        public List<vwOrder> OrderList
        {
            get
            {
                return orderList;
            }
            set
            {
                orderList = value;
                OnPropertyChanged("OrderList");
            }
        }
        #endregion

        #region Constructor
        public CreateNewOrderViewModel(CreateNewOrder createNewOrder)
        {
            this.createNewOrder = createNewOrder;

            Service s = new Service();

            AllMenuList = s.GetAllMenu().ToList();
            AllOrderItemList = s.GetAllOrderItem().ToList();
            AllOrderList = s.GetAllOrder().ToList();

            try
            {
                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblOrder tblOrder = new tblOrder();
                    DateTime dateTime = DateTime.Now;

                    tblOrder.DateTimeOrder = dateTime;
                    tblOrder.Guest = LoggedGuest.id;
                    tblOrder.OrderStatus = 1;
                    tblOrder.TotalPrice = 0;
                    tblOrder.Archived = 0;

                    context.tblOrders.Add(tblOrder);
                    context.SaveChanges();
                }
                AllOrderList = s.GetAllOrder().ToList();

                OrderList = s.GetOrder(AllOrderList.LastOrDefault().OrderID).ToList();
            }
            catch (Exception)
            {

            }
        }
        #endregion

        #region Comands
        private ICommand addItem;
        public ICommand AddItem
        {
            get
            {
                if (addItem == null)
                {
                    addItem = new RelayCommand(param => AddItemExecute(), param => CanAddItemExecute());
                }
                return addItem;
            }
        }

        /// <summary>
        /// Add the selected menu item to the order
        /// </summary>
        private void AddItemExecute()
        {
            try
            {
                Service s = new Service();
                AddOrderItem addOrderItem = new AddOrderItem();
                if (AllMenu != null)
                {
                    List<tblOrder> tblOrders = s.GetAllOrder();

                    addOrderItem.txtName.Text = AllMenu.ProductName;
                    addOrderItem.txtOrder.Text = Convert.ToString(tblOrders.LastOrDefault().OrderID);
                    addOrderItem.txtPrice.Text = Convert.ToString(AllMenu.PriceProduct);

                    addOrderItem.ShowDialog();
                    if ((addOrderItem.DataContext as AddOrderItemViewModel).IsUpdateItem == true)
                    {
                        OrderList = s.GetOrder(AllOrderList.LastOrDefault().OrderID).ToList();
                        TotalSum = 0;
                        if (OrderList.Count == 0)
                        {
                            createNewOrder.msgNoItems.Visibility = Visibility.Visible;
                            createNewOrder.gridOrderItem.Visibility = Visibility.Collapsed;
                            createNewOrder.btnPlaceOrderNow.Visibility = Visibility.Collapsed;
                            createNewOrder.txtTotalSum.Text = TotalSum.ToString() + ",00";
                            createNewOrder.txtTotalSumBottom.Text = TotalSum.ToString() + ",00 RSD";
                        }
                        else
                        {
                            createNewOrder.msgNoItems.Visibility = Visibility.Collapsed;
                            createNewOrder.gridOrderItem.Visibility = Visibility.Visible;
                            createNewOrder.btnPlaceOrderNow.Visibility = Visibility.Visible;
                            foreach (var item in OrderList)
                            {

                                TotalSum += item.OrderSum;
                                createNewOrder.txtTotalSum.Text = TotalSum.ToString() + ",00";
                                createNewOrder.txtTotalSumBottom.Text = TotalSum.ToString() + ",00 RSD";
                            }
                        }
                        CreateNewOrder.counter = CreateNewOrder.counter + 1;
                        createNewOrder.CountingBadge.Badge = CreateNewOrder.counter;
                    }
                }
                createNewOrder.DataGridAllMenu.UnselectAll();
            }
            catch (Exception)
            {

            }
            finally
            {

            }
        }

        private bool CanAddItemExecute()
        {
            if (AllMenu == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

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
        /// exit the form and delete the order and the 
        /// line item that has not been saved
        /// </summary>
        private void ExitExecute()
        {
            MessageBoxResult dialog = Xceed.Wpf.Toolkit.MessageBox.Show("Do you want to cancel the order?", "Cancel Order", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (dialog == MessageBoxResult.Yes)
            {
                try
                {
                    Service s = new Service();

                    //Delete all order items
                    foreach (var item in OrderList)
                    {
                        int orderItemID = item.OrderItemID;
                        bool isOrderItem = s.IsOrderID(orderItemID);
                        if (isOrderItem == true)
                        {
                            s.DeleteOrderItem(orderItemID);
                        }
                    }
                    //Delete order
                    List<tblOrder> tblOrders = s.GetAllOrder();
                    s.DeleteOrder(tblOrders.LastOrDefault().OrderID);
                }
                catch (Exception)
                {

                }
                finally
                {
                    createNewOrder.Close();
                }
            }
        }

        private bool CanExitExecute()
        {
            return true;
        }

        private ICommand delete;
        public ICommand Delete
        {
            get
            {
                if (delete == null)
                {
                    delete = new RelayCommand(param => DeleteExecute(), param => CanDeleteExecute());
                }
                return delete;
            }
        }

        /// <summary>
        /// Method for deleting the selected item from the order
        /// </summary>
        public void DeleteExecute()
        {
            try
            {
                MessageBoxResult dialogDelete = Xceed.Wpf.Toolkit.MessageBox.Show($"Do you want to exclude the item from the order?\n\nItem: {order.Expr2} ({order.Expr3})", "Delete item", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (dialogDelete == MessageBoxResult.Yes)
                {
                    if (Order != null)
                    {
                        Service s = new Service();

                        int orderItemID = Order.OrderItemID;
                        bool isOrderItem = s.IsOrderID(orderItemID);
                        if (isOrderItem == true)
                        {
                            s.DeleteOrderItem(orderItemID);
                            OrderList = s.GetOrder(AllOrderList.LastOrDefault().OrderID).ToList();

                            OrderList = s.GetOrder(AllOrderList.LastOrDefault().OrderID).ToList();
                            TotalSum = 0;
                            if (OrderList.Count == 0)
                            {
                                createNewOrder.msgNoItems.Visibility = Visibility.Visible;
                                createNewOrder.gridOrderItem.Visibility = Visibility.Collapsed;
                                createNewOrder.btnPlaceOrderNow.Visibility = Visibility.Collapsed;
                                createNewOrder.txtTotalSum.Text = TotalSum.ToString() + ",00";
                                createNewOrder.txtTotalSumBottom.Text = TotalSum.ToString() + ",00 RSD";
                            }
                            else
                            {
                                createNewOrder.msgNoItems.Visibility = Visibility.Collapsed;
                                createNewOrder.gridOrderItem.Visibility = Visibility.Visible;
                                createNewOrder.btnPlaceOrderNow.Visibility = Visibility.Visible;
                                foreach (var item in OrderList)
                                {

                                    TotalSum += item.OrderSum;
                                    createNewOrder.txtTotalSum.Text = TotalSum.ToString() + ",00";
                                    createNewOrder.txtTotalSumBottom.Text = TotalSum.ToString() + ",00 RSD";
                                }
                            }
                            CreateNewOrder.counter = CreateNewOrder.counter - 1;
                            createNewOrder.CountingBadge.Badge = CreateNewOrder.counter;
                        }
                        else
                        {
                            MessageBoxResult dialog = Xceed.Wpf.Toolkit.MessageBox.Show("Unable to delete...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanDeleteExecute()
        {
            if (Order == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        private ICommand placeOrderNow;
        public ICommand PlaceOrderNow
        {
            get
            {
                if (placeOrderNow == null)
                {
                    placeOrderNow = new RelayCommand(param => PlaceOrderNowExecute(), param => CanPlaceOrderNowExecute());
                }
                return placeOrderNow;
            }
        }

        /// <summary>
        /// Ordering method (Creating a pending order)
        /// </summary>
        private void PlaceOrderNowExecute()
        {
            using (PizzaRestoranEntities context = new PizzaRestoranEntities())
            {
                DateTime dateTime = DateTime.Now;

                tblOrder orderSave = (from r in context.tblOrders where r.Guest == LoggedGuest.id where r.OrderStatus == 1 select r).First();
                orderSave.DateTimeOrder = dateTime;
                orderSave.TotalPrice = TotalSum;
                context.SaveChanges();
            }
            Xceed.Wpf.Toolkit.MessageBox.Show("You have successfully placed your order.", "Create order", MessageBoxButton.OK, MessageBoxImage.Asterisk);

            IsUpdateItem = true;

            createNewOrder.Close();
        }

        private bool CanPlaceOrderNowExecute()
        {
            return true;
        }
        #endregion
    }
}
