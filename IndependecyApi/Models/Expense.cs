using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndependecyApi.Models
{
        public class Expense
    {
        [Key]
        public int Expense_id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0,double.MaxValue)]
        [Column(TypeName ="(decimal(18,2))")]
        public decimal Cost { get; set; }

        public DateTime Creation_Date{get ; set;}=DateTime.Now;
        
        public int TypeId { get; set; }

        [ForeignKey("TypeId")]

        public required Type Type {get; set;}

    }
}
