using System.Collections.Generic;

namespace Trestlebridge.Interfaces
{
    public interface IFacility<T>
    {
        double Capacity { get; }

        void AddResource (T resource);
        void AddResource (List<T> resources);
    }
}