using BankAccount.Services;
using System;

namespace ConsoleClient
{
    internal class Program
    {
        private static double Amount;
        private static double Rate;
        private static int Duration;
        private static readonly AccountService accountService = new AccountService();
        static void Main(string[] args)
        {
            Console.WriteLine("Credit Simulation Application");
            Console.WriteLine("-----------------------------");

            AskForAmountInput();

            AskForRateInput();

            AskForDurationInput();
            
            
            var MonthlyPaiement = accountService.CalculateMonthlyPayment(Amount, Rate, Duration);
            
            Console.WriteLine("-----------------------------------");
            Console.WriteLine($"The result is : {MonthlyPaiement : 0.00} DHS");

        }

        public static void AskForAmountInput()
        {
            try
            {
                Console.WriteLine($"Please insert the Amount (DHS) :");
                Amount = Math.Abs(double.Parse(Console.ReadLine()));
                
            }catch(FormatException){
                Console.WriteLine("the amount value is incorrect");
                AskForAmountInput();
            }
            
        }

        public static void AskForRateInput()
        {
            try
            {
                Console.WriteLine($"Please insert the rate (%) :");
                Rate = double.Parse(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine("the rate value is incorrect");
                AskForRateInput();
            }


        }

        public static void AskForDurationInput()
        {
            try
            {
                Console.WriteLine($"Please insert the duration (months) :");
                Duration = int.Parse(Console.ReadLine());

            }
            catch (FormatException)
            {
                Console.WriteLine("the duration value is incorrect");
                AskForDurationInput();
            }


        }
    }
}
