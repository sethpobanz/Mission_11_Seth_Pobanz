using Microsoft.AspNetCore.Mvc;
using Mission_11.Models;
using Mission_11.Models.ViewModels;
using System.Diagnostics;

namespace Mission_11.Controllers
{
    public class HomeController : Controller
    {
        private IBookInterface _repo;

        public HomeController(IBookInterface repo)
        {
            _repo = repo;
        }

        public IActionResult Index(int pageNum)
        {
            int pageSize = 10;
            var blah = new BooksListViewModel
            {
                Books = _repo.Books
                .OrderBy(x => x.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),
                PaginationInfo = new PaginationInfo
                {
                    currentPage = pageNum,
                    itemsPerPage = 10,
                    totalItems = _repo.Books.Count()

                }
            };
        

            return View(blah);
        }

       
    }
}
