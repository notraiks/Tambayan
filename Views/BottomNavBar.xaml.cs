using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Tambayan.Views;

public partial class BottomNavBar : ContentView
{
    public BottomNavBar()
    {
        InitializeComponent();
    }
    private async void OnHomeTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//MainPage");
    }

    private async void OnChatTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Chat");
    }
    
    private async void OnPostTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//PostJob");
    }
    
    private async void OnNotificationTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Notification");
    }

    private async void OnProfileTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Profile");
    }
}