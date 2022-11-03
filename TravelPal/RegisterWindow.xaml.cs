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

namespace TravelPal;

/// <summary>
/// Interaction logic for RegisterWindow.xaml
/// </summary>
public partial class RegisterWindow : Window
{
    private MainWindow mainWindow;
    public RegisterWindow(MainWindow mainWindow)
    {
        InitializeComponent();
        this.mainWindow = mainWindow;

        cbCountry.ItemsSource = Enum.GetValues(typeof(Countries));
    }

    private void btnRegister_Click(object sender, RoutedEventArgs e)
    {
        Close();
        mainWindow.Show();
    }
}
