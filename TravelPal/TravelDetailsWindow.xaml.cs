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
using TravelPal.Model;

namespace TravelPal;

/// <summary>
/// Interaction logic for TravelDetailsWindow.xaml
/// </summary>
public partial class TravelDetailsWindow : Window
{
    private TravelsWindow travelsWindow;
    public TravelDetailsWindow(TravelsWindow travelsWindow, Travel travel)
    {
        InitializeComponent();
        this.travelsWindow = travelsWindow;
        if (travel.GetType() == typeof(Trip))
        {
            ListViewItem Item1 = new ListViewItem();
            Item1.Content = $"Trip type: {((Trip)travel).type}";
            lvTravel.Items.Add(Item1);
            ListViewItem Item2 = new ListViewItem();
            Item2.Content = $"Number of travellers: {travel.Travellers}";
            lvTravel.Items.Add(Item2);
            ListViewItem Item3 = new ListViewItem();
            Item3.Content = $"Country: {travel.Country}";
            lvTravel.Items.Add(Item3);
            ListViewItem Item4 = new ListViewItem();
            Item4.Content = $"Destination: {travel.Destination}";
            lvTravel.Items.Add(Item4);
        }
        else
        {
            ListViewItem Item1 = new ListViewItem();
            Item1.Content = $"All inclusive: {((Vacation)travel).AllInclusive}";
            lvTravel.Items.Add(Item1);
            ListViewItem Item2 = new ListViewItem();
            Item2.Content = $"Number of travellers: {travel.Travellers}";
            lvTravel.Items.Add(Item2);
            ListViewItem Item3 = new ListViewItem();
            Item3.Content = $"Country: {travel.Country}";
            lvTravel.Items.Add(Item3);
            ListViewItem Item4 = new ListViewItem();
            Item4.Content = $"Destination: {travel.Destination}";
            lvTravel.Items.Add(Item4);
        }

    }

    private void btnBack_Click(object sender, RoutedEventArgs e)
    {
        travelsWindow.Show();
        Close();
    }
}
