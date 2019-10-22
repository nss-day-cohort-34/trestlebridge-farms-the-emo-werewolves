using System;
using System.Threading;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class PurchaseSeed
    {
        static void DisplayBanner()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine(@"
        +-++-++-++-++-++-++-++-++-++-++-++-++-+
        |T||r||e||s||t||l||e||b||r||i||d||g||e|
        +-++-++-++-++-++-++-++-++-++-++-++-++-+
                    |F||a||r||m||s|
                    +-++-++-++-++-+");
            Console.WriteLine();
        }
        public static void CollectInput(Farm farm)
        {
            Console.WriteLine("1. Sesame");
            Console.WriteLine("2. Sunflower");
            Console.WriteLine("3. Wildflower");

            Console.WriteLine();
            Console.WriteLine("What are you buying today?");

            Console.Write("> ");
            string choice = Console.ReadLine();
            try
            {
                switch (Int32.Parse(choice))
                {
                    case 1:
                        ChoosePlowedField.CollectInput(farm, new Sesame());
                        break;
                    case 2:
                        ChooseSunflowerField<Sunflower>.CollectInput(farm, new Sunflower());
                        break;
                    case 3:
                        ChooseNaturalField.CollectInput(farm, new Wildflower());
                        break;
                    default:
                        Console.WriteLine("Invalid option. Redirecting to main menu.");
                        Thread.Sleep(2000);
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid option. Please try again.");
                Thread.Sleep(2000);
                DisplayBanner();
                PurchaseSeed.CollectInput(farm);
            }
        }
    }
}