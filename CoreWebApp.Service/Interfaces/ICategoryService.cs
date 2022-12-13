using CoreWebApp.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Service.Interfaces
{
    public interface ICategoryService
    {
        List<CategoriesDTO> GetCategories();
    }
}
