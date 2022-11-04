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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TravelPal.Managers;
using TravelPal.Model;

namespace TravelPal;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private UserManager userManager = new();
    public MainWindow()
    {
        InitializeComponent();
        Admin admin = new Admin()
        {
            Username = "admin",
            Password = "password",
            Location = Enums.Countries.Sweden
        };
        userManager.AddUser(admin);
        User user = new User()
        {
            Username = "Gandalf",
            Password = "password",
            Location = Enums.Countries.United_Kingdom
        };
        Trip travel1 = new Trip(Enums.TripTypes.Work,"New York", Enums.Countries.United_States, 1);
        user.TravelManager.AddTravel(travel1);
        Vacation travel2 = new Vacation(true, "Copenhagen", Enums.Countries.Denmark, 3);
        user.TravelManager.AddTravel(travel2);
        userManager.AddUser(user);
    }

    private void btnRegister_Click(object sender, RoutedEventArgs e)
    {
        Hide();
        RegisterWindow registerWindow = new RegisterWindow(this, userManager);
        registerWindow.Show();
    }

    private void btnSignIn_Click(object sender, RoutedEventArgs e)
    {
        if (userManager.SignInUser(txtUsername.Text, pwdPassword.Password))
        {
            Hide();
            TravelsWindow travelsWindow = new TravelsWindow(this, userManager);
            travelsWindow.Show();
        }
        else
        {
            MessageBox.Show("Wrong username or password!");
        }
    }
}
