using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseChickenCoop
    {
        public static void CollectInput(Farm farm, Chicken animal)
        {
            Console.Clear();

            for (int i = 0; i < farm.ChickenCoop.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Chicken Coop (current stock: {farm.ChickenCoop[i].CurrentStock()})");
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
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

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}