using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheWaterProject.Models;
using TheWaterProject.Models.ViewModels;

namespace TheWaterProject.Controllers
{
    public class HomeController : Controller
    {
        private IWaterRepository _repo;

        public HomeController(IWaterRepository temp)
        {
            _repo = temp;
        }
        public IActionResult Index(int pageNum)
        {
            int pageSize = 2;

            //returning one variable to the view
            var blah = new ProjectListViewModel
            {
                //projects object query
                Projects = _repo.Projects
                .OrderBy(x => x.ProjectName)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),


                //Making a pagination object
                PaginationInfo = new PaginationInfo
                {
                    CurrentPage = pageNum,
                    ItemPerPage = pageSize,
                    TotalItems = _repo.Projects.Count()
                }
            };

            return View(blah);
        }


    }
}
