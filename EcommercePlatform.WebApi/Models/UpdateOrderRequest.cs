using System.ComponentModel.DataAnnotations;

namespace ECommercePlatform.WebApi.Models
{
    public class UpdateOrderRequest
    {
        [Required]
        public string OrderName { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public decimal TotalAmount { get; set; }
        [Required]
        public List<int> ProductIds { get; set; }
    }
}
