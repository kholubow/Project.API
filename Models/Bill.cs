namespace Project.API.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Salesman { get; set; }
        public string Buyer { get; set; }
        public string ServiceName { get; set; }
        public float Price { get; set; }
        public string PaymentMethod { get; set; }
    }
}
