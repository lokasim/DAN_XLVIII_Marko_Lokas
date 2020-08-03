using PizzaRestaurant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PizzaRestaurant.Views
{
    /// <summary>
    /// Interaction logic for CreateNewOrder.xaml
    /// </summary>
    public partial class CreateNewOrder : Window
    {
        //number of products in the cart
        public static int counter;

        public CreateNewOrder()
        {
            InitializeComponent();
            this.DataContext = new CreateNewOrderViewModel(this);

            this.Language = XmlLanguage.GetLanguage("sr-SR");
            gridOrderItem.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// A method that shows how many products are 
        /// in the shopping cart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (CountingBadge.Badge == null || Equals(CountingBadge.Badge, ""))
            {
                CountingBadge.Badge = counter;
            }
        }
    }
}
