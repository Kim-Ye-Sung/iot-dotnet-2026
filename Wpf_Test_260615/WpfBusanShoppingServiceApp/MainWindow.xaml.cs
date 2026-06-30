using MahApps.Metro.Controls;
using NLog;
using System.Printing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfBusanShoppingServiceApp.Helpers;
using WpfBusanShoppingServiceApp.Models;
using WpfBusanShoppingServiceApp.Services;

namespace WpfBusanShoppingServiceApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        // NLog 기본 객체 생성방법
        //private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private readonly ShoppingApiService service;

        // 객체 생성은 클래스 생성자에서 일반적으로 구현
        public MainWindow()
        {
            InitializeComponent();

            service = new ShoppingApiService();
            // logger 에서 쓸 수 있는 메서드 Info(), Trace(), Debug(), Warn(), Error()
            Common.logger.Info("부산 관광쇼핑정보앱 시작.");
        }

        private async void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Common.logger.Info("부산 관광쇼핑정보앱 로드 시작");
            //string? key = Environment.GetEnvironmentVariable("BUSAN_FESTIVAL_API_KEY");
            //Console.WriteLine(key);

            // Api서비스 생성
            //FestivalApiService service = new FestivalApiService();            
            //var festivals = await service.GetFestivalsAsync();
            //DgrFestival.ItemsSource = festivals;
            await SearchShoppingAsync();

            Common.logger.Info("공공데이터 API 데이터 로드 완료");
        }

        // 검색
        private async void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            //WebTestWindow win = new WebTestWindow();
            //win.Owner = this;
            //win.ShowDialog();

            await SearchShoppingAsync();
        }

        // 검색기능 처리
        private async Task SearchShoppingAsync()
        {
            try
            {
                BtnSearch.IsEnabled = false;  // 검색이 완료될때까지 비활성화. 다시 못누르게

                // NumPageNo.Value == Null ? 1 : NumPageNo.Value
                int pageNo = Convert.ToInt32(NumPageNo.Value ?? 1);
                int numOfRows = Convert.ToInt32(NumOfRows.Value ?? 10);

                var Shopping = await service.GetShoppingsAsync(pageNo, numOfRows);

                DgrShopping.ItemsSource = Shopping;

                Common.logger.Info($"Page : {pageNo}, Records : {Shopping.Count} 로드 완료!");

                SbiStatus.Text = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {pageNo} 페이지 {Shopping.Count} 건 로드 완료";
            }
            catch (Exception ex)
            {
                Common.logger.Error($"데이터 로드 실패 SearchShoppingAsync() : {ex.Message}");

                SbiStatus.Text = $"로드 실패!!";
            }
            finally
            {
                BtnSearch.IsEnabled = true;
            }
        }

        private void DgrShopping_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (DgrShopping.SelectedItems.Count == 0)
            {
                return;
            }

            ShoppingItem detailItem = DgrShopping.SelectedItem as ShoppingItem;

            ShoppingDetailWindow win = new ShoppingDetailWindow(detailItem);
            win.Owner = this;

            win.ShowDialog();  // 부모창으로 데이터를 넘길게 아니면 Result true/false
        }
    }
}