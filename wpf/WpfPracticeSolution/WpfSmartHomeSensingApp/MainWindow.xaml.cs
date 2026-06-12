using MahApps.Metro.Controls;
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

using Bogus;
using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;
using WpfSmartHomeSensingApp.Models;
using System.Text.Json;
using WpfSmartHomeSensingApp.Helpers;
using MQTTnet;

namespace WpfSmartHomeSensingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private bool IsConnected { get; set; }  // 접속여부 확인

        #region DummyData용 속성/변수들   

        private string[] Rooms { get; set; }
        private string HomeId { get; set; }
        private Faker SmartHomeFaker { get; set; }

        #endregion

        #region MQTT 전송용 속성/변수들

        private IMqttClient? MqttClient { get; set; }
        private string MqttHost { get; set; } = "127.0.0.1";
        private int MqttPort { get; set; } = 1833;

        private string MqttUser { get; set; } = "root";

        private string MqttPassword { get; set; } = "mqtt123456";
        private string MqttTopic { get; set; } = "home/sensor";
        #endregion

        public MainWindow()
        {
            InitializeComponent();  // UI 초기화

            // 커스텀 초기화
            IsConnected = false; // 접속안한 상태

            InitFakeData(); // Bogus Faker 초기화
        }

        private void InitFakeData()
        {
            Rooms = ["BED", "BATH", "LIVING", "DINING"];
            HomeId = "D101H703";
            SmartHomeFaker = new Faker();

            Common.logger.Info("Bogus Faker 초기화완료.");
        }

        private async void BtnConnect_Click(object sender, RoutedEventArgs e)
        {
            // Bogus 테스트
            //var faker = new Faker("ko");    // 한국어 더미데이터

            //Console.WriteLine(faker.Name.FullName());
            //Console.WriteLine(faker.Name.JobTitle());
            //Console.WriteLine(faker.Phone.PhoneNumber());
            //Console.WriteLine(faker.Address.FullAddress());


            if (string.IsNullOrWhiteSpace(TxtMqttBrokerIp.Text))
            {
                await this.ShowMessageAsync("오류", "MQTT브로커주소를 입력하세요.");

                Common.logger.Warn("MQTT브로커주소 미입력!");
                return;
            }

            if (IsConnected == false)
            {
                // 아치피주소 형식에 맞지 않으면 메시지창 출력
                IsConnected = true;
                TxtStatus.Text = "DISCONNECT";

                Common.logger.Info("Bogus Faker 처리시작");
                StartSensing(); // 연결후 처리시작
            }
            else
            {
                IsConnected = false;
                TxtStatus.Text = "CONNECT";
                StopSensing();  // 연결종료 후 처리중지
                Common.logger.Info("Bogus Faker 처리종료.");
            }

        }


        private static void StopSensing()
        {

        }

        private async void StartSensing()
        {
            try
            {
                // TODO : 나중에 수정
                while (true)
                {
                    // Rooms 갯수(4개) 만큼 Bogus.Faker 사용해서 임의값 생성
                    List<SensorData> lists = Rooms.Select(room => new SensorData
                    {
                        HomeId = HomeId,
                        RoomName = room,
                        SensingDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Temp = Math.Round(SmartHomeFaker.Random.Double(20, 30), 1),
                        Humid = Math.Round(SmartHomeFaker.Random.Double(40, 70), 1)
                    }).ToList();

                    // list 데이터를 json으로 변환. 직렬화 -> 네트워크로 전송
                    string json = JsonSerializer.Serialize(lists, new JsonSerializerOptions { WriteIndented = true });

                    //Console.WriteLine(json);
                    AddLog("home/sensor", json);

                    await Task.Delay(TimeSpan.FromSeconds(1));
                }
            }
            catch (Exception)
            {

            }
        }


        private void AddLog(string topic, string payload)
        {
            // 언젠가 응답없음 발생함!
            //RtbLog.AppendText($"{topic} : {payload}\r\n");    // 이 방식으로 텍스트 입력 가능

            // RichTextBox 활용
            Dispatcher.Invoke(() =>
            {
                // UI스레드와 충돌없이 텍스트 출력방법
                Paragraph p = new Paragraph();

                p.Margin = new Thickness(0, 0, 0, 10);  // bottom에 10여백

                p.Inlines.Add(  // 출력시간표시
                    new Run($"[{DateTime.Now:HH:mm:ss}] ")
                    {
                        FontWeight = FontWeights.Bold,
                        Foreground = new SolidColorBrush(Colors.Blue)
                    });

                p.Inlines.Add(//토픽
                    new Run($"TOPIC : {topic}\n")
                    {
                        FontWeight = FontWeights.Bold
                    });

                p.Inlines.Add(// json 페이로드
                    new Run(payload)
                    {
                        FontFamily = new FontFamily("Consolas")
                    });

                RtbLog.Document.Blocks.Add(p);  

                if(RtbLog.Document.Blocks.Count > 100)
                {
                    RtbLog.Document.Blocks.Remove(
                        RtbLog.Document.Blocks.FirstBlock);
                }

                RtbLog.ScrollToEnd();   // 리치텍스트박스 가장 마지막으로 포커스
            });
        }
    }
}