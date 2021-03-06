using WeddingApp.Models;
using WeddingApp.Views;
using WeddingApp.Views.UserControls;
using WeddingApp.Views.UserControls.Admin;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Collections.Generic;

namespace WeddingApp.ViewModels
{
    internal class MainVM : ViewModelBase
    {
        public ICommand LoadedCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        public ICommand SwitchTabCommand { get; set; }
        public ICommand LogOutCommand { get; set; }

        public static Stack<UIElement> NextUCs = new Stack<UIElement>();
        public static Stack<UIElement> PreviousUCs = new Stack<UIElement>();
        public static MainWindow mainwindow1;

        //public string Fullname
        //{ get => CurrentAccount.User.FULLNAME_; set { CurrentAccount.User.FULLNAME_ = value; OnPropertyChanged("Fullname"); } }
        //public string Avatar
        //{ get => CurrentAccount.User.AVATAR_; set { CurrentAccount.User.AVATAR_ = value; OnPropertyChanged("Avatar"); } }

        private string mail;

        public string Mail
        { get => mail; set { mail = value; OnPropertyChanged("Mail"); } }

        private string phone;

        public string Phone
        { get => phone; set { phone = value; OnPropertyChanged("Phone"); } }

        private string userName;

        public string UserName
        { get => userName; set { userName = value; OnPropertyChanged("UserName"); } }

        private string address;

        public string Address
        { get => address; set { address = value; OnPropertyChanged("Address"); } }

        public static string WeddingHall;

