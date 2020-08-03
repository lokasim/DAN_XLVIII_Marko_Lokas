using PizzaRestaurant.ViewModel;
using System;
using System.Media;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace PizzaRestaurant.Views
{
    /// <summary>
    /// Interaction logic for ArchivedOrder.xaml
    /// </summary>
    public partial class ArchivedOrder : UserControl
    {
        public ArchivedOrder()
        {
            InitializeComponent();
            this.DataContext = new ArchivedOrderViewModel(this);

            this.Name = "ArchivedOrder";
            this.Language = XmlLanguage.GetLanguage("en-GB");
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
        

        public void RefreshList()
        {
            this.DataContext = new ArchivedOrderViewModel(this);
        }
    }
}
