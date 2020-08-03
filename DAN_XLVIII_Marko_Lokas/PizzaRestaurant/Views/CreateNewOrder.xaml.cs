using PizzaRestaurant.ViewModel;
using System.Windows;
using System.Windows.Markup;

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
