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
using TravelPal.Managers;

namespace TravelPal;

/// <summary>
/// Interaction logic for TravelsWindow.xaml
/// </summary>
public partial class TravelsWindow : Window
{
    private MainWindow mainWindow;
    private UserManager userManager;
    public TravelsWindow(MainWindow mainWindow, UserManager userManager)
    {
        InitializeComponent();
        lblUser.Content = userManager.SignedInUser.Username;
        this.mainWindow = mainWindow;
        this.userManager = userManager;
    }

    private void btnUser_Click(object sender, RoutedEventArgs e)
    {
        Hide();
        UserDetailsWindow userDetailsWindow = new UserDetailsWindow(this,userManager);
        userDetailsWindow.Show();
    }

    private void btnAddTravel_Click(object sender, RoutedEventArgs e)
    {
        Hide();
        AddTravelWindow addTravelWindow = new AddTravelWindow(this, UserManager);
        addTravelWindow.Show();
    }
}
