using PizzaRestaurant.ViewModel;
using System.Windows;
using System.Windows.Markup;

namespace PizzaRestaurant.Views
{
    /// <summary>
    /// Interaction logic for ApproveReject.xaml
    /// </summary>
    public partial class ApproveReject : Window
    {
        public ApproveReject()
        {
            InitializeComponent();
            this.DataContext = new ApproveRejectViewModel(this);

            this.Language = XmlLanguage.GetLanguage("en-GB");
        }
    }
}
