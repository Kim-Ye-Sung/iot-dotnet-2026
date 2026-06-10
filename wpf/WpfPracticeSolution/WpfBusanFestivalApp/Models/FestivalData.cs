using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;

namespace WpfBusanFestivalApp.Models
{
    public class FestivalData
    {
        [JsonProperty("item")]
        public ObservableCollection<FestivalItem> Items { get; set; }   


    }
}
