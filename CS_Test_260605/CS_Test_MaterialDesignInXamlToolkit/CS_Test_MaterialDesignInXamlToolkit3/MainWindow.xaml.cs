using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CS_Test_MaterialDesignInXamlToolkit3
{
    public partial class MainWindow : Window
    {
        private readonly List<MenuProduct> allProducts = new List<MenuProduct>();
        private readonly ObservableCollection<MenuProduct> filteredProducts = new ObservableCollection<MenuProduct>();
        private readonly ObservableCollection<CartItem> cartItems = new ObservableCollection<CartItem>();

        private string currentCategory = "전체";

        public MainWindow()
        {
            InitializeComponent();

            MakeSampleMenu();

            MenuItemsControl.ItemsSource = filteredProducts;
            CartItemsControl.ItemsSource = cartItems;

            RefreshMenu();
            RefreshCart();
        }

        private void MakeSampleMenu()
        {
            allProducts.Add(new MenuProduct("프리미엄 불고기 버거", "버거", 6900, "🍔", "진한 불고기 소스와 두툼한 패티"));
            allProducts.Add(new MenuProduct("더블 치즈 버거", "버거", 7400, "🧀", "치즈 2장과 고소한 소고기 패티"));
            allProducts.Add(new MenuProduct("스파이시 치킨 버거", "버거", 6500, "🍗", "매콤한 치킨 패티와 신선한 양상추"));
            allProducts.Add(new MenuProduct("베이컨 클래식 버거", "버거", 7900, "🥓", "바삭한 베이컨이 들어간 클래식 버거"));

            allProducts.Add(new MenuProduct("감자튀김", "사이드", 2800, "🍟", "바삭하고 짭짤한 기본 사이드"));
            allProducts.Add(new MenuProduct("치즈스틱", "사이드", 3500, "🧀", "쭉 늘어나는 고소한 치즈스틱"));
            allProducts.Add(new MenuProduct("치킨너겟", "사이드", 4200, "🍗", "한입 크기의 바삭한 너겟"));
            allProducts.Add(new MenuProduct("어니언링", "사이드", 3900, "🧅", "달콤한 양파를 바삭하게 튀긴 메뉴"));

            allProducts.Add(new MenuProduct("콜라", "음료", 2200, "🥤", "시원한 탄산음료"));
            allProducts.Add(new MenuProduct("제로 콜라", "음료", 2300, "🥤", "당 걱정 없는 제로 음료"));
            allProducts.Add(new MenuProduct("아이스 아메리카노", "음료", 3000, "☕", "깔끔하고 시원한 커피"));
            allProducts.Add(new MenuProduct("레몬 에이드", "음료", 3600, "🍋", "상큼한 레몬 향의 에이드"));

            allProducts.Add(new MenuProduct("초코 선데이", "디저트", 3200, "🍨", "달콤한 초코 시럽 아이스크림"));
            allProducts.Add(new MenuProduct("애플파이", "디저트", 2900, "🥧", "따뜻하고 달콤한 사과 파이"));
            allProducts.Add(new MenuProduct("쿠키 세트", "디저트", 2500, "🍪", "바삭한 쿠키 2개 세트"));
        }

        private void RefreshMenu()
        {
            var result = allProducts.Where(product =>
            {
                bool categoryMatched = currentCategory == "전체" || product.Category == currentCategory;

                return categoryMatched;
            });

            filteredProducts.Clear();

            foreach (MenuProduct product in result)
            {
                filteredProducts.Add(product);
            }

            CategoryTitleText.Text = currentCategory == "전체" ? "전체 메뉴" : currentCategory;
        }

        private void RefreshCart()
        {
            int totalCount = cartItems.Sum(item => item.Quantity);
            int total = cartItems.Sum(item => item.LineTotal);

            CountText.Text = $"{totalCount}개 선택됨";
            SubTotalText.Text = $"₩ {total:N0}";
            TotalText.Text = $"₩ {total:N0}";
            PaymentTotalText.Text = $"₩ {total:N0}";

            EmptyCartText.Visibility = cartItems.Count == 0 ? Visibility.Visible : Visibility.Collapsed;

            CartItemsControl.Items.Refresh();
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is string category)
            {
                currentCategory = category;
                RefreshMenu();
            }
        }

        private void AddMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is MenuProduct product)
            {
                CartItem existingItem = cartItems.FirstOrDefault(item => item.Product.Name == product.Name);

                if (existingItem == null)
                {
                    cartItems.Add(new CartItem(product));
                }
                else
                {
                    existingItem.Quantity++;
                }

                RefreshCart();
            }
        }

        private void IncreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is CartItem item)
            {
                item.Quantity++;
                RefreshCart();
            }
        }

        private void DecreaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is CartItem item)
            {
                item.Quantity--;

                if (item.Quantity <= 0)
                {
                    cartItems.Remove(item);
                }

                RefreshCart();
            }
        }

        private void RemoveCartButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is CartItem item)
            {
                cartItems.Remove(item);
                RefreshCart();
            }
        }

        private void ClearCartButton_Click(object sender, RoutedEventArgs e)
        {
            cartItems.Clear();
            RefreshCart();
        }

        private void PaymentButton_Click(object sender, RoutedEventArgs e)
        {
            if (cartItems.Count == 0)
            {
                MessageBox.Show("먼저 메뉴를 선택해주세요.", "알림", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            PaymentOverlay.Visibility = Visibility.Visible;
        }

        private void CancelPaymentButton_Click(object sender, RoutedEventArgs e)
        {
            PaymentOverlay.Visibility = Visibility.Collapsed;
        }

        private void CompletePaymentButton_Click(object sender, RoutedEventArgs e)
        {
            PaymentOverlay.Visibility = Visibility.Collapsed;

            MessageBox.Show("주문이 완료되었습니다.\n영수증 번호: A-102", "주문 완료", MessageBoxButton.OK, MessageBoxImage.Information);

            cartItems.Clear();
            RefreshCart();
        }
    }

    public class MenuProduct
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }

        public MenuProduct(string name, string category, int price, string icon, string description)
        {
            Name = name;
            Category = category;
            Price = price;
            Icon = icon;
            Description = description;
        }
    }

    public class CartItem
    {
        public MenuProduct Product { get; set; }
        public int Quantity { get; set; }

        public int LineTotal
        {
            get
            {
                return Product.Price * Quantity;
            }
        }

        public CartItem(MenuProduct product)
        {
            Product = product;
            Quantity = 1;
        }
    }
}