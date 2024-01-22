using BookSale.Sale.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSale.Sale.Business.Abstract
{
    public interface IBookService
    {
        Task<Book> GetBookById(int bookId);
        Task<List<Book>> GetBookList();
        Task<List<Book>> GetBookListByCategory(int categoryId);
        Task AddBook(Book book);
        Task DeleteBook(Book book);
        Task UpdateBook(Book book);
    }
}
