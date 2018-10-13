using ProjectSplash.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSplash.ViewModel
{
    public class PhotoViewModel
    {
        private readonly IPhotoRepository photoRepository;

        public PhotoViewModel(IPhotoRepository photoRepository)
        {
            this.photoRepository = photoRepository;
        }
    }
}
