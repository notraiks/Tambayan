using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tambayan;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
    }
    private async void GoToLoginPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Login");
    }


    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        // Show success alert
        await DisplayAlert("Success", "Registered Successfully", "OK");


        // Navigate to main page
        await Shell.Current.GoToAsync("//MainPage");
    }
}