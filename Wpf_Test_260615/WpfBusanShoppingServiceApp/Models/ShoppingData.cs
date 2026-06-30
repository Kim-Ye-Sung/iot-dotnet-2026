using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace WpfBusanShoppingServiceApp.Models
{
    public class ShoppingData
    {
        [JsonProperty("item")]
        public ObservableCollection<ShoppingItem> Items { get; set; }
    }
}
