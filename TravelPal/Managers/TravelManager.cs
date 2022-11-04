using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Model;

namespace TravelPal.Managers;

public class TravelManager
{
    public List<Travel> Travels { get; set; } = new List<Travel>();

    //Adds a travel to the Travels list
    public void AddTravel(Travel travelToAdd)
    {
        Travels.Add(travelToAdd);
    }

    //Removes a travel from the Travels list
    public void RemoveTravel(Travel travelToDelete)
    {
        Travels.Remove(travelToDelete);
    }
}
