using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants
{
    public class Wildflower : IResource, INatural
    {
        public string Type { get; } = "Wildflower";

        public void Grow()
        {
            Console.WriteLine("The wildflower plant grew!");
        }

        public override string ToString()
        {
            return $"One row of wildflower plants. Yum!";
        }
    }
}