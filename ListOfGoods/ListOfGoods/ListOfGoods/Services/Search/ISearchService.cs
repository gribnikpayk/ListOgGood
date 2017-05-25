using System.Collections.Generic;
using System.Threading.Tasks;

namespace ListOfGoods.Services.Search
{
    public interface ISearchService
    {
        Task<List<string>> SearchImagesAsync(string query);
    }
}
