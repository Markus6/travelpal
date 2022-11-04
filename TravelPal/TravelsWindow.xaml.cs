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

        if (userManager.SignedInUser.GetType() == typeof(Admin))
        {
            btnAddTravel.IsEnabled = false;
            btnUser.IsEnabled = false;
            foreach (IUser user in userManager.Users)
            {
                if (user.GetType() != typeof(Admin))
                {
                    foreach (Travel travel in ((User)user).TravelManager.Travels)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Content = $"{user.Username} - {travel.GetInfo()}";
                        item.Tag = new TravelUserInfo(travel, user);
                        lvTravels.Items.Add(item);
                    }
                }
            }
        }
        else
        {
            travelManager = ((User)userManager.SignedInUser).TravelManager;
            foreach (Travel travel in travelManager.Travels)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = travel;
                item.Content = travel.GetInfo();
                lvTravels.Items.Add(item);
            }
            btnAddTravel.IsEnabled = true;
            btnUser.IsEnabled = true;
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
    public void UpdateUsernameLabel(string newUsername)
    {
        lblUser.Content = newUsername;
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
            if (userManager.SignedInUser.GetType() == typeof(Admin))
            {
                ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;
                TravelUserInfo travelUserInfo = selectedItem.Tag as TravelUserInfo;
                travelManager = ((User)travelUserInfo.User).TravelManager;
                Travel travelToRemove = travelUserInfo.Travel;
                travelManager.RemoveTravel(travelToRemove);
                lvTravels.Items.Remove(selectedItem);
            }
            else
            {
                ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;
                Travel travelToRemove = selectedItem.Tag as Travel;
                travelManager.RemoveTravel(travelToRemove);
                lvTravels.Items.Remove(selectedItem);
            }
        }
        else
        {
            MessageBox.Show("You have to select a travel to remove first!");
        }
    }

    private void btnDetails_Click(object sender, RoutedEventArgs e)
    {
        if (lvTravels.SelectedItem != null)
        {
            Hide();
            if (userManager.SignedInUser.GetType() == typeof(Admin))
            {
                ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;

                TravelUserInfo travelUserInfo = selectedItem.Tag as TravelUserInfo;
                TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(this, travelUserInfo.Travel);
                travelDetailsWindow.Show();
            }
            else
            {
                ListViewItem selectedItem = lvTravels.SelectedItem as ListViewItem;

                Travel travel = selectedItem.Tag as Travel;
                TravelDetailsWindow travelDetailsWindow = new TravelDetailsWindow(this, travel);
                travelDetailsWindow.Show();
            }
        }
        else
        {
            MessageBox.Show("You have to select a travel to show first!");
        }
    }
}

public class TravelUserInfo
{
    public TravelUserInfo(Travel travel, IUser user)
    {
        this.Travel = travel;
        this.User = user;
    }
    public IUser User { get; set; }
    public Travel Travel { get; set; }
}
