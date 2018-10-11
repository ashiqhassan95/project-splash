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
    public class PhotoRepository : IPhotoRepository
    { 
        private List<Photo> ParseData(string jsonContent)
        {
            var photoList = new List<Photo>();
            JArray array = JArray.Parse(jsonContent);
            foreach(var item in array)
            {
                var photo = new Photo();
                photo.Id = item["id"].ToString();
                photo.CreatedAt = item["created_at"].Value<DateTime>();
                photo.Width = item["width"].Value<double>();
                photo.Height = item["height"].Value<double>();
                photo.LikeCount = item["like"].Value<int>();
                photo.Description = item["description"].ToString();

                photo.User.Id = item["user"]["id"].ToString();
                photo.User.Username = item["user"]["username"].ToString();
                photo.User.Name = item["user"]["name"].ToString();
                photo.User.Location = item["user"]["location"].ToString();
                photo.User.PhotoCount = item["user"]["total_photos"].Value<int>();
                photo.User.SmallImageUrl = item["user"]["profile_image"]["small"].ToString();
                photo.User.MediumImageUrl = item["user"]["profile_image"]["medium"].ToString();
                photo.User.LargeImageUrl = item["user"]["profile_image"]["large"].ToString();

                photo.Url.RawImageUrl = item["urls"]["raw"].ToString();
                photo.Url.FullImageUrl = item["urls"]["full"].ToString();
                photo.Url.RegularImageUrl = item["urls"]["regular"].ToString();
                photo.Url.SmallImageUrl = item["urls"]["small"].ToString();
                photo.Url.ThumbImageUrl = item["urls"]["thumb"].ToString();

                photoList.Add(photo);
            }
            return photoList;
        }

        public async Task<List<Photo>> GetPhotosAsync(int perPage, int page, PhotoOrderBy orderBy = PhotoOrderBy.Latest)
        {
            var url = $"{Config.APIUrl}/photos?client_id={Config.ClientID}&per_page={perPage}&page={page}&order_by={orderBy.ToString().ToLower()}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return ParseData(responseContent);
            }

            return null;
        }

        public async Task<List<Photo>> GetPhotosByCollectionAsync(string collectionId, int perPage, int page)
        {
            var url = $"{Config.APIUrl}//collections/featured?client_id={Config.ClientID}&per_page={perPage}&page={page}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return ParseData(responseContent);
            }

            return null;
        }

        public async Task<List<Photo>> GetPhotosByQueryAsync(string query, int perPage, int page)
        {
            var url = $"{Config.APIUrl}/photos?client_id={Config.ClientID}&query={query}&per_page={perPage}&page={page}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return ParseData(responseContent);
            }

            return null;
        }

        public async Task<List<Photo>> GetPhotosByUserAsync(string username, int perPage, int page, PhotoOrderBy orderBy = PhotoOrderBy.Latest)
        {
            var url = $"{Config.APIUrl}/users/{username}/photos?client_id={Config.ClientID}&per_page={perPage}&page={page}&order_by={orderBy.ToString().ToLower()}";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                return ParseData(responseContent);
            }

            return null;
        }
    }
}
