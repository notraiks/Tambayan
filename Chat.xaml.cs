﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tambayan;

public partial class Chat : ContentPage
{
    public Chat()
    {
        InitializeComponent();
    }
    private async void OnViewChatTapped(object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new UserChat());
    }
}