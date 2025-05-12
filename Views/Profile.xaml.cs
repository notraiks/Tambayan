using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tambayan.Views;

public partial class Profile : ContentView
{
    public Profile()
    {
        InitializeComponent();
    }
    private async void OnApplicationTapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("MyApplication");
    }
}