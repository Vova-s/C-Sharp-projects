using System;
using static System.Console;

namespace ConsumerDataProcessor
{
    struct consumers
    {
        private byte ID;
        private string Surname;
        private string Name;
        private string last_name;
        private DateTime date_credit;
        private double sum_loan;
        public consumers(byte ID, string Surname, string Name, string last_name, DateTime date_credit, double sum_loan)
        {
            this.ID = ID;
            this.Surname = Surname;
            this.Name = Name;
            this.last_name = last_name;
            this.date_credit = date_credit;
            this.sum_loan = sum_loan;

        }

        public byte getID() => ID;
        public string getSurname() => Surname;
        public string getName() => Name;
        public string getlast_name() => last_name;
        public DateTime get_date_credit() => date_credit;
        public double get_sum_loan() => sum_loan;

        public void printconsumers()
        {
            Write($"{ID,3},");
            Write($"{Surname,5},");
            Write($"{Name,5},");
            Write($"{last_name,5},");
            Write($"{date_credit,5}.");
            Write($"{sum_loan,5}.");
        }
    }
}