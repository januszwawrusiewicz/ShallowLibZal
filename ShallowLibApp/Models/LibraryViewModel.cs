using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShallowLibApp.Models
{
    public class LibraryViewModel
    {
        //public string Tytul { get; set; }
        //public List<LibraryItem>Libraries { get; set; }

       // IEnumerable<Library> Pobierzwszystkiemedia();

         public IEnumerable<LibraryItem> Items { get; set; }
        public IEnumerable<Media> Itemsmedia { get; set; }
    }
}
