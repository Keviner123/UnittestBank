using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model
{
    public class Card
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public int Pin { get; set; }

        public int ExpireMonth { get; set; }
        public int ExpireYear { get; set; }


        public Card(int UserPin)
        {
            Pin = UserPin;
            Id = Guid.NewGuid();
            Number = GenerateCardNumber();

            DateTime localDate = DateTime.Now;

            //Set expire date to three years from now
            localDate.AddYears(3);
            this.ExpireMonth = localDate.Month;
            this.ExpireYear = localDate.Year;


        }

        private string GenerateCardNumber()
        {
            Random rnd = new Random();
            int cardNumber1 = rnd.Next(4572, 4999);
            int cardNumber2 = rnd.Next(1000, 9999);
            int cardNumber3 = rnd.Next(1000, 9999);
            int cardNumber4 = rnd.Next(1000, 9999);

            return (cardNumber1.ToString() + cardNumber2.ToString() + cardNumber3.ToString() + cardNumber3.ToString());
        }

    }
}
