using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class ChooseChickenCoop
    {
        public static void CollectInput(Farm farm, Chicken animal)
        {
            Console.Clear();

            List<ChickenCoop> openChickenCoops = new List<ChickenCoop>();

            List<ChickenCoop> sortedCoops = farm.ChickenCoop.Where(coop => (coop.Capacity - 1) >= coop.CurrentStock()).ToList();
            
            for (int i = 0; i < sortedCoops.Count; i++)
            {
                if ((sortedCoops[i].Capacity - 1) >=
                sortedCoops[i].CurrentStock())
                {
                    openChickenCoops.Add(sortedCoops[i]);
                    Console.WriteLine($"{i + 1}. Chicken Coop (Current Stock: {sortedCoops[i].CurrentStock()})");

                    sortedCoops[i].ShowAnimalsByType();
                }
            }

            Console.WriteLine();

            if (openChickenCoops.Count > 0)
            {

                Console.WriteLine($"Place the animal where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                if (animal is Chicken)
                {
                    sortedCoops[choice - 1].AddResource(animal);
                }
                else
                {
                    // Console.Clear();
                    Console.WriteLine("Please select another facility");
                    for (int i = 0; i < farm.ChickenCoop.Count; i++)
                    {
                        Console.WriteLine("This facility does not exist. Please try again.");
                        Thread.Sleep(2000);
                        ChooseChickenCoop.CollectInput(farm, new Chicken());
                    }
                }
                // else
                // {
                //     // Console.Clear();
                //     Console.WriteLine("Please select another facility");
                //     for (int i = 0; i < farm.ChickenCoop.Count; i++)
                //     {
                //         Console.WriteLine($"{i + 1}. Chicken Coop");
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