using PizzaRestaurant.ViewModel;
using System.Windows.Controls;

namespace PizzaRestaurant.Views
{
    /// <summary>
    /// Interaction logic for CreateOrder.xaml
    /// </summary>
    public partial class CreateOrder : UserControl
    {
        public CreateOrder()
        {
            InitializeComponent();
            this.DataContext = new CreateOrderViewModel(this);
        }
    }
}
