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

		public void TDelete(Writer entity)
		{
			throw new NotImplementedException();
		}

		public Writer TGetByID(int id)
		{
			throw new NotImplementedException();
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
			throw new NotImplementedException();
		}
	}
}
