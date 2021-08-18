using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model
{
    public class Account
    {
        public double Balance { get; set; }
        public Card AccountCard { get; set; }
    }
}
