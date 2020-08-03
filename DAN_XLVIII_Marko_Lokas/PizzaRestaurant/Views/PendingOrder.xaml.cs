using PizzaRestaurant.Models;
using PizzaRestaurant.ViewModel;
using System;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PizzaRestaurant.Views
{
    /// <summary>
    /// Interaction logic for PendingOrder.xaml
    /// </summary>
    public partial class PendingOrder : UserControl
    {
        public static int OrderID = 0;
        public static DateTime OrderDateTime = DateTime.Now;
        public static int OrderTotalPrice = 0;

        public PendingOrder()
        {
            InitializeComponent();
            this.DataContext = new PendingOrderViewModel(this);

            this.Language = XmlLanguage.GetLanguage("en-GB");
        }

        /// <summary>
        /// Pending orders
        /// Based on the selected order, a new window opens where 
        /// the employee can approve or reject the order
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var order = (tblOrder)DataGridOrderEmployeeHoldOn.SelectedItem;

            if (order != null)
            {
                //Selected OrderID
                OrderID = order.OrderID;
                //Selected DateTime
                OrderDateTime = order.DateTimeOrder;
                //Selected TotalPriceOrder
                OrderTotalPrice = order.TotalPrice;

                ApproveReject windowToOpen = new ApproveReject();

                windowToOpen.txtOrderNumber.Text = OrderID.ToString();
                windowToOpen.txtOrderingDate.Text = OrderDateTime.ToString("dddd dd. MMMM yyyy. HH:mm");
                windowToOpen.txtTotalSum.Text = OrderTotalPrice.ToString("N2") + " RSD";
                DataGridOrderEmployeeHoldOn.SelectedCells.Clear();

                windowToOpen.ShowDialog();
            }
            //refresh pending order list
            this.DataContext = new PendingOrderViewModel(this);
            //undo the selected order
            DataGridOrderEmployeeHoldOn.UnselectAll();
            ArchivedOrder archivedOrder = new ArchivedOrder();
            archivedOrder.RefreshList();
        }
    }
}
