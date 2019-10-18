using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities {
    public class PlowedField : IFacility<IPlowed>
    {
        private int _capacity = 20;
        private Guid _id = Guid.NewGuid();

        private List<IPlowed> _plants = new List<IPlowed>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (IPlowed plant)
        {
            _plants.Add(plant);
        }

        public void AddResource (List<IPlowed> plants) 
        {
            foreach (IPlowed plant in plants)
            {
                _plants.Add(plant);
            }
        }

        public int CurrentStock(){
            return _plants.Count;
        }
 
        public void ShowPlantByType(){
            var plantTypes = _plants
            .GroupBy(plant => plant.Type)
            .Select(group => 
            {
                return new
                {
                    PlantType = group.Key,
                    PlantCount = group.Count()
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

            output.Append($"Plowed field {shortId} has {this._plants.Count} plants\n");
            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }
    }
}