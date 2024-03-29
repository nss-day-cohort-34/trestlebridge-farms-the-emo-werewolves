using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Sesame : IResource, ISeedProducing, IPlowed
    {
        private int _seedsProduced = 520;
        public string Type { get; } = "Sesame";

        public void Grow()
        {
            Console.WriteLine("The sesame plant grew!");
        }

        public double Harvest () {
            return _seedsProduced;
        }

        public override string ToString () {
            return $"One row of sesame plants. Yum!";
        }
    }
}