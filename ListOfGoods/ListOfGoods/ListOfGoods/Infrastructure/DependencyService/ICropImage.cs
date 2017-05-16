using System.IO;
using System.Threading.Tasks;

namespace ListOfGoods.Infrastructure.DependencyService
{
    public interface ICropImage
    {
        Task<string> GetCroppedBitmapAsync(string originalImgFile, uint height, uint width);
    }
}
