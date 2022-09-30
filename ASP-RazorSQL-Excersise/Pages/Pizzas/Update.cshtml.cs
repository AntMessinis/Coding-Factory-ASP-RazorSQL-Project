using ASP_RazorSQL_Excersise.DAO;
using ASP_RazorSQL_Excersise.DTO;
using ASP_RazorSQL_Excersise.Model;
using ASP_RazorSQL_Excersise.Service;
using ASP_RazorSQL_Excersise.Validator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_RazorSQL_Excersise.Pages.Pizzas
{
    public class UpdateModel : PageModel
    {
        private readonly IPizzaDAO pizzaDAO = new PizzaDAOImpl();
        private readonly IPizzaService? pizzaService;

        internal PizzaDTO pizzaDto = new PizzaDTO();
        public string ErrorMessage = "";
        public UpdateModel()
        {
            pizzaService = new PizzaServiceImpl(pizzaDAO);
        }
        public void OnGet()
        {
            try
            {
                Pizza? pizza;

                if (int.TryParse(Request.Query["id"], out int id))
                {
                    pizza = pizzaService!.GetPizza(id);
                    pizzaDto = ConvertToDTO(pizza);
                }
            }catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        public void OnPost()
        {
           
            // Get DTO
            if (int.TryParse(Request.Form["pizzaId"], out int id))
            {
                pizzaDto.Id = id;
            }
            pizzaDto.ColdCut = Request.Form["coldCut"];
            pizzaDto.Cheese = Request.Form["cheese"];
            pizzaDto.Topping1 = Request.Form["topping1"];
            pizzaDto.Topping2 = Request.Form["topping2"];

            // Validate DTO
            ErrorMessage = PizzaValidator.Validate(pizzaDto);

            // If Error return
            if (!ErrorMessage.Equals("")) return;

            // Update pizza

            try 
            {
                pizzaService!.UpdatePizza(pizzaDto);
                // On Success
                Response.Redirect("/Pizzas");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
        }

        private PizzaDTO ConvertToDTO(Pizza pizza)
        {
            return new PizzaDTO()
            {
                Id = pizza.Id,
                ColdCut = pizza.ColdCut,
                Cheese = pizza.Cheese,
                Topping1 = pizza.Topping1,
                Topping2 = pizza.Topping2
            };
        }
    }
}
