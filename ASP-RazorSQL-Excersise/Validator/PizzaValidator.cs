using ASP_RazorSQL_Excersise.DTO;

namespace ASP_RazorSQL_Excersise.Validator
{
    public class PizzaValidator
    {
        private PizzaValidator() { }

        public static string Validate(PizzaDTO dto)
        {
            if ((dto!.ColdCut!.Length == 0) || (dto!.Cheese!.Length == 0) || (dto!.Topping1!.Length == 0) || (dto!.Topping2!.Length == 0))
            {
                return "None of the ingridients fields should be empty";
            }
            return "";
        }
    }
}
