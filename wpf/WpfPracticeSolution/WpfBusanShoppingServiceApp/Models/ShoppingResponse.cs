using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WpfBusanShoppingServiceApp.Models
{
    public class ShoppingResponse
    {
        [JsonProperty("getShoppingKr")]
        public ShoppingData? ShoppingData { get; set; }
    }
}
