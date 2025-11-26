namespace CarStatusAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public string CustomerName { get; set; }
        public string Car {  get; set; }
        public string CarStatus { get; set; }
        public List<string> ToDos { get; set; }
    }
}
