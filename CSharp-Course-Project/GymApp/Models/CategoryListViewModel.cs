using GymApp.Data.Models;

namespace GymApp.Models
{
    public class CategoryListViewModel
    {
        public ICollection<CategoryViewModel> Categories { get; set; } = null!;

    }
}
