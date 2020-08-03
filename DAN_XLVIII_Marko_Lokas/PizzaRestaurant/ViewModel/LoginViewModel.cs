using PizzaRestaurant.Commands;
using PizzaRestaurant.Models;
using PizzaRestaurant.Services;
using PizzaRestaurant.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace PizzaRestaurant.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
        readonly Login login;

        #region Properties
        public static bool employeeLoging = false;
        public static bool guestLoging = false;

        private List<tblGuest> guestList;
        public List<tblGuest> GuestList
        {
            get
            {
                return guestList;
            }
            set
            {
                guestList = value;
                OnPropertyChanged("GuestList");
            }
        }

        private tblGuest guest;
        public tblGuest Guest
        {
            get
            {
                return guest;
            }
            set
            {
                guest = value;
                OnPropertyChanged("Guest");
            }
        }

        private bool isUpdateGuest;
        public bool IsUpdateGuest
        {
            get
            {
                return isUpdateGuest;
            }
            set
            {
                isUpdateGuest = value;
            }
        }
        #endregion

        #region Constructor
        public LoginViewModel(Login login)
        {
            this.login = login;
            guest = new tblGuest();

            Service s = new Service();
        }
        #endregion

        #region Commands
        private ICommand exit;
        public ICommand Exit
        {
            get
            {
                if (exit == null)
                {
                    exit = new RelayCommand(param => ExitExecute(), param => CanExitExecute());
                }
                return exit;
            }
        }

        /// <summary>
        /// Exit application
        /// </summary>
        private void ExitExecute()
        {
            MessageBoxResult dialog = Xceed.Wpf.Toolkit.MessageBox.Show("Do you want to exit the application?", "Exit", MessageBoxButton.YesNo);

            if (dialog == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private bool CanExitExecute()
        {
            return true;
        }

        /// <summary>
        /// Login employee
        /// </summary>
        private ICommand loginE;
        public ICommand LoginE
        {
            get
            {
                if (loginE == null)
                {
                    loginE = new RelayCommand(param => LoginEExecute(), param => CanLoginEExecute());
                }
                return loginE;
            }
        }

        private void LoginEExecute()
        {
            if (login.usernameEmployee.Text == "Zaposleni" && login.passwordBoxEmployee.Password == "Zaposleni")
            {
                guestLoging = false;
                employeeLoging = true;
                login.loggedIn = false;
                login.Close();
            }
            else
            {
                login.loginFailEmployee.Visibility = Visibility.Visible;
            }
        }

        private bool CanLoginEExecute()
        {
            return true;
        }

        /// <summary>
        /// Login Guest
        /// </summary>
        private ICommand loginG;
        public ICommand LoginG
        {
            get
            {
                if (loginG == null)
                {
                    loginG = new RelayCommand(param => LoginGExecute(), param => CanLoginGExecute());
                }
                return loginG;
            }
        }

        private void LoginGExecute()
        {
            Service s = new Service();

            string jmbg = login.JMBG.Text;

            tblGuest guestLogin = s.GetJMBG(jmbg);

            if (guestLogin != null && login.passwordBox.Password == "Gost")
            {
                //Storing logged in guest data
                LoggedGuest.name = guestLogin.GuestName;
                LoggedGuest.surname = guestLogin.GuestSurname;
                LoggedGuest.jmbg = guestLogin.JMBG;
                LoggedGuest.email = guestLogin.EMail;
                LoggedGuest.id = guestLogin.GuestID;
                employeeLoging = false;
                guestLoging = true;
                login.loggedIn = false;
                login.Close();
            }
            else
            {
                VisibleLoginFail();
            }
        }

        private bool CanLoginGExecute()
        {
            if (login.JMBG.Text.Length != 13)
            {
                login.jmbgHint.Foreground = new SolidColorBrush(Colors.Red);
                return false;
            }
            else
            {
                login.jmbgHint.Foreground = new SolidColorBrush(Colors.Green);
                return true;
            }
        }

        public async void VisibleLoginFail()
        {
            login.loginFail.Visibility = Visibility.Visible;
            await Task.Delay(2000);
            login.loginFail.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// View guest login form
        /// </summary>
        private ICommand loginGuest;
        public ICommand LoginGuest
        {
            get
            {
                if (loginGuest == null)
                {
                    loginGuest = new RelayCommand(param => LoginGuestExecute(), param => CanLoginGuestExecute());
                }
                return loginGuest;
            }
        }

        private void LoginGuestExecute()
        {
            login.pnlLoginEmployee.Visibility = Visibility.Collapsed;
            login.pnlLoginGuest.Visibility = Visibility.Visible;
            login.pnlSignUpGuest.Visibility = Visibility.Collapsed;
            login.loginFail.Visibility = Visibility.Collapsed;
        }

        private bool CanLoginGuestExecute()
        {
            if (login.pnlLoginGuest.Visibility == Visibility.Visible)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// View Guest login form
        /// </summary>
        private ICommand loginEmployee;
        public ICommand LoginEmployee
        {
            get
            {
                if (loginEmployee == null)
                {
                    loginEmployee = new RelayCommand(param => LoginEmployeeExecute(), param => CanLoginEmployeeExecute());
                }
                return loginEmployee;
            }
        }

        private void LoginEmployeeExecute()
        {
            login.pnlLoginGuest.Visibility = Visibility.Collapsed;
            login.pnlLoginEmployee.Visibility = Visibility.Visible;
            login.pnlSignUpGuest.Visibility = Visibility.Collapsed;
            login.loginFail.Visibility = Visibility.Collapsed;
        }

        private bool CanLoginEmployeeExecute()
        {
            if (login.pnlLoginEmployee.Visibility == Visibility.Visible)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// View guest registration form
        /// </summary>
        private ICommand signUpGuest;
        public ICommand SignUpGuest
        {
            get
            {
                if (signUpGuest == null)
                {
                    signUpGuest = new RelayCommand(param => SignUpGuestExecute(), param => CanSignUpGuestExecute());
                }
                return signUpGuest;
            }
        }

        private void SignUpGuestExecute()
        {
            login.pnlLoginGuest.Visibility = Visibility.Collapsed;
            login.pnlLoginEmployee.Visibility = Visibility.Collapsed;
            login.pnlSignUpGuest.Visibility = Visibility.Visible;
            login.error.Visibility = Visibility.Collapsed;
            login.txtName.Text = "";
            login.txtSurname.Text = "";
            login.txtJMBG.Text = "";
            login.txtEmail.Text = "";
            login.JMBG.Text = "";
            login.passwordBox.Password = "";
            login.loginFail.Visibility = Visibility.Collapsed;
        }

        private bool CanSignUpGuestExecute()
        {
            return true;
        }


        private ICommand signUp;
        public ICommand SignUp
        {
            get
            {
                if (signUp == null)
                {
                    signUp = new RelayCommand(param => SignUpExecute(), param => CanSignUpExecute());
                }
                return signUp;
            }
        }

        /// <summary>
        /// A method for registering new guests
        /// </summary>
        private void SignUpExecute()
        {
            try
            {
                Service s = new Service();

                string name = Guest.GuestName;
                string surname = Guest.GuestSurname;
                string jmbg = Guest.JMBG;
                string email = Guest.EMail;

                //JMBG validation
                if (!ValidationJMBG.CheckJMBG(jmbg))
                {
                    return;
                }

                //Check if the JMBG exists in the database
                tblGuest employee = s.GetGuestJMBG(jmbg);

                if (employee != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("JMBG already exists in the database, try another.", "JMBG");
                    return;
                }

                //Check if the email exists in the database
                tblGuest employeeEmail = s.GetGuestEmail(email);

                if (employeeEmail != null)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("E-mail already exists in the database, try another.", "E-mail");
                    return;
                }

                s.AddGuest(Guest);

                IsUpdateGuest = true;

                string poruka = "Guest: " + Guest.GuestName + " " + Guest.GuestSurname;
                Xceed.Wpf.Toolkit.MessageBox.Show(poruka, "Successfully added Guest", MessageBoxButton.OK);
                login.txtName.Text = "";
                login.txtSurname.Text = "";
                login.txtJMBG.Text = "";
                login.txtEmail.Text = "";
                login.pnlLoginGuest.Visibility = Visibility.Visible;
                login.pnlLoginEmployee.Visibility = Visibility.Collapsed;
                login.pnlSignUpGuest.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                Xceed.Wpf.Toolkit.MessageBox.Show(ex.ToString());
            }
        }

        private bool CanSignUpExecute()
        {
            if (String.IsNullOrEmpty(guest.GuestName) || String.IsNullOrWhiteSpace(guest.GuestName) ||
                String.IsNullOrEmpty(guest.GuestSurname) || String.IsNullOrWhiteSpace(guest.GuestSurname) ||
                String.IsNullOrEmpty(guest.JMBG) ||
                String.IsNullOrEmpty(guest.EMail))
            {
                return false;
            }
            else if (guest.JMBG.Length != 13)
            {
                return false;
            }
            else if (!Regex.IsMatch(login.txtEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}

