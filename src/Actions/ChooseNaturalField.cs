using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;

namespace Trestlebridge.Actions
{
    public class ChooseNaturalField
    {
        static void DisplayBanner ()
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
        public static void CollectInput(Farm farm, INatural plant)
        {
            Console.Clear();

            List<IFacility<INatural>> openNaturalFields = new List<IFacility<INatural>>();

            var sortedNaturalFields = farm.NaturalFields.Where(naturalField => (naturalField.Capacity - 1) >= naturalField.CurrentStock()).ToList();

            for (int i = 0; i < sortedNaturalFields.Count; i++)
            {
                if ((sortedNaturalFields[i].Capacity - 1) >=
                sortedNaturalFields[i].CurrentStock())
                {
                    openNaturalFields.Add(sortedNaturalFields[i]);
                    Console.WriteLine($"{i + 1}. Natural Field (Current Stock: {sortedNaturalFields[i].CurrentStock()})");

                    sortedNaturalFields[i].ShowPlantsByType();
                }
            }

            Console.WriteLine();

            if (sortedNaturalFields.Count > 0)
            {
                Console.WriteLine($"Place the plant where?");
                Console.Write("> ");
                try
                {
                    int choice = Int32.Parse(Console.ReadLine());
                    if (plant is INatural)
                    {
                        try
                        {
                            sortedNaturalFields[choice - 1].AddResource(plant);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Invalid option. Please create a new plant and try again.");
                            Thread.Sleep(2000);
                            DisplayBanner();
                            PurchaseSeed.CollectInput(farm);
                        }

                    }
                    else
                    {
                        Console.WriteLine("There are no matching facilities available. Please create one first.");
                        Thread.Sleep(2000);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid option. Please create a new plant and try again.");
                    Thread.Sleep(2000);
                    DisplayBanner();
                    PurchaseSeed.CollectInput(farm);
                }
            }

            // if (openNaturalFields.Count > 0)
            // {

            //     Console.WriteLine($"Place the plant where?");

            //     Console.Write("> ");
            //     int choice = Int32.Parse(Console.ReadLine());

            //     if (plant is INatural)
            //     {
            //         sortedNaturalFields[choice - 1].AddResource(plant);
            //     }
            //     else
            //     {
            //         // Console.Clear();
            //         Console.WriteLine("Please select another facility");
            //         for (int i = 0; i < farm.NaturalFields.Count; i++)
            //         {
            //             Console.WriteLine($"{i + 1}. Natural Field");
            //         }
            //     }
            // }
            else
            {
                Console.WriteLine("There are no matching facilities available. Please create one first.");
                Thread.Sleep(2000);
            }
            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}