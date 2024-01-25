using BookSale.MVC.Models.Dtos;

namespace BookSale.MVC.Models
{
    public class CategoryListViewModel
    {
        public List<CategoryDto> Categories {  get; set; }
        public BookCreateDto BookCreateDto { get; set; }
    }
}
