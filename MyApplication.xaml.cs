using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tambayan;

public partial class MyApplication : ContentPage
{
    public MyApplication()
    {
        InitializeComponent();
    }
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}