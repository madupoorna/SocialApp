using SocialApp.Data;
using SocialApp.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SocialApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CommentsPage : ContentPage
	{
        public ObservableCollection<Comment> CommentsList { get; }
        DataRetreiver _dr;

        public CommentsPage(Post post)
        {
            InitializeComponent();

            BindingContext = post;

            Title = "Comments";
            CommentsList = new ObservableCollection<Comment>();
            CommentsListView.ItemsSource = CommentsList;

            CommentsListView.ItemSelected += CommentsListView_ItemSelected;

            _dr = new DataRetreiver();
            AddToolbarItem(post.userId);

            CommentsListView.IsVisible = false;
            ActivityIndicator.IsVisible = true;

            LoadDataAsync(post.id);
        }

        private void CommentsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Comment comment = e.SelectedItem as Comment;
                Device.OpenUri(new Uri("mailto:" + comment.email));
            }

            // Clear selection
            CommentsListView.SelectedItem = null;
        }

        private void AddToolbarItem(int userId)
        {
            ToolbarItems.Add(new ToolbarItem("", "user.png", ()=>
            {
                Navigation.PushAsync(new ProfilePage(userId));
            }));
        }

        private async void LoadDataAsync(int postId)
        {
            CommentsList.Clear();

            List<Comment> Comments = await _dr.GetComments(postId);

            ActivityIndicator.IsRunning = false;
            ActivityIndicator.IsVisible = false;
            CommentsListView.IsVisible = true;

            foreach (Comment p in Comments)
            {
                CommentsList.Add(p);
            }
        }
    }
}