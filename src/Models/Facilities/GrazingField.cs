using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities {
    public class GrazingField : IFacility<IGrazing>
    {
        private int _capacity = 20;
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _animals = new List<IGrazing>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (IGrazing animal)
        {
            _animals.Add(animal);
        }

        public void AddResource (List<IGrazing> animals) 
        {
            foreach (IGrazing animal in animals)
            {
                _animals.Add(animal);
            }
        }

        public int CurrentStock(){
            return _animals.Count;
        }
 
        public void ShowAnimalsByType(){
            var animalTypes = _animals
            .GroupBy(animal => animal.Type)
            .Select(group => 
            {
                return new
                {
                    AnimalType = group.Key,
                    AnimalCount = group.Count()
                };
            });
            foreach (var animal in animalTypes)
            {
                Console.WriteLine($"{animal.AnimalType}: {animal.AnimalCount}");
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._animals.Count} animal(s)\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}