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
    public interface IPostService
    {
        void Add(Post post);
        void Update(Post post);
        void Delete(Post post);
        void Delete(int id);
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetAllPaging(int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Post> GetByTagPaging(string tag, int pageIndex, int pageSize, out int totalRow);
        IEnumerable<Post> GetByCategoryPaging(int categoryId, int pageIndex, int pageSize, out int totalRow);
        void SaveChange();
    }

    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;
        
        public PostService(IPostRepository postRepository,
            IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            this._postRepository.Add(post);
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }

        public void Delete(int id)
        {
            _postRepository.Delete(id);
        }

        public void Delete(Post post)
        {
            _postRepository.Delete(post);
        }

        public Post GetById(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllPaging(int pageIndex, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(p => p.Status, out totalRow, pageIndex, pageSize);
        }
        
        public IEnumerable<Post> GetByTagPaging(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            return _postRepository.GetByTag(tag, pageIndex, pageSize, out totalRow);
        }

        public IEnumerable<Post> GetByCategoryPaging(int categoryId, int pageIndex, int pageSize, out int totalRow)
        {
            return _postRepository.GetMultiPaging(p => p.Status && p.PostCategoryID == categoryId, out totalRow, pageIndex, pageSize);
        }

        public void SaveChange()
        {
            _unitOfWork.Commit();
        }
    }
}
