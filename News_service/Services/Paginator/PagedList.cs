using Microsoft.EntityFrameworkCore;
using News_service.Data;

namespace News_service.Services.Paginator
{
    public class PagedList
    {
        public PaginatorModel GetList( PaginatorModel paginator, int totalItems)
        {
            var totalPages = (int)Math.Ceiling((double)totalItems / paginator.PageSize);
            var pagesCountListed = paginator.PagesCountToShow / 2;
            var nextPagesEnds = paginator.CurrentPage + pagesCountListed;

            List<int> PageList = new List<int>();
            for (int i = paginator.CurrentPage - pagesCountListed; i <= totalPages; i++)
            {
                if (i > 0 && paginator.CurrentPage + pagesCountListed >= i)
                {
                    PageList.Add(i);
                }
            }
            paginator.PageList = PageList;

            return paginator;
        }
    }
}
