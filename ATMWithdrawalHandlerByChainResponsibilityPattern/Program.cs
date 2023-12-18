using System;
using static System.Console;


namespace ATMWithdrawalHandlerByChainResponsibilityPattern
{
    public class Program
    {
        static void Main(string[] args)
        {
            string result;
            UAH1000Handler uah1000 = new UAH1000Handler();
            UAH500Handler uah500 = new UAH500Handler();
            UAH200Handler uah200 = new UAH200Handler();
            UAH100Handler uah100 = new UAH100Handler();
            UAH50Handler uah50 = new UAH50Handler();
            uah1000.SetSuccessor(uah500);
            uah500.SetSuccessor(uah200);
            uah200.SetSuccessor(uah100);
            uah100.SetSuccessor(uah50);
            while (true)
            {
                Write("Enter the amount you want to withdraw: ");
                if (!int.TryParse(ReadLine(), out int amount))
                {
                    Environment.Exit(0);
                }

                if (amount % 50 != 0)
                {
                    WriteLine("The amount must be a multiple of  50.");
                }
                else

                {
                    result = uah1000.withdraw(amount);
                    WriteLine(result);
                }
            }
        }
    }
    public abstract class MoneyHandler
    {
        protected MoneyHandler successor;
        protected string result;
        public void SetSuccessor(MoneyHandler successor)
        {
            this.successor = successor;
        }
        public abstract string withdraw(int amount);
    }
    public class UAH1000Handler : MoneyHandler
    {
        public override string withdraw(int amount)
        {
            result = null;
            if (amount >= 1000)
            {
                int num = amount / 1000;
                int rest = amount % 1000;
                result = $"Issuing {num} of 1000 uah bill(s)\n";
                if (successor != null && rest != 0)
                {
                    result += successor.withdraw(rest);
                    return result;
                }
                else if (rest == 0)
                {
                    return result;
                }
            }
            else if (successor != null)
            {
                result += successor.withdraw(amount);
                return result;
            }
            return result;
        }
    }
    public class UAH500Handler : MoneyHandler
    {
        public override string withdraw(int amount)
        {
            result = null;
            if (amount >= 500)
            {
                int num = amount / 500;
                int rest = amount % 500;
                result = $"Issuing {num} of 500 uah bill(s)\n";
                if (successor != null && rest != 0)
                {
                    result += successor.withdraw(rest);
                    return result;
                }
                else if (rest == 0) return result;
            }
            else if (successor != null)
            {
                result += successor.withdraw(amount);
                return result;
            }
            return result;

        }
    }
    public class UAH200Handler : MoneyHandler
    {
        public override string withdraw(int amount)
        {
            result = null;
            if (amount >= 200)
            {
                int num = amount / 200;

                int rest = amount % 200;
                result = $"Issuing {num} of 200 uah bill(s)\n";
                if (successor != null && rest != 0)
                {
                    result += successor.withdraw(rest);
                    return result;
                }
                else if (rest == 0) return result;
            }
            else if (successor != null)
            {
                result += successor.withdraw(amount);
                return result;
            }
            return result;
        }
    }
    public class UAH100Handler : MoneyHandler
    {
        public override string withdraw(int amount)
        {
            result = null;
            if (amount >= 100)
            {
                int num = amount / 100;
                int rest = amount % 100;
                result = $"Issuing {num} of 100 uah bill(s)\n";
                if (successor != null && rest != 0)
                {
                    result += successor.withdraw(rest);
                    return result;
                }
                else if (rest == 0) return result;
            }
            else if (successor != null)
            {
                result += successor.withdraw(amount);
                return result;
            }
            return result;
        }
    }
    public class UAH50Handler : MoneyHandler
    {
        public override string withdraw(int amount)
        {
            result = null;
            if (amount >= 50)
            {

                int num = amount / 50;
                int rest = amount % 50;
                result = $"Issuing {num} of 50 uah bill(s)\n";
                if (successor != null && rest != 0)
                {
                    result += successor.withdraw(rest);
                    return result;
                }
                else if (rest == 0) return result;
            }
            else if (successor != null)
            {
                result += successor.withdraw(amount);
                return result;
            }
            return result;
        }
    }
}