using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using WpfBusanShoppingServiceApp.Helpers;
using WpfBusanShoppingServiceApp.Models;

namespace WpfBusanShoppingServiceApp.Services
{
    public class ShoppingApiService
    {
        //private readonly Logger logger = LogManager.GetCurrentClassLogger();

        // 서비스키가 공개됨. github 등
        //private readonly string ServiceKey = "....XlJz%2B%2FK8A%3D%3D";        
        private string? ServiceKey { get; set; }

        public ShoppingApiService() {         
            
            ServiceKey = Environment.GetEnvironmentVariable("BUSAN_Festival_API_KEY");
        }

        // OpenAPI를 네트워크 요청시 응답이 늦으면 UI스레드 충돌때문에 응답없음 뜰 수 있음
        public async Task<ObservableCollection<ShoppingItem>> GetShoppingsAsync(int pageNo = 1, int numOfRows = 10)
        {
            if (ServiceKey == null)
            {
                Common.logger.Warn("공공데이터 포털 API가 없습니다.");
                return new ObservableCollection<ShoppingItem>(); 
            }

            string serviceUrl = $"https://apis.data.go.kr/6260000/ShoppingService/getShoppingKr" +
                                $"?serviceKey={ServiceKey}" +
                                $"&pageNo={pageNo}" +
                                $"&numOfRows={numOfRows}" +
                                $"&resultType=json";

            try
            {
                using HttpClient client = new HttpClient();

                string json = await client.GetStringAsync(serviceUrl);

                // 데이터 직렬화(Serialization)로 네트워크 다운로드 
                // 역직렬화로 데이터 변환 
                ShoppingResponse? response = JsonConvert.DeserializeObject<ShoppingResponse>(json);

                //return response.FestivalData.Items;

                // 1번 예전 C#방식
                /*
                if (response != null &&  
                    response.FestivalData != null &&
                    response.FestivalData.Items != null)
                {
                    return response.FestivalData.Items;
                } 
                else
                {
                    return new ObservableCollection<FestivalItem>(); // 빈 리스트
                }*/

                // 2번 좀더 최근 C#방식
                return response?.ShoppingData?.Items?? new ObservableCollection<ShoppingItem>();

            }
            catch (Exception ex)
            {
                Common.logger.Error($"예외발생 GetShoppingsAsync() : {ex.Message}");
                return new ObservableCollection<ShoppingItem>();
            }
            

        }
    }
}
