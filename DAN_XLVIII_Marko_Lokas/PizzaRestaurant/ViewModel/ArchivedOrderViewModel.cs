using PizzaRestaurant.Commands;
using PizzaRestaurant.Models;
using PizzaRestaurant.Services;
using PizzaRestaurant.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace PizzaRestaurant.ViewModel
{
    class ArchivedOrderViewModel : ViewModelBase
    {
        readonly ArchivedOrder archivedOrder;

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

        private bool isUpdateOrderItemList;
        public bool IsUpdateOrderItemList
        {
            get
            {
                return isUpdateOrderItemList;
            }
            set
            {
                isUpdateOrderItemList = value;
            }
        }
        #endregion

        #region Constructor
        public ArchivedOrderViewModel(ArchivedOrder archivedOrder)
        {
            this.archivedOrder = archivedOrder;
            IsUpdateOrderItemList = true;
            Service s = new Service();
            AllOrderItemList = s.GetOrderItemEmployeeArchive();

            //Grouping a list by orderID
            archivedOrder.lvOrder.ItemsSource = AllOrderItemList;

            if (AllOrderItemList != null)
            {
                if (AllOrderItemList.Count > 0)
                {
                    archivedOrder.lvOrder.Visibility = Visibility.Visible;
                    archivedOrder.msgNoOrder.Visibility = Visibility.Collapsed;
                    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(archivedOrder.lvOrder.ItemsSource);
                    PropertyGroupDescription groupDescription = new PropertyGroupDescription("Header");
                    view.GroupDescriptions.Add(groupDescription);
                }
                else
                {
                    archivedOrder.lvOrder.Visibility = Visibility.Collapsed;
                    archivedOrder.msgNoOrder.Visibility = Visibility.Visible;
                }
            }
            else
            {
                archivedOrder.lvOrder.Visibility = Visibility.Collapsed;
                archivedOrder.msgNoOrder.Visibility = Visibility.Visible;
            }
        }
        #endregion

        #region Commands
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
        /// A method for deleting an archived order
        /// </summary>
        public void DeleteExecute()
        {
            try
            {
                int orderNum = -1;
                orderNum = Convert.ToInt32(archivedOrder.OrderNumber.Text.ToString());
                if (archivedOrder.OrderNumber.Text.Length < 1)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Enter a number.", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else if (orderNum == 0)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Enter a number greater than zero.", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    Service s = new Service();
                    tblOrder order = s.GetOrderID(Convert.ToInt32(archivedOrder.OrderNumber.Text.ToString()));

                    if (order == null)
                    {
                        Xceed.Wpf.Toolkit.MessageBox.Show("The order number you entered does not exist, try another.", "Order Number", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        MessageBoxResult dialogDelete = Xceed.Wpf.Toolkit.MessageBox.Show($"Are you sure you want to delete the order {archivedOrder.OrderNumber.Text}?", "Delete order", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                        if (dialogDelete == MessageBoxResult.Yes)
                        {
                            using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                            {
                                int orderNumber = Convert.ToInt32(archivedOrder.OrderNumber.Text.ToString());

                                tblOrder orderDelete = (from r in context.tblOrders where r.OrderID == orderNumber select r).First();
                                orderDelete.Archived = 0;
                                context.SaveChanges();
                                AllOrderItemList = s.GetOrderItemEmployeeArchive();
                                Xceed.Wpf.Toolkit.MessageBox.Show($"You have successfully deleted the order number {archivedOrder.OrderNumber.Text}.", "Delete Order", MessageBoxButton.OK);

                                AllOrderItemList = s.GetOrderItemEmployeeArchive();
                                archivedOrder.lvOrder.ItemsSource = AllOrderItemList;

                                if (AllOrderItemList.Count > 0)
                                {
                                    archivedOrder.lvOrder.Visibility = Visibility.Visible;
                                    archivedOrder.msgNoOrder.Visibility = Visibility.Collapsed;
                                    CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(archivedOrder.lvOrder.ItemsSource);
                                    PropertyGroupDescription groupDescription = new PropertyGroupDescription("Header");
                                    view.GroupDescriptions.Add(groupDescription);
                                }
                                else
                                {
                                    archivedOrder.lvOrder.Visibility = Visibility.Collapsed;
                                    archivedOrder.msgNoOrder.Visibility = Visibility.Visible;
                                }
                            }
                        }
                    }
                }
                archivedOrder.OrderNumber.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanDeleteExecute()
        {
            if(archivedOrder.OrderNumber.Text.Trim() == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// A method for refreshing a list of archived orders
        /// </summary>
        public void RefreshListView()
        {
            Service s = new Service();

            AllOrderItemList = s.GetOrderItemEmployeeArchive();
            archivedOrder.lvOrder.ItemsSource = AllOrderItemList;

            archivedOrder.lvOrder.Visibility = Visibility.Visible;
            archivedOrder.msgNoOrder.Visibility = Visibility.Collapsed;
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(archivedOrder.lvOrder.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Header");
            view.GroupDescriptions.Add(groupDescription);
        }
        #endregion
    }
}
