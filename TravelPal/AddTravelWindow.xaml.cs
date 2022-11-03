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


        string[] countries = Enum.GetNames(typeof(Countries));
        cbCountry.ItemsSource = countries;

        string[] travelTypes = new string[] {"Trip", "Vacation"};
        cbTravelType.ItemsSource = travelTypes;
    }

    private void btnAdd_Click(object sender, RoutedEventArgs e)
    {
        string type;
        if (cbTravelType.SelectedItem == "Trip")
        {
            try
            {
                Countries country = (Countries)Enum.Parse(typeof(Countries), (string)cbCountry.SelectedItem);
                TripTypes tripType = (TripTypes)Enum.Parse(typeof(TripTypes), (string)cbTripVacationType.SelectedItem);
                Trip trip = new Trip(tripType, txtDestination.Text, country, Convert.ToInt32(txtTravellers.Text));
                travelManager.AddTravel(trip);
                ListViewItem item = new();
                item.Content = trip.GetInfo();
                item.Tag = trip;
                travelsWindow.addListViewItem(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Input!");
            }
        }
        else if(cbTravelType.SelectedItem == "Vacation")
        {
            try
            {
                bool allInclusive = false;
                if (cbTripVacationType.SelectedItem == "yes")
                {
                    allInclusive = true;
                }
                Countries country = (Countries)Enum.Parse(typeof(Countries), (string)cbCountry.SelectedItem);
                Vacation vacation = new Vacation(allInclusive, txtDestination.Text, country, Convert.ToInt32(txtTravellers.Text));
                travelManager.AddTravel(vacation);
                ListViewItem item = new();
                item.Content = vacation.GetInfo();
                item.Tag = vacation;
                travelsWindow.addListViewItem(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Input!");
            }
        }
        else
        {
            MessageBox.Show("You have to choose a travel type!");
        }
        travelsWindow.Show();
        Hide();
    }

    private void cbTravelType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (cbTravelType.SelectedItem == "Trip")
        {
            cbTripVacationType.ItemsSource = Enum.GetNames(typeof(TripTypes));
            lblTripVacationType.Content = "Trip type";
        }
        else
        {
            cbTripVacationType.ItemsSource = new string[] { "yes", "no" };
            lblTripVacationType.Content = "All inclusive";
        }
    }
}
