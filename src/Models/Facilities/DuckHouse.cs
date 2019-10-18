using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
using System.Linq;

namespace Trestlebridge.Models.Facilities {
    public class DuckHouse : IFacility<Duck>
    {
        private int _capacity = 12;
        private Guid _id = Guid.NewGuid();

        private List<Duck> _animals = new List<Duck>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (Duck animal)
        {
            _animals.Add(animal);
        }

        public void AddResource (List<Duck> animals) 
        {
            foreach (Duck animal in animals)
            {
                _animals.Add(animal);
            }
        }
        public int CurrentStock(){
            return _animals.Count;
        }

        public void ShowAnimalsByType(){
            if (_animals.Count !=  0)
            {
                Console.WriteLine($"Duck: {_animals.Count()}");
            }
        }
        

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Duck house {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}