using ASP_RazorSQL_Excersise.DAO;
using ASP_RazorSQL_Excersise.DTO;
using ASP_RazorSQL_Excersise.Model;
using ASP_RazorSQL_Excersise.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_RazorSQL_Excersise.Pages.Pizzas
{
    public class DeleteModel : PageModel
    {
        private readonly IPizzaDAO dao = new PizzaDAOImpl();
        private readonly IPizzaService pizzaService;

        internal PizzaDTO dto = new PizzaDTO();
        public string ErrorMessage = "";

        public DeleteModel()
        {
            pizzaService = new PizzaServiceImpl(dao);
        }
        public void OnGet()
        {
            try
            {
                if (int.TryParse(Request.Query["id"], out int id))
                {
                    dto.Id = id;
                }
                pizzaService.DeletePizza(dto);

                Response.Redirect("/Pizzas");
            }catch(Exception e)
            {
                ErrorMessage = e.Message;
                return;
            }
            
        }
    }
}
