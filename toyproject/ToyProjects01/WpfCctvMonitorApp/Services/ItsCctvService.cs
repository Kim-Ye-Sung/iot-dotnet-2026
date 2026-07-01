using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using WpfCctvMonitorApp.Models;

namespace WpfCctvMonitorApp.Services
{
    public class ItsCctvService
    {
        private readonly HttpClient httpClient = new();

        // TODO
        public async Task<ObservableCollection<CctvInfo>> GetCctvListAsync() {

            string json = await httpClient.GetStringAsync(apiUrl);

            var result = JsonConvert.DeserializeObject<ObservableCollection<CctvInfo>>(json);

            return result;
        }

        public async Task<ObservableCollection<CctvInfo>> GetAllCctvListAsync()
        {
            return null;
        }
    }
}
