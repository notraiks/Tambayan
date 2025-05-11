// DetailsPage.xaml.cs
namespace Tambayan;

public partial class DetailsPage : ContentPage
{
    public DetailsPage()
    {
        InitializeComponent();
    }

    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}