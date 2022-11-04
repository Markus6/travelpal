using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
/// Interaction logic for RegisterWindow.xaml
/// </summary>
public partial class RegisterWindow : Window
{
    private MainWindow mainWindow;
    private UserManager userManager;
    public RegisterWindow(MainWindow mainWindow, UserManager userManager)
    {
        InitializeComponent();
        this.mainWindow = mainWindow;
        this.userManager = userManager;

        string[] countries = Enum.GetNames(typeof(Countries));
        cbCountry.ItemsSource = countries;
    }

    private void btnRegister_Click(object sender, RoutedEventArgs e)
    {
        bool success = true;
        User user = new User();
        try
        {
            user.Location = (Countries)Enum.Parse(typeof(Countries), (string)cbCountry.SelectedItem);
        }
        catch (Exception ex)
        {
            MessageBox.Show("You need to select a country!");
            success = false;
        }
        user.Username = txtUsername.Text;
        user.Password = pwdPassword.Password;
        if (success && txtUsername.Text != "" && pwdPassword.Password != "" && pwdConfirmPassword.Password != "")
        {
            if (pwdPassword.Password == pwdConfirmPassword.Password)
            {
                if (!userManager.AddUser(user))
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
        mainWindow.Show();
    }
}
