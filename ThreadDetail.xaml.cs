using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Tambayan
{
    public partial class ThreadDetail : ContentPage
    {
        public ThreadDetail()
        {
            InitializeComponent();
        }

        private async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }


        // Method to handle the send button click
        private void OnSendButtonClicked(object sender, EventArgs e)
        {
            // Get the comment text from the entry
            var commentText = CommentEntry.Text;

            // Check if the comment is not empty
            if (!string.IsNullOrEmpty(commentText))
            {
                // Create a new label with the comment text and user info
                var commentLabel = new Label
                {
                    Text = $"You: {commentText}",
                    FontSize = 14,
                    TextColor = Colors.Black
                };

                // Add the new comment to the replies section
                var replyStack = new VerticalStackLayout
                {
                    Spacing = 10,
                    Children = { commentLabel }
                };

                var replyFrame = new Frame
                {
                    BackgroundColor = Colors.White,
                    Padding = 10,
                    BorderColor = Colors.Transparent,
                    HasShadow = true,
                    Content = replyStack
                };

                // Add the new reply to the stack layout
                RepliesStackLayout.Children.Add(replyFrame);

                // Clear the entry field
                CommentEntry.Text = string.Empty;
            }
        }
    }
}