        public MainVM()
        {
            LoadedCommand = new RelayCommand<MainWindow>(parameter => true, parameter => Loaded(parameter));
            CloseWindowCommand = CloseWindowCommand = new RelayCommand<UserControl>((p) => p == null ? false : true, p =>
            {
                if (CustomMessageBox.Show("Thoát ứng dụng?", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    FrameworkElement window = ControlBarVM.GetParentWindow(p);
                    var w = window as Window;
                    if (w != null)
                    {
                        w.Close();
                    }
                }
            });
            SwitchTabCommand = new RelayCommand<MainWindow>(p => true, (p) => SwitchTab(p));
            LogOutCommand = new RelayCommand<MainWindow>(p => true, (p) => LogOut(p));

        }
        public static void NextUC()
        {
            PreviousUCs.Push(NextUCs.Pop());
            mainwindow1.ucWindow.Children.Clear();
            mainwindow1.ucWindow.Children.Add(NextUCs.First());
        }
        public static void ReturnFirstPage()
        {
            NextUCs.Push(new ServiceSelectionUC());
            NextUCs.Push(new MenuUC());
            NextUCs.Push(new SetWeddingInfomationUC());
            mainwindow1.ucWindow.Children.Clear();
            mainwindow1.ucWindow.Children.Add(NextUCs.First());
        }
        public static void PreviousUC()
        {
            mainwindow1.ucWindow.Children.Clear();
            mainwindow1.ucWindow.Children.Add(PreviousUCs.First());
            NextUCs.Push(PreviousUCs.Pop());
        }
        private void Loaded(MainWindow mainWindow)
        {
            SetWeddingInfomationUC setWeddingInfomationUC = new SetWeddingInfomationUC();
            MenuUC menuUC = new MenuUC();
            ServiceSelectionUC serviceSelectionUC = new ServiceSelectionUC();
            NextUCs.Push(serviceSelectionUC);
            NextUCs.Push(menuUC);
            NextUCs.Push(setWeddingInfomationUC);

            List<PERMISSION> list = Data.Ins.DB.PERMISSIONs.Where(x => x.ROLEID == CurrentAccount.Role).ToList();
            List<string> FunctionName = new List<string>();
            foreach (var item in list)
            {
                FunctionName.Add(item.FUNCTIONID.ToString());
            }
            mainWindow.listViewMenu.Items.Cast<ListViewItem>().ToList().ForEach(item =>
            {
                if (FunctionName.Contains(item.Name))
                    item.Visibility = Visibility.Visible;
            });
            if (CurrentAccount.Role == "GD")
            {
                mainWindow.listViewMenu.SelectedIndex = 1;
                mainWindow.ucWindow.Children.Add(new DashBoardUC());
            }
            else
            {
                mainWindow.listViewMenu.SelectedIndex = 0;
                mainWindow.ucWindow.Children.Add(NextUCs.First());
            }
            mainWindow.controlBar.closeBtn.Command = CloseWindowCommand;
            mainWindow.controlBar.closeBtn.CommandParameter = mainWindow.controlBar;
            mainwindow1 = mainWindow;
        }

        private void SwitchTab(MainWindow mainWindow)
        {
            int index = mainWindow.listViewMenu.SelectedIndex;
            List<ListViewItem> listViewItems  = mainWindow.listViewMenu.Items.Cast<ListViewItem>().ToList();
            ListViewItem listViewItem = listViewItems[index];
            switch (listViewItem.Name)
            {
                case "WeddingHallUC":
                    mainWindow.ucWindow.Children.Clear();
                    mainWindow.ucWindow.Children.Add(new WeddingHallUC());
                    break;

                case "WeddingListUC":
                    mainWindow.ucWindow.Children.Clear();
                    mainWindow.ucWindow.Children.Add(new WeddingListUC());
                    break;

                case "InvoiceListUC":
                    mainWindow.ucWindow.Children.Clear();
                    mainWindow.ucWindow.Children.Add(new InvoiceListUC());
                    break;

                case "DashBoardUC":
                    mainWindow.ucWindow.Children.Clear();
                    mainWindow.ucWindow.Children.Add(new DashBoardUC());
                    break;

                case "DishListUC":
                    mainWindow.ucWindow.Children.Clear();
                    mainWindow.ucWindow.Children.Add(new DishListUC());
                    break;

                case "EmployeeListUC":
                    mainWindow.ucWindow.Children.Clear();
                    mainWindow.ucWindow.Children.Add(new EmployeeListUC());
                    break;

                case "ServiceListUC":
                    mainWindow.ucWindow.Children.Clear();
                    mainWindow.ucWindow.Children.Add(new ServiceListUC());
                    break;

                case "WeddingHallTypeListUC":
                    mainWindow.ucWindow.Children.Clear();
                    mainWindow.ucWindow.Children.Add(new WeddingHallTypeListUC());
                    break;

                case "CompletedInvoiceListUC":
                    mainWindow.ucWindow.Children.Clear();
                    mainWindow.ucWindow.Children.Add(new CompletedInvoiceListUC());
                    break;
                case "SetWeddingInformationUC":
                    SetWeddingInfomationUC setWeddingInfomationUC = new SetWeddingInfomationUC();
                    MenuUC menuUC = new MenuUC();
                    ServiceSelectionUC serviceSelectionUC = new ServiceSelectionUC();
                    NextUCs.Clear();
                    PreviousUCs.Clear();
                    NextUCs.Push(serviceSelectionUC);
                    NextUCs.Push(menuUC);
                    NextUCs.Push(setWeddingInfomationUC);
                    mainWindow.ucWindow.Children.Clear();
                    mainWindow.ucWindow.Children.Add(NextUCs.First());
                    break;

                case "RoleListUC":
                    mainWindow.ucWindow.Children.Clear();
                    mainWindow.ucWindow.Children.Add(new RoleListUC());
                    break;
                case "ShiftListUC":
                    mainWindow.ucWindow.Children.Clear();
                    mainWindow.ucWindow.Children.Add(new ShiftListUC());
                    break;
            }
        }
        private void LogOut(MainWindow mainWindow)
        {
            if (CustomMessageBox.Show("Bạn có muốn đăng xuất?", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                NextUCs.Clear();
                PreviousUCs.Clear();
                NextUCs.Push(new ServiceSelectionUC());
                NextUCs.Push(new MenuUC());//......
                NextUCs.Push(new SetWeddingInfomationUC());
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
                mainWindow.Close();
            }
        }
    }
}