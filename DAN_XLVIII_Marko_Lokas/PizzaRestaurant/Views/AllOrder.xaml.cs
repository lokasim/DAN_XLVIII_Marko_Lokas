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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
