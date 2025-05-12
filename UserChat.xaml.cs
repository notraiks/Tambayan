using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Tambayan;

public partial class UserChat : ContentPage
{
    public UserChat()
    {
        InitializeComponent();
    }
    
    private async void OnBackButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
        private void OnSendClicked(object sender, EventArgs e)
        {
            string messageText = MessageEntry.Text?.Trim();

            if (!string.IsNullOrEmpty(messageText))
            {
                // Create message bubble
                var messageFrame = new Frame
                {
                    BackgroundColor = Color.FromArgb("#007AFF"),
                    CornerRadius = 15,
                    HasShadow = false,
                    Padding = new Thickness(12),
                    Margin = new Thickness(0, 5, 0, 0),
                    Content = new Label
                    {
                        Text = messageText,
                        TextColor = Colors.White,
                        FontSize = 14
                    },
                    HorizontalOptions = LayoutOptions.End,
                    MaximumWidthRequest = 270
                };

                var timeStamp = new Label
                {
                    Text = "Now",
                    FontSize = 11,
                    TextColor = Colors.Gray,
                    HorizontalOptions = LayoutOptions.End,
                    Margin = new Thickness(5, -15, 0, 0)
                };

                // Add to message stack
                MessageStack.Children.Add(messageFrame);
                MessageStack.Children.Add(timeStamp);

                MessageEntry.Text = string.Empty;

                // Auto-scroll to bottom
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await ChatScrollView.ScrollToAsync(0, MessageStack.Height, true);
                });
            }
        }

        private void OnLinkClicked(object sender, EventArgs e)
        {
            // Handle link attachment (e.g., open file picker)
        }

        private void OnCameraClicked(object sender, EventArgs e)
        {
            // Handle camera access
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            // Optional: Show send button only when text is present
        }
}