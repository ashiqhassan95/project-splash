namespace ProjectSplash.Core.Model
{
    public class Profile
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Location { get; set; }
        public int PhotoCount { get; set; }
        public int CollectionCount { get; set; }
        public string SmallImageUrl { get; set; }
        public string MediumImageUrl { get; set; }
        public string LargeImageUrl { get; set; }
        public string ProfileUrl { get; set; }
    }
}
