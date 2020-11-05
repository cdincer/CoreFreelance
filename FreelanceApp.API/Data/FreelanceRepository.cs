using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreelanceApp.API.Helpers;
using FreelanceApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FreelanceApp.API.Data
{
    public class FreelanceRepository : IFreelancerRepository
    {

        private readonly DataContext _context;

        public FreelanceRepository(DataContext context)
        {
            this._context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Photo> GetMainPhotoUser(int userId)
        {
            return await _context.Photos.Where(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsMain);
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
            return photo;
        }

        public async Task<User> GetUser(int id)
        {
        var user = await  _context.Users.Include(p => p.Photos).
        FirstOrDefaultAsync(u => u.Id == id);

        return user;
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users =  _context.Users.Include(p => p.Photos).OrderByDescending(u => u.LastActive).AsQueryable();

            users = users.Where(u => u.Id != userParams.UserId);

         //TODO:Add a experience filter   users = users.Where( u => u.Experience )

         if(userParams.minExperience > 0 || userParams.maxExperience < 99)
         {
                var minExp = userParams.minExperience;
                var maxExp = userParams.maxExperience;

                    users = users.Where(u => u.Experience >= minExp && u.Experience <= maxExp);
         }

            if(!string.IsNullOrEmpty(userParams.OrderBy))
            {
                switch(userParams.OrderBy)
                {
                    case "created":
                        users = users.OrderByDescending(u =>u.Created);
                        break;
                        default:
                        users = users.OrderByDescending(u => u.LastActive);
                        break;
                }
            }


            return await PagedList<User>.CreateAsync(users, userParams.PageNumber,userParams.PageSize);
        }

        public async Task<bool> SaveAll()
        {
           return await _context.SaveChangesAsync() > 0;
        }
    }
}