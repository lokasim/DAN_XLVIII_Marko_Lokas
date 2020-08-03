using PizzaRestaurant.ViewModel;
using System;
using System.Media;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace PizzaRestaurant.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public bool loggedIn;

        public Login()
        {
            InitializeComponent();
            JMBG.Focus();
            this.DataContext = new LoginViewModel(this);
            this.Language = XmlLanguage.GetLanguage("sr-SR");
        }

        private void DragMe(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// Allows only letters
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private Boolean TextAllowed(String s)
        {
            foreach (Char c in s.ToCharArray())
            {
                if (Char.IsLetter(c) || Char.IsControl(c))
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

        private void PreviewTextInputHandler(Object sender, TextCompositionEventArgs e)
        {
            e.Handled = !TextAllowed(e.Text);
        }

        /// <summary>
        /// Space is not allowed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
            if (e.Key == Key.Space)
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// only numbers allowed
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

        /// <summary>
        /// validation JMBG
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void JMBGsign(object sender, TextChangedEventArgs e)
        {
            if (txtJMBG.Focus())
            {
                error.Visibility = Visibility.Visible;
                error.FontSize = 16;
                loginFail.Visibility = Visibility.Collapsed;
                error.Foreground = new SolidColorBrush(Colors.Red);
                error.Text = "The JMBG must contain 13 digits";
            }

            if (txtJMBG.Text.Length != 13)
            {
                txtJMBG.BorderBrush = new SolidColorBrush(Colors.Red);
                txtJMBG.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                error.Visibility = Visibility.Collapsed;
                txtJMBG.BorderBrush = new SolidColorBrush(Colors.Green);
                txtJMBG.Foreground = new SolidColorBrush(Colors.Green);
            }
            txtJMBG.MaxLength = 13;
            if (txtJMBG.Text.Length >= txtJMBG.MaxLength)
            {
                SystemSounds.Beep.Play();
            }
        }

        /// <summary>
        /// validation EMAIL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Email(object sender, TextChangedEventArgs e)
        {
            if (txtEmail.Focus())
            {
                error.Visibility = Visibility.Visible;
                loginFail.Visibility = Visibility.Collapsed;
                error.FontSize = 16;
                error.Foreground = new SolidColorBrush(Colors.Red);
                error.Text = "Make sure you have entered the\ncorrect email address";
            }
            if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                txtEmail.BorderBrush = new SolidColorBrush(Colors.Red);
                txtEmail.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                error.Visibility = Visibility.Collapsed;
                txtEmail.BorderBrush = new SolidColorBrush(Colors.Green);
                txtEmail.Foreground = new SolidColorBrush(Colors.Green);
            }
        }
    }
}
