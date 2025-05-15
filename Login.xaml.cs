using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        await Shell.Current.GoToAsync("//Register");
    }

    private async void OnLoginTapped(object sender, EventArgs e)
    {
        string email = EmailEntry.Text?.Trim();
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email))
        {
            await DisplayAlert("Missing Input", "Please enter your email.", "OK");
            return;
        }

        if (!IsValidEmail(email))
        {
            await DisplayAlert("Invalid Email", "Please enter a valid email address.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert("Missing Input", "Please enter your password.", "OK");
            return;
        }

        // TODO: Add authentication logic here

        // Navigate to MainPage only if all validations pass
        await Shell.Current.GoToAsync("//MainPage");
    }

    // Simple regex-based email validation
    private bool IsValidEmail(string email)
    {
        return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }
}