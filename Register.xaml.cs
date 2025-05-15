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
        string fullName = FullNameEntry.Text?.Trim();
        string email = EmailEntry.Text?.Trim();
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(fullName))
        {
            await DisplayAlert("Missing Input", "Please enter your full name.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            await DisplayAlert("Missing Input", "Please enter your email.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Missing Input", "Please enter your password.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(confirmPassword))
        {
            await DisplayAlert("Missing Input", "Please confirm your password.", "OK");
            return;
        }

        if (password != confirmPassword)
        {
            await DisplayAlert("Password Mismatch", "Passwords do not match. Please try again.", "OK");
            return;
        }

        // Show success alert
        await DisplayAlert("Success", "Registered Successfully", "OK");

        // Navigate to main page
        await Shell.Current.GoToAsync("//MainPage");
    }
}