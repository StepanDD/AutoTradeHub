using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTradeHub.Models
{
    public class Model
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("marks")]
        public int MarkaId { get; set; }
        public Marka? Marka { get; set; }
    }
}
