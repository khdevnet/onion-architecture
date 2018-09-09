using OA.Domain.Entities;
using OA.Domain.Extensibility.Repositories;
using System.Linq;
using System.Web.Mvc;

namespace OA.Web.Controllers
{
    public class StoreController : Controller
    {
        private readonly ICrudRepository<Genre, int> genresRepository;
        private readonly IAlbumRepository albumRepository;

        public StoreController(ICrudRepository<Genre, int> genresRepository, IAlbumRepository albumRepository)
        {
            this.genresRepository = genresRepository;
            this.albumRepository = albumRepository;
        }

        //
        // GET: /Store/

        public ActionResult Index()
        {
            return View(genresRepository.Get());
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            Genre genreModel = genresRepository.Get("Albums")
                .Single(g => g.Name == genre);

            return View(genreModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            Album album = albumRepository.GetById(id);

            return View(album);
        }


        //GET: /Store/GenreMenu

        [ChildActionOnly]
        public ActionResult GenreMenu()
        {

            return PartialView(genresRepository.Get());
        }

    }
}
