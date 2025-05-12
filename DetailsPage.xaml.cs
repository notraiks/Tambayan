using Microsoft.Maui.Storage;
using CommunityToolkit.Maui.Views;
using System.IO;

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

    private async void OnApplyNowClicked(object sender, EventArgs e)
    {
        ApplyNowFrame.IsVisible = false;
        ApplicationFormOverlay.TranslationY = 600;
        ApplicationFormOverlay.IsVisible = true;
        await ApplicationFormOverlay.TranslateTo(0, 0, 300, Easing.SinOut);
    }

    private async void CloseFormClicked(object sender, EventArgs e)
    {
        await ApplicationFormOverlay.TranslateTo(0, 600, 300, Easing.SinIn);
        ApplicationFormOverlay.IsVisible = false;
        ApplyNowFrame.IsVisible = true;
    }

    // File picker handler
    private void OnPageLoaded(object sender, EventArgs e)
    {
        LoadUploadButtons(); // ensure buttons are visible initially
    }

    private void LoadUploadButtons()
    {
        ResumeUploadContainer.Children.Clear();
        MediaUploadContainer.Children.Clear();
        ShortPitchUploadContainer.Children.Clear();

        ResumeUploadContainer.Children.Add(CreateUploadButton("Resume"));
        MediaUploadContainer.Children.Add(CreateUploadButton("Media"));
        ShortPitchUploadContainer.Children.Add(CreateUploadButton("ShortPitch"));
    }

    private async void OnUploadClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var fileType = button?.CommandParameter?.ToString() ?? "Unknown";

        try
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                PickerTitle = $"Select your {fileType} file"
            });

            if (result != null)
            {
                var cachePath = Path.Combine(FileSystem.CacheDirectory, result.FileName);

                using var stream = await result.OpenReadAsync();
                using var fileStream = File.OpenWrite(cachePath);
                await stream.CopyToAsync(fileStream);

                ShowFilePreview(fileType, result.FileName);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"File picking failed: {ex.Message}", "OK");
        }
    }
    private Button CreateUploadButton(string fileType)
    {
        var button = new Button
        {
            Text = "Upload File",
            BackgroundColor = Color.FromArgb("#6C63FF"),
            TextColor = Colors.White,
            CornerRadius = 12,
            CommandParameter = fileType
        };

        button.Clicked += OnUploadClicked;
        return button;
    }


    private void ShowFilePreview(string fileType, string fileName)
    {
        var container = fileType switch
        {
            "Resume" => ResumeUploadContainer,
            "Media" => MediaUploadContainer,
            "ShortPitch" => ShortPitchUploadContainer,
            _ => null
        };

        if (container == null) return;

        container.Children.Clear();

        var fileLabel = new Label
        {
            Text = $"📄 {fileName}",
            FontSize = 14,
            TextColor = Colors.Black,
            VerticalOptions = LayoutOptions.Center
        };

        var clearButton = new ImageButton
        {
            Source = "close_icon.png",
            BackgroundColor = Colors.Transparent,
            HeightRequest = 24,
            WidthRequest = 24,
            VerticalOptions = LayoutOptions.Center
        };

        clearButton.Clicked += (s, e) =>
        {
            container.Children.Clear();
            container.Children.Add(CreateUploadButton(fileType));
        };

        var row = new HorizontalStackLayout
        {
            Spacing = 10,
            Children = { fileLabel, clearButton }
        };

        container.Children.Add(row);
    }
    
    private string currentTab = "Description";
    
    private void OnTabTapped(object sender, EventArgs e)
    {
        if (sender is Label tappedLabel)
        {
            string selectedTab = tappedLabel.Text;

            if (selectedTab == currentTab)
                return;

            currentTab = selectedTab;

            // Update visuals
            bool isDescription = selectedTab == "Description";

            DescriptionTab.BackgroundColor = isDescription ? Colors.White : Colors.Transparent;
            RequirementsTab.BackgroundColor = isDescription ? Colors.Transparent : Colors.White;

            DescriptionTabLabel.TextColor = isDescription ? Color.FromArgb("#4A4AFF") : Colors.Gray;
            RequirementsTabLabel.TextColor = isDescription ? Colors.Gray : Color.FromArgb("#4A4AFF");

            // Update visibility
            DescriptionContent.IsVisible = isDescription;
            RequirementsContent.IsVisible = !isDescription;
        }
    }


    
}