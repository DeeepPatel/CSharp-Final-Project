﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group9Project.Aydin_s_Pages
{
    class BankSystem
    {
        public double Balance { get; protected set; }
        public double OverdraftAmount { get; protected set; }
        public string User { get; set; }
        public BankSystem()
        {
            Balance = 100;
            OverdraftAmount = 0;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public void Withdraw(double amount)
        {

            if (Balance < amount)
            {
                Balance = 0;
                OverdraftAmount -= amount;
            }
            else if (Balance >= amount)
            {
                Balance -= amount;
            }

            if (OverdraftAmount <= -100)
                throw new Exception();

        }

        public void UpdateValues(double balance, double overdraftAmt)
        {
            Balance = balance;
            OverdraftAmount = overdraftAmt;


        }
    }
}
