using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;

namespace Trestlebridge.Actions
{
    public class ChooseGrazingField
    {
        public static void CollectInput(Farm farm, IGrazing animal)
        {
            Console.Clear();

            List<IFacility<IGrazing>> openFields = new List<IFacility<IGrazing>>();

            var sortedGrazingFields = farm.GrazingFields.Where(grazingField => (grazingField.Capacity - 1) >= grazingField.CurrentStock()).ToList();

            for (int i = 0; i < sortedGrazingFields.Count; i++)
            {
                if ((sortedGrazingFields[i].Capacity - 1) >=
                sortedGrazingFields[i].CurrentStock())
                {
                    openFields.Add(sortedGrazingFields[i]);
                    Console.WriteLine($"{i + 1}. Grazing Field (Current Stock: {sortedGrazingFields[i].CurrentStock()})");

                    sortedGrazingFields[i].ShowAnimalsByType();
                }
            }

            Console.WriteLine();

            if (openFields.Count > 0)
            {
                Console.WriteLine($"Place the animal where?");
                Console.Write("> ");
                int choice = Int32.Parse(Console.ReadLine());

                if (animal is IGrazing)
                {
                    sortedGrazingFields[choice - 1].AddResource(animal);
                }
                else
                {
                    Console.WriteLine("Please select another facility");
                    for (int i = 0; i < farm.GrazingFields.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Grazing Field");
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