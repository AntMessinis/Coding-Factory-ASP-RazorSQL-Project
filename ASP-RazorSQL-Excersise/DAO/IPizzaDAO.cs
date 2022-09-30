using ASP_RazorSQL_Excersise.Model;

namespace ASP_RazorSQL_Excersise.DAO
{
    public interface IPizzaDAO
    {
        List<Pizza> GetAll();
        void Delete(Pizza pizza);
        void Update(Pizza pizza);
        Pizza Get(long id);
        void Insert(Pizza pizza);
    }
}
