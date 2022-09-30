namespace ASP_RazorSQL_Excersise.Model
{
    public class Pizza : IdentifiableEntity
    {
        public int Id { get; set; }
        public string? ColdCut { get; set; }
        public string? Cheese { get; set; }
        public string? Topping1 { get; set; }
        public string? Topping2 { get; set; }
    }
}
