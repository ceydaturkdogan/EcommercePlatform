namespace ECommercePlatform.WebApi.Models
{
    public class AddProductRequest
    {
        public string ProductName {  get; set; }
        public decimal Price { get; set; }

        public int StockQuantity { get; set; }


    }
}
