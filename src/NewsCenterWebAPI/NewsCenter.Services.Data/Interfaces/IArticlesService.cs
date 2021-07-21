using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsCenter.Services.Data.Interfaces
{
    public interface IArticlesService
    {
        Task CreateAsync(string title, string imageUrl, string content, int categoryId);
    }
}
