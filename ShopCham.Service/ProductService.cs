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
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        void Delete(int id);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllPaging(int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Product> GetByTagPaging(string tag, int pageIndex, int pageSize, out int totalRow);
        void SaveChange();
    }

    public class ProductService : IProductService
    {
        IProductRepository _productRepository;
        IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository,
            IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        void IProductService.Add(Product product)
        {
            _productRepository.Add(product);
        }

        void IProductService.Update(Product product)
        {
            _productRepository.Update(product);
        }

        void IProductService.Delete(int id)
        {
            _productRepository.Delete(id);
        }

        void IProductService.Delete(Product product)
        {
            _productRepository.Delete(product);
        }

        Product IProductService.GetById(int id)
        {
            return _productRepository.GetSingleById(id);
        }

        IEnumerable<Product> IProductService.GetAll()
        {
            return _productRepository.GetAll(new string[] { "ProductCategory" });
        }

        IEnumerable<Product> IProductService.GetAllPaging(int pageIndex, int pageSize, out int totalRow)
        {
            return _productRepository.GetMultiPaging(p => p.Status, out totalRow, pageIndex, pageSize);
        }        

        IEnumerable<Product> IProductService.GetByTagPaging(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            return _productRepository.GetByTag(tag, pageIndex, pageSize, out totalRow);
        }

        void IProductService.SaveChange()
        {
            _unitOfWork.Commit();
        }        
    }
}
