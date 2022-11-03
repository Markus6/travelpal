using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Model;

public class Trip : Travel
{
    public TripTypes type { get; set; }

    public Trip(TripTypes type, string destination, Countries country, int travellers) : base(destination, country, travellers)
    {
        this.type = type;
    }

    public string GetInfo()
    {
        return "";
    }
}
