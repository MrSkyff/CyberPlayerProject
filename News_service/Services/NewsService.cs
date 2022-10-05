using Grpc.Core;
using News_service.Interfaces;
using News_service.Protos.News;
using News_service.Services.Paginator;
using System.Linq;

namespace News_service.Services
{
    public class NewsService : News.NewsBase
    {
        private readonly INews newsRepository;
        private Mapper.Mapper mapper;

        public NewsService(INews newsRepository, Mapper.Mapper mapper)
        {
            this.newsRepository = newsRepository;
            this.mapper = mapper;
        }

        public override Task<NewsListResponse> GetNewsList(NewsListRequest request, ServerCallContext context)
        {
            PaginatorModel paginatorModel = new PaginatorModel();
            paginatorModel.CurrentPage = request.PagedNews.CurrentPage;
            paginatorModel.PageSize = request.PagedNews.PageSize;
            paginatorModel.PagesCountToShow = request.PagedNews.PagesCountToShow;

            var model = newsRepository.GetNewsList(paginatorModel);

            PaginatorNewsProto paginatorNewsProto = new PaginatorNewsProto();
            paginatorNewsProto.CurrentPage = model.Paginator.CurrentPage;
            paginatorNewsProto.PagesCountToShow = model.Paginator.PagesCountToShow;
            paginatorNewsProto.PageSize = model.Paginator.PageSize;
            paginatorNewsProto.PageList.Add(model.Paginator.PageList);

            List<NewsSimpleProto> newsProto = new List<NewsSimpleProto>();
            newsProto = mapper.MapToProto(newsProto, model.News);

            NewsListResponse response = new NewsListResponse();
            response.NewsList.AddRange(newsProto);
            response.PagedNews = paginatorNewsProto;

            return Task.FromResult(response);
        }

        public override Task<NewsByIdResponse> GetNewsById(NewsByIdRequest request, ServerCallContext context)
        {
            var model = newsRepository.GetNewsById(request.Id);

            NewsByIdResponse response = new NewsByIdResponse();
            response.News = mapper.MapToProto(new NewsProto(), model);

            return Task.FromResult(response);
        }

        public override Task<NewsCreateResponse> CreateNews(NewsCreateRequest request, ServerCallContext context)
        {
            return Task.FromResult(new NewsCreateResponse());
        }

        public override Task<NewsUpdateResponse> UpdateNews(NewsUpdateRequest request, ServerCallContext context)
        {
            return Task.FromResult(new NewsUpdateResponse());
        }

        public override Task<NewsListByGameResponse> GetNewsByGame(NewsListByGameRequest request, ServerCallContext context)
        {
            NewsListByGameResponse newsListByGameResponse = new NewsListByGameResponse();
            newsListByGameResponse.NewsList.Add(mapper.MapToProto(new List<NewsSimpleProto>(), newsRepository.GetNewsByGameId(request.Id)));
            return Task.FromResult(newsListByGameResponse);
        }

    }
}
