using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;


namespace WebApi.Controllers
{
    [Produces("application/json")]
//    [Route("api/Repository")]
    [Route("api/[controller]")]
    [ApiController]

    public class RepositoryController : ControllerBase
    {
        private DatabaseContext _dbContext;
      
        public RepositoryController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        //
        [HttpGet ]
        public ActionResult<IEnumerable<LibraryRepositorys>> GetsAllItem()
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IQueryable<LibraryRepositorys> ItemsLibrary = _dbContext.Librarys.Select(item => new LibraryRepositorys()
            {
                ID = item.ID,
                Year = item.Year,
                TypeofMedia = item.TypeofMedia,
                Title = item.Title,
                AutorId = item.Autor.ID,
                AutorName = item.Autor.Name,
                DateRent = item.DateRent,
                Renter = item.Renter,
                Lender = item.Lender,
                BlobID = item.BlobID,
                State = item.State
            });
            return  ItemsLibrary.ToList();
        }

        [HttpGet("{id_item}")]
        public IEnumerable<LibraryRepositorys> Gets(int id_item)
        {
            IQueryable<LibraryRepositorys> ItemsLibrary = _dbContext.Librarys.Where(s => s.ID == id_item).Select(item => new LibraryRepositorys()
            {
                ID = item.ID,
                Year = item.Year,
                TypeofMedia = item.TypeofMedia,
                Title = item.Title,
                AutorId = item.Autor.ID,
                AutorName = item.Autor.Name,
                DateRent = item.DateRent,
                Renter = item.Renter,
                Lender = item.Lender,
                BlobID = item.BlobID,
                State = item.State
            });
            return ItemsLibrary.ToList();
        }


        [HttpPost("{AutorID}")]
        public IActionResult AddNewItem(int AutorID, [FromBody] LibraryRepositorys item)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var autor_id = _dbContext.Autors.SingleOrDefault(a => a.ID == AutorID);

            if (autor_id == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Librarys.Add(new Library()
                {

                    Year = item.Year,
                    TypeofMedia = item.TypeofMedia,
                    Title = item.Title,
                    Autor = autor_id,
                    DateRent = item.DateRent,
                    Renter = item.Renter,
                    Lender = item.Lender,
                    BlobID = item.BlobID,
                    State = item.State

                });
            }
            _dbContext.SaveChanges(true);

            return StatusCode(StatusCodes.Status201Created);
                
        }


        [HttpPost]
        public IActionResult AddAutor( [FromBody] Autors item)
        {


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _dbContext.Autors.Add(new Autor()
            {
                Name=item.Name
            }) ;
          
            _dbContext.SaveChanges(true);

            return StatusCode(StatusCodes.Status201Created);

        }



        [HttpPut("{id_item}")]
        public IActionResult UpdateStatusItem(int id_item , [FromBody] LibraryRepositorys item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id_item != item.ID)
            {
                return BadRequest();
            }

            try
            {
                Database.Entities.Library dbitem = _dbContext.Librarys.SingleOrDefault(i => i.ID == id_item);

                dbitem.DateRent = item.DateRent;
                dbitem.Renter = item.Renter;
                dbitem.Lender = item.Lender;
                if (item.State== false)
                {
                    dbitem.DateRent = DateTime.Now;
                    dbitem.Renter = "";
                    dbitem.Lender = "";
                };
                dbitem.State = item.State;
                _dbContext.Librarys.Update(dbitem);
                _dbContext.SaveChanges(true);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound("No Record Found against this id ");
            }
            return Ok("Update ok");
                        
        }

        [HttpDelete("{id_item}")]
        public IActionResult DeleteItem(int id_item, [FromBody] LibraryRepositorys item)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id_item != item.ID)
            {
                return BadRequest();
            }

            try
            {
                Database.Entities.Library dbitem = _dbContext.Librarys.SingleOrDefault(i => i.ID == id_item);

                _dbContext.Librarys.Remove(dbitem);
                _dbContext.SaveChanges(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return NotFound("No Record Found against this id ");
            }
            return Ok("Delete ok");
        }
 
    }
}