using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseDuckHouse
    {
        public static void CollectInput(Farm farm, Duck animal)
        {
            Console.Clear();

            for (int i = 0; i < farm.DuckHouse.Count; i++)
            {
                if ((farm.DuckHouse[i].Capacity - 1) >= 
                farm.DuckHouse[i].CurrentStock()) 
                {
                    Console.WriteLine($"{i + 1}. Duck House (Current Stock: {farm.DuckHouse[i].CurrentStock()})");

                    farm.DuckHouse[i].ShowAnimalsByType();
                }
            }

            Console.WriteLine();

            // How can I output the type of animal chosen here?
            Console.WriteLine($"Place the animal where?");

            Console.Write("> ");
            int choice = Int32.Parse(Console.ReadLine());

            if (animal is Duck)
            {
                farm.DuckHouse[choice - 1].AddResource(animal);
            }
            else
            {
                // Console.Clear();
                Console.WriteLine("Please select another facility");
                for (int i = 0; i < farm.DuckHouse.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. Duck House");
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