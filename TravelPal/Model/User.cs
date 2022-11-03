using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Enums;
using TravelPal.Managers;

namespace TravelPal.Model;

public class User : IUser
{
    public TravelManager TravelManager { get; set; } = new TravelManager();
    public string Username { get; set; }
    public string Password { get; set; }
    public Countries Location { get; set; }
}
