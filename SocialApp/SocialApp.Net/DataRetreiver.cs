using Newtonsoft.Json;
using SocialApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace SocialApp.Net
{
    public class DataRetreiver
    {
        public DataRetreiver()
        {
        }

        public async Task<List<Post>> GetPosts()
        {
            List<Post> Posts = new List<Post>();

            using (WebClient wc = new WebClient())
            {
                string json = await wc.DownloadStringTaskAsync(new Uri(Constants.POSTS_URL));

                if (!string.IsNullOrEmpty(json))
                {
                    Posts = JsonConvert.DeserializeObject<Post[]>(json).ToList();
                }
            }

            return Posts;
        }

        public async Task<List<Comment>> GetComments(int postId)
        {
            List<Comment> Comments = new List<Comment>();

            String commentsUrl = GenerateCommentsUrl(postId);

            using (WebClient wc = new WebClient())
            {
                string json = await wc.DownloadStringTaskAsync(new Uri(commentsUrl));

                if (!string.IsNullOrEmpty(json))
                {
                    Comments = JsonConvert.DeserializeObject<Comment[]>(json).ToList();
                }
            }

            return Comments;
        }

        public async Task<Profile> GetProfile(int userId)
        {
            Profile profile = null;
            String profileUrl = GenerateProfileUrl(userId);

            using (WebClient wc = new WebClient())
            {
                string json = await wc.DownloadStringTaskAsync(new Uri(profileUrl));

                if (!string.IsNullOrEmpty(json))
                {
                    profile = JsonConvert.DeserializeObject<Profile>(json);
                }
            }

            return profile;
        }

        public string GenerateCommentsUrl(int postId)
        {
            return string.Format(Constants.COMMENTS_URL, postId);
        }

        public string GenerateProfileUrl(int userId)
        {
            return string.Format(Constants.PROFILE_URL, userId);
        }
    }
}
