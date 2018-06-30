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
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory post);
        void Update(PostCategory post);
        void Delete(PostCategory post);
        void Delete(int id);
        PostCategory GetById(int id);
        IEnumerable<PostCategory> GetAll();
        IEnumerable<PostCategory> GetAllPaging(int pageIndex, int pageSize, out int totalRow);
        IEnumerable<PostCategory> GetByParentId(int parentId);
        void Save();
    }

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;
        
        public PostCategoryService(IPostCategoryRepository postCategoryRepository,
            IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory post)
        {
            return this._postCategoryRepository.Add(post);
        }

        public void Update(PostCategory post)
        {
            _postCategoryRepository.Update(post);
        }

        public void Delete(int id)
        {
            _postCategoryRepository.Delete(id);
        }

        public void Delete(PostCategory post)
        {
            _postCategoryRepository.Delete(post);
        }

        public PostCategory GetById(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<PostCategory> GetAllPaging(int pageIndex, int pageSize, out int totalRow)
        {
            return _postCategoryRepository.GetMultiPaging(p => p.Status, out totalRow, pageIndex, pageSize);
        }

        public IEnumerable<PostCategory> GetByParentId(int parentId)
        {
            return _postCategoryRepository.GetMulti(p => p.Status && p.ParentID == parentId);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }        
    }
}
