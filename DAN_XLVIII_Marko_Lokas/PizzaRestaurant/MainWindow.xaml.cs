using MaterialDesignThemes.Wpf;
using PizzaRestaurant.Models;
using PizzaRestaurant.Services;
using PizzaRestaurant.ViewModel;
using PizzaRestaurant.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

namespace PizzaRestaurant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel(this);
            this.Language = XmlLanguage.GetLanguage("en-GB");

            Login login = new Login();
            if (login.loggedIn == false)
            {
                login.ShowDialog();
            }
            else
            {
                login.Close();
            }

            //Employee menu
            if (LoginViewModel.employeeLoging == true)
            {
                msgHappy.Text = "We wish you happy work :)".ToString();
                acceptReject.Text = "".ToString();
                DataGridAllMenu.Visibility = Visibility.Collapsed;
                processOrdering.Visibility = Visibility.Collapsed;
                lblPrezime.Content = "Employee".ToString();
                lblIme.Content = "".ToString(); ;
                var menuOrders = new List<Subitem>
                    {
                        new Subitem("Pending orders", new PendingOrder()),
                        //new Subitem("All orders"),
                        new Subitem("Archived orders", new ArchivedOrder()),
                    };

                var item1 = new ItemMenu("Reports", menuOrders, PackIconKind.Pizzeria);

                var item50 = new ItemMenu("Menu", new UserControl(), PackIconKind.Pizza);

                Menu.Children.Add(new UserControlMenuItem(item50, this));
                Menu.Children.Add(new UserControlMenuItem(item1, this));
            }

            //Guest menu
            if (LoginViewModel.guestLoging == true)
            {
                lblIme.Content = LoggedGuest.name;
                lblPrezime.Content = LoggedGuest.surname;
                msgHappy.Text = "Thank you for using our services :)".ToString();

                if (LoggedGuest.name != null || LoggedGuest.name != "")
                {
                    PrintMessage();
                }

                var menuOrders = new List<Subitem>
                    {
                        new Subitem("Create an order", new CreateOrder()),
                        //new Subitem("Create an order",new PersonalReports()),
                        new Subitem("View all orders", new AllOrder()),
                    };

                var item1 = new ItemMenu("Orders", menuOrders, PackIconKind.Pizzeria);

                var item50 = new ItemMenu("Menu", new UserControl(), PackIconKind.Pizza);

                Menu.Children.Add(new UserControlMenuItem(item50, this));
                Menu.Children.Add(new UserControlMenuItem(item1, this));
            }

            //determines the current page length
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            //Current time
            Vreme();

        }

        public void PrintMessage()
        {
            Service s = new Service();
            string jmbg = LoggedGuest.jmbg;
            List<vwOrder> accept = s.GetAcceptOrder(jmbg);
            if (accept != null)
            {
                if (accept.LastOrDefault().OrderStatus == 2)
                {
                    acceptReject.Text = "Your order has been approved".ToString();
                    Task.Delay(2000);
                }
                if (accept.LastOrDefault().OrderStatus == 3)
                {
                    acceptReject.Text = "Your order has been declined".ToString();
                    Task.Delay(2000);
                }
            }
        }
        /// <summary>
        /// Method to change the menu
        /// </summary>
        /// <param name="sender">Selected UserControl</param>
        public void SwitchScreen(object sender)
        {
            welcomeMsg.Visibility = Visibility.Collapsed;
            DataGridAllMenu.Visibility = Visibility.Collapsed;
            processOrdering.Visibility = Visibility.Collapsed;
            acceptReject.Visibility = Visibility.Collapsed;

            var screen = ((UserControl)sender);
            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);

                //ArchivedOrder ao = StackPanelMain.FindName("ArchivedOrder") as ArchivedOrder;
                //ArchivedOrder ar = new ArchivedOrder();

                if (screen.Name == "ArchivedOrder")
                {
                    ArchivedOrder archivedOrder = new ArchivedOrder();
                    StackPanelMain.Children.Clear();
                    StackPanelMain.Children.Add(archivedOrder);
                }
                else
                {
                    StackPanelMain.Children.Clear();
                    StackPanelMain.Children.Add(screen);
                }

            }
        }


        private void DragMe(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

                // throw;
            }
        }

        private void Vreme()
        {
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Dogadjaj;
            timer.Start();
        }

        /// <summary>
        /// method for printing the current time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Dogadjaj(object sender, EventArgs e)
        {
            vr.Text = DateTime.Now.ToString(@"HH:mm:ss");
        }

        /// <summary>
        /// method for the application user to log out, 
        /// after which a new login form is displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            LoginViewModel.guestLoging = false;
            LoginViewModel.employeeLoging = false;
            this.Close();
            Login login = new Login
            {
                loggedIn = false
            };

            MainWindow main = new MainWindow();
            main.ShowDialog();
        }

        /// <summary>
        /// Exit application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, RoutedEventArgs e)
        {
            MessageBoxResult dijalog = Xceed.Wpf.Toolkit.MessageBox.Show("Do you want to leave the program", "Exit app", MessageBoxButton.YesNo);

            if (dijalog == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
        }

        /// <summary>
        /// Window enlargement method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Povecaj_prozor(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                PovecajProzor.ToolTip = "Restore Down";
                PovecajProzor1.Visibility = Visibility.Visible;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                PovecajProzor.ToolTip = "Maximize";
                PovecajProzor1.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Window reduction method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spusti_prozor(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Minimized;
            }
        }

        private void Napustii_Click(object sender, RoutedEventArgs e)
        {
            ArchivedOrder archivedOrder = new ArchivedOrder();
            StackPanelMain.Children.Clear();
            StackPanelMain.Children.Add((UserControl)archivedOrder);
        }
    }
}