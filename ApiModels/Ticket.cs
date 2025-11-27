using System.ComponentModel.DataAnnotations;

namespace CarStatusAPI.ApiModels
{
    public class Ticket
    {
        public int Ticketnumber { get; set; }

        public string CustomerName { get; set; }

        public string Car { get; set; }

        public string CarStatus { get; set; }

        public List<string> ToDos { get; set; }
    }
}
