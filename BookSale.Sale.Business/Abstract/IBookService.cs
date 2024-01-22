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
        Book GetBookById(int bookId);
        List<Book> GetBookList();
        List<Book> GetBookListByCategory(int categoryId);
        void AddBook(Book book);
        void DeleteBook(Book book);
        void UpdateBook(Book book);
    }
}
