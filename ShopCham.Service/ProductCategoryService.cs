using ShopCham.Data.Infrastructure;
using ShopCham.Data.Repositories;
using ShopCham.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCham.Service
{
    public interface IProductCategoryService
    {
        void Add(ProductCategory category);
        void Update(ProductCategory category);
        void Delete(ProductCategory category);
        void Delete(int id);
        ProductCategory GetById(int id);
        IEnumerable<ProductCategory> GetAll();
        IEnumerable<ProductCategory> GetAllPaging(int pageIndex, int pageSize, out int totalRow);
        IEnumerable<ProductCategory> GetByParentId(int parentId);
        void SaveChange();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _productCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository,
            IUnitOfWork unitOfWork)
        {
            this._productCategoryRepository = productCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(ProductCategory category)
        {
            _productCategoryRepository.Add(category);
        }

        public void Update(ProductCategory category)
        {
            _productCategoryRepository.Update(category);
        }
        
        public void Delete(ProductCategory category)
        {
            _productCategoryRepository.Delete(category);
        }

        public void Delete(int id)
        {
            _productCategoryRepository.Delete(id);
        }

        public ProductCategory GetById(int id)
        {
            return _productCategoryRepository.GetSingleById(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
           return _productCategoryRepository.GetAll(new string[] { "ProductCategory" });
        }

        public IEnumerable<ProductCategory> GetAllPaging(int pageIndex, int pageSize, out int totalRow)
        {
           return _productCategoryRepository.GetMultiPaging(p => p.Status, out totalRow, pageIndex, pageSize);
        }
        
        public IEnumerable<ProductCategory> GetByParentId(int parentId)
        {
            return _productCategoryRepository.GetMulti(p => p.Status && p.ParentID == parentId);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }        
    }
}
 