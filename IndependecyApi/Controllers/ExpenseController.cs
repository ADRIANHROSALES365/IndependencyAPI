using AutoMapper;
using IndependecyApi.Models;
using IndependecyApi.Models.Dtos;
using IndependecyApi.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IndependecyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController: ControllerBase
    {
       
       private readonly IMapper _mapper;
       private readonly IExpenseRepository _repository;

       public ExpenseController(IExpenseRepository repository , IMapper mapper)
        {
            
            _mapper=mapper;
            _repository=repository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]

        public IActionResult CreateExpense([FromBody]CreateExpenseDto expense)
        {
            if(expense==null)
            {
                ModelState.AddModelError("CustomError","There had been an error while trying to create a new expense");
                return BadRequest(ModelState);
            }

            var expense_bd=_mapper.Map<Expense>(expense);

            if(!_repository.CreateExpense(expense_bd))
            {
                 ModelState.AddModelError("CustomError","There had been an error while trying to create a new expense");
                 return BadRequest(ModelState);
            }

            return Created();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        

        public IActionResult GetExpenses()
        {
            var expenses=_repository.GetExpenses();
            if(expenses==null)
            {
                ModelState.AddModelError("CustomError","There are not Expenses in the database");
                return BadRequest(ModelState);
            }

            var expensesList=_mapper.Map<List<ExpenseDto>>(expenses);

            return Ok(expensesList);

        }
        

        
    }


}
