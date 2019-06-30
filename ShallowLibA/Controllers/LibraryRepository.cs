using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Microsoft.AspNetCore.Mvc;
using ShallowLibAPI.Models;
using Database;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShallowLibAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryRepository : ControllerBase
    {
        DatabaseContext _dbContext;

        public LibraryRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/values/5
        [HttpGet("{Id}")]
        public ActionResult<IEnumerable<LibraryRepositorys>> Get(int Id)
        {
            IQueryable<LibraryRepositorys> ItemsLibrary = _dbContext.Librarys.Where(item => item.ID == Id ).Include("Autor").Select(item => new LibraryRepositorys()
            {
                ID = item.ID,
                Year = item.Year,
                TypeofMedia=item.TypeofMedia,
                Title = item.Title,
                AutorId=item.Autor.ID,
                DateRent=item.DateRent,
                Renter=item.Renter,
                Lender=item.Lender,
                BlobID=item.BlobID,
                State=item.State
             });

           return ItemsLibrary.ToList();
        }

        // POST: api/LibrariesControllerItem
        [HttpPost]
        public async Task<ActionResult<Library>> PostLibrary(Library library)
        {
            _dbContext.Librarys.Add(library);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("GetLibrary", new { id = library.ID }, library);
        }


        // POST api/values
        //[HttpPost]
        //public ActionResult<Library> Post([FromBody] LibraryRepositorys value)
        //{
        //   int id = ;
        //    _dbContext.Librarys.Add(new Database.Entities.Library()
        //    {
        //       // ID = id,
        //        Year = value.Year,
        //        TypeofMedia = value.TypeofMedia,
        //        Title = value.Title,
        //        //Autor = value.AutorId,
        //        DateRent = value.DateRent,
        //        Renter = value.Renter,
        //        Lender = value.Lender,
        //        BlobID = value.BlobID,
        //        State = value.State
        //    });

        //    _dbContext.SaveChanges();

        //    return id;
        //}

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromQuery]int id, [FromBody] LibraryRepositorys value)
        {
            Database.Entities.Library dbItem = _dbContext.Librarys.SingleOrDefault(item => item.ID == id);
            dbItem.Renter = value.Renter;
            _dbContext.SaveChanges();
        }


    }
}
