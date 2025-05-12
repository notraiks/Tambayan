using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tambayan;

public partial class Threads : ContentPage
{
    public Threads()
    {
        InitializeComponent();
    }

    private async void OnJobsClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
    
    private async void OnThreadDetailTapped(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ThreadDetail());
    }
}