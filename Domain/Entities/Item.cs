using System.Globalization;

namespace Domain.Entities;

public class Item : BaseEntity
{
    public string SerialNumber { get; set; }
    public string Description { get; set; }
    
    public string StockGroupNumber { get; set; }
    
    public DateTime PurchaseDate { get; set; }
    public DateTime WarrantyDate { get; set; }
    
    public string Room { get; set; }
    public string Floor { get; set; }
    
    public string Model { get; set; }
    public string Brand { get; set; }
    
    public string Vendor { get; set; }

}