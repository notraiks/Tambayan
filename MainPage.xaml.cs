namespace Tambayan;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnViewDetailsTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new DetailsPage());
    }
    private async void OnThreadsClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//Threads");
    }

}