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
            
            Dictionary<int, IPlantField> plantFieldDictionary = new Dictionary<int, IPlantField>();
            
            for (int i = 0; i < farm.PlowedFields.Count; i++)
            {
                if ((farm.PlowedFields[i].Capacity - 1) >=
                farm.PlowedFields[i].CurrentStock())
                {
                    plantFieldDictionary.Add(i + 1, farm.PlowedFields[i]);
                    Console.WriteLine($"{i + 1}. Plowed Field (Current Stock: {farm.PlowedFields[i].CurrentStock()})");

                    farm.PlowedFields[i].ShowPlantsByType();
                }
            }
            for (int i = 0; i < farm.NaturalFields.Count; i++)
            {
                if ((farm.NaturalFields[i].Capacity - 1) >=
                farm.NaturalFields[i].CurrentStock())
                {
                    plantFieldDictionary.Add(i + farm.PlowedFields.Count + 1, farm.NaturalFields[i]);     
                    Console.WriteLine($"{i + farm.PlowedFields.Count + 1}. Natural Field (Current Stock: {farm.NaturalFields[i].CurrentStock()})");

                    farm.NaturalFields[i].ShowPlantsByType();
                }
            }
            
            Console.WriteLine();

            if (plantFieldDictionary.Count > 0)
            {
                Console.WriteLine($"Place the plant where?");

                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());
                
                // Take user's choice and search for the dictionary key that matches the integer. Return the type of the chosen field. 
                string chosenField = plantFieldDictionary[choice].Type;
                
                if (chosenField == "Plowed Field")
                {
                    farm.PlowedFields[choice - 1].AddResource(plant);
                }
                else if (chosenField == "Natural Field")
                {
                    Console.WriteLine($"Choice: {choice}");
                    Console.WriteLine(farm.PlowedFields.Count);
                    farm.NaturalFields[choice - farm.PlowedFields.Count - 1].AddResource(plant);
                }
                else
                {
                    Console.WriteLine("Please select another facility");
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