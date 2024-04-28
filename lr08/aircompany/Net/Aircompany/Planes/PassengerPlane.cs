using System;

namespace Aircompany.Planes
{
    public class PassengerPlane : Plane
    {
        public int PassengersCapacity { get; }
        public PassengerPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, int passengersCapacity)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            PassengersCapacity = passengersCapacity;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PassengerPlane plane))
            return false;
            return base.Equals(obj) && PassengersCapacity == plane.PassengersCapacity;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() + PassengersCapacity.GetHashCode();
        }

        public override string ToString()
        {
            return $"{base.ToString()}, passengersCapacity={PassengersCapacity}";
        }

    }
}