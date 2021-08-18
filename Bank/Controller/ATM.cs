using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Model
{
    public class ATM
    {
        public bool InUse { get; set; }
        public Account CurrentUser { get; set; }

        public bool Access(Account UserAccount, int UserPincode)
        {
            bool Trylogin = UserAccount.AccountCard.Pin == UserPincode;

            if (Trylogin) 
            { 
                InUse = true;
                CurrentUser = UserAccount;
            }

            return (Trylogin);
        }

        public bool AccountHasEnoughMoney(int Amount)
        {
            return (CurrentUser.Balance > Amount);
        }

        public string WithdrawMoney(int Amount)
        {
            if (this.InUse && AccountHasEnoughMoney(Amount)) {
                this.CurrentUser.Balance -= Amount;
                return ("Success");
            }
            return (null);
        }
    }
}
