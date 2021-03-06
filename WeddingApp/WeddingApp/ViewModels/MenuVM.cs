using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Threading.Tasks;
using WeddingApp.Models;
using WeddingApp.Views.UserControls;
using WeddingApp.Views;
using System.Windows.Controls;
using System.Windows.Data;
using System.Globalization;
using System.Windows;

namespace WeddingApp.ViewModels
{
    internal class MenuVM : ViewModelBase
    {
        private long totalPrice;
        private List<DISH> selectedDishes;
        public ICommand LoadedCommand { get; set; }
        public ICommand PreviousUCCommand { get; set; }
        public ICommand AddToCartCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand HoverItemCommand { get; set; }
        public ICommand CancelHoverItemCommand { get; set; }
        public ICommand DeleteCartCommand { get; set; }
        public ICommand PreviousUCCommand1 { get; set; }

        public List<DISH> SelectedDishes
        {
            get => selectedDishes;
            set
            {
                selectedDishes = value;
                OnPropertyChanged(nameof(SelectedDishes));
            }
        }
        public long TotalPrice
        {
            get => totalPrice;
            set
            {
                totalPrice = value;
                OnPropertyChanged("TotalPrice");
            }
        }

        public MenuUC thisUC;

        public MenuVM()
        {
            LoadedCommand = new RelayCommand<MenuUC>(p => true, p => Loaded(p));
            PreviousUCCommand = new RelayCommand<MenuUC>(p => true, p => PreviousUC(p));
            AddToCartCommand = new RelayCommand<ListViewItem>(p => true, p => AddToCart(p));
            SearchCommand = new RelayCommand<MenuUC>(p => true, p => Search(p));
            HoverItemCommand = new RelayCommand<Button>((paramter) => paramter == null ? false : true, (parameter) => HoverItem(parameter));
            CancelHoverItemCommand = new RelayCommand<Button>((paramter) => paramter == null ? false : true, (parameter) => CancelHoverItem(parameter));
            DeleteCartCommand = new RelayCommand<ListViewItem>(p => p == null ? false : true, (p) => DeleteCart(p));
            PreviousUCCommand1 = new RelayCommand<ServiceSelectionUC>(p => true, p => PreviousUC1());
            SelectedDishes = new List<DISH>();
        }
        public void Loaded(MenuUC menuUC)
        {
            menuUC.comboxTypeDish.Items.Add("Tất cả");
            foreach(var item in Data.Ins.DB.DISHTYPES.ToList())
            {
                menuUC.comboxTypeDish.Items.Add(item.DISHTYPENAME);
            }
            List<DISH> dishList = Data.Ins.DB.DISHES.Where(x=>x.STATUS == 1).ToList();
            menuUC.ViewListProducts.ItemsSource = dishList;
            thisUC = menuUC;
            menuUC.combox.SelectionChanged += new SelectionChangedEventHandler(SelectionChanged); 
            menuUC.comboxTypeDish.SelectionChanged += new SelectionChangedEventHandler(SelectionChanged2);
            List<DISH> temp = new List<DISH>();
            SelectedDishes.ForEach(item => temp.Add(item));
            temp.Clear();
            SelectedDishes = temp;
            TotalPrice = GetTotalPrice(SelectedDishes);
        }
        public void PreviousUC1()
        {
            MainVM.PreviousUC();
            List<DISH> temp = new List<DISH>();
            SelectedDishes.ForEach(dish => temp.Add(dish));
            SelectedDishes = temp;
            foreach (var lvi in FindVisualChildren<ListViewItem>(thisUC.ViewListProducts))
            {
                DISH dish = lvi.DataContext as DISH;
                if (SelectedDishes.Contains(dish))
                {
                    Button button = GetVisualChild<Button>(lvi);
                    button.IsEnabled = false;
                }
            }

        }
        public void SelectionChanged2(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            if(thisUC.comboxTypeDish.SelectedIndex == 0)
            {
                List<DISH> dishList = Data.Ins.DB.DISHES.Where(x => x.STATUS == 1).ToList();
                thisUC.ViewListProducts.ItemsSource = dishList;
            }
            else
            {
                List<DISH> dishList = Data.Ins.DB.DISHES.Where(x => x.STATUS == 1 && x.DISHTYPE.DISHTYPENAME == thisUC.comboxTypeDish.SelectedItem.ToString()).ToList();
                thisUC.ViewListProducts.ItemsSource = dishList;
            }
        }
        public void SelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            List<DISH> SortedDish;
            switch (thisUC.combox.SelectedIndex)
            {
                case 0:
                    SortedDish = Data.Ins.DB.DISHES.OrderBy(p => p.DISHCOST).ToList();
                    thisUC.ViewListProducts.ItemsSource = SortedDish;
                    break;
                case 1:
                    SortedDish = Data.Ins.DB.DISHES.OrderByDescending(p => p.DISHCOST).ToList();
                    thisUC.ViewListProducts.ItemsSource = SortedDish;
                    break;
            }
        }
        public void Search(MenuUC menuUC)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(menuUC.ViewListProducts.ItemsSource);
            view.Filter = CompareString;
            CollectionViewSource.GetDefaultView(menuUC.ViewListProducts.ItemsSource).Refresh();
        }

        private bool CompareString(object item)
        {
            string a = (item as DISH).DISHNAME;
            string Search = thisUC.SearchTxt.Text.Trim();
            string b = Search;
            a = RemoveSign4VietnameseString(a);
            if (b != null)
            {
                b = RemoveSign4VietnameseString(b);
            }
            if (string.IsNullOrEmpty(b))
                return true;
            else
                return (a.IndexOf(b, StringComparison.OrdinalIgnoreCase) >= 0);
        }
        private static readonly string[] VietnameseSigns = new string[]
        {
            "aAeEoOuUiIdDyY",

            "áàạảãâấầậẩẫăắằặẳẵ",

            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",

            "éèẹẻẽêếềệểễ",

            "ÉÈẸẺẼÊẾỀỆỂỄ",

            "óòọỏõôốồộổỗơớờợởỡ",

            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",

            "úùụủũưứừựửữ",

            "ÚÙỤỦŨƯỨỪỰỬỮ",

            "íìịỉĩ",

            "ÍÌỊỈĨ",

            "đ",

            "Đ",

            "ýỳỵỷỹ",

            "ÝỲỴỶỸ"
        };
        public static string RemoveSign4VietnameseString(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }
        public bool isSearched(string a, string b)
        {
            if (string.CompareOrdinal(a, b) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddToCart(ListViewItem listViewItem)
        {
            DISH selectedDish = listViewItem.DataContext as DISH;
            List<DISH> temp = new List<DISH>();
            SelectedDishes.ForEach(dish => temp.Add(dish));
            if (!temp.Contains(selectedDish))
            {
                temp.Add(selectedDish);
            }
            SelectedDishes = temp;
            TotalPrice = GetTotalPrice(SelectedDishes);
            Button button = GetVisualChild<Button>(listViewItem);
            button.IsEnabled = false;
        }
        public void PreviousUC(MenuUC menuUC)
        {
            MainVM.PreviousUC();
        }

        private void DeleteCart(ListViewItem parameter)
        {
            DISH dishToDelete = parameter.DataContext as DISH;

            var menuUC = GetAncestorOfType<MenuUC>(parameter);
            foreach (var item in FindVisualChildren<ListViewItem>(menuUC.ViewListProducts))
            {
                DISH dish = item.DataContext as DISH;
                if (dish.DISHID == dishToDelete.DISHID)
                {

                    Button button = GetVisualChild<Button>(item);
                    button.IsEnabled = true;
                }
            }
            List<DISH> temp = new List<DISH>();
            SelectedDishes.ForEach(dish => temp.Add(dish));
            temp.Remove(dishToDelete);
            SelectedDishes = temp;
            TotalPrice = GetTotalPrice(SelectedDishes);
        }
        private long GetTotalPrice(List<DISH> Dishes)
        {
            long res = 0;
            foreach (var item in Dishes)
            {
                res += Convert.ToInt32(item.DISHCOST);
            }
            return res;
        }
        private void HoverItem(Button deleteBtn)
        {
            deleteBtn.Visibility = Visibility.Visible;
        }

        private void CancelHoverItem(Button deleteBtn)
        {
            deleteBtn.Visibility = Visibility.Collapsed;
        }
    }
}