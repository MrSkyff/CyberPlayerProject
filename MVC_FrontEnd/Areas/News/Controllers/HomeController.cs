using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace MVC_FrontEnd.Areas.News.Controllers
{
    [Area("News")]
    public class HomeController : Controller
    {
        private readonly IConfiguration config; //config.GetSection("ServiceRouting").GetSection("NewsService").Value

        public HomeController(IConfiguration config)
        {
            this.config = config;
        }
    }
}
