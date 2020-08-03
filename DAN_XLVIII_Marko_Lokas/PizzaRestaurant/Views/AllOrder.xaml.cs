using PizzaRestaurant.ViewModel;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PizzaRestaurant.Views
{
    /// <summary>
    /// Interaction logic for AllOrder.xaml
    /// </summary>
    public partial class AllOrder : UserControl
    {
        public AllOrder()
        {
            InitializeComponent();
            this.DataContext = new AllOrderViewModel(this);

            this.Language = XmlLanguage.GetLanguage("en-GB");
        }
    }
}
