using ASP_RazorSQL_Excersise.DAO;
using ASP_RazorSQL_Excersise.DTO;
using ASP_RazorSQL_Excersise.Service;
using ASP_RazorSQL_Excersise.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_RazorSQL_Excersise.Pages.Pizzas
{
    public class CreateModel : PageModel
    {
        private readonly IPizzaDAO dao = new PizzaDAOImpl();
        private readonly IPizzaService pizzaService;

        public string? ErrorMessage { get; set; } = null;
        public string? SuccessMessage { get; set; } = null;

        internal PizzaDTO dto = new PizzaDTO();

        public CreateModel()
        {
            pizzaService = new PizzaServiceImpl(dao);
        }

        public void OnGet()
        {
        }

        public void OnPost()
        {
            ErrorMessage = "";

            // Get DTO
            dto.ColdCut = Request.Form["coldCut"];
            dto.Cheese = Request.Form["cheese"];
            dto.Topping1 = Request.Form["topping1"];
            dto.Topping2 = Request.Form["topping2"];

            // Validate DTO
            ErrorMessage = PizzaValidator.Validate(dto);

            // If error, return
            if (!ErrorMessage.Equals("")) return;

            // Insert new Pizza

            try 
            {
                pizzaService.AddNewPizza(dto);

                // On Success
                Response.Redirect("/Pizzas");
            }catch(Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }
    }
}
