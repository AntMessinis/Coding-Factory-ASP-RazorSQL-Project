using ASP_RazorSQL_Excersise.DTO;
using ASP_RazorSQL_Excersise.Model;

namespace ASP_RazorSQL_Excersise.Service
{
    public interface IPizzaService
    {
        void AddNewPizza(PizzaDTO dto);
        void UpdatePizza(PizzaDTO dto);
        void DeletePizza(PizzaDTO dto);
        Pizza GetPizza(int id);
        List<Pizza> GetAllPizzas();
    }
}
