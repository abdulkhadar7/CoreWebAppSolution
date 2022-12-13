using CoreWebApp.DAL.DbSets;
using CoreWebApp.DAL.UnitOfWork;
using CoreWebApp.Models.DTO;
using CoreWebApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWebApp.Service
{
    public class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitofWork) 
        { 
            _unitOfWork= unitofWork;
        }    
        public List<CategoriesDTO> GetCategories()
        {
            //Categories obj = new Categories
            //{
            //    Name = "Travelogue",
            //    DisaplayOrder = 100,
            //    CreatedDateTime = DateTime.Now
            //};

            //_unitOfWork.CategoriesRepo.Insert(obj);
            //_unitOfWork.Save();

            var list = _unitOfWork.CategoriesRepo.GetAll().Select(s => new CategoriesDTO
            {
                Id = s.Id,
                Name = s.Name,
                CreatedDateTime = s.CreatedDateTime,
                DisplayOrder = s.DisaplayOrder
            }).ToList();
            return list;
        }
    }
}
