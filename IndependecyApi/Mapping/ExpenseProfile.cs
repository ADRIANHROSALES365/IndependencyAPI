using AutoMapper;
using IndependecyApi.Models;
using IndependecyApi.Models.Dtos;

namespace IndependecyApi.Mapping
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<Expense,ExpenseDto>().ReverseMap();
            CreateMap<Expense,CreateExpenseDto>().ReverseMap();
        }
    }
}