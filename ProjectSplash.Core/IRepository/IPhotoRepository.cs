using ProjectSplash.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSplash.Core.IRepository
{
    public interface IPhotoRepository
    { 
        /// <summary>
        /// Retrieve list of photos
        /// </summary>
        /// <param name="perPage">Specify the number of photo to be retrieved per page</param>
        /// <param name="page">Specify the number of the page</param>
        /// <param name="orderBy">Specify order the photo to be retrieved (Latest, Oldest, and Popular; default latest)</param>
        /// <returns>List of Photo</returns>
        Task<List<Photo>> GetPhotosAsync(int perPage, int page, PhotoOrderBy orderBy = PhotoOrderBy.Latest);

        /// <summary>
        /// Retrieve list of photos of a single user
        /// </summary>
        /// <param name="username">Specify the username</param>
        /// <param name="perPage">Specify the number of photo to be retrieved per page</param>
        /// <param name="page">Specify the number of the page</param>
        /// <param name="orderBy">Specify order the photo to be retrieved (Latest, Oldest and Popular; default latest)</param>
        /// <returns>List of Photo</returns>
        Task<List<Photo>> GetPhotosByUserAsync(string username, int perPage, int page, PhotoOrderBy orderBy = PhotoOrderBy.Latest);

        /// <summary>
        /// Retrieve list of photos of a collection
        /// </summary>
        /// <param name="collectionId">Specify collection id</param>
        /// <param name="perPage">Specify the number of photo to be retrieved per page</param>
        /// <param name="page">Specify the number of the page</param>
        /// <returns>List of Photo</returns>
        Task<List<Photo>> GetPhotosByCollectionAsync(string collectionId, int perPage, int page);

        /// <summary>
        /// Retrieve list of photos by a search query term
        /// </summary>
        /// <param name="query">Specify search query (keyword)</param>
        /// <param name="perPage">Specify the number of photo to be retrieved per page</param>
        /// <param name="page">Specify the number of the page</param>
        /// <returns>List of Photo</returns>
        Task<List<Photo>> GetPhotosByQueryAsync(string query, int perPage, int page);   
    }
}
