using System.Threading.Tasks;

namespace ListOfGoods.Services.Media
{
    public interface IMediaService
    {
        Task<string> TakePhotoFromGalleryAsync();
        Task<string> TakePhotoFromCameraAsync();
    }
}
