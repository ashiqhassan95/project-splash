using Newtonsoft.Json.Linq;
using ProjectSplash.Core.IRepository;
using ProjectSplash.Core.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSplash.Infrastructure.Repository
{
    public class SplashRepository : ISplashRepository
    {
        public async Task<List<Collection>> GetCollectionsAsync(int perPage, int page)
        {
            string Url = $"{Config.APIUrl}/collections/featured?client_id={Config.ClientID}&per_page={perPage}&page={page}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(Url);
            if(response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return ParseData(responseContent);
            }
            return null;
        }

        private List<Collection> ParseData(string responseContent)
        {
            var collectionList = new List<Collection>();
            JArray array = JArray.Parse(responseContent);
            foreach (var item in array)
            {
                var collection = new Collection();
                collection.Id = item["id"].ToString();
                collection.Title = item["title"].ToString();
                collection.Description = item["description"].ToString();

                collection.CreatedAt = item["published_at"].Value<DateTime>();
                collection.UpdatedAt = item["updated_at"].Value<DateTime>();
                collection.PhotoCount = item["total_photos"].Value<int>();

                collection.CoverPhotoUrl.RawImageUrl = item["cover_photo"]["urls"]["raw"].ToString();
                collection.CoverPhotoUrl.FullImageUrl = item["cover_photo"]["urls"]["full"].ToString();
                collection.CoverPhotoUrl.RegularImageUrl = item["cover_photo"]["urls"]["regular"].ToString();
                collection.CoverPhotoUrl.SmallImageUrl = item["cover_photo"]["urls"]["small"].ToString();
                collection.CoverPhotoUrl.ThumbImageUrl = item["cover_photo"]["urls"]["thumb"].ToString();
                 
                collection.User.Id = item["user"]["id"].ToString();
                collection.User.Name = item["user"]["name"].ToString();
                collection.User.Username = item["user"]["username"].ToString();
                collection.User.Location = item["user"]["location"].ToString();
                collection.User.PhotoCount = item["user"]["total_photos"].Value<int>();

                collection.User.SmallImageUrl = item["user"]["profile_image"]["small"].ToString();
                collection.User.MediumImageUrl = item["user"]["profile_image"]["medium"].ToString();
                collection.User.LargeImageUrl = item["user"]["profile_image"]["large"].ToString();
                 
                collectionList.Add(collection);
            }
            return collectionList;
        }
    }
}
