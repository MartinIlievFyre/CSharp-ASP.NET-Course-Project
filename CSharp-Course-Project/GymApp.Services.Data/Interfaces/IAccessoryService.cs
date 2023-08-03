using GymApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace GymApp.Services.Data.Interfaces
{
    public interface IAccessoryService
    {
        Task<IEnumerable<AccessoryViewModel>> AllAccessoriesAsync();
        Task<AccessoryViewModel> GetProductByIdAsync(string id);
        Task<List<int>> RandomAccessoryIdsAsync(string id);
        Task<List<AccessoryViewModel>> RandomAccessoriesWithIdsAsync(List<int> randomAccessoryIds);
    }
}
