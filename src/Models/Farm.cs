using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Models
{
    public class Farm
    {
        public List<GrazingField> GrazingFields { get; } = new List<GrazingField>();
        public List<PlowedField> PlowedFields { get; } = new List<PlowedField>();
        public List<NaturalField> NaturalFields { get; } = new List<NaturalField>();
        public List<ChickenCoop> ChickenCoop { get; } = new List<ChickenCoop>();
        public List<DuckHouse> DuckHouse { get; } = new List<DuckHouse>();

        /*
            This method must specify the correct product interface of the
            resource being purchased.
         */
        public void PurchaseResource<T> (IResource resource, int index)
        {
            Console.WriteLine(typeof(T).ToString());
            switch (typeof(T).ToString())
            {
                case "Cow":
                    GrazingFields[index].AddResource((IGrazing)resource);
                    break;
                default:
                    break;
            }
        }

        public void AddGrazingField (GrazingField field)
        {
            GrazingFields.Add(field);
            Console.WriteLine("You have added a Grazing Field!");
            Thread.Sleep(1000);
        }

        public void AddPlowedField (PlowedField field)
        {
            PlowedFields.Add(field);
            Console.WriteLine("You have added a Plowed Field!");
            Thread.Sleep(1000);
        }

        public void AddNaturalField (NaturalField field)
        {
            NaturalFields.Add(field);
            Console.WriteLine("You have added a Natural Field!");
            Thread.Sleep(1000);
        }

        public void AddChickenCoop (ChickenCoop coop)
        {
            ChickenCoop.Add(coop);
            Console.WriteLine("You have added a Chicken Coop!");
            Thread.Sleep(1000);
        }
        public void AddDuckHouse (DuckHouse duckHouse)
        {
            DuckHouse.Add(duckHouse);
            Console.WriteLine("You have added a Duck House!");
            Thread.Sleep(1000);
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            GrazingFields.ForEach(gf => report.Append(gf));
            PlowedFields.ForEach(pf => report.Append(pf));
            NaturalFields.ForEach(nf => report.Append(nf));
            ChickenCoop.ForEach(cc => report.Append(cc));
            DuckHouse.ForEach(dh => report.Append(dh));

            return report.ToString();
        }
    }
}