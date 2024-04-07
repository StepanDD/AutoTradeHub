using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoTradeHub.Models
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("marks")]
        public int MarkaId { get; set; }
        public Marka? Marka { get; set; }
        [ForeignKey("models")]
        public int ModelId { get; set; }
        public Model? Model { get; set; }
        public int Price { get; set; }
        public double EngineVolume { get; set; }
        public int EnginePower { get; set; }
        public bool SteeringWheel { get; set; }
        public byte Gearbox { get; set; }
        [ForeignKey("colors")]
        public int ColorId { get; set; }
        public Color? Color { get; set; }
        public string? Description { get; set; }
    }
}
