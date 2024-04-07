using System.ComponentModel.DataAnnotations;

namespace AutoTradeHub.Models
{
    public class Color
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
