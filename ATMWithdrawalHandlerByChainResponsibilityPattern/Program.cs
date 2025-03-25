using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Console;

namespace EnhancedATMSimulator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Initialize the ATM with denominations and their quantities
            ATM atm;

            if (args.Length > 0)
            {
                // Initialize from command line arguments
                // Format expected: denomination1:quantity1 denomination2:quantity2 ...
                Dictionary<int, int> denominations = new Dictionary<int, int>();

                foreach (var arg in args)
                {
                    string[] parts = arg.Split(':');
                    if (parts.Length == 2 && int.TryParse(parts[0], out int denom) && int.TryParse(parts[1], out int qty))
                    {
                        denominations[denom] = qty;
                    }
                }

                atm = new ATM(denominations);
            }
            else
            {
                // Try to initialize from file if no arguments provided
                try
                {
                    atm = new ATM("atm_config.txt");
                }
                catch (Exception ex)
                {
                    WriteLine($"Error loading ATM configuration: {ex.Message}");
                    WriteLine("Using default configuration instead.");

                    // Default configuration if file loading fails
                    Dictionary<int, int> defaultDenominations = new Dictionary<int, int>
                    {
                        { 1000, 10 },
                        { 500, 10 },
                        { 200, 10 },
                        { 100, 10 },
                        { 50, 10 },
                        { 20, 10 },
                        { 10, 10 }
                    };

                    atm = new ATM(defaultDenominations);
                }
            }

            // Display initial ATM state
            WriteLine("ATM initialized with the following bills:");
            atm.DisplayAvailableCash();
            WriteLine($"Total available: {atm.GetTotalAvailableCash()} UAH");
            WriteLine();

            // Main operation loop
            while (true)
            {
                try
                {
                    Write("Enter the amount you want to withdraw (or 'q' to quit): ");
                    string input = ReadLine();

                    if (input.ToLower() == "q")
                    {
                        break;
                    }

                    if (!int.TryParse(input, out int amount))
                    {
                        WriteLine("Please enter a valid number.");
                        continue;
                    }

                    if (amount <= 0)
                    {
                        WriteLine("Please enter a positive amount.");
                        continue;
                    }

                    // Attempt to withdraw
                    Dictionary<int, int> result = atm.Withdraw(amount);

                    // Display the result
                    WriteLine("\nTransaction successful. Dispensing bills:");
                    foreach (var item in result.OrderByDescending(x => x.Key))
                    {
                        WriteLine($"{item.Value} x {item.Key} UAH");
                    }

                    // Show remaining cash
                    WriteLine("\nRemaining cash in ATM:");
                    atm.DisplayAvailableCash();
                    WriteLine($"Total available: {atm.GetTotalAvailableCash()} UAH");
                    WriteLine();
                }
                catch (Exception ex)
                {
                    WriteLine($"Error: {ex.Message}");
                    WriteLine();

                    if (ex.Message.Contains("insufficient") || ex.Message.Contains("impossible"))
                    {
                        WriteLine("ATM status:");
                        atm.DisplayAvailableCash();
                        WriteLine($"Total available: {atm.GetTotalAvailableCash()} UAH");

                        if (atm.GetTotalAvailableCash() == 0)
                        {
                            WriteLine("ATM is out of cash. Program will now exit.");
                            break;
                        }
                    }
                }
            }

            WriteLine("Thank you for using our ATM. Goodbye!");
        }
    }

    public class ATM
    {
        // Dictionary to store available denominations and their quantities
        private Dictionary<int, int> availableBills;

        // Constructor with direct dictionary initialization
        public ATM(Dictionary<int, int> initialBills)
        {
            // Sort bills in descending order for greedy algorithm
            availableBills = initialBills.OrderByDescending(x => x.Key)
                                         .ToDictionary(x => x.Key, x => x.Value);
        }

        // Constructor to load from file
        public ATM(string configFilePath)
        {
            availableBills = new Dictionary<int, int>();

            string[] lines = File.ReadAllLines(configFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[0], out int denom) && int.TryParse(parts[1], out int qty))
                {
                    availableBills[denom] = qty;
                }
            }

            // Sort bills in descending order
            availableBills = availableBills.OrderByDescending(x => x.Key)
                                          .ToDictionary(x => x.Key, x => x.Value);

            if (availableBills.Count == 0)
            {
                throw new Exception("No valid denomination configurations found in the file.");
            }
        }

        // Get total available cash in the ATM
        public int GetTotalAvailableCash()
        {
            return availableBills.Sum(bill => bill.Key * bill.Value);
        }

        // Display available cash
        public void DisplayAvailableCash()
        {
            foreach (var bill in availableBills.OrderByDescending(x => x.Key))
            {
                WriteLine($"{bill.Value} x {bill.Key} UAH");
            }
        }

        // Main withdraw method using dynamic programming to find optimal solution
        public Dictionary<int, int> Withdraw(int amount)
        {
            // Check if we have enough money
            int totalAvailable = GetTotalAvailableCash();
            if (amount > totalAvailable)
            {
                throw new Exception($"Insufficient funds in ATM. Maximum available: {totalAvailable} UAH");
            }

            // Create a working copy of available bills to manipulate
            Dictionary<int, int> workingBills = new Dictionary<int, int>(availableBills);

            // First try a greedy approach (works best for standard denominations)
            Dictionary<int, int> greedyResult = TryGreedyWithdraw(amount, workingBills);

            if (greedyResult != null)
            {
                // Update available bills
                foreach (var bill in greedyResult)
                {
                    availableBills[bill.Key] -= bill.Value;
                }
                return greedyResult;
            }

            // If greedy fails, try dynamic programming approach
            Dictionary<int, int> dpResult = TryDynamicProgrammingWithdraw(amount);

            if (dpResult != null)
            {
                // Update available bills
                foreach (var bill in dpResult)
                {
                    availableBills[bill.Key] -= bill.Value;
                }
                return dpResult;
            }

            throw new Exception($"It's impossible to dispense exactly {amount} UAH with the available bill denominations.");
        }

        // Try to withdraw using a greedy approach first (usually works for standard denominations)
        private Dictionary<int, int> TryGreedyWithdraw(int amount, Dictionary<int, int> workingBills)
        {
            Dictionary<int, int> result = new Dictionary<int, int>();
            int remainingAmount = amount;

            foreach (var bill in workingBills.OrderByDescending(x => x.Key))
            {
                int denomination = bill.Key;
                int availableCount = bill.Value;

                if (denomination <= remainingAmount && availableCount > 0)
                {
                    int neededCount = Math.Min(remainingAmount / denomination, availableCount);

                    if (neededCount > 0)
                    {
                        result[denomination] = neededCount;
                        remainingAmount -= denomination * neededCount;
                    }
                }
            }

            // If we can't dispense the exact amount, return null
            return remainingAmount == 0 ? result : null;
        }

        // Try to withdraw using dynamic programming approach for better solutions
        private Dictionary<int, int> TryDynamicProgrammingWithdraw(int amount)
        {
            // Initialize DP table
            int[] dp = new int[amount + 1];
            int[] usedDenom = new int[amount + 1];

            // Base case
            dp[0] = 0;

            // Build up the DP table
            for (int i = 1; i <= amount; i++)
            {
                dp[i] = int.MaxValue - 1;
                usedDenom[i] = -1;
            }

            // Create a list of available denominations
            List<int> denoms = new List<int>();
            foreach (var bill in availableBills)
            {
                for (int i = 0; i < bill.Value; i++)
                {
                    denoms.Add(bill.Key);
                }
            }

            // Sort denominations for better efficiency
            denoms.Sort((a, b) => b.CompareTo(a));

            // Fill the DP table
            foreach (int denom in denoms)
            {
                for (int i = amount; i >= denom; i--)
                {
                    if (dp[i - denom] != int.MaxValue - 1 && dp[i - denom] + 1 < dp[i])
                    {
                        dp[i] = dp[i - denom] + 1;
                        usedDenom[i] = denom;
                    }
                }
            }

            // If no solution, return null
            if (dp[amount] == int.MaxValue - 1)
            {
                return null;
            }

            // Reconstruct the solution
            Dictionary<int, int> result = new Dictionary<int, int>();
            int remainingAmount = amount;

            while (remainingAmount > 0)
            {
                int denom = usedDenom[remainingAmount];
                if (!result.ContainsKey(denom))
                {
                    result[denom] = 0;
                }
                result[denom]++;
                remainingAmount -= denom;
            }

            // Verify the solution against available bills
            Dictionary<int, int> tempAvailable = new Dictionary<int, int>(availableBills);
            foreach (var bill in result)
            {
                if (!tempAvailable.ContainsKey(bill.Key) || tempAvailable[bill.Key] < bill.Value)
                {
                    return null; // Solution not valid with current availability
                }
                tempAvailable[bill.Key] -= bill.Value;
            }

            return result;
        }
    }
}