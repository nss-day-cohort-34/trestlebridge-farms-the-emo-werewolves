using System;
using System.Collections.Generic;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;

namespace Trestlebridge.Actions
{
    public class ChooseNaturalField
    {
        public static void CollectInput(Farm farm, INatural plant)
        {
            Console.Clear();

            List<IFacility<INatural>> openNaturalFields = new List<IFacility<INatural>>();
            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                if ((farm.NaturalFields[i].Capacity - 1) >=
                farm.NaturalFields[i].CurrentStock())
                {
                    openNaturalFields.Add(farm.NaturalFields[i]);
                    Console.WriteLine($"{i + 1}. Natural Field (Current Stock: {farm.NaturalFields[i].CurrentStock()})");

                    farm.NaturalFields[i].ShowPlantsByType();
                }
            }

            Console.WriteLine();

            if (openNaturalFields.Count > 0)
            {

                Console.WriteLine($"Place the plant where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                if (plant is INatural)
                {
                    farm.NaturalFields[choice - 1].AddResource(plant);
                }
                else
                {
                    // Console.Clear();
                    Console.WriteLine("Please select another facility");
                    for (int i = 0; i < farm.NaturalFields.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Natural Field");
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