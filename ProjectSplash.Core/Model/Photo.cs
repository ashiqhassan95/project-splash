using System;

namespace ProjectSplash.Core.Model
{
    public class Photo
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Description { get; set; }
        public int LikeCount { get; set; }
        public int DownloadCount { get; set; }
        public Profile User { get; set; }
        public PhotoMeta Meta { get; set; }
        public Location Location { get; set; }
        public PhotoUrl Url { get; set; }

        public string Resolution => $"{Width} X {Height}";

        public Photo()
        {
            User = new Profile();
            Meta = new PhotoMeta();
            Location = new Location();
            Url = new PhotoUrl();
        }
    }
}
