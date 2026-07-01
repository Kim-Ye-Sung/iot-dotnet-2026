using LibVLCSharp.Shared;
using LibVLCSharp.WPF;
using System; // Uri를 사용하기 위해 필요합니다.
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfCctvMonitorApp.Services;

namespace WpfCctvMonitorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LibVLC libVLC;
        private readonly MediaPlayer mediaPlayer;

        private readonly ItsCctvService itsCctvService;

        public MainWindow()
        {
            InitializeComponent();


            Core.Initialize();

            libVLC = new LibVLC();
            mediaPlayer = new MediaPlayer(libVLC);
            VvwScreen.MediaPlayer = mediaPlayer;

            // OpenAPI 서비스 객체 생성
            itsCctvService= new ItsCctvService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // TODO : 나중에 지울것.. Video
            var media = new Media(libVLC, new Uri("https://cctvsec.ktict.co.kr:8082/mgmt026/mgmtcctv00005799D/main_stream.m3u8?nimblesessionid=22611035&wmsAuthSign=c2VydmVyX3RpbWU9Ny8xLzIwMjYgNDozMzo1OSBBTSZoYXNoX3ZhbHVlPTZIaE9QVEx0REg4WU1WaVlvZG8zRUE9PSZ2YWxpZG1pbnV0ZXM9MTIwJmlkPW1sdG0jbnRpY2xpdmUjODc0Ng==\r\n"));

            mediaPlayer.Play(media);

            Common.AppCommon.ItsOpenApiKey= ConfigurationManager.AppSettings["ItsOpenApiKey"];
            // MessageBox.Show(Common.AppCommon.ItsOpenApiKey);

            InitComboItems();

        }

        private void InitComboItems()
        {
            CboRegions.Items.Add("전국");
        }

        private void BtnExpress_Click(object sender, RoutedEventArgs e)
        {
            Common.AppCommon.ApiType = "ex";
        }

        private void BtnNational_Click(object sender, RoutedEventArgs e)
        {
            Common.AppCommon.ApiType = "nt";

        }

        private void BtnFavorites_Click(object sender, RoutedEventArgs e)
        {
            Common.AppCommon.ApiType = "fav";
        }
    }
}