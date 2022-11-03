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
using TravelPal.Model;

namespace TravelPal;

/// <summary>
/// Interaction logic for AddTravelWindow.xaml
/// </summary>
public partial class AddTravelWindow : Window
{
    private TravelsWindow travelsWindow;
    private UserManager userManager;
    private TravelManager travelManager;
    public AddTravelWindow(TravelsWindow travelsWindow, UserManager userManager)
    {
        InitializeComponent();
        this.travelsWindow = travelsWindow;
        this.userManager = userManager;
        travelManager = ((User)userManager.SignedInUser).TravelManager;
    }
}
