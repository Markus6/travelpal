using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Model;

namespace TravelPal.Managers;

public class UserManager
{
    public List<IUser> Users { get; set; }
    public IUser SignedInUser { get; set; }

    public bool AddUser(IUser userToAdd)
    {
        return false;
    }
    public void RemoveUser(IUser userToRemove)
    {

    }
    public bool UpdateUsername(IUser userToUpdate, string username)
    {
        return false;
    }
    private bool validateUsername(string username)
    {
        return false;
    }
    public bool SignInUser(string username, string password)
    {
        return false;
    }
}
