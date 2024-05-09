using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTradeHub.Models
{
    public class Generation
    {
        [Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("models")]
        public int ModelId { get; set; }
        public Model? Model { get; set; }
    }
}
