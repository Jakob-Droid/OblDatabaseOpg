using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelClient
{
    class Program
    {
        static void Main(string[] args)
        {
            //Insert own data here, to test the Manager
            Facility newFacility = new Facility() { Name = "Gym" };
            ManageFacilities.ReadFacilities();

            ManageFacilities.UpdateFacilityName(1, "Handicap Toilet");
            ManageFacilities.ReadFacilities();
            ManageFacilities.UpdateFacilityName(1, "Swimming Pool");
            ManageFacilities.ReadFacilities();

            //ManageFacilities.CreateFacility(newFacility);
            //ManageFacilities.ReadFacilities();

            //ManageFacilities.DeleteFacility(13);
            //ManageFacilities.ReadFacilities();

            Console.ReadLine();
        }
    }
}
