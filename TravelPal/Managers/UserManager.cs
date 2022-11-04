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

    //Adds a user to the Users list
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

    //Updates the username of a specified user
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

    //Checks if a username already exists in Users list
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

    //Checks if username and password matches a user in the User list. If it finds a user it makes the found user the signed in user
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
