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
    class AddOrderItemViewModel : ViewModelBase
    {
        readonly AddOrderItem addOrderItem;

        #region Properties
        private tblOrderItem orderItem;
        public tblOrderItem OrderItem
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

        private List<tblOrder> orderList;
        public List<tblOrder> OrderList
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
        #endregion

        #region Constructor
        public AddOrderItemViewModel(AddOrderItem addOrderItem)
        {
            this.addOrderItem = addOrderItem;
        }
        #endregion


        #region Commandes

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => SaveExecute(), param => CanSaveExecute());
                }
                return save;
            }
        }

        /// <summary>
        /// A method for entering the quantity of an item in a product
        /// </summary>
        private void SaveExecute()
        {
            try
            {
                if (addOrderItem.txtQuantity.Text.Length < 1)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Enter a number.", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                if (addOrderItem.txtQuantity.Text.ToString() == "0" || addOrderItem.txtQuantity.Text.ToString() == "00")
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("Quantity must be greater than zero.", "Wrong input", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                Service s = new Service();
                string productName = addOrderItem.txtName.Text;
                tblProduct menu = s.GetProductID(Convert.ToString(productName));

                using (PizzaRestoranEntities context = new PizzaRestoranEntities())
                {
                    tblOrderItem tblOrderItem = new tblOrderItem();
                    OrderList = s.GetAllOrder();

                    tblOrderItem.ProductName = menu.ProductID;
                    tblOrderItem.ProductPrice = Convert.ToInt32(addOrderItem.txtPrice.Text);
                    tblOrderItem.ProductQuantity = Convert.ToInt32(addOrderItem.txtQuantity.Text);
                    tblOrderItem.OrderName = OrderList.LastOrDefault().OrderID;
                    tblOrderItem.OrderSum = Convert.ToInt32(addOrderItem.txtPrice.Text) * Convert.ToInt32(addOrderItem.txtQuantity.Text);

                    context.tblOrderItems.Add(tblOrderItem);
                    context.SaveChanges();
                }

                IsUpdateItem = true;

                addOrderItem.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSaveExecute()
        {
            return true;
        }

        private ICommand close;
        public ICommand Close
        {
            get
            {
                if (close == null)
                {
                    close = new RelayCommand(param => CloseExecute(), param => CanCloseExecute());
                }
                return close;
            }
        }

        /// <summary>
        /// Exit form
        /// </summary>
        private void CloseExecute()
        {
            try
            {
                addOrderItem.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool CanCloseExecute()
        {
            return true;
        }
        #endregion
    }
}
