using IndependecyApi.Models;

namespace IndependecyApi.Repository.IRepository
{
        public interface IExpenseRepository
    {   
        ICollection<Expense> GetExpenses();

        Expense GetExpense(int id);

        Expense GetExpense(string name);

        bool ExpenseExists(string name);

        bool CreateExpense(Expense expense);

        bool UpdateExpense(Expense expense);

        bool DeleteExpense(Expense expense);

        bool save();



    }
}
