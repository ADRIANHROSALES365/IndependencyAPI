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
        throw new NotImplementedException();
    }

    public bool DeleteExpense(Expense expense)
    {
        throw new NotImplementedException();
    }

    public bool ExpenseExists(string name)
    {
         throw new NotImplementedException();
    }

    public Expense GetExpense(int id)
    {
        throw new NotImplementedException();
    }

    public Expense GetExpense(string name)
    {
        throw new NotImplementedException();
    }

    public ICollection<Expense> GetExpenses()
    {
        throw new NotImplementedException();
    }

    public bool save()
    {
        return _db.SaveChanges()>=0 ? true:false;
    }

    public bool UpdateExpense(Expense expense)
    {
        throw new NotImplementedException();
    }
}