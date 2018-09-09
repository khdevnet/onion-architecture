using OA.Domain.Extensibility.Repositories;
using OA.Web.ViewModels.Home;
using System.Web.Mvc;

namespace OA.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAlbumRepository albumRepository;

        public HomeController(IAlbumRepository albumRepository)
        {
            this.albumRepository = albumRepository;
        }

        public ActionResult Index()
        {
            return View(new IndexViewModel { Albums = albumRepository.GetTopSelling(5) });
        }
    }
}
