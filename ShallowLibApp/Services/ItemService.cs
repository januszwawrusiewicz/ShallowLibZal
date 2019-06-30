using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AuthDatabase.Entities;

using AutoMapper;
using ShallowLibApp.Models;

namespace ShallowLibApp.Services
{
    public class ItemService : ILibService
    {
        string url = "http://localhost:58326";
        HttpClient httpClient = new HttpClient();

        private readonly IMapper _mapper;

        public ItemService(IMapper mapper)
        {
            _mapper = mapper;
        }


        //public async Task<Library[]> GetIncompleteItemsAsync(AppUser user)
        //{
        //    ShallowLibServiceHttp ServiceClient = new ShallowLibServiceHttp(url, httpClient);

        //    ICollection<LibraryRepositorys> dtoItems = await ServiceClient.GetsAllItemAsync();

        //    ICollection<Library> returnValue = _mapper.Map<ICollection<Library>>(dtoItems);

        //    return returnValue.ToArray();

        //}

        public async Task<LibraryItem[]> GetIncompleteItemsAsync(AppUser user)
        {
            ShallowLibServiceHttp ServiceClient = new ShallowLibServiceHttp(url, httpClient);

            IEnumerable<LibraryRepositorys> dtoItems = await ServiceClient.GetsAllItemAsync();

            IEnumerable<LibraryItem> returnValue = _mapper.Map<IEnumerable<LibraryItem>>(dtoItems);
            

            return returnValue.ToArray();
        }

      
        public async Task<bool> AddItemAsync( LibraryItem newItem, AppUser user)
        {
            ShallowLibServiceHttp ServiceClient = new ShallowLibServiceHttp(url, httpClient);



            //var autorid = new List<Authors>();

            //IEnumerable<LibraryRepositorys> autorid = await ServiceClient.GetsAllItemAsync();



            newItem.AutorId = 21;

            //newItem.Year = item.Year,
            //newItem.TypeofMedia = item.TypeofMedia,
            //newItem.Title = item.Title,
            //newItem.DateRent = item.DateRent,
            //newItem.Renter = item.Renter,
            //newItem.Lender = item.Lender,
            //newItem.BlobID = item.BlobID,
            //newItem.State = item.State

            await ServiceClient.AddNewItemAsync(newItem.AutorId, _mapper.Map<LibraryRepositorys>(newItem));


            return true;
        }









        //public Task<LibraryViewModel[]> GetIncompleteItemsAsync(AppUser user)
        //{
        //    throw new NotImplementedException();
        //}



        //public async Task<Guid> AddItemAsync(LibraryViewModel newItem, AppUser user)
        //{
        //    LibServiceHttpClient todoServiceClient = new LibServiceHttpClient(url, httpClient);

        //    newItem.Tytul = user.Id;


        //    Guid returnValue = await todoServiceClient.PostAsync(_mapper.Map<LibraryRepositorys>(newItem));

        //    return returnValue;
        //}

        //public async Task<LibraryViewModel[]> GetIncompleteItemsAsync(LibraryViewModel newItem, AppUser user)
        //{
        //    ShallowLibServiceHttp todoServiceClient = new ShallowLibServiceHttp(url, httpClient);

        //    ICollection<LibraryRepositorys> dtoItems = await todoServiceClient.GetAsync(newItem.Tytul);

        //    ICollection<LibraryViewModel> returnValue = _mapper.Map<ICollection<LibraryViewModel>>(dtoItems);

        //    return returnValue.ToArray();
        //}

        //public Task<LibraryViewModel[]> GetIncompleteItemsAsync(AppUser user)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Library[]> GetIncompleteItemsAsync(AppUser user)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<bool> MarkDoneAsync(LibraryViewModel item, AppUser user)
        //{
        //    LibServiceHttpClient todoServiceClient = new LibServiceHttpClient(url, httpClient);

        //    item.OwnerId = user.Id;
        //    item.IsDone = true;

        //    await todoServiceClient.PutAsync(item.Id, _mapper.Map<LibraryRepositorys>(item));
        //    return true;

        //}

    }
}