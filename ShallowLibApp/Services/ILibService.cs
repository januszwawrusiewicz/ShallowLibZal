using AuthDatabase.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShallowLibApp.Models;

namespace ShallowLibApp.Services
{
    public interface ILibService
    {
        Task<LibraryItem[]> GetIncompleteItemsAsync(AppUser user);

         Task<bool> AddItemAsync(LibraryItem newItem, AppUser user);


    }
}
