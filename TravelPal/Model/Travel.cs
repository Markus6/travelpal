using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Model;

public class Travel
{
    public string Destination { get; set; }
    public Countries Country { get; set; }
    public int Travellers { get; set; }
    public Travel(string destination, Countries country, int travellers)
    {
        this.Destination = destination;
        this.Country = country;
        this.Travellers = travellers;
    }

    //Returns destination of the Travel
    virtual public string GetInfo()
    {
        return $"{Destination}";
    }
}
