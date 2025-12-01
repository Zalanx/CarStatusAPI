using AutoMapper;
using CarStatusAPI.ApiModels;
using CarStatusAPI.DbModels;
using CarStatusAPI.Interface;
using CarStatusAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace CarStatusAPI.Repository
{
    public class CarStatusRepoHelper(CarStatusDbContext dbContext, IMapper mapper)
    {

        private const int keySize = 24;
        private const int iterations = 240_000;

        public byte[] GenerateSalt()
        {
            return RandomNumberGenerator.GetBytes(keySize);
        }

        public byte[] HashPassword(string password, byte[] salt)
        {
            var hash = new Rfc2898DeriveBytes(password, salt, iterations);
            return hash.GetBytes(keySize);
        }

        public bool CompareHashedPasswords(string loginPassword, string dbPassword, byte[] salt)
        {
            var passwordNewHashed = HashPassword(loginPassword, salt);

            return CryptographicOperations.FixedTimeEquals(passwordNewHashed, Convert.FromBase64String(dbPassword));
        }



        public async Task ResetTicketNumbers()
        {
            string prefix = "WT-";

            var newTicket = new Ticketnumber()
            {
                ChangedDate = DateTime.Now,
                Current_Ticketnumber = $"{prefix}20210",
                Prefix = prefix
            };

            var newDbTicket = mapper.Map<DbTicketnumber>(newTicket);
            dbContext.DbTicketNumbers.Add(newDbTicket);
            await dbContext.SaveChangesAsync();
        }

        public async Task<String> NewTicketNumber()
        {
            var currentDbTicketNumber = await dbContext.DbTicketNumbers.FirstOrDefaultAsync() ?? throw new Exception("No Ticket");
            var currentTicketNumber = mapper.Map<Ticketnumber>(currentDbTicketNumber);

            var oldTicketNumber = currentTicketNumber.Current_Ticketnumber;
            var prefix = currentTicketNumber.Prefix;


            var replacedNumber = oldTicketNumber.Replace(prefix, "");
            int numberParse = int.Parse(replacedNumber);
            int newTicketNumber = numberParse + 1;

            var TicketNumber = $"{prefix}{newTicketNumber}";


            var dbTicketNumbers = await dbContext.DbTicketNumbers.FirstOrDefaultAsync();
            dbTicketNumbers!.Current_Ticketnumber = TicketNumber;
            await dbContext.SaveChangesAsync();

            return TicketNumber;

        }





    }
}
