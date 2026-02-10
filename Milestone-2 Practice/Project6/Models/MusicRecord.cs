using System.Collections;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace Project6.Models
{
    public class MusicRecord{
    public int MusicRecordId {get; set;}
    public string Artist {get; set;}
    public string Album{get ; set;}
    public string Genre{get; set;}
    public decimal Price{get; set;}
    public int StockQuantity {get ;set;}
    public int? OrderId {get; set;}

    [JsonIgnore]
    public Order? Order{get; set;}
    }
    
}