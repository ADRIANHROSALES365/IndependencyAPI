using System.ComponentModel.DataAnnotations;

public class CreateTypeDto
{
    [Required(ErrorMessage =" Name is required")]
    [MaxLength(30,ErrorMessage = "Name cant be longer than 30 characters")]
    [MinLength(5,ErrorMessage ="Name can not be shorter than 5 Characters")]

    public string Name { get; set; }= string.Empty;





}