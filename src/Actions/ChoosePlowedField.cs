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
    public class ChoosePlowedField
    {
        public static void CollectInput(Farm farm, IPlowed plant)
        {
            Console.Clear();

            List<IFacility<IPlowed>> openPlowedFields = new List<IFacility<IPlowed>>();
            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                if ((farm.PlowedFields[i].Capacity - 1) >=
                farm.PlowedFields[i].CurrentStock())
                {
                    openPlowedFields.Add(farm.PlowedFields[i]);
                    Console.WriteLine($"{i + 1}. Plowed Field (Current Stock: {farm.PlowedFields[i].CurrentStock()})");

                    farm.PlowedFields[i].ShowPlantsByType();
                }
            }

            Console.WriteLine();

            if (openPlowedFields.Count > 0)
            {

                Console.WriteLine($"Place the plant where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                if (plant is IPlowed)
                {
                    farm.PlowedFields[choice - 1].AddResource(plant);
                }
                else
                {
                    // Console.Clear();
                    Console.WriteLine("Please select another facility");
                    for (int i = 0; i < farm.PlowedFields.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Plowed Field");
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