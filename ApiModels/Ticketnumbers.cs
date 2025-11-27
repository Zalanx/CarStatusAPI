using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;

namespace CarStatusAPI.ApiModels
{
    public class Ticketnumbers
    {

        public DateTime ChangedDate { get; set; }

        public string Current_Ticketnumber { get; set; }

        public string Prefix { get; set; }

    }
}
