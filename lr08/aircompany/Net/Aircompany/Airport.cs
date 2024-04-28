using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes { get; }

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengerPlanes()
        {
            return Planes.OfType<PassengerPlane>().ToList();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return Planes.OfType<MilitaryPlane>().ToList();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPassengerPlanes().OrderByDescending(plane => plane.PassengersCapacity).FirstOrDefault();
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(plane => plane.Type == MilitaryType.TRANSPORT).ToList();
        }

        public void SortByMaxDistance()
        {
            Planes.OrderBy(w => w.MaxFlightDistance);
        }

        public void SortByMaxSpeed()
        {
            Planes.OrderBy(w => w.MaxSpeed);
        }

        public void SortByMaxLoadCapacity()
        {
            Planes.OrderBy(w => w.MaxLoadCapacity);
        }
        public override string ToString()
        {
            return "Airport{" + "planes=" + string.Join(", ", Planes.Select(x => x.Model)) + '}';
        }
    }
}
