using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPhotoMetaData
    {
        Task SavePhotoMetaData(string userName, string desciption, string fileName);
        Task<List<PhotoModel>> GetUserPhotos(string userName);
    }
}
