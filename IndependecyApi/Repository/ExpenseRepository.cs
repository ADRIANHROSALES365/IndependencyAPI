using IndependecyApi.Models;
using IndependecyApi.Repository.IRepository;

public class ExpenseRepository : IExpenseRepository
{   
    public readonly ApplicationDbContext _db;
    public ExpenseRepository(ApplicationDbContext dbContext)
    {
        _db=dbContext;
    }
    public bool CreateExpense(Expense expense)
    {
        if(expense==null)
        {
            return false;
        }
        expense.Creation_Date=DateTime.Now;
        _db.Expenses.Add(expense);
        return save();
       
    }

    public bool DeleteExpense(Expense expense)
    {
          if(expense==null)
        {
            return false;
        }

        _db.Expenses.Remove(expense);
        return save();
    }

    public bool ExpenseExists(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return false;
        }

        if(!_db.Expenses.Any(p=> p.Name.ToLower().Trim() == name.ToLower().Trim()))
        {
            return false;
        }

        return true;
            
        
    }

    public Expense? GetExpense(int id)
    {
        if(id<=0)
        {
            return null;
        }

        if(!_db.Expenses.Any(p=> p.Expense_id==id))
        {
            return null;
        }

        Expense? exp= _db.Expenses.FirstOrDefault(p=> p.Expense_id==id);
        return exp;
    }

    public Expense? GetExpense(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return null;
        }

        if(!_db.Expenses.Any(p=>p.Name.ToLower().Trim()==name.ToLower().Trim()))
        {
            return null;
        }

        Expense? exp=_db.Expenses.FirstOrDefault(p=>p.Name.ToLower().Trim()==name.ToLower().Trim());
        return exp;
    }

    public ICollection<Expense> GetExpenses()
    {
        ICollection<Expense> expenses= _db.Expenses.OrderBy(p => p.Name).ToList();

        return expenses;
    }

    public bool save()
    {
        return _db.SaveChanges()>=0 ? true:false;
    }

    public bool UpdateExpense(Expense expense)
    {
        if(expense==null)
        {
            return false;
        }

        _db.Expenses.Update(expense);
        return save();
    }
}