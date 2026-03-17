namespace IndependecyApi.Models.Dtos
{
    public class CreateExpenseDto
    {
        public string Name { get; set; } = string.Empty;
       
        public decimal Cost { get; set; }
        
        public int TypeId { get; set; }
        
    }
}