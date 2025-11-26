namespace CarStatusAPI.ApiModels
{
    public class Ticket
    {
        public string CustomerName { get; set; }
        public string Car { get; set; }
        public string CarStatus { get; set; }
        public List<string> ToDos { get; set; }
    }
}
