using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;

namespace Trestlebridge.Actions
{
    public class ChooseSunflowerField<TPlantType> where TPlantType : IPlowed, INatural
    {
        static void DisplayBanner()
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
        public static void CollectInput(Farm farm, TPlantType plant)
        {
            Console.Clear();

            Dictionary<int, IPlantField> plantFieldDictionary = new Dictionary<int, IPlantField>();

            var sortedPlowedFields = farm.PlowedFields.Where(plowedField => (plowedField.Capacity - 1) >= plowedField.CurrentStock()).ToList();
            var sortedNaturalFields = farm.NaturalFields.Where(naturalField => (naturalField.Capacity - 1) >= naturalField.CurrentStock()).ToList();

            for (int i = 0; i < sortedPlowedFields.Count; i++)
            {
                if ((sortedPlowedFields[i].Capacity - 1) >=
                sortedPlowedFields[i].CurrentStock())
                {
                    plantFieldDictionary.Add(i + 1, sortedPlowedFields[i]);
                    Console.WriteLine($"{i + 1}. Plowed Field (Current Stock: {sortedPlowedFields[i].CurrentStock()})");

                    sortedPlowedFields[i].ShowPlantsByType();
                }
            }
            for (int i = 0; i < sortedNaturalFields.Count; i++)
            {
                if ((sortedNaturalFields[i].Capacity - 1) >=
                sortedNaturalFields[i].CurrentStock())
                {
                    plantFieldDictionary.Add(i + sortedPlowedFields.Count + 1, sortedNaturalFields[i]);
                    Console.WriteLine($"{i + sortedPlowedFields.Count + 1}. Natural Field (Current Stock: {sortedNaturalFields[i].CurrentStock()})");

                    sortedNaturalFields[i].ShowPlantsByType();
                }
            }

            Console.WriteLine();

            if (plantFieldDictionary.Count > 0)
            {
                Console.WriteLine($"Place the plant where?");

                Console.Write("> ");
                try
                {
                    int choice = Int32.Parse(Console.ReadLine());
                    // Take user's choice and search for the dictionary key that matches the integer. Return the type of the chosen field. 
                    string chosenField = plantFieldDictionary[choice].Type;

                    if (chosenField == "Plowed Field")
                    {
                        try
                        {
                            sortedPlowedFields[choice - 1].AddResource(plant);
                        }
                        catch (KeyNotFoundException)
                        {
                            Console.WriteLine("Invalid option. Please create a new plant and try again.");
                            Thread.Sleep(2000);
                            DisplayBanner();
                            PurchaseSeed.CollectInput(farm);
                        }
                    }
                    else if (chosenField == "Natural Field")
                    {
                        try
                        {
                            sortedNaturalFields[choice - sortedPlowedFields.Count - 1].AddResource(plant);
                        }
                        catch (KeyNotFoundException)
                        {
                            Console.WriteLine("Invalid option. Please create a new plant and try again.");
                            Thread.Sleep(2000);
                            DisplayBanner();
                            PurchaseSeed.CollectInput(farm);
                        }
                    }
                    else
                    {

                        Console.WriteLine("Please select another facility");
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
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid option. Please create a new plant and try again.");
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

        /*
            Couldn't get this to work. Can you?
            Stretch goal. Only if the app is fully functional.
         */
        // farm.PurchaseResource<IGrazing>(animal, choice);

    }
}
