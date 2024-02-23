using Product.Business.Abstract;
using Product.DataAccess.Abstract;
using Product.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Business.Concrete
{
    public class BookManager : IBookManager
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
