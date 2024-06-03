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
	public class WriterManager : IWriterService
	{
		IWriterDal _writerDal;

		public WriterManager(IWriterDal writerDal)
		{
			_writerDal = writerDal;
		}

        public List<Writer> GetWriterByID(int id)
        {
            return _writerDal.GetListAll(x=>x.WriterID==id);
        }

        public void TDelete(Writer entity)
		{
			throw new NotImplementedException();
		}

		public Writer TGetByID(int id)
		{
			return _writerDal.GetById(id);
		}

		public List<Writer> TGetList()
		{
			throw new NotImplementedException();
		}

		public void TInsert(Writer entity)
		{
			_writerDal.Insert(entity);
		}

		public void TUpdate(Writer entity)
		{
			_writerDal.Update(entity);
		}
	}
}
