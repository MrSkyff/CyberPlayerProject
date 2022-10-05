using News_service.ComboModels;
using News_service.Models;
using News_service.Protos.News;
using News_service.Services.Paginator;

namespace News_service.Interfaces
{
    public interface INews
    {
        NewsPagingComboModel GetNewsList(PaginatorModel paginator);
        NewsModel GetNewsById(int id);
        List<NewsModel> GetNewsByGameId(int id);

        NewsCreateResponse CreateNews(NewsCreateRequest request);
        NewsUpdateResponse UpdateNews(NewsUpdateRequest request);
        
    }
}
