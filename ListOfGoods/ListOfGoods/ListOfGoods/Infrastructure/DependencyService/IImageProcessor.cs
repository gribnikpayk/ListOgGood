using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListOfGoods.Infrastructure.DependencyService
{
    public interface IImageProcessor
    {
        Task<string> GetCroppedImagePathAsync(string filePath, string fileName, int requestedMinSide);
    }
}
