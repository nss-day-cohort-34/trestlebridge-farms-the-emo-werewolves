using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Trestlebridge.Interfaces;
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

            for (int i = 0; i < farm.ChickenCoop.Count; i++)
            {
                if ((farm.ChickenCoop[i].Capacity - 1) >=
                farm.ChickenCoop[i].CurrentStock())
                {
                    openChickenCoops.Add(farm.ChickenCoop[i]);
                    Console.WriteLine($"{i + 1}. Chicken Coop (Current Stock: {farm.ChickenCoop[i].CurrentStock()})");

                    farm.ChickenCoop[i].ShowAnimalsByType();
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
                    farm.ChickenCoop[choice - 1].AddResource(animal);
                }
                else
                {
                    // Console.Clear();
                    Console.WriteLine("Please select another facility");
                    for (int i = 0; i < farm.ChickenCoop.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Chicken Coop");
                    }
                }
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