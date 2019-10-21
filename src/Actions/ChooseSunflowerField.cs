using System;
using System.Collections.Generic;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;

namespace Trestlebridge.Actions
{
    public class ChooseSunflowerField<TPlantType> where TPlantType : IPlowed, INatural
    {
        public static void CollectInput(Farm farm, TPlantType plant)
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
            List<IFacility<INatural>> openNaturalFields = new List<IFacility<INatural>>();
            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                if ((farm.NaturalFields[i].Capacity - 1) >=
                farm.NaturalFields[i].CurrentStock())
                {
                    openNaturalFields.Add(farm.NaturalFields[i]);
                    Console.WriteLine($"{i + farm.PlowedFields.Count + 1}. Natural Field (Current Stock: {farm.NaturalFields[i].CurrentStock()})");

                    farm.NaturalFields[i].ShowPlantsByType();
                }
            }
            
            Console.WriteLine();

            if (openPlowedFields.Count > 0 || openNaturalFields.Count > 0)
            {

                Console.WriteLine($"Place the plant where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());
                
                // If statement below needs to match the number of the user's choice with the type of field because the plant will always be both IPlowed and INatural
                if (plant is IPlowed)
                {
                    farm.PlowedFields[choice - 1].AddResource(plant);
                }
                else if (plant is INatural)
                {
                    Console.WriteLine($"Choice: {choice}");
                    Console.WriteLine(farm.PlowedFields.Count);
                    farm.NaturalFields[choice - farm.PlowedFields.Count - 1].AddResource(plant);
                }
                else
                {
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