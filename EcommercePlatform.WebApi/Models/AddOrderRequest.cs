
using System.ComponentModel.DataAnnotations;

namespace ECommercePlatform.WebApi.Models
{
    public class AddOrderRequest
    {
        [Required]
        public string OrderName { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }
        public List<int> ProductId { get; set; }
    }
}
