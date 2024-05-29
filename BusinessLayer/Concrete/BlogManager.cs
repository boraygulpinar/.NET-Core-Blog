using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

		public List<Blog> GetBlogByID(int id)
		{
            return _blogDal.GetListAll(x => x.BlogID == id);
		}

		public List<Blog> GetBlogListByWriter(int id)
		{
			return _blogDal.GetListAll(x=>x.WriterID == id);
		}

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }

		public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public void TDelete(Blog entity)
        {
            _blogDal.Delete(entity);
        }

        public Blog TGetByID(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> TGetList()
        {
            return _blogDal.GetListAll();
        }

        public void TInsert(Blog entity)
        {
            _blogDal.Insert(entity);
        }

        public void TUpdate(Blog entity)
        {
            _blogDal.Update(entity);
        }
    }
}
