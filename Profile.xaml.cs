using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tambayan.Views;

namespace Tambayan;

public partial class Profile : ContentPage
{
    public static readonly BindableProperty SelectedTabProperty =
        BindableProperty.Create(nameof(SelectedTab), typeof(string), typeof(Profile), "AboutMe", propertyChanged: OnTabChanged);

    public string SelectedTab
    {
        get => (string)GetValue(SelectedTabProperty);
        set => SetValue(SelectedTabProperty, value);
    }

    public Profile()
    {
        InitializeComponent();
        BindingContext = this;
    }

    private static void OnTabChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var page = bindable as Profile;
        page?.UpdateTabContent();
    }

    private void UpdateTabContent()
    {
        if (SelectedTab == "AboutMe")
        {
            TabContentView.Content = new AboutMeContent();
        }
        else if (SelectedTab == "Activities")
        {
            TabContentView.Content = new ActivitiesContent();
        }
    }

    private void OnAboutMeClicked(object sender, EventArgs e) => SelectedTab = "AboutMe";

    private void OnActivitiesClicked(object sender, EventArgs e) => SelectedTab = "Activities";
}
