using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tambayan;

public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();
    }
    
    private async void GoToRegisterPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("RegisterPage");
    }


    private async void OnLoginTapped(object sender, EventArgs e)
    {
        // Navigate to MainPage after tapping the login label
        await Shell.Current.GoToAsync("//MainPage");
    }
}