using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities {
    public class NaturalField : IFacility<INatural>
    {
        // 10 rows of plants. 6 plants per row
        private int _capacity = 60;
        private Guid _id = Guid.NewGuid();

        private List<INatural> _plants = new List<INatural>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (INatural plant)
        {
            _plants.Add(plant);
        }

        public void AddResource (List<INatural> plants) 
        {
            foreach (INatural plant in plants)
            {
                _plants.Add(plant);
            }
        }

        public int CurrentStock(){
            return _plants.Count * 6;
        }
 
        public void ShowPlantsByType(){
            var plantTypes = _plants
            .GroupBy(plant => plant.Type)
            .Select(group => 
            {
                return new
                {
                    PlantType = group.Key,
                    PlantCount = group.Count() * 6
                };
            });
            foreach (var plant in plantTypes)
            {
                Console.WriteLine($"{plant.PlantType}: {plant.PlantCount}");
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Natural field {shortId} has {this._plants.Count} row(s) of 6 plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}