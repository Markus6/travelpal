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
/// Interaction logic for TravelsWindow.xaml
/// </summary>
public partial class TravelsWindow : Window
{
    private MainWindow mainWindow;
    private UserManager userManager;
    private TravelManager travelManager;
    public TravelsWindow(MainWindow mainWindow, UserManager userManager)
    {
        InitializeComponent();
        lblUser.Content = userManager.SignedInUser.Username;
        this.mainWindow = mainWindow;
        this.userManager = userManager;
        travelManager = ((User)userManager.SignedInUser).TravelManager;

        foreach (Travel travel in travelManager.Travels)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = travel;
            item.Content = travel.GetInfo();
            lvTravels.Items.Add(item);
        }
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
        AddTravelWindow addTravelWindow = new AddTravelWindow(this, userManager);
        addTravelWindow.Show();
    }

    public void addListViewItem(ListViewItem listViewItem)
    {
        lvTravels.Items.Add(listViewItem);
    }

    private void btnSignOut_Click(object sender, RoutedEventArgs e)
    {
        mainWindow.Show();
        Close();
    }

    private void btnRemove_Click(object sender, RoutedEventArgs e)
    {
        if (lvTravels.SelectedItem != null)
        {
            Travel travelToRemove = travelManager.Travels[lvTravels.SelectedIndex];
            travelManager.RemoveTravel(travelToRemove);
            ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;
            lvTravels.Items.Remove(selectedItem);
        }
        else
        {
            MessageBox.Show("You have to select a travel to remove first!");
        }
    }

    private void btnDetails_Click(object sender, RoutedEventArgs e)
    {
        Hide();
        Travel travel = travelManager.Travels[lvTravels.SelectedIndex];
        TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(travel);
        travelDetailsWindow.Show();
    }
}
