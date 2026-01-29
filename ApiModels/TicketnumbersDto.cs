using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices.JavaScript;
using Microsoft.EntityFrameworkCore;

namespace CarStatusAPI.ApiModels
{
    public class Ticketnumber
    {

        public DateTime ChangedDate { get; set; }

        public string Current_Ticketnumber { get; set; }

        public string Prefix { get; set; }

    }
}
