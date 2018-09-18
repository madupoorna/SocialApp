using SocialApp.Data;
using SocialApp.Net;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilePage : ContentPage
	{
        DataRetreiver _dr;

        public ProfilePage(int userId)
        {
            InitializeComponent();

            Title = userId+ "'s Profile";
            _dr = new DataRetreiver();

            ActivityIndicator.IsVisible = true;

            SetData(userId);
        }

        private async void SetData(int userId)
        {
            ActivityIndicator.IsVisible = false;

            Profile profile = await _dr.GetProfile(userId);

            nameLabel.Text = profile.name;
            usernameLabel.Text = profile.username;
            emailLabel.Text = profile.email;
            phoneLabel.Text = profile.phone;
            websiteLabel.Text = profile.website;
        }
    }
}