using GymApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApp.Services.Data.Interfaces
{
    public interface ISupplementService
    {
        Task<Supplement> GetSupplemenntByNameAsync(string supplementName);
    }
}
