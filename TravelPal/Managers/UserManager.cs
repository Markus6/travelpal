using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelPal.Model;

namespace TravelPal.Managers;

public class UserManager
{
    public List<IUser> Users { get; set; } = new List<IUser>();
    public IUser SignedInUser { get; set; }

    public bool AddUser(IUser userToAdd)
    {
        if (validateUsername(userToAdd.Username))
        {
            Users.Add(userToAdd);
            return true;
        }
        else
        {
            return false;
        }
        
    }
    public void RemoveUser(IUser userToRemove)
    {

    }
    public bool UpdateUsername(IUser userToUpdate, string newUsername)
    {
        if (validateUsername(newUsername))
        {
            userToUpdate.Username = newUsername;
            return true;
        }
        else
        {
            return false;
        }
    }
    private bool validateUsername(string username)
    {
        foreach (IUser user in Users)
        {
            if (username == user.Username)
            {
                return false;
            }
        }
        return true;
    }
    public bool SignInUser(string username, string password)
    {
        foreach (IUser user in Users)
        {
            if (user.Username==username&&user.Password==password)
            {
                SignedInUser = user;
                return true;
            }
        }
        return false;
    }
}
