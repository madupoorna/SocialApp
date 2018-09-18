using SocialApp.Data;
using SocialApp.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SocialApp
{
    public partial class PostListPage : ContentPage
    {
        public ObservableCollection<Post> PostsList { get; }
        DataRetreiver _dr;

        public PostListPage()
        {
            InitializeComponent();
            
            Title = "Posts";
            PostsList = new ObservableCollection<Post>();
            PostsListView.ItemsSource = PostsList;
            PostsListView.ItemSelected += UsersListView_ItemSelected;

            _dr = new DataRetreiver();

            PostsListView.IsVisible = false;
            ActivityIndicator.IsVisible = true;

            LoadDataAsync();
        }

        private void UsersListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                CommentsPage comments = new CommentsPage(e.SelectedItem as Post);
                Navigation.PushAsync(comments);
            }

            // Clear selection
            PostsListView.SelectedItem = null;
        }

        private async Task LoadDataAsync()
        {
            PostsList.Clear();

            List<Post> Posts = await _dr.GetPosts();

            ActivityIndicator.IsRunning = false;
            ActivityIndicator.IsVisible = false;
            PostsListView.IsVisible = true;

            foreach (Post p in Posts)
            {
                PostsList.Add(p);
            }
        }
    }
}
