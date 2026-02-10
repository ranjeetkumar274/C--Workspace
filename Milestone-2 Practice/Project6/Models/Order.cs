using System.Collections;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Project6.Models
{
    public class Order{
        public int OrderId{get; set;}
        public string CustomerName{get; set;}
        public string OrderDate{get; set;}

        [JsonIgnore]
        public ICollection<MusicRecord> MusicRecords{get; set;} =new List<MusicRecord>();
    }
}