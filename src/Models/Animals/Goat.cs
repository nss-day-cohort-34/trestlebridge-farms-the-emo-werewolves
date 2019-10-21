using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Animals {
    public class Goat : IResource, IGrazing {

        private Guid _id = Guid.NewGuid();
        private string _shortId {
            get {
                return this._id.ToString().Substring(this._id.ToString().Length - 6);
            }
        }

        public double GrassPerDay { get; set; } = 5.4;
        public string Type { get; } = "Goat";

        // Methods
        public void Graze () {
            Console.WriteLine($"Goat {this._shortId} just ate {this.GrassPerDay}kg of grass");
        }

        public override string ToString () {
            return $"Goat {this._shortId}. I am a goat!";
        }
    }
}