using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;


namespace Trestlebridge.Models.Facilities {
    public class ChickenCoop : IFacility<Chicken>
    {
        private int _capacity = 50;
        private Guid _id = Guid.NewGuid();

        private List<Chicken> _animals = new List<Chicken>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (Chicken animal)
        {
            _animals.Add(animal);
        }

        public void AddResource (List<Chicken> animals) 
        {
            foreach (Chicken animal in animals)
            {
                _animals.Add(animal);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Chicken coop {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}