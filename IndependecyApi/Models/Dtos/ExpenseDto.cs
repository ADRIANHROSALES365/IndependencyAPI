    public class ExpenseDto
{
        public int Expense_id { get; set; }

        public string Name { get; set; } = string.Empty;
        
        public decimal Cost { get; set; }

        public DateTime Creation_Date{get ; set;}=DateTime.Now;
        
        public int TypeId { get; set; }

}