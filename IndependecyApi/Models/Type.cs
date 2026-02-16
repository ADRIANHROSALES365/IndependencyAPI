using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

public class Type
{
 [Key]  
 public int TypeId { get; set; }
 [Required]
 public String Name { get; set; } = string.Empty;
 public DateTime Creation_Date { get; set; }
 public DateTime Update_Date { get; set; }

 
}