using ASP_RazorSQL_Excersise.DAO;
using ASP_RazorSQL_Excersise.Model;
using ASP_RazorSQL_Excersise.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_RazorSQL_Excersise.Pages.Pizzas
{
    public class IndexModel : PageModel
    {
        private readonly IPizzaDAO dao = new PizzaDAOImpl();
        private readonly IPizzaService pizzaService;

        public List<Pizza> Pizzas { get; set; } = new();

        public IndexModel()
        {
            pizzaService = new PizzaServiceImpl(dao);
        }

        public void OnGet()
        {
            try
            {
                Pizzas = pizzaService.GetAllPizzas();
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
