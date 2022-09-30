using ASP_RazorSQL_Excersise.DAO;
using ASP_RazorSQL_Excersise.DTO;
using ASP_RazorSQL_Excersise.Model;

namespace ASP_RazorSQL_Excersise.Service
{
    public class PizzaServiceImpl : IPizzaService
    {
        private readonly IPizzaDAO dao;

        public PizzaServiceImpl(IPizzaDAO dao)
        {
            this.dao = dao;
        }

        public void AddNewPizza(PizzaDTO dto)
        {
            try
            {
                dao.Insert(ExtractFields(dto));
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeletePizza(PizzaDTO dto)
        {
            try
            {
                dao.Delete(ExtractFields(dto));
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Pizza> GetAllPizzas()
        {
            try
            {
                return dao.GetAll();
            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return new List<Pizza>();
            }
        }

        public Pizza GetPizza(int id)
        {
            try
            {
                return dao.Get(id);
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdatePizza(PizzaDTO dto)
        {
            try
            {
                dao.Update(ExtractFields(dto));
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private Pizza ExtractFields(PizzaDTO dto)
        {
            Pizza pizza = new()
            {
                Id = dto.Id,
                ColdCut = dto.ColdCut,
                Cheese = dto.Cheese,
                Topping1 = dto.Topping1,
                Topping2 = dto.Topping2
            };

            return pizza;
        }
    }
}
