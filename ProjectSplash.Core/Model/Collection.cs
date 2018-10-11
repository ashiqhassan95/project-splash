using System;

namespace ProjectSplash.Core.Model
{
    public class Collection
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int PhotoCount { get; set; }
        public Profile User { get; set; }
        public PhotoUrl CoverPhotoUrl { get; set; }

        public Collection()
        {
            User = new Profile();
            CoverPhotoUrl = new PhotoUrl();
        }
    }
}
