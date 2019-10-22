using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseDuckHouse
    {
        public static void CollectInput(Farm farm, Duck animal)
        {
            Console.Clear();

            List<DuckHouse> openDuckHouses = new List<DuckHouse>();

            List<DuckHouse> sortedHouses = farm.DuckHouse.Where(duckHouse => (duckHouse.Capacity - 1) >= duckHouse.CurrentStock()).ToList();

            for (int i = 0; i < sortedHouses.Count; i++)
            {
                if ((sortedHouses[i].Capacity - 1) >=
                sortedHouses[i].CurrentStock())
                {
                    openDuckHouses.Add(sortedHouses[i]);
                    Console.WriteLine($"{i + 1}. Duck House (Current Stock: {sortedHouses[i].CurrentStock()})");

                    sortedHouses[i].ShowAnimalsByType();
                }
            }

            Console.WriteLine();

            if (openDuckHouses.Count > 0)
            {
                Console.WriteLine($"Place the animal where?");
                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                if (animal is Duck)
                {
                    sortedHouses[choice - 1].AddResource(animal);
                }
                else
                {
                    Console.WriteLine("Please select another facility");
                    for (int i = 0; i < farm.DuckHouse.Count; i++)
                    {
                        Console.WriteLine("This facility does not exist. Please try again.");
                        Thread.Sleep(2000);
                        ChooseDuckHouse.CollectInput(farm, new Duck());
                    }
                }
                // else
                // {
                //     Console.WriteLine("Please select another facility");
                //     for (int i = 0; i < farm.DuckHouse.Count; i++)
                //     {
                //         Console.WriteLine($"{i + 1}. Duck House");
                //     }
                // }
            }
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