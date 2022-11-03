using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;

namespace TravelPal.Model;

public class Vacation : Travel
{
    public bool AllInclusive { get; set; }
    public Vacation(bool allInclusive, string destination, Countries country, int travellers) : base(destination, country, travellers)
    {
        this.AllInclusive = allInclusive;
    }
    override public string GetInfo()
    {
        return $"{base.Destination}";
    }
}
