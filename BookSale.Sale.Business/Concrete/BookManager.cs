using BookSale.Sale.Business.Abstract;
using BookSale.Sale.DataAccess.Abstract.Dals;
using BookSale.Sale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Business.Concrete
{
    public class BookManager : IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public Book GetBookById(int bookId)
        {
            return _bookDal.Get(b => b.Id == bookId);
        }

        public List<Book> GetBookList()
        {
            return _bookDal.GetList().ToList();
        }
        public List<Book> GetBookListByCategory(int categoryId)
        {
            return new List<Book>(_bookDal.GetList(b => b.Category_Id == categoryId).ToList());
        }
        
        public void Add(Book book)
        {
            throw new NotImplementedException();
        }

        public void Delete(Book book)
        {
            throw new NotImplementedException();
        }

        public void Update(Book book)
        {
            throw new NotImplementedException();
        }


    }
}
