using System.ComponentModel.DataAnnotations;

namespace Cellar.Api.Models.Requests.Reception
{
    public class OrderItem
    {
        [Required]
        public string SortimentItemId { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
