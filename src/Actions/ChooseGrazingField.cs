using System;
using System.Collections.Generic;
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

            for (int i = 0; i < farm.GrazingFields.Count; i++)
            {
                if ((farm.GrazingFields[i].Capacity - 1) >=
                farm.GrazingFields[i].CurrentStock())
                {
                    openFields.Add(farm.GrazingFields[i]);
                    Console.WriteLine($"{i + 1}. Grazing Field (Current Stock: {farm.GrazingFields[i].CurrentStock()})");

                    farm.GrazingFields[i].ShowAnimalsByType();
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
                    try 
                    {
                        sortedGrazingField[choice - 1].AddResource(animal);
                    } catch(ArgumentOutOfRangeException)
                    {
                        Console.WriteLine("This facility does not exist. Please try again.");
                        Thread.Sleep(2000);
                        ChooseChickenCoop.CollectInput(farm, new Chicken());
                    }
                }
                // else
                // {
                //     Console.WriteLine("Please select another facility");
                //     for (int i = 0; i < farm.GrazingFields.Count; i++)
                //     {
                //         Console.WriteLine($"{i + 1}. Grazing Field");
                //     }
                // }
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