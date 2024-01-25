using BookSale.Sale.Business.Abstract;
using BookSale.Sale.DataAccess.Abstract.Dals;
using BookSale.Sale.DataAccess.Concrete.EntityFramework.Dals;
using BookSale.Sale.Entities.Concrete;
using BookSale.Sale.Entities.Concrete.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public async Task AddBook(Book book)
        {
            await _bookDal.Add(book);
        }
        public async Task UpdateBook(Book book)
        {
            await _bookDal.Update(book);
        }
        public async Task DeleteBook(int bookId)
        {
            await _bookDal.Delete(b => b.Id == bookId);
        }
        public async Task<Book> GetBookById(int bookId)
        {
            return await _bookDal.Get(b => b.Id == bookId);
        }
        public async Task<List<Book>> GetBookListByCategory(int categoryId)
        {
            return await _bookDal.GetList(b => b.Category_Id == categoryId);
        }
        public async Task<List<Book>> GetBookList()
        {
            return await _bookDal.GetList();
        }


    }
}
