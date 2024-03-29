using System;
using System.Threading;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class CreateFacility
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
            Console.WriteLine("1. Grazing field");
            Console.WriteLine("2. Plowed field");
            Console.WriteLine("3. Natural field");
            Console.WriteLine("4. Chicken Coop");
            Console.WriteLine("5. Duck House");

            Console.WriteLine();
            Console.WriteLine("Choose what you want to create");

            Console.Write("> ");
            string input = Console.ReadLine();
            try
            {
                if (int.Parse(input) <= 5 && int.Parse(input) >= 1)
                {
                    switch (Int32.Parse(input))
                    {
                        case 1:
                            farm.AddGrazingField(new GrazingField());
                            break;
                        case 2:
                            farm.AddPlowedField(new PlowedField());
                            break;
                        case 3:
                            farm.AddNaturalField(new NaturalField());
                            break;
                        case 4:
                            farm.AddChickenCoop(new ChickenCoop());
                            break;
                        case 5:
                            farm.AddDuckHouse(new DuckHouse());
                            break;
                        default:
                            Console.WriteLine("Invalid option. Redirecting to main menu.");
                            Thread.Sleep(2000);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option. Please try again.");
                    Thread.Sleep(2000);
                    DisplayBanner();
                    CreateFacility.CollectInput(farm);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid option. Please try again.");
                Thread.Sleep(2000);
                DisplayBanner();
                CreateFacility.CollectInput(farm);
            }
        }
    }
}