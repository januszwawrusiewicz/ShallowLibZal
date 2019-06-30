using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShallowLibApp.Models
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly AppDbContext _databaseContext;

        public LibraryRepository(AppDbContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void AddMedia(Library library)
        {
            throw new NotImplementedException();
        }

        public void DeleteMedia(Library library)
        {
            throw new NotImplementedException();
        }

        public void EditMedia(Library library)
        {
            throw new NotImplementedException();
        }

        public Library PobierzmediaID(int mediaID)
        {
            return _databaseContext.Librarys.FirstOrDefault(s=>s.AutorId == mediaID);
        }

        public IEnumerable<Library> Pobierzwszystkiemedia()
        {
            return _databaseContext.Librarys;
        }
    }
}
