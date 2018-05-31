using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopCham.Data.Infrastructure;
using ShopCham.Data.Repositories;
using ShopCham.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCham.UnitTest.RepositoryTest
{
    [TestClass]
    public class PostCategoryRepositoryTest
    {
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;
        private IDbFactory _dbFactory;

        [TestInitialize]
        public void Initialize()
        {
            _dbFactory = new DbFactory();
            _postCategoryRepository = new PostCategoryRepository(_dbFactory);
            _unitOfWork = new UnitOfWork(_dbFactory);
        }

        public PostCategoryRepositoryTest()
        {
            _postCategoryRepository = new PostCategoryRepository(_dbFactory);
        }

        [TestMethod]
        public void PostCategory_Repository_Create()
        {
            var model = new PostCategory();
            model.PostCategoryName = "name";
            model.Alias = "adias";
            model.Description = "description";
            var result = _postCategoryRepository.Add(model);
            _unitOfWork.Commit();

            Assert.AreEqual(1, result.ID);
        }
    }
}
