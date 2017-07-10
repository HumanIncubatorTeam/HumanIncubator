using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.Entities;
using System.Data.Entity;

namespace PhotoAlbum.Data
{
    public class UserRepository : IRepository<Users>
    {
        private UserAlbumContext db;

        public UserRepository(UserAlbumContext context)
        {
            this.db = context;
        }
        public void Create(Users user)
        {
            db.Users.Add(user);
        }

        public void Delete(Guid id)
        {
            Users user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }

        public void Edit(Users user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public Users Find(Guid id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<Users> FindAll()
        {
            return db.Users;
        }

    }
}
