using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TravelPal.Enums;
using TravelPal.Managers;
using TravelPal.Model;

namespace TravelPal;

/// <summary>
/// Interaction logic for UserDetailsWindow.xaml
/// </summary>
public partial class UserDetailsWindow : Window
{
    private TravelsWindow travelsWindow;
    private UserManager userManager;
    public UserDetailsWindow(TravelsWindow travelsWindow, UserManager userManager)
    {
        InitializeComponent();
        this.travelsWindow = travelsWindow;
        this.userManager = userManager;

        string[] countries = Enum.GetNames(typeof(Countries));
        cbCountry.ItemsSource = countries;
    }

    //If the user enters correct inputs the signed in user will update with the new inputs
    private void btnSave_Click(object sender, RoutedEventArgs e)
    {
        bool success = true;
        User currentUser = (User)userManager.SignedInUser;
        Countries country;
        try
        {
            country = (Countries)Enum.Parse(typeof(Countries), (string)cbCountry.SelectedItem);
        }
        catch (Exception ex)
        {
            MessageBox.Show("You need to select a country!");
            success = false;
        }
        if (success && txtUsername.Text != "" && pwdPassword.Password != "" && pwdConfirmPassword.Password != "")
        {
            if (pwdPassword.Password == pwdConfirmPassword.Password)
            {
                if (userManager.UpdateUsername(currentUser, txtUsername.Text))
                {
                    currentUser.Password = pwdPassword.Password;
                }
                else
                {
                    MessageBox.Show("Username already exists!");
                }
            }
            else
            {
                MessageBox.Show("Password and confirm password are not matching!");
            }
        }
        else
        {
            MessageBox.Show("Invalid input!");
        }
        Close();
        travelsWindow.UpdateUsernameLabel(userManager.SignedInUser.Username);
        travelsWindow.Show();
    }

    //Closes the user details window and opens the travels window
    private void btnCancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
        travelsWindow.Show();
    }
}
