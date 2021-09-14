using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sakuri.Models;


namespace Sakuri.Services
{
    public interface IAccountService
    {
        User User { get; }
        Task Initialize();
        Task Login(Login model);
        Task Logout();
        Task Register(AddUser model);
        Task<IList<User>> GetAllUsers();
        Task<User> GetById(string id);
        Task UpdateUser(string id, EditUser model);
        Task Delete(string id);
    }
    public class AccountService : IAccountService
    {
        public User User { get; private set; }
        private IHttpService _httpService;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private string _userKey = "user";
        
        public AccountService(IHttpService httpService, NavigationManager navigationManager, ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }
        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<User>(_userKey);
        }
        public async Task Login(Login model)
        {
            User = await _httpService.Post<User>("/users/authenticate", model);
            await _localStorageService.SetItem(_userKey, User);
        }
        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem(_userKey);
            _navigationManager.NavigateTo("account/login");
        }
        public async Task Register(AddUser model)
        {
            await _httpService.Post("/users/register", model);
        }
        public async Task<IList<User>> GetAllUsers()
        {
            return await _httpService.Get<IList<User>>("/users");
        }
        public async Task<User> GetById(string id)
        {
            return await _httpService.Get<User>($"/users/{id}");
        }
        public async Task UpdateUser(string id, EditUser model)
        {
            await _httpService.Put("/users/{id}", model);
            if(id == User.Id)
            {
                User.FirstName = model.FirstName;
                User.LastName = model.LastName;
                User.UserName = model.UserName;
                await _localStorageService.SetItem(_userKey, User);
            }
        }
        public async Task Delete(string id)
        {
            await _httpService.Delete($"/users/{id}");
            if (id == User.Id)
                await Logout();
        }
        


    }

}
