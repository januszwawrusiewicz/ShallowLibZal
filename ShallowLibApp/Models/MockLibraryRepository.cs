using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ShallowLibApp.Models
{
    public class MockLibraryRepository : ILibraryRepository
    {
        private List<Library> libraries;

        public MockLibraryRepository()
        {
            if( libraries==null)
            {
                zaladujbiblioteke();
            }
        }

        private void zaladujbiblioteke()
        {
            libraries = new List<Library>
            {
                    new Library{AutorId=21,TypeofMedia="DVD",Title="Anioł",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/aniol-w-iext54577174.jpg",State=false},
                    new Library{AutorId=19,TypeofMedia="DVD",Title="Atomic Blonde",Year="2017",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/atomic-blonde-wydanie-ksiazkowe-w-iext51444012.jpg",State=false},
                    new Library{AutorId=6,TypeofMedia="Book",Title="Człowiek nietoperz. Harry Hole. Tom 1",Year="2017",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/czlowiek-nietoperz-harry-hole-tom-1-w-iext47427107.jpg",State=false},
                    new Library{AutorId=19,TypeofMedia="DVD",Title="Deadpool 2",Year="2018",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/deadpool-2-wydanie-ksiazkowe-komiks-w-iext53482336.jpg",State=false},
                   // new Library{AutorId=6,TypeofMedia="Book",Title="Doktor Proktor i proszek pierdzioszek",Year="2018",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/.jpg",State=false},
                    new Library{AutorId=11,TypeofMedia="CD",Title="Forever Child",Year="2016",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/forever-child-w-iext45053013.jpg",State=false},
                    new Library{AutorId=19,TypeofMedia="DVD",Title="John Wick",Year="2015",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/john-wick-wydanie-ksiazkowe-w-iext48027863.jpg",State=false},
                    new Library{AutorId=22,TypeofMedia="DVD",Title="Kapitan Marvel",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/kapitan-marvel-w-iext54591950.jpg",State=false},
                    new Library{AutorId=6,TypeofMedia="Book",Title="Karaluchy. Harry Hole. Tom 2",Year="2011",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/karaluchy-harry-hole-tom-2-w-iext37523227.jpg",State=false},
                    new Library{AutorId=2,TypeofMedia="Book",Title="Kolejne 365 dni",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/kolejne-365-dni-w-iext54486427.jpg",State=false},
                    new Library{AutorId=14,TypeofMedia="Book",Title="Królowa Mroku i Powietrza. Mroczne intrygi. Tom 3",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/krolowa-mroku-i-powietrza-mroczne-intrygi-tom-3-w-iext54678613.jpg",State=false},
                    new Library{AutorId=3,TypeofMedia="Book",Title="Leonardo da Vinci",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/leonardo-da-vinci-w-iext54537422.jpg",State=false},
                    new Library{AutorId=8,TypeofMedia="Book",Title="Listy zza grobu",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/listy-zza-grobu-w-iext54504978.jpg",State=false},
                    new Library{AutorId=12,TypeofMedia="Book",Title="Ludzie. Krótka historia o tym jak spieprzyliśmy wszystko",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/ludzie-krotka-historia-o-tym-jak-spieprzylismy-wszystko-w-iext54154305.jpg",State=false},
                   // new Library{AutorId=6,TypeofMedia="Book",Title="Macbeth",Year="2018",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/.jpg",State=false},
                    new Library{AutorId=17,TypeofMedia="CD",Title="Małomiasteczkowy",Year="2018",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/malomiasteczkowy-w-iext53346209.jpg",State=false},
                    new Library{AutorId=14,TypeofMedia="Book",Title="Miasto kości. Dary anioła. Tom 1",Year="2016",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/miasto-kosci-dary-aniola-tom-1-w-iext38649042.jpg",State=false},
                    new Library{AutorId=9,TypeofMedia="Book",Title="Mister",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/mister-w-iext54238346.jpg",State=false},
                    new Library{AutorId=10,TypeofMedia="Book",Title="Nela i kierunek Antarktyda",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/nela-i-kierunek-antarktyda-w-iext54586394.jpg",State=false},
                    new Library{AutorId=6,TypeofMedia="Book",Title="Nóż. Harry Hole. Tom 12",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/noz-harry-hole-tom-12-w-iext54543720.jpg",State=false},
                    new Library{AutorId=7,TypeofMedia="Book",Title="Obcym alfabetem. Jak ludzie Kremla i PiS zagrali podsłuchami",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/obcym-alfabetem-jak-ludzie-kremla-i-pis-zagrali-podsluchami-w-iext54699886.jpg",State=false},
                    new Library{AutorId=13,TypeofMedia="Book",Title="Odwet",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/odwet-w-iext54497341.jpg",State=false},
                   // new Library{AutorId=4,TypeofMedia="Book",Title="Pacjentka",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/pacjentka-w-iext53973814..jpg",State=false},
                    new Library{AutorId=11,TypeofMedia="CD",Title="Pink Punk",Year="2018",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/pink-punk-w-iext53346871.jpg",State=false},
                    new Library{AutorId=6,TypeofMedia="Book",Title="Policja. Harry Hole. Tom 10",Year="2013",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/policja-harry-hole-tom-10-w-iext43174058.jpg",State=false},
                  //  new Library{AutorId=6,TypeofMedia="Book",Title="Pragnienie. Harry Hole. Tom 11",Year="2017",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/.jpg",State=false},
                    new Library{AutorId=20,TypeofMedia="DVD",Title="Przykładny obywatel",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/przykladny-obywatel-wydanie-ksiazkowe-w-iext54594569.jpg",State=false},
                    new Library{AutorId=18,TypeofMedia="CD",Title="Rammstein",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/rammstein-w-iext54333688.jpg",State=false},
                    new Library{AutorId=15,TypeofMedia="CD",Title="Roksana Węgiel",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/roksana-wegiel-w-iext53994021.jpg",State=false},
                    new Library{AutorId=23,TypeofMedia="DVD",Title="Spider-Man Uniwersum",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/spider-man-uniwersum-wydanie-ksiazkowe-w-iext54506547.jpg",State=false},
                    new Library{AutorId=2,TypeofMedia="Book",Title="Ten dzień",Year="2018",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/ten-dzien-w-iext53348510.jpg",State=false},
                  //  new Library{AutorId=1,TypeofMedia="Book",Title="Test",Year="2019",DateRent=DateTime.Now,Renter="Piotr",Lender="Janusz",BlobID="/images/kolejne-365-dni-w-iext54486427.jpg.jpg",State=false},
                    new Library{AutorId=16,TypeofMedia="CD",Title="The Essential: Celine Dion",Year="2011",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/the-essential-celine-dion-w-iext36382201.jpg",State=false},
                    new Library{AutorId=11,TypeofMedia="CD",Title="Winna",Year="2004",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/winna-w-iext38085357.jpg",State=false},
                    new Library{AutorId=14,TypeofMedia="Book",Title="Władca cieni. Mroczne intrygi. Tom 2",Year="2017",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/wladca-cieni-mroczne-intrygi-tom-2-w-iext50269191.jpg",State=false},
                    new Library{AutorId=11,TypeofMedia="Book",Title="Zezia, miłość i bunt na statku",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/zezia-milosc-i-bunt-na-statku-w-iext54590737.jpg",State=false},
                    new Library{AutorId=5,TypeofMedia="Book",Title="Zranić marionetkę",Year="2019",DateRent=DateTime.Now,Renter="",Lender="",BlobID="/images/zranic-marionetke-w-iext54519453.jpg",State=false},




            };
        }

        public Library PobierzmediaID(int mediaID)
        {
            return libraries.FirstOrDefault(s => s.AutorId == mediaID);
        }

        public IEnumerable<Library> Pobierzwszystkiemedia()
        {
            return libraries;
        }

        public void AddMedia(Library library)
        {
            libraries.Add(library);
        }

        public void EditMedia(Library library)
        {
            
        }

        public void DeleteMedia(Library library)
        {
            libraries.Remove(library);
        }
    }
}
