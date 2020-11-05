using System.Collections.Generic;
using System.Threading.Tasks;
using FreelanceApp.API.Helpers;
using FreelanceApp.API.Models;

namespace FreelanceApp.API.Data
{
    public interface IFreelancerRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<PagedList<User>> GetUsers(UserParams userParams);

         Task<User> GetUser(int id);
         Task<Photo> GetPhoto(int id);

         Task<Photo> GetMainPhotoUser(int userId);
    }
}