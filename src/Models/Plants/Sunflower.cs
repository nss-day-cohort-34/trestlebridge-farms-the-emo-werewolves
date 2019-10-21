using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sunflower : IResource, ISeedProducing, IPlowed, INatural
    {
        private int _seedsProduced = 40;
        public string Type { get; } = "Sunflower";

        public void Grow()
        {
            Console.WriteLine("The sunflower plant grew!");
        }

        public double Harvest () {
            return _seedsProduced;
        }

        public override string ToString () {
            return $"One row of sunflower plants. Yum!";
        }
    }
}