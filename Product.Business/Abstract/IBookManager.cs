using Product.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Business.Abstract
{
    public interface IBookManager
    {
        Task AddBook(Book book);
        Task UpdateBook(Book book);
        Task DeleteBook(int bookId);
        Task<Book> GetBookById(int bookId);
        Task<List<Book>> GetBookList();
        Task<List<Book>> GetBookListByCategory(int categoryId);
    }
}
