using Google.Protobuf.WellKnownTypes;
using News_service.ComboModels;
using News_service.Data;
using News_service.Interfaces;
using News_service.Models;
using News_service.Protos.News;
using News_service.Services.Paginator;
using System.Linq;

namespace News_service.Repositories
{
    public class NewsRepository : INews
    {
        private readonly ServiceDbContext dbContext;

        public NewsRepository(ServiceDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public NewsModel GetNewsById(int id)
        {
            return dbContext.News.Where(x => x.Id == id).FirstOrDefault();
        }

        public NewsPagingComboModel GetNewsList(PaginatorModel paginator)
        {
            NewsPagingComboModel newsCombo = new NewsPagingComboModel();

            var totalItems = dbContext.News.Count();       
            newsCombo.News = dbContext.News.OrderByDescending(x=>x.Id).Skip((paginator.CurrentPage - 1) * paginator.PageSize).Take(paginator.PageSize).ToList();

            PagedList pagedList = new PagedList();
            newsCombo.Paginator = pagedList.GetList(paginator, totalItems);

            return newsCombo;
        }

        public List<NewsModel> GetNewsByGameId(int id)
        {
            var d = dbContext.News.Where(x => x.GameId == id).OrderByDescending(x => x.Id).ToList();
            return d;
        }

        #region CRUD

        public NewsCreateResponse CreateNews(NewsCreateRequest request)
        {
            NewsModel newsModel = new NewsModel
            {
                Id = request.News.Id,
                Title = request.News.Title,
                Text = request.News.Text,
                ShortText = request.News.ShortText,
                Logo = request.News.Logo,
                AuthorId = request.News.AuthorId,
                //PostDate = request.News.PostDate.ToDateTime(),
                NewsType = request.News.NewsType
            };

            dbContext.News.Add(newsModel);
            dbContext.SaveChanges();

            NewsCreateResponse response = new NewsCreateResponse();
            response.News.Id = newsModel.Id;
            response.News.Title = newsModel.Title;
            response.News.Text = newsModel.Text;
            response.News.ShortText = newsModel.ShortText;
            response.News.Logo = newsModel.Logo;
            response.News.AuthorId = newsModel.AuthorId;
            response.News.PostDate = ""; //newsModel.PostDate.ToTimestamp(),
            response.News.NewsType = newsModel.NewsType;

            return response;
        }

        public NewsUpdateResponse UpdateNews(NewsUpdateRequest request)
        {
            NewsModel newsModel = new NewsModel
            {
                Id = request.News.Id,
                Title = request.News.Title,
                Text = request.News.Text,
                ShortText = request.News.ShortText,
                Logo = request.News.Logo,
                AuthorId = request.News.AuthorId,
                //PostDate = request.News.PostDate,
                NewsType = request.News.NewsType
            };

            dbContext.News.Add(newsModel);
            dbContext.SaveChanges();

            NewsUpdateResponse response = new NewsUpdateResponse();
            response.News.Id = newsModel.Id;
            response.News.Title = newsModel.Title;
            response.News.Text = newsModel.Text;
            response.News.ShortText = newsModel.ShortText;
            response.News.Logo = newsModel.Logo;
            response.News.AuthorId = newsModel.AuthorId;
            //response.News.PostDate = newsModel.PostDate.ToTimestamp();
            response.News.NewsType = newsModel.NewsType;

            return response;
        }

        #endregion
    }
}
