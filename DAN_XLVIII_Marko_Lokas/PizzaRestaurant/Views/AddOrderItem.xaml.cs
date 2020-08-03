using PizzaRestaurant.ViewModel;
using System;
using System.Media;
using System.Windows;
using System.Windows.Input;

namespace PizzaRestaurant.Views
{
    /// <summary>
    /// Interaction logic for AddOrderItem.xaml
    /// </summary>
    public partial class AddOrderItem : Window
    {
        public AddOrderItem()
        {
            InitializeComponent();
            this.DataContext = new AddOrderItemViewModel(this);

            txtQuantity.Focus();
        }

        /// <summary>
        /// A method that allows only numbers to be entered
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private Boolean NumberAllowed(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c))
                {
                    continue;
                }
                else
                {
                    SystemSounds.Beep.Play();
                    return false;
                }
            }
            return true;
        }
        private void PreviewNumberInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !NumberAllowed(e.Text);
        }
    }
}
