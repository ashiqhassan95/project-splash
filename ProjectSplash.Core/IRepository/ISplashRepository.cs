using ProjectSplash.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSplash.Core.IRepository
{
    public interface ISplashRepository
    {
        /// <summary>
        /// Retrieve a list of collection
        /// </summary>
        /// <param name="perPage">Specify the number of photo to be retrieved per page</param>
        /// <param name="page">Specify the number of the page</param>
        /// <returns>List of Collection</returns>
        Task<List<Collection>> GetCollectionsAsync(int perPage, int page);
    }
}
