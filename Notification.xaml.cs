using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tambayan;

public partial class Notification : ContentPage
{
    public Notification()
    {
        InitializeComponent();
    }
    
    private async void OnApplicantClicked(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new Applicant());
    }
}