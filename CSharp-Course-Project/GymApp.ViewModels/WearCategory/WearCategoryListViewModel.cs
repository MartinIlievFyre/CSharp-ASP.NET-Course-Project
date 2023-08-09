using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.ViewModels.WearCategory
{
    public class WearCategoryListViewModel
    {
        public ICollection<WearCategoryViewModel> Categories { get; set; } = null!;
    }
}
