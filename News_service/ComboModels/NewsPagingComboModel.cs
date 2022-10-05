using News_service.Models;
using News_service.Services.Paginator;

namespace News_service.ComboModels
{
    public class NewsPagingComboModel
    {
        public List<NewsModel> News { get; set; }
        public PaginatorModel Paginator { get; set; }
    }
}
