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
        static void DisplayBanner ()
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

            if (sortedGrazingFields.Count > 0)
            {
                Console.WriteLine($"Place the animal where?");
                Console.Write("> ");
                try
                {
                    int choice = Int32.Parse(Console.ReadLine());
                    if (animal is IGrazing)
                    {
                        try
                        {
                            sortedGrazingFields[choice - 1].AddResource(animal);
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Invalid option. Please create a new animal and try again.");
                            Thread.Sleep(2000);
                            DisplayBanner();
                            PurchaseLivestock.CollectInput(farm);
                        }

                    }
                    else
                    {
                        Console.WriteLine("There are no matching facilities available. Please create one first.");
                        Thread.Sleep(2000);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid option. Please create a new animal and try again.");
                    Thread.Sleep(2000);
                    DisplayBanner();
                    PurchaseLivestock.CollectInput(farm);
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