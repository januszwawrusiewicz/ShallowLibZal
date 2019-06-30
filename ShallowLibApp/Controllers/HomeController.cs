using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthDatabase.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShallowLibApp.Models;
using ShallowLibApp.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShallowLibApp.Controllers
{
    public class HomeController : Controller
    {
       // private readonly ILibraryRepository _libraryRepository;

        private readonly ILibService _libService;
        private readonly UserManager<AppUser> _userManager;

        public HomeController( ILibService libService, UserManager<AppUser> userManager)
        {
           // _libraryRepository = libraryRepository;
            _libService = libService;
            _userManager = userManager;

        }



        // GET: /<controller>/
        public async Task<IActionResult> Index( string searchString,string id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if( currentUser == null)
            {
                return Challenge();
            }

            IEnumerable<LibraryItem> currentTodoItems = await _libService.GetIncompleteItemsAsync(currentUser);
            

            if (!String.IsNullOrEmpty(searchString) || !String.IsNullOrEmpty(id))
            {
                currentTodoItems = currentTodoItems.Where(m => (id == null || m.TypeofMedia.Contains(id)) &&
                                                                ((searchString == null || m.Title.ToLower().Contains(searchString.ToLower())) ||
                                                                (searchString == null || m.AutorName.ToLower().Contains(searchString.ToLower()))));

               

            }

            var libraryVM = new LibraryViewModel(){Items = currentTodoItems};


            if (libraryVM == null)
            {
                libraryVM.Items.Select(m => m);
                
            }


            return View(libraryVM);
        }
        [HttpGet]
        public IActionResult CreateMedia(string returnUrl = null)
        {
            

            ViewData["ReturnUrl"] = returnUrl;
            return View();

           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMedia(LibraryItem libraryItem, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)

            {
                var currentUser = await _userManager.GetUserAsync(User);
                if (currentUser == null)
                {
                    return Challenge();
                }


                
                var Item = new LibraryItem { Year = libraryItem.Year, TypeofMedia = libraryItem.TypeofMedia, Title = libraryItem.Title, AutorId = 21, DateRent = DateTime.Now
                                           , BlobID = " ", State = false };

                await _libService.AddItemAsync( Item, currentUser);
                

               
                return RedirectToAction(nameof(Index));
            }

           

            


            return View(libraryItem);
        }




        public async Task<IActionResult> ItemByMediastring(string id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge();
            }

            IEnumerable<LibraryItem> currentTodoItems = await _libService.GetIncompleteItemsAsync(currentUser);

            var libraryVM = new LibraryViewModel()
            {
                Items = currentTodoItems.Where(m => m.Title.Contains(id) || m.AutorName.Contains(id) || id==null ).Select(m => m)

            };



            return View(libraryVM);
        }

    }
}
