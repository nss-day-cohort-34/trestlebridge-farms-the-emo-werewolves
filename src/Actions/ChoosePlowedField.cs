using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;

namespace Trestlebridge.Actions
{
    public class ChoosePlowedField
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
        public static void CollectInput(Farm farm, IPlowed plant)
        {
            Console.Clear();

            List<IFacility<IPlowed>> openPlowedFields = new List<IFacility<IPlowed>>();

            var sortedPlowedFields = farm.PlowedFields.Where(plowedField => (plowedField.Capacity - 1) >= plowedField.CurrentStock()).ToList();

            for (int i = 0; i < sortedPlowedFields.Count; i++)
            {
                if ((sortedPlowedFields[i].Capacity - 1) >=
                sortedPlowedFields[i].CurrentStock())
                {
                    openPlowedFields.Add(sortedPlowedFields[i]);
                    Console.WriteLine($"{i + 1}. Plowed Field (Current Stock: {sortedPlowedFields[i].CurrentStock()})");

                    sortedPlowedFields[i].ShowPlantsByType();
                }
            }

            Console.WriteLine();

            if (sortedPlowedFields.Count > 0)
            {
                Console.WriteLine($"Place the plant where?");
                Console.Write("> ");
                try
                {
                    int choice = Int32.Parse(Console.ReadLine());
                    if (plant is IPlowed)
                    {
                        try
                        {
                            sortedPlowedFields[choice - 1].AddResource(plant);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("This facility does not exist. Please create a new plant and try again.");
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

            // if (openPlowedFields.Count > 0)
            // {

            //     Console.WriteLine($"Place the plant where?");

            //     Console.Write("> ");
            //     int choice = Int32.Parse(Console.ReadLine());

            //     if (plant is IPlowed)
            //     {
            //         sortedPlowedFields[choice - 1].AddResource(plant);
            //     }
            //     else
            //     {
            //         // Console.Clear();
            //         Console.WriteLine("Please select another facility");
            //         for (int i = 0; i < farm.PlowedFields.Count; i++)
            //         {
            //             Console.WriteLine($"{i + 1}. Plowed Field");
            //         }
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("There are no matching facilities available. Please create one first.");
            //     Thread.Sleep(2000);
            // }
            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}